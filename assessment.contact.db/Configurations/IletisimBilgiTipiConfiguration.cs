using assessment.contact.db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assessment.contact.db.Configurations
{
  public class IletisimBilgiTipiConfiguration : IEntityTypeConfiguration<IletisimBilgiTipi>
  {
    public void Configure(EntityTypeBuilder<IletisimBilgiTipi> builder)
    {
      builder.ToTable("tbl_iletisim_bilgi_tipi");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true).HasColumnName("id");
      builder.Property(x => x.Ad).IsRequired(true).HasMaxLength(100).HasColumnName("ad");
    }
  }
}