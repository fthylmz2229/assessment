using assessment.report.business.Abstract;
using assessment.report.db;
using assessment.report.db.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.report.business.Concrete
{
  public class RaporDurumService : IRaporDurumService
  {
    private readonly ReportDBContext _context;
    public RaporDurumService(ReportDBContext context)
    {
      _context = context;
    }
    public async Task<RaporDurum> Add(RaporDurum model)
    {
      _context.RaporDurum.Add(model);
      await _context.SaveChangesAsync();
      return model;
    }

    public async Task<List<RaporDurum>> GetAll()
    {
      return await Task.Run(() => _context.RaporDurum.ToList());
    }
  }
}
