using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Request;
using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Response;
using assessment.contact.business.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.KisiIletisimBilgi
{
  public class CreateKisiIletisimBilgiCommandHandler : IRequestHandler<CreateKisiIletisimBilgiCommandRequest, CreateKisiIletisimBilgiCommandResponse>
  {
    IKisiIletisimBilgiService _kisiIletisimBilgiService;
    public CreateKisiIletisimBilgiCommandHandler(IKisiIletisimBilgiService kisiIletisimBilgiService)
    {
      _kisiIletisimBilgiService = kisiIletisimBilgiService;
    }

    public async Task<CreateKisiIletisimBilgiCommandResponse> Handle(CreateKisiIletisimBilgiCommandRequest request, CancellationToken cancellationToken)
    {
      var model = new db.Entities.KisiIletisimBilgi { IletisimBilgiTipiId = request.IletisimBilgiTipiId, BilgiIcerigi = request.BilgiIcerigi, KisiId = request.KisiId };
      model = await _kisiIletisimBilgiService.Add(model);
      if (model.Id > 0)
        return await Task.FromResult(new CreateKisiIletisimBilgiCommandResponse() { Success = true, Message = "Kişi iletişim bilgi ekleme başarılı." });
      else
        return await Task.FromResult(new CreateKisiIletisimBilgiCommandResponse() { Success = false, Message = "Kişi iletişim bilgi ekleme başarısız." });
    }
  }
}
