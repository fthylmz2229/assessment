using assessment.report.db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.report.business.Abstract
{
  public interface IRaporService
  {
    Task<Rapor> Add(Rapor model);
    Task<bool> UpdateRaporDurum(int Id, int RaporDurumId, string DosyaYolu);
    Task<List<Rapor>> GetAll();
    Task<Rapor> Get(int Id);
  }
}
