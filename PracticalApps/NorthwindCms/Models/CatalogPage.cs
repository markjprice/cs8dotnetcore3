using Piranha.AttributeBuilder; // [PageType]
using Piranha.Extend.Fields;
using Piranha.Models; // Page<T>
using NorthwindCms.Models.Regions;
using System.Collections.Generic;

namespace NorthwindCms.Models
{
  [PageType(Title = "Catalog page", UseBlocks = false)]
  [PageTypeRoute(Title = "Default", Route = "/catalog")]
  public class CatalogPage : Page<CatalogPage>
  {
  }
}