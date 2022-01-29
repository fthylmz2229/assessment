using assessment.contact.api.CQRS.Command.Kisi.Response;
using MediatR;

namespace assessment.contact.api.CQRS.Command.Kisi.Request
{
  public class DeleteKisiCommandRequest : IRequest<DeleteKisiCommandResponse>
  {
    public int Id { get; set; }
  }
}
