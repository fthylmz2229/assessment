using assessment.contact.api.CQRS.Command.Rapor.Response;
using MediatR;

namespace assessment.contact.api.CQRS.Command.Rapor.Request
{
  public class GetRaporCommandRequest : IRequest<GetRaporCommandResponse>
  {
    public int Id { get; set; }
  }
}
