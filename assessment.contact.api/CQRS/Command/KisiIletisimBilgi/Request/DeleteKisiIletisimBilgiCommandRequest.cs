using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Response;
using MediatR;

namespace assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Request
{
  public class DeleteKisiIletisimBilgiCommandRequest : IRequest<DeleteKisiIletisimBilgiCommandResponse>
  {
    public int Id { get; set; }
  }
}
