using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessment.report.api.CQRS.Query.RaporDurum.Response
{
  public class GetAllRaporDurumQueryResponse
  {
    public int Id { get; set; }
    public string Durum { get; set; }
  }
}
