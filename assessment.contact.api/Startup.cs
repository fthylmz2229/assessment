using assessment.contact.business.Abstract;
using assessment.contact.business.Concrete;
using assessment.contact.db;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace assessment.contact.api
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

      services.AddTransient<IKisiService, KisiService>();
      services.AddTransient<IKisiIletisimBilgiService, KisiIletisimBilgiService>();

      services.AddSingleton<CancellationTokenSource>();

      services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
      services.AddControllers();

      services.AddDbContext<ContactDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ContactDbConnection"),
        b => b.MigrationsAssembly("assessment.contact.db")));

      services.AddHttpContextAccessor();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "assessment.contact.api", Version = "v1" });
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
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "assessment.contact.api v1"));
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
