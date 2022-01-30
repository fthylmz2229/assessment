using assessment.report.api.CQRS.Command.Rapor.Request;
using assessment.report.api.CQRS.Command.Rapor.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace assessment.contact.api.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class RaporController : ControllerBase
  {
    IMediator _mediator;

    public RaporController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Yeni rapor oluştur.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ActionName("create")]
    public async Task<IActionResult> Create([FromBody] CreateRaporCommandRequest request)
    {
      CreateRaporCommandResponse response = await _mediator.Send(request);
      return Ok(response);
    }

    /// <summary>
    /// Raporun durumunu güncellemek için kullanılır.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    [ActionName("update_rapor_durum")]
    public async Task<IActionResult> UpdateRaporDurum([FromBody] UpdateRaporDurumCommandRequest request)
    {
      UpdateRaporDurumCommandResponse response = await _mediator.Send(request);

      return Ok(response);
    }
  }
}
