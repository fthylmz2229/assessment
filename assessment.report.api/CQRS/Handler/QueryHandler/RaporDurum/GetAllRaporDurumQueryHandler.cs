using assessment.report.api.CQRS.Query.RaporDurum.Request;
using assessment.report.api.CQRS.Query.RaporDurum.Response;
using assessment.report.business.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.report.api.CQRS.Handler.QueryHandler.RaporDurum
{
  public class GetAllRaporDurumQueryHandler : IRequestHandler<GetAllRaporDurumQueryRequest, List<GetAllRaporDurumQueryResponse>>
  {
    IRaporDurumService _raporDurumService;
    CancellationTokenSource _tokenSource;
    public GetAllRaporDurumQueryHandler(IRaporDurumService raporDurumService, CancellationTokenSource tokenSource)
    {
      _raporDurumService = raporDurumService;
      _tokenSource = tokenSource;
    }

    public async Task<List<GetAllRaporDurumQueryResponse>> Handle(GetAllRaporDurumQueryRequest request, CancellationToken cancellationToken)
    {
      cancellationToken = _tokenSource.Token;

      if (cancellationToken.IsCancellationRequested)
      {
        return await Task.FromCanceled<List<GetAllRaporDurumQueryResponse>>(cancellationToken);
      }

      var response = await _raporDurumService.GetAll();

      return response.Select(raporDurum => new GetAllRaporDurumQueryResponse()
      {
        Id = raporDurum.Id,
        Durum = raporDurum.Durum

      }).ToList();
    }
  }
}
