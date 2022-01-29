using assessment.contact.db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.business.Abstract
{
  interface IIletisimBilgiTipiService
  {
    Task Add(IletisimBilgiTipi model);
    Task Delete(int Id);
    Task<List<IletisimBilgiTipi>> GetAll();
  }
}
