using assessment.contact.api.CQRS.Command.Rapor.Request;
using assessment.contact.api.CQRS.Command.Rapor.Response;
using assessment.report.api.CQRS.Command.Rapor.Request;
using assessment.report.api.CQRS.Command.Rapor.Response;
using assessment.report.api.CQRS.Query.Rapor.Request;
using assessment.report.api.CQRS.Query.Rapor.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    /// Yeni rapor isteği oluştur.
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ActionName("create")]
    public async Task<IActionResult> Create()
    {
      CreateRaporCommandResponse response = await _mediator.Send(new CreateRaporCommandRequest());
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

    /// <summary>
    /// Sistemin oluşturduğu raporların listelenmesi
    /// </summary>
    /// <returns></returns>
    [HttpGet("[action]")]
    [ActionName("get_all")]
    public async Task<IActionResult> GetAll()
    {
      List<GetAllRaporQueryResponse> response = await _mediator.Send(new GetAllRaporQueryRequest());

      return Ok(response);
    }

    /// <summary>
    /// Sistemin oluşturduğu bir raporun detay bilgilerinin getirilmesi
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    [ActionName("get")]
    public async Task<IActionResult> Get([FromBody] GetRaporCommandRequest request)
    {
      GetRaporCommandResponse response = await _mediator.Send(request);

      return Ok(response);
    }
  }
}
