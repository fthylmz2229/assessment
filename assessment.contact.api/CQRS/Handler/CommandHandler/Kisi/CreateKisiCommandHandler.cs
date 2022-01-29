using assessment.contact.api.CQRS.Command.Kisi.Request;
using assessment.contact.api.CQRS.Command.Kisi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.Kisi
{
  public class CreateKisiCommandHandler : IRequestHandler<CreateKisiCommandRequest, CreateKisiCommandResponse>
  {
    IKisiService _kisiService;
    public CreateKisiCommandHandler(IKisiService kisiService)
    {
      _kisiService = kisiService;
    }

    public async Task<CreateKisiCommandResponse> Handle(CreateKisiCommandRequest request, CancellationToken cancellationToken)
    {
      var model = new db.Entities.Kisi { Ad = request.Ad, Soyad = request.Soyad, Firma = request.Firma };
      model = await _kisiService.Add(model);
      if (model.Id > 0)
        return await Task.FromResult(new CreateKisiCommandResponse() { Success = true, Message = "Kişi ekleme başarılı." });
      else
        return await Task.FromResult(new CreateKisiCommandResponse() { Success = false, Message = "Kişi ekleme başarısız." });
    }
  }
}
