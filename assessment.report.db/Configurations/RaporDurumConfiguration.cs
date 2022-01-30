using assessment.report.db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assessment.report.db.Configurations
{
  public class RaporDurumConfiguration : IEntityTypeConfiguration<RaporDurum>
  {
    public void Configure(EntityTypeBuilder<RaporDurum> builder)
    {
      builder.ToTable("tbl_rapor_durum");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true).HasColumnName("id");
      builder.Property(x => x.Durum).IsRequired(true).HasMaxLength(50).HasColumnName("durum");
    }
  }
}