using System.Collections.Generic; 
using System.Linq;

using Microsoft.AspNetCore.Mvc; 

using Packt.Shared;

namespace NorthwindService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly Northwind db;

    public CategoriesController(Northwind db)
    {
      this.db = db;
    }

    // GET: api/categories
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IEnumerable<Category> Get()
    {
      var categories = db.Categories.ToArray(); 
      return categories;
    }

    // GET api/categories/5 
    [HttpGet("{id}", Name = nameof(GetCategory))]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(404)]
    public Category GetCategory(int id)
    {
      var category = db.Categories.Find(id); 
      return category;
    }
  }
}
