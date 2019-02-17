using System.Collections.Generic;

using NorthwindCms.Models.Regions;

using Piranha.AttributeBuilder; // [PageType]
using Piranha.Extend.Fields;
using Piranha.Models; // Page<T>

namespace NorthwindCms.Models
{
  [PageType(Title = "Category Page", UseBlocks = false)]
  [PageTypeRoute(Title = "Default", Route = "/category")]
  public class CategoryPage : Page<CategoryPage>
  {
    [Region(Title = "Category detail")]
    [RegionDescription("The details for this category.")]
    public CategoryRegion CategoryDetail { get; set; }

    [Region(Title = "Category products")]
    [RegionDescription("The products for this category.")]
    public IList<ProductRegion> Products { get; set; }
      = new List<ProductRegion>();
  }
}
