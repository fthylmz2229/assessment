using assessment.contact.db.Entities;
using Microsoft.EntityFrameworkCore;

namespace assessment.contact.db
{
  public class ContactDBContext : DbContext
  {
    public ContactDBContext(DbContextOptions<ContactDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Kisi> Kisi { get; set; }
    public virtual DbSet<KisiIletisimBilgi> KisiIletisimBilgi { get; set; }
    public virtual DbSet<IletisimBilgiTipi> IletisimBilgiTipi { get; set; }
  }
}
