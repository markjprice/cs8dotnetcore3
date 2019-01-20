using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;

namespace NorthwindCms
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(config =>
      {
        config.ModelBinderProviders.Insert(0, new Piranha.Manager.Binders.AbstractModelBinderProvider());
      });
      services.AddPiranhaApplication();
      services.AddPiranhaFileStorage();
      services.AddPiranhaImageSharp();
      services.AddPiranhaEF(options =>
          options.UseSqlite("Filename=./piranha.blog.db"));
      services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options =>
          options.UseSqlite("Filename=./piranha.blog.db"));
      services.AddPiranhaManager();
      services.AddPiranhaMemCache();

      services.AddDbContext<Packt.Shared.Northwind>(options =>
        options.UseSqlite("Data Source=../NorthwindWeb/Northwind.db"));

      return services.BuildServiceProvider();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services, IApi api)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // Initialize Piranha
      App.Init();

      // Configure cache level
      App.CacheLevel = Piranha.Cache.CacheLevel.Basic;

      // Build content types
      var pageTypeBuilder = new Piranha.AttributeBuilder.PageTypeBuilder(api)
          .AddType(typeof(Models.BlogArchive))
          .AddType(typeof(Models.StandardPage))
          .AddType(typeof(Models.CatalogPage))
          .AddType(typeof(Models.CategoryPage));
      pageTypeBuilder.Build()
          .DeleteOrphans();
      var postTypeBuilder = new Piranha.AttributeBuilder.PostTypeBuilder(api)
          .AddType(typeof(Models.BlogPost));
      postTypeBuilder.Build()
          .DeleteOrphans();
      var siteTypeBuilder = new Piranha.AttributeBuilder.SiteTypeBuilder(api)
          .AddType(typeof(Models.BlogSite));
      siteTypeBuilder.Build()
          .DeleteOrphans();

      // Register middleware
      app.UseStaticFiles();
      app.UseAuthentication();
      app.UsePiranha();
      app.UsePiranhaManager();
      app.UseHttpsRedirection();
      app.UseMvc(routes =>
      {
        routes.MapRoute(name: "areaRoute",
                  template: "{area:exists}/{controller}/{action}/{id?}",
                  defaults: new { controller = "Home", action = "Index" });

        routes.MapRoute(
                  name: "default",
                  template: "{controller=home}/{action=index}/{id?}");
      });
    }
  }
}