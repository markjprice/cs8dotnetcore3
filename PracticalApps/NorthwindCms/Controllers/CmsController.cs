using Microsoft.AspNetCore.Mvc;
using Piranha;
using System;
using System.Linq;
using NorthwindCms.Models;

namespace NorthwindCms.Controllers
{
  public class CmsController : Controller
  {
    private readonly IApi _api;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="api">The current api</param>
    public CmsController(IApi api)
    {
      _api = api;
    }

    /// <summary>
    /// Gets the blog archive with the given id.
    /// </summary>
    /// <param name="id">The unique page id</param>
    /// <param name="year">The optional year</param>
    /// <param name="month">The optional month</param>
    /// <param name="page">The optional page</param>
    /// <param name="category">The optional category</param>
    /// <param name="tag">The optional tag</param>
    [Route("archive")]
    public IActionResult Archive(Guid id, int? year = null, int? month = null, int? page = null,
        Guid? category = null, Guid? tag = null)
    {
      Models.BlogArchive model;

      if (category.HasValue)
        model = _api.Archives.GetByCategoryId<Models.BlogArchive>(id, category.Value, page, year, month);
      else if (tag.HasValue)
        model = _api.Archives.GetByTagId<Models.BlogArchive>(id, tag.Value, page, year, month);
      else model = _api.Archives.GetById<Models.BlogArchive>(id, page, year, month);

      return View(model);
    }

    /// <summary>
    /// Gets the page with the given id.
    /// </summary>
    /// <param name="id">The unique page id</param>
    [Route("page")]
    public IActionResult Page(Guid id)
    {
      var model = _api.Pages.GetById<Models.StandardPage>(id);

      return View(model);
    }

    /// <summary>
    /// Gets the post with the given id.
    /// </summary>
    /// <param name="id">The unique post id</param>
    [Route("post")]
    public IActionResult Post(Guid id)
    {
      var model = _api.Posts.GetById<Models.BlogPost>(id);

      return View(model);
    }

    /// <summary>
    /// Gets the catalog page with the given id.
    /// </summary>
    /// <param name="id">The unique catalog page id</param>
    [Route("catalog")]
    public IActionResult Catalog(Guid id)
    {
      var catalog = _api.Pages.GetById<CatalogPage>(id);

      var model = new CatalogViewModel
      {
        CatalogPage = catalog,
        Categories = _api.Sites.GetSitemap()
            .Where(item => item.Id == catalog.Id)
            .SelectMany(item => item.Items)
            .Select(item =>
              {
                var page = _api.Pages.GetById<CategoryPage>(item.Id);
                var ci = new CategoryItem
                {
                  Title = page.Title,
                  PageUrl = page.Permalink,
                  ImageUrl = page.CategoryDetail.CategoryImage.Resize(_api, 200).Substring(2)
                };
                return ci;
              })
      };

      return View(model);
    }

    /// <summary>
    /// Gets the category page with the given id.
    /// </summary>
    /// <param name="id">The unique category page id</param>
    [Route("category")]
    public IActionResult Category(Guid id)
    {
      var model = _api.Pages.GetById<Models.CategoryPage>(id);

      return View(model);
    }

  }
}