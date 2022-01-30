using assessment.report.api.CQRS.Query.RaporDurum.Request;
using assessment.report.api.CQRS.Query.RaporDurum.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.api.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class RaporDurumController : ControllerBase
  {
    IMediator _mediator;

    public RaporDurumController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Rapor durumu belirlemek için kullanılacak olan sabitleri getirir.
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ActionName("get_all")]
    public async Task<IActionResult> GetAll()
    {
      List<GetAllRaporDurumQueryResponse> response = await _mediator.Send(new GetAllRaporDurumQueryRequest());

      return Ok(response);
    }
  }
}
