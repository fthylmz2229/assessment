using assessment.contact.business.Abstract;
using assessment.contact.db;
using assessment.contact.db.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.contact.business.Concrete
{
  public class KisiService : IKisiService
  {
    private readonly ContactDBContext _context;
    public KisiService(ContactDBContext context)
    {
      _context = context;
    }
    public async Task<Kisi> Add(Kisi model)
    {
      _context.Kisi.Add(model);
      await _context.SaveChangesAsync();
      return model;
    }
    public async Task<bool> Delete(int Id)
    {
      var temp = _context.Kisi.FirstOrDefault(x => x.Id == Id);
      if (temp == null)
        return await Task.Run(() => false);
      _context.Kisi.Update(new Kisi() { Id = Id, SilindiMi = true });
      return await Task.Run(() => (_context.SaveChanges() > 0 ? true : false));
    }
    public async Task<List<Kisi>> GetAll()
    {
      return await Task.Run(() => _context.Kisi.Where(x => x.SilindiMi == false).ToList());
    }

    public async Task<Kisi> Get(int Id)
    {
      return await Task.Run(() => _context.Kisi.FirstOrDefault(x => x.Id == Id));
    }
  }
}
