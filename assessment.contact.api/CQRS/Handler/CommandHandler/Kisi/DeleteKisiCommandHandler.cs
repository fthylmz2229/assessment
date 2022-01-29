using assessment.contact.api.CQRS.Command.Kisi.Request;
using assessment.contact.api.CQRS.Command.Kisi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.Kisi
{
  public class DeleteKisiCommandHandler : IRequestHandler<DeleteKisiCommandRequest, DeleteKisiCommandResponse>
  {
    IKisiService _kisiService;
    public DeleteKisiCommandHandler(IKisiService kisiService)
    {
      _kisiService = kisiService;
    }

    public async Task<DeleteKisiCommandResponse> Handle(DeleteKisiCommandRequest request, CancellationToken cancellationToken)
    {
      var result = await _kisiService.Delete(request.Id);
      if (result)
        return await Task.FromResult(new DeleteKisiCommandResponse() { Success = true, Message = "Kişi silme başarılı." });
      else
        return await Task.FromResult(new DeleteKisiCommandResponse() { Success = false, Message = "Kişi silme başarısız." });
    }
  }
}
