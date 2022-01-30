using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Request;
using assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Response;
using assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Request;
using assessment.contact.api.CQRS.Query.KisiIletisimBilgi.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assessment.contact.api.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class KisiIletisimBilgiController : ControllerBase
  {
    IMediator _mediator;

    public KisiIletisimBilgiController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Rehberdeki kişiye iletişim bilgisi ekleme
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] CreateKisiIletisimBilgiCommandRequest request)
    {
      CreateKisiIletisimBilgiCommandResponse response = await _mediator.Send(request);
      return Ok(response);
    }

    /// <summary>
    /// Rehberdeki kişiden iletişim bilgisi kaldırma
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    [ActionName("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteKisiIletisimBilgiCommandRequest request)
    {
      DeleteKisiIletisimBilgiCommandResponse response = await _mediator.Send(request);
      return Ok(response);
    }

    /// <summary>
    /// Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor talebi
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ActionName("rapor")]
    public async Task<IActionResult> Rapor()
    {
      List<GetRaporQueryResponse> response = await _mediator.Send(new GetRaporQueryRequest());

      return Ok(response);
    }
  }
}
