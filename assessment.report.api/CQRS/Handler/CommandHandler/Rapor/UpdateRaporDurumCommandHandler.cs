using assessment.report.api.CQRS.Command.Rapor.Request;
using assessment.report.api.CQRS.Command.Rapor.Response;
using assessment.report.business.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.report.api.CQRS.Handler.CommandHandler.Rapor
{
  public class UpdateRaporDurumCommandHandler : IRequestHandler<UpdateRaporDurumCommandRequest, UpdateRaporDurumCommandResponse>
  {
    IRaporService _raporService;
    public UpdateRaporDurumCommandHandler(IRaporService raporService)
    {
      _raporService = raporService;
    }

    public async Task<UpdateRaporDurumCommandResponse> Handle(UpdateRaporDurumCommandRequest request, CancellationToken cancellationToken)
    {
      var result = await _raporService.UpdateRaporDurum(request.Id, request.RaporDurumId, request.DosyaYolu);
      if (result)
        return await Task.FromResult(new UpdateRaporDurumCommandResponse() { Success = true, Message = "Rapor durum güncelleme başarılı." });
      else
        return await Task.FromResult(new UpdateRaporDurumCommandResponse() { Success = false, Message = "Rapor durum güncelleme başarısız." });
    }
  }
}
