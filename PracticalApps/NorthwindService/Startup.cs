using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using NorthwindService.Repositories;

using Packt.Shared;

using Swashbuckle.AspNetCore.Swagger;

namespace NorthwindService
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
      services.AddCors();

      services.AddDbContext<Northwind>(options =>
        options.UseSqlite("Data Source=../NorthwindWeb/Northwind.db"));

      // .NET Core 3.0 Preview 2 seems to remove JSON formatters
      // so they have to be manually added back
      services.AddMvcCore().AddJsonFormatters();

      services.AddMvc()
        .AddXmlSerializerFormatters()
        .SetCompatibilityVersion(CompatibilityVersion.Latest);

      services.AddScoped<ICustomerRepository, CustomerRepository>();

      // Register the Swagger generator and define a Swagger document
      // for Northwind service 
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc(name: "v1", info: new OpenApiInfo
          { Title = "Northwind Service API", Version = "v1" });
      });

      services.AddHealthChecks()
        .AddDbContextCheck<Northwind>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseCors(configurePolicy: options => 
        {
          options.WithMethods("GET", "POST", "PUT", "DELETE");
          options.WithOrigins(
            "https://localhost:5001", // for MVC client
            "https://localhost:5002" // for Swagger
          );
        });

      app.UseHttpsRedirection();
      app.UseMvc();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
          "Northwind Service API Version 1.0");
      });

      app.UseHealthChecks(path: "/howdoyoufeel");
    }
  }
}
