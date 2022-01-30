using System.Collections.Generic;

namespace assessment.contact.api.CQRS.Command.Kisi.Response
{
  public class GetKisiCommandResponse
  {
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Firma { get; set; }
    public List<KisiIletisimBilgi> KisiIletisimBilgi { get; set; }
  }

  public class KisiIletisimBilgi
  {
    public int Id { get; set; }
    public int IletisimBilgiTipiId { get; set; }
    public string BilgiIcerigi { get; set; }
  }
}
