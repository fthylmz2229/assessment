using assessment.contact.db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.business.Abstract
{
  public interface IKisiIletisimBilgiService
  {
    Task Add(KisiIletisimBilgi model);
    Task Delete(int Id);
    Task<List<KisiIletisimBilgi>> GetAll();
  }
}
