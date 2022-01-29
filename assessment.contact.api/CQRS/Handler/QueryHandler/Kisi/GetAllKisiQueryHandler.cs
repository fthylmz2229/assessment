using assessment.contact.api.CQRS.Query.Kisi.Request;
using assessment.contact.api.CQRS.Query.Kisi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.QueryHandler.Kisi
{
  public class GetAllKisiQueryHandler : IRequestHandler<GetAllKisiQueryRequest, List<GetAllKisiQueryResponse>>
  {
    IKisiService _kisiService;
    CancellationTokenSource _tokenSource;
    public GetAllKisiQueryHandler(IKisiService kisiService, CancellationTokenSource tokenSource)
    {
      _kisiService = kisiService;
      _tokenSource = tokenSource;
    }

    public async Task<List<GetAllKisiQueryResponse>> Handle(GetAllKisiQueryRequest request, CancellationToken cancellationToken)
    {
      cancellationToken = _tokenSource.Token;

      if (cancellationToken.IsCancellationRequested)
      {
        return await Task.FromCanceled<List<GetAllKisiQueryResponse>>(cancellationToken);
      }

      var response = await _kisiService.GetAll();

      return response.Select(kisi => new GetAllKisiQueryResponse()
      {
        Id = kisi.Id,
        Ad = kisi.Ad,
        Soyad = kisi.Soyad,
        Firma = kisi.Firma

      }).ToList();
    }
  }
}
