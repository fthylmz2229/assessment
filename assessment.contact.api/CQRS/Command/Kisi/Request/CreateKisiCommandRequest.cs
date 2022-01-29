using assessment.contact.api.CQRS.Command.Kisi.Response;
using MediatR;

namespace assessment.contact.api.CQRS.Command.Kisi.Request
{
  public class CreateKisiCommandRequest : IRequest<CreateKisiCommandResponse>
  {
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Firma { get; set; }
  }
}
