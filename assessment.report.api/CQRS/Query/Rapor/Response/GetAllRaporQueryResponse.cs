using System;

namespace assessment.report.api.CQRS.Query.Rapor.Response
{
  public class GetAllRaporQueryResponse
  {
    public int Id { get; set; }
    public DateTime TalepTarihi { get; set; }
    public int RaporDurumId { get; set; }
    public db.Entities.RaporDurum RaporDurum { get; set; }
    public string DosyaYolu { get; set; }
  }
}
