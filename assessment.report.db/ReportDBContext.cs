using Microsoft.EntityFrameworkCore;

namespace assessment.report.db
{
  public class ReportDBContext : DbContext
  {
    public ReportDBContext(DbContextOptions<ReportDBContext> options) : base(options)
    {

    }


  }
}
