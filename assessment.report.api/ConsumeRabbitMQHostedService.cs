using assessment.report.api.Helpers;
using assessment.report.business.Abstract;
using assessment.report.db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.report.api
{
  public class ConsumeRabbitMQHostedService : BackgroundService
  {
    private IConnection _connection;
    private IModel _channel;
    private IServiceScopeFactory _serviceScopeFactory;
    public ConsumeRabbitMQHostedService(IServiceScopeFactory serviceScopeFactory)
    {
      InitRabbitMQ();
      _serviceScopeFactory = serviceScopeFactory;
    }

    private void InitRabbitMQ()
    {
      var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };

      // create connection  
      _connection = factory.CreateConnection();

      // create channel  
      _channel = _connection.CreateModel();

      _channel.ExchangeDeclare("rapor.exchange", ExchangeType.Topic);
      //_channel.QueueDeclare("rapor", false, false, false, null);
      _channel.QueueBind("rapor", "rapor.exchange", "rapor.*", null);
      _channel.BasicQos(0, 1, false);

      _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
      stoppingToken.ThrowIfCancellationRequested();

      var consumer = new EventingBasicConsumer(_channel);
      consumer.Received += (ch, ea) =>
      {
        var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
        //Burada kuyruktaki modeli alıyoruz.
        var model = JsonSerializer.Deserialize<db.Entities.Rapor>(content);
        //Modeli aldıktan sonra contact.api ye istek atıp bilgileri alıyoruz.
        List<RaporModel> data = ContactApiOperations.GetRapor();
        //Gelen bilgilerle raporu oluşturuyoruz.
        string dosyaYolu = ExcelOperations.WriteFile(data);
        //sonrasında rapor un durumunu ve dosya yolunu report.db ye yazıyoruz.
        using (var scope = _serviceScopeFactory.CreateScope())
        {
          var context = scope.ServiceProvider.GetRequiredService<ReportDBContext>();
          var rapor = context.Rapor.FirstOrDefault(x => x.Id == model.Id);
          if (rapor != null)
          {
            rapor.RaporDurumId = 2;
            rapor.DosyaYolu = dosyaYolu;
            context.SaveChanges();
          }
        }
        _channel.BasicAck(ea.DeliveryTag, false);
      };

      consumer.Shutdown += OnConsumerShutdown;
      consumer.Registered += OnConsumerRegistered;
      consumer.Unregistered += OnConsumerUnregistered;
      consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

      _channel.BasicConsume("rapor", false, consumer);
      return Task.CompletedTask;
    }

    private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
    private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
    private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
    private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

    public override void Dispose()
    {
      _channel.Close();
      _connection.Close();
      base.Dispose();
    }
  }
}
