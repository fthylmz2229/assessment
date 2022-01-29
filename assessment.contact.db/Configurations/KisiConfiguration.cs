using assessment.contact.db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assessment.contact.db.Configurations
{
  public class KisiConfiguration : IEntityTypeConfiguration<Kisi>
  {
    public void Configure(EntityTypeBuilder<Kisi> builder)
    {
      builder.ToTable("tbl_kisi");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true).HasColumnName("id");
      builder.Property(x => x.Ad).IsRequired(true).HasMaxLength(100).HasColumnName("ad");
      builder.Property(x => x.Soyad).IsRequired(true).HasMaxLength(100).HasColumnName("soyad");
      builder.Property(x => x.Firma).IsRequired(true).HasMaxLength(250).HasColumnName("firma");
    }
  }
}
