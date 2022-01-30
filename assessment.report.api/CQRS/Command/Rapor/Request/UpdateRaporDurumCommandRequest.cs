using assessment.report.api.CQRS.Command.Rapor.Response;
using MediatR;

namespace assessment.report.api.CQRS.Command.Rapor.Request
{
  public class UpdateRaporDurumCommandRequest : IRequest<UpdateRaporDurumCommandResponse>
  {
    public int Id { get; set; }
    public int RaporDurumId { get; set; }
    public string DosyaYolu { get; set; }
  }
}