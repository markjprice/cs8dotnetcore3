using System.Collections.Generic;

namespace Packt.Shared
{
  public class HomeIndexViewModel
  {
    public int VisitorCount;
    public IList<Category> Categories { get; set; } 
    public IList<Product> Products { get; set; }
  }
}