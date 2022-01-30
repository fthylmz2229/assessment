using assessment.contact.business.Concrete;
using assessment.contact.db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.business.Abstract
{
  public interface IKisiIletisimBilgiService
  {
    Task<KisiIletisimBilgi> Add(KisiIletisimBilgi model);
    Task<bool> Delete(int Id);
    Task<List<KisiIletisimBilgi>> GetAll();
    Task<List<KisiIletisimBilgi>> GetAll(int kisiId);
    Task<List<RaporModel>> Rapor();
  }
}
