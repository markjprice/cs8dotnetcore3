using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.Models;
using Piranha.Extend.Blocks;
using System;
using System.Linq;
using Packt.Shared;
using NorthwindCms.Models;
using NorthwindCms.Models.Regions;
using Microsoft.EntityFrameworkCore; // Include extension method

namespace NorthwindCms.Controllers
{
  public class ImportController : Controller
  {
    private readonly IApi api;

    private readonly Northwind db;

    public ImportController(IApi api, Northwind injectedContext)
    {
      this.api = api;
      db = injectedContext;
    }

    [Route("/import")]
    public IActionResult Import()
    {
      var site = api.Sites.GetDefault();
      var catalog = api.Pages.GetBySlug<CatalogPage>("catalog");

      foreach (var category in db.Categories.Include(c => c.Products))
      {
        // if the category page already exists,
        // then skip to the next iteration of the loop
        CategoryPage categoryPage = api.Pages.GetBySlug<CategoryPage>(
          $"catalog/{category.CategoryName.ToLower()}");
        
        if (categoryPage == null)
        {
          categoryPage = CategoryPage.Create(api);
          categoryPage.Id = Guid.NewGuid();
          categoryPage.SiteId = site.Id;
          categoryPage.ParentId = catalog.Id;
        
          categoryPage.CategoryDetail.CategoryID = category.CategoryID;
          categoryPage.CategoryDetail.CategoryName = category.CategoryName;
          categoryPage.CategoryDetail.Description = category.Description;

          // find image with correct filename for category id
          var image = api.Media.GetAll().First(media => 
            media.Type == MediaType.Image &&
            media.Filename == $"category{category.CategoryID}.jpeg");

          categoryPage.CategoryDetail.CategoryImage = image;
        }

        if (categoryPage.Products.Count == 0)
        {
          // convert the products for this category into
          // a list of instances of ProductRegion
          categoryPage.Products = category.Products
            .Select(p => new ProductRegion
            {
              ProductID = p.ProductID,
              ProductName = p.ProductName,
              UnitPrice = p.UnitPrice.HasValue ? p.UnitPrice.Value.ToString("c") : "n/a",
              UnitsInStock = p.UnitsInStock ?? 0
            }).ToList();
        }

        categoryPage.Title = category.CategoryName;
        categoryPage.MetaDescription = category.Description;
        categoryPage.NavigationTitle = category.CategoryName;
        categoryPage.Published = DateTime.Now;

        api.Pages.Save(categoryPage);
      }

      return Redirect("~/");
    }
  }
}