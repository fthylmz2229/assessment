using assessment.contact.api.CQRS.Command.Kisi.Request;
using assessment.contact.api.CQRS.Command.Kisi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.Kisi
{
  public class GetKisiCommandHandler : IRequestHandler<GetKisiCommandRequest, GetKisiCommandResponse>
  {
    IKisiService _kisiService;
    IKisiIletisimBilgiService _kisiIletisimBilgiService;
    public GetKisiCommandHandler(IKisiService kisiService, IKisiIletisimBilgiService kisiIletisimBilgiService)
    {
      _kisiService = kisiService;
      _kisiIletisimBilgiService = kisiIletisimBilgiService;
    }

    public async Task<GetKisiCommandResponse> Handle(GetKisiCommandRequest request, CancellationToken cancellationToken)
    {
      GetKisiCommandResponse result = new GetKisiCommandResponse();
      var kisi = await _kisiService.Get(request.Id);
      if (kisi != null && kisi.Id > 0)
      {
        var kisiIletisimBilgi = await _kisiIletisimBilgiService.GetAll(kisi.Id);
        result.Ad = kisi.Ad;
        result.Firma = kisi.Firma;
        result.Id = kisi.Id;
        result.Soyad = kisi.Soyad;
        if (kisiIletisimBilgi.Any())
          result.KisiIletisimBilgi = kisiIletisimBilgi.Select(a => new assessment.contact.api.CQRS.Command.Kisi.Response.KisiIletisimBilgi() { BilgiIcerigi = a.BilgiIcerigi, Id = a.Id, IletisimBilgiTipiId = a.IletisimBilgiTipiId }).ToList();
        
      }
      return await Task.FromResult(result);
    }
  }
}
