using assessment.report.api.CQRS.Command.Rapor.Request;
using assessment.report.api.CQRS.Command.Rapor.Response;
using assessment.report.business.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.Rapor
{
  public class CreateRaporCommandHandler : IRequestHandler<CreateRaporCommandRequest, CreateRaporCommandResponse>
  {
    IRaporService _raporService;
    public CreateRaporCommandHandler(IRaporService raporService)
    {
      _raporService = raporService;
    }

    public async Task<CreateRaporCommandResponse> Handle(CreateRaporCommandRequest request, CancellationToken cancellationToken)
    {
      var model = new report.db.Entities.Rapor { RaporDurumId = request.RaporDurumId, TalepTarihi = request.TalepTarihi };
      model = await _raporService.Add(model);
      if (model.Id > 0)
        return await Task.FromResult(new CreateRaporCommandResponse() { Success = true, Message = "Rapor ekleme başarılı." });
      else
        return await Task.FromResult(new CreateRaporCommandResponse() { Success = false, Message = "Rapor ekleme başarısız." });
    }
  }
}
