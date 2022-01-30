using assessment.report.db.Entities;
using System;

namespace assessment.contact.api.CQRS.Command.Rapor.Response
{
  public class GetRaporCommandResponse
  {
    public int Id { get; set; }
    public DateTime TalepTarihi { get; set; }
    public int RaporDurumId { get; set; }
    public virtual RaporDurum RaporDurum { get; set; }
    public string DosyaYolu { get; set; }
  }
}
