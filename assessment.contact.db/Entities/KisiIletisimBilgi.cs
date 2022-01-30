namespace assessment.contact.db.Entities
{
  public class KisiIletisimBilgi
  {
    public int Id { get; set; }
    public int IletisimBilgiTipiId { get; set; }
    public virtual IletisimBilgiTipi IletisimBilgiTipi { get; set; }
    public string BilgiIcerigi { get; set; }
    public int KisiId { get; set; }
    public virtual Kisi Kisi { get; set; }
    public bool SilindiMi { get; set; } = false;
  }
}
