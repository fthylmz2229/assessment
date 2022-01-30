using assessment.report.api.CQRS.Command.Rapor.Response;
using MediatR;
using System;

namespace assessment.report.api.CQRS.Command.Rapor.Request
{
  public class CreateRaporCommandRequest : IRequest<CreateRaporCommandResponse>
  {
    public DateTime TalepTarihi { get; set; }
    public int RaporDurumId { get; set; }
  }
}
