using assessment.report.db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assessment.report.db.Configurations
{
  class RaporConfiguration : IEntityTypeConfiguration<Rapor>
  {
    public void Configure(EntityTypeBuilder<Rapor> builder)
    {
      builder.ToTable("tbl_rapor_durum");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true).HasColumnName("id");
      builder.Property(x => x.TalepTarihi).IsRequired(true).HasColumnName("talep_tarihi");
      builder.Property(x => x.RaporDurumId).IsRequired(true).HasColumnName("talep_durum_id");
      builder.Property(x => x.DosyaYolu).IsRequired(false).HasMaxLength(250).HasColumnName("dosya_yolu");
    }
  }
}