using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using Packt.Shared;

namespace NorthwindWeb
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddDbContext<Northwind>(options => 
        options.UseSqlite("Data Source=Northwind.db"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      // app.Run(async (context) =>
      // {
      //   await context.Response.WriteAsync("Hello World!");
      // });

      app.UseDefaultFiles(); // index.html, default.html, and so on
      app.UseStaticFiles();
      app.UseMvc(); // includes the Razor Pages feature
    }
  }
}
