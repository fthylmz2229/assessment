
using assessment.contact.api.CQRS.Command.Rapor.Request;
using assessment.contact.api.CQRS.Command.Rapor.Response;
using assessment.report.business.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.Rapor
{
  public class GetRaporCommandHandler : IRequestHandler<GetRaporCommandRequest, GetRaporCommandResponse>
  {
    IRaporService _raporService;
    public GetRaporCommandHandler(IRaporService raporService)
    {
      _raporService = raporService;
    }

    public async Task<GetRaporCommandResponse> Handle(GetRaporCommandRequest request, CancellationToken cancellationToken)
    {
      GetRaporCommandResponse result = new GetRaporCommandResponse();
      var rapor = await _raporService.Get(request.Id);
      return await Task.FromResult(new GetRaporCommandResponse() { DosyaYolu = rapor.DosyaYolu, Id = rapor.Id, RaporDurumId = rapor.RaporDurumId, RaporDurum = rapor.RaporDurum, TalepTarihi = rapor.TalepTarihi });
    }
  }
}
