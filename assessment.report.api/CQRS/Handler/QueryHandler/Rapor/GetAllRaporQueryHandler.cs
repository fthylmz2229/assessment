using assessment.report.api.CQRS.Query.Rapor.Request;
using assessment.report.api.CQRS.Query.Rapor.Response;
using assessment.report.business.Abstract;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.report.api.CQRS.Handler.QueryHandler.Rapor
{
  public class GetAllRaporQueryHandler : IRequestHandler<GetAllRaporQueryRequest, List<GetAllRaporQueryResponse>>
  {
    IRaporService _raporService;
    CancellationTokenSource _tokenSource;
    public GetAllRaporQueryHandler(IRaporService raporService, CancellationTokenSource tokenSource)
    {
      _raporService = raporService;
      _tokenSource = tokenSource;
    }

    public async Task<List<GetAllRaporQueryResponse>> Handle(GetAllRaporQueryRequest request, CancellationToken cancellationToken)
    {
      cancellationToken = _tokenSource.Token;

      if (cancellationToken.IsCancellationRequested)
      {
        return await Task.FromCanceled<List<GetAllRaporQueryResponse>>(cancellationToken);
      }

      var response = await _raporService.GetAll();

      return response.Select(rapor => new GetAllRaporQueryResponse()
      {
        Id = rapor.Id,
        DosyaYolu = rapor.DosyaYolu,
        RaporDurum = rapor.RaporDurum,
        RaporDurumId = rapor.RaporDurumId,
        TalepTarihi = rapor.TalepTarihi
      }).ToList();
    }
  }
}
