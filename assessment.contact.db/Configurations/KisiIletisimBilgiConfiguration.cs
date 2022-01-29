using assessment.contact.db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assessment.contact.db.Configurations
{
  public class KisiIletisimBilgiConfiguration : IEntityTypeConfiguration<KisiIletisimBilgi>
  {
    public void Configure(EntityTypeBuilder<KisiIletisimBilgi> builder)
    {
      builder.ToTable("tbl_kisi_iletisim_bilgi");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true).HasColumnName("id");
      builder.Property(x => x.IletisimBilgiTipiId).IsRequired(true).HasColumnName("iletisim_bilgi_tipi_id");
      builder.Property(x => x.BilgiIcerigi).IsRequired(true).HasMaxLength(250).HasColumnName("bilgi_icerigi");
      
    }
  }
}