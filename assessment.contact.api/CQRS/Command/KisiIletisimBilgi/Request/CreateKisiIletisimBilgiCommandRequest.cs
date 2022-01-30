using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Response;
using MediatR;

namespace assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Request
{
  public class CreateKisiIletisimBilgiCommandRequest : IRequest<CreateKisiIletisimBilgiCommandResponse>
  {
    public int IletisimBilgiTipiId { get; set; }
    public string BilgiIcerigi { get; set; }
    public int KisiId { get; set; }
  }
}

