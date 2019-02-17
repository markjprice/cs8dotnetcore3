using System.Collections.Generic;

using NorthwindCms.Models.Regions;

using Piranha.AttributeBuilder; // [PageType]
using Piranha.Extend.Fields;
using Piranha.Models; // Page<T>

namespace NorthwindCms.Models
{
  [PageType(Title = "Catalog page", UseBlocks = false)]
  [PageTypeRoute(Title = "Default", Route = "/catalog")]
  public class CatalogPage : Page<CatalogPage>
  {
  }
}
