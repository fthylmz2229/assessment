using assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Response;
using MediatR;
using System.Collections.Generic;

namespace assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Request
{
  public class GetRaporQueryRequest : IRequest<List<GetRaporQueryResponse>>
  {
  }
}
