using assessment.contact.business.Abstract;
using assessment.contact.db;
using assessment.contact.db.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.contact.business.Concrete
{
  public class KisiIletisimBilgiService : IKisiIletisimBilgiService
  {
    private readonly ContactDBContext _context;
    public KisiIletisimBilgiService(ContactDBContext context)
    {
      _context = context;
    }
    public async Task<KisiIletisimBilgi> Add(KisiIletisimBilgi model)
    {
      _context.KisiIletisimBilgi.Add(model);
      await _context.SaveChangesAsync();
      return model;
    }

    public async Task<bool> Delete(int Id)
    {
      var temp = _context.KisiIletisimBilgi.FirstOrDefault(x => x.Id == Id);
      if (temp == null)
        return await Task.Run(() => false);
      _context.KisiIletisimBilgi.Update(new KisiIletisimBilgi() { Id = Id, SilindiMi = true });
      return await Task.Run(() => (_context.SaveChanges() > 0 ? true : false));
    }

    public async Task<List<KisiIletisimBilgi>> GetAll()
    {
      return await Task.Run(() => _context.KisiIletisimBilgi.Where(x=>x.SilindiMi == false).ToList());
    }

    public async Task<List<KisiIletisimBilgi>> GetAll(int kisiId)
    {
      return await Task.Run(() => _context.KisiIletisimBilgi.Where(x=>x.KisiId == kisiId && x.SilindiMi == false).ToList());
    }

    public async Task<List<RaporModel>> Rapor()
    {
      List<RaporModel> result = new List<RaporModel>();

      var konumlar = _context.KisiIletisimBilgi.Where(x => x.IletisimBilgiTipiId == 3 && x.SilindiMi == false).GroupBy(x => x.BilgiIcerigi).Select(x => x.Key).ToList();

      if (konumlar.Any())
      {
        foreach (var konum in konumlar)
        {
          var kisilerIds = _context.KisiIletisimBilgi.Where(x => x.BilgiIcerigi == konum).GroupBy(x => x.KisiId).Select(x => x.Key).ToList();
          var KisiSayisi = kisilerIds.Count;
          var TelefonNumarasiSayisi = _context.KisiIletisimBilgi.Where(x => x.IletisimBilgiTipiId == 1 && kisilerIds.Contains(x.KisiId) && x.SilindiMi == false).Count();

          result.Add(new RaporModel() { KisiSayisi = KisiSayisi, KonumBilgisi = konum, TelefonNumarasiSayisi = TelefonNumarasiSayisi });
        }
      }

      return await Task.Run(() => result);
    }
  }

  public class RaporModel
  {
    public string KonumBilgisi { get; set; }
    public int KisiSayisi { get; set; }
    public int TelefonNumarasiSayisi { get; set; }
  }
}
