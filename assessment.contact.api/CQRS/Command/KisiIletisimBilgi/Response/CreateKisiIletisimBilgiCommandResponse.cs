using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Command.KisiIletisimBilgi.Response
{
  public class CreateKisiIletisimBilgiCommandResponse
  {
    public bool Success { get; set; } = false;
    public string Message { get; set; }
  }
}
