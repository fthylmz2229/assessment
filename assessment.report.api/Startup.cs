using assessment.report.business.Abstract;
using assessment.report.business.Concrete;
using assessment.report.db;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace assessment.report.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(
          name: "AllowOrigin",
          builder =>
          {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
          });
      });

      services.AddTransient<IRaporService, RaporService>();
      services.AddTransient<IRaporDurumService, RaporDurumService>();

      services.AddSingleton<CancellationTokenSource>();

      services.AddHostedService<ConsumeRabbitMQHostedService>();

      services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

      services.AddControllers();

      services.AddDbContext<ReportDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ReportDbConnection"),
       b => b.MigrationsAssembly("assessment.report.db")));

      services.AddHttpContextAccessor();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "assessment.report.api", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "assessment.report.api v1"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
