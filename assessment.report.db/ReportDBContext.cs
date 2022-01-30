using assessment.report.db.Entities;
using Microsoft.EntityFrameworkCore;

namespace assessment.report.db
{
  public class ReportDBContext : DbContext
  {
    public ReportDBContext(DbContextOptions<ReportDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Rapor> Rapor { get; set; }
    public virtual DbSet<RaporDurum> RaporDurum { get; set; }
  }
}
