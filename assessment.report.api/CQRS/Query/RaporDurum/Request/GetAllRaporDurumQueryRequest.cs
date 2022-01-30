using assessment.report.api.CQRS.Query.RaporDurum.Response;
using MediatR;
using System.Collections.Generic;

namespace assessment.report.api.CQRS.Query.RaporDurum.Request
{
  public class GetAllRaporDurumQueryRequest : IRequest<List<GetAllRaporDurumQueryResponse>>
  {
  }
}
