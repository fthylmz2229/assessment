using assessment.contact.api.CQRS.Query.Kisi.Response;
using MediatR;
using System.Collections.Generic;

namespace assessment.contact.api.CQRS.Query.Kisi.Request
{
  public class GetAllKisiQueryRequest : IRequest<List<GetAllKisiQueryResponse>>
  {
  }
}
