using System.Collections.Generic; 
using System.Linq;

using Microsoft.AspNetCore.Mvc; 

using Packt.Shared;

namespace NorthwindService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly Northwind db;

    public ProductsController(Northwind db)
    {
      this.db = db;
    }

    // GET: api/products 
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
    public IEnumerable<Product> Get()
    {
      var products = db.Products.ToArray(); 
      return products;
    }

    // GET api/products/5
    [HttpGet("{id}" , Name = nameof(GetProductsByCategoryID))]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
    public IEnumerable<Product> GetProductsByCategoryID(int id)
    {
      var products = db.Products.Where(
          product => product.CategoryID == id)
          .ToArray(); 
      return products;
    }
  }
}
