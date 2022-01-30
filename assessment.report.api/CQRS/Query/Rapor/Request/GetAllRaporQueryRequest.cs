using assessment.report.api.CQRS.Query.Rapor.Response;
using MediatR;
using System.Collections.Generic;

namespace assessment.report.api.CQRS.Query.Rapor.Request
{
  public class GetAllRaporQueryRequest : IRequest<List<GetAllRaporQueryResponse>>
  {
  }
}
