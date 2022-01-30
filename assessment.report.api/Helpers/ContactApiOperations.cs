using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace assessment.report.api.Helpers
{
  public static class ContactApiOperations
  {
    private static string BASE_URL = "http://localhost:2412/api/";

    public static List<RaporModel> GetRapor()
    {
      var client = new RestClient(BASE_URL + "KisiIletisimBilgi/Rapor");
      client.Timeout = -1;
      var request = new RestRequest(Method.GET);
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
      IRestResponse response = client.Execute(request);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        return JsonSerializer.Deserialize<List<RaporModel>>(response.Content);
      }
      else
      {
        return null;
      }
    }
  }

  public class RaporModel
  {
    [JsonPropertyName("konumBilgisi")]
    public string KonumBilgisi { get; set; }

    [JsonPropertyName("kisiSayisi")]
    public int KisiSayisi { get; set; }

    [JsonPropertyName("telefonNumarasiSayisi")]
    public int TelefonNumarasiSayisi { get; set; }
  }
}
