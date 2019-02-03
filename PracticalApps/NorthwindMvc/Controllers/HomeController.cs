using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindMvc.Models;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;

namespace NorthwindMvc.Controllers
{
  public class HomeController : Controller
  {
    private Northwind db;

    private readonly IHttpClientFactory clientFactory;

    public HomeController(Northwind injectedContext,
      IHttpClientFactory httpClientFactory)
    {
      db = injectedContext;
      clientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
      var model = new HomeIndexViewModel
      {
        VisitorCount = (new Random()).Next(1, 1001),
        Categories = db.Categories.ToList(),
        Products = db.Products.ToList()
      };

      return View(model); // pass model to view
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ProductDetail(int? id)
    {
      if (!id.HasValue)
      {
        return NotFound("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
      }

      var model = db.Products
        .SingleOrDefault(p => p.ProductID == id);

      if (model == null)
      {
        return NotFound($"Product with ID of {id} not found.");
      }

      return View(model); // pass model to view
    }

    public IActionResult ProductsThatCostMoreThan(decimal? price)
    {
      if (!price.HasValue)
      {
        return NotFound("You must pass a product price in the query string, for example, /Home/ProductsThatCostMoreThan?price=50");
      }

      var model = db.Products
        .Include(p => p.Category)
        .Include(p => p.Supplier)
        .Where(p => p.UnitPrice > price)
        .ToArray();

      if (model.Count() == 0)
      {
        return NotFound($"No products cost more than {price:C}.");
      }
      ViewData["MaxPrice"] = price.Value.ToString("C");

      return View(model); // pass model to view
    }

    public async Task<IActionResult> Customers(string country)
    {
      string uri;

      if (string.IsNullOrEmpty(country))
      {
        ViewData["Title"] = "All Customers Worldwide";
        uri = "api/customers/";
      }
      else
      {
        ViewData["Title"] = $"Customers in {country}";
        uri = $"api/customers/?country={country}";
      }
        
      var client = clientFactory.CreateClient(
        name: "NorthwindService");

      var request = new HttpRequestMessage(
        method: HttpMethod.Get, requestUri: uri);

      HttpResponseMessage response = await client.SendAsync(request);

      string jsonString = await response.Content.ReadAsStringAsync();

      IEnumerable<Customer> model = JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonString);

      return View(model);
    }
  }
}