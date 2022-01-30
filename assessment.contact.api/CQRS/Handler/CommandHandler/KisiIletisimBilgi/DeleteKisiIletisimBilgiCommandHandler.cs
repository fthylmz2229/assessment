using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Request;
using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.KisiIletisimBilgi
{
  public class DeleteKisiIletisimBilgiCommandHandler : IRequestHandler<DeleteKisiIletisimBilgiCommandRequest, DeleteKisiIletisimBilgiCommandResponse>
  {
    IKisiIletisimBilgiService _kisiIletisimBilgiService;
    public DeleteKisiIletisimBilgiCommandHandler(IKisiIletisimBilgiService kisiIletisimBilgiService)
    {
      _kisiIletisimBilgiService = kisiIletisimBilgiService;
    }

    public async Task<DeleteKisiIletisimBilgiCommandResponse> Handle(DeleteKisiIletisimBilgiCommandRequest request, CancellationToken cancellationToken)
    {
      var result = await _kisiIletisimBilgiService.Delete(request.Id);
      if (result)
        return await Task.FromResult(new DeleteKisiIletisimBilgiCommandResponse() { Success = true, Message = "Kişi iletişim bilgisi silme başarılı." });
      else
        return await Task.FromResult(new DeleteKisiIletisimBilgiCommandResponse() { Success = false, Message = "Kişi iletişim bilgisi başarısız." });
    }
  }
}
