using assessment.report.api.CQRS.Command.Rapor.Request;
using assessment.report.api.CQRS.Command.Rapor.Response;
using assessment.report.business.Abstract;
using MediatR;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api.CQRS.Handler.CommandHandler.Rapor
{
  public class CreateRaporCommandHandler : IRequestHandler<CreateRaporCommandRequest, CreateRaporCommandResponse>
  {
    IRaporService _raporService;

    private readonly ConnectionFactory _factory;
    private readonly IConnection _connection;

    public CreateRaporCommandHandler(IRaporService raporService)
    {
      _raporService = raporService;

      _factory = new ConnectionFactory()
      {
        HostName = "localhost",
        UserName = "guest",
        Password = "guest"
      };
      _connection = _factory.CreateConnection();
    }

    public async Task<CreateRaporCommandResponse> Handle(CreateRaporCommandRequest request, CancellationToken cancellationToken)
    {
      var model = new report.db.Entities.Rapor { RaporDurumId = 1, TalepTarihi = DateTime.Now };
      model = await _raporService.Add(model);
      if (model.Id > 0)
      {
        //Başarılı ise RabbitMQ ya rapor oluşturma isteğini iletelim.
        //Bu kısmı bir sınıf haline getirip kullanabilirdim. Hayat kısa vakit tükeniyor :)
        using (var channel = _connection.CreateModel())
        {
          //Durable -> queue'nun omru
          //Exclusive  -> kuyruk farkli connectionlar ile kullanilabilir mi 
          //AutoDelete -> kuyrukta yer alan veri consumer'a ulastiginda silinmesi
          var result = channel.QueueDeclare(queue: "rapor", durable: true, exclusive: false, autoDelete: false, arguments: null);
          var raporPayload = JsonSerializer.Serialize(model);
          var body = Encoding.UTF8.GetBytes(raporPayload);
          channel.BasicPublish(exchange: "", routingKey: "rapor", basicProperties: null, body: body);
        }

        return await Task.FromResult(new CreateRaporCommandResponse() { Success = true, Message = "Rapor ekleme başarılı." });
      }
      else
        return await Task.FromResult(new CreateRaporCommandResponse() { Success = false, Message = "Rapor ekleme başarısız." });
    }
  }
}
