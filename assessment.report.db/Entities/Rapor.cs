using System;

namespace assessment.report.db.Entities
{
  public class Rapor
  {
    public int Id { get; set; }
    public DateTime TalepTarihi { get; set; }
    public int RaporDurumId { get; set; }
    public virtual RaporDurum RaporDurum { get; set; }
    public string DosyaYolu { get; set; }
  }
}
