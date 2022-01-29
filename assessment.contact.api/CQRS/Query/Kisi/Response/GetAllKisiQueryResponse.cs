using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Query.Kisi.Response
{
  public class GetAllKisiQueryResponse
  {
    public long Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Firma { get; set; }
  }
}
