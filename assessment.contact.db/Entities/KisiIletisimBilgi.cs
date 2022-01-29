namespace assessment.contact.db.Entities
{
  public class KisiIletisimBilgi
  {
    public int Id { get; set; }
    public int IletisimBilgiTipiId { get; set; }
    public virtual IletisimBilgiTipi IletisimBilgiTipi { get; set; }
    public string BilgiIcerigi { get; set; }
  }
}
