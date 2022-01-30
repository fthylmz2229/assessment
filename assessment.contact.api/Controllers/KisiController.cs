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
    /// Rehberde kişi oluşturma
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
    /// Rehberde kişi kaldırma
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
    /// Rehberdeki kişilerin listelenmesi
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

    /// <summary>
    /// Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ActionName("get")]
    public async Task<IActionResult> Get([FromBody] GetKisiCommandRequest request)
    {
      GetKisiCommandResponse response = await _mediator.Send(request);

      return Ok(response);
    }
  }
}
