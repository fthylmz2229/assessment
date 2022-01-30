using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Response
{
  public class GetRaporQueryResponse
  {
    public string KonumBilgisi { get; set; }
    public int KisiSayisi { get; set; }
    public int TelefonNumarasiSayisi { get; set; }
  }
}
