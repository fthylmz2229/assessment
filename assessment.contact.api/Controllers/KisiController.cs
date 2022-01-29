using assessment.contact.api.CQRS.Command.Kisi.Request;
using assessment.contact.api.CQRS.Command.Kisi.Response;
using assessment.contact.api.CQRS.Query.Kisi.Request;
using assessment.contact.api.CQRS.Query.Kisi.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.api.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class KisiController : ControllerBase
  {
    IMediator _mediator;

    public KisiController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Yeni Kişi oluşturur.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] CreateKisiCommandRequest request)
    {
      CreateKisiCommandResponse response = await _mediator.Send(request);
      return Ok(response);
    }

    /// <summary>
    /// Mevcut kişiyi siler.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    [ActionName("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteKisiCommandRequest request)
    {
      DeleteKisiCommandResponse response = await _mediator.Send(request);
      return Ok(response);
    }

    /// <summary>
    /// Tüm Kişileri getirir.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ActionName("get_all")]
    public async Task<IActionResult> GetAll()
    {
      List<GetAllKisiQueryResponse> response = await _mediator.Send(new GetAllKisiQueryRequest());

      return Ok(response);
    }
  }
}
