using assessment.contact.db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.business.Abstract
{
  public interface IKisiService
  {
    Task<Kisi> Add(Kisi model);
    Task<bool> Delete(int Id);
    Task<List<Kisi>> GetAll();
  }
}
