using assessment.report.db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.report.business.Abstract
{
  public interface IRaporDurumService
  {
    Task<RaporDurum> Add(RaporDurum model);
    Task<List<RaporDurum>> GetAll();
  }
}
