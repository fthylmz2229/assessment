using assessment.contact.api.CQRS.Command.Kisi.Response;
using MediatR;

namespace assessment.contact.api.CQRS.Command.Kisi.Request
{
  public class GetKisiCommandRequest : IRequest<GetKisiCommandResponse>
  {
    public int Id { get; set; }
  }
}
