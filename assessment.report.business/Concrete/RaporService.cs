using assessment.report.business.Abstract;
using assessment.report.db;
using assessment.report.db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.report.business.Concrete
{
  public class RaporService : IRaporService
  {
    private readonly ReportDBContext _context;
    public RaporService(ReportDBContext context)
    {
      _context = context;
    }
    public async Task<Rapor> Add(Rapor model)
    {
      _context.Rapor.Add(model);
      await _context.SaveChangesAsync();
      return model;
    }

    public async Task<bool> UpdateRaporDurum(int Id, int RaporDurumId, string DosyaYolu)
    {
      var temp = _context.Rapor.FirstOrDefault(x => x.Id == Id);
      if (temp == null)
        return await Task.Run(() => false);

       temp.RaporDurumId = RaporDurumId;
      temp.DosyaYolu = DosyaYolu;
      _context.Rapor.Update(temp);
      return await Task.Run(() => (_context.SaveChanges() > 0 ? true : false));
    }

    public async Task<List<Rapor>> GetAll()
    {
      return await Task.Run(() => _context.Rapor.Include(x=>x.RaporDurum).ToList());
    }

    public async Task<Rapor> Get(int Id)
    {
      return await Task.Run(() => _context.Rapor.Include(x=>x.RaporDurum).FirstOrDefaultAsync(x=>x.Id == Id));
    }
  }
}

