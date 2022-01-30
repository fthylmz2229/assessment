using assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Request;
using assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.QueryHandler.Kisi
{
  public class GetRaporQueryHandler : IRequestHandler<GetRaporQueryRequest, List<GetRaporQueryResponse>>
  {
    IKisiIletisimBilgiService _kisiIletisimBilgiService;
    CancellationTokenSource _tokenSource;
    public GetRaporQueryHandler(IKisiIletisimBilgiService kisiIletisimBilgiService, CancellationTokenSource tokenSource)
    {
      _kisiIletisimBilgiService = kisiIletisimBilgiService;
      _tokenSource = tokenSource;
    }

    public async Task<List<GetRaporQueryResponse>> Handle(GetRaporQueryRequest request, CancellationToken cancellationToken)
    {
      cancellationToken = _tokenSource.Token;

      if (cancellationToken.IsCancellationRequested)
      {
        return await Task.FromCanceled<List<GetRaporQueryResponse>>(cancellationToken);
      }

      var response = await _kisiIletisimBilgiService.Rapor();

      return response.Select(a => new GetRaporQueryResponse() { KisiSayisi = a.KisiSayisi, KonumBilgisi = a.KonumBilgisi, TelefonNumarasiSayisi = a.TelefonNumarasiSayisi }).ToList(); ;
    }
  }
}
