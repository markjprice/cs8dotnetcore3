using Piranha.AttributeBuilder; // [PageType]
using Piranha.Extend.Fields;
using Piranha.Models; // Page<T>

namespace NorthwindCms.Models
{
    [PageType(Title = "Standard page")]
    public class StandardPage  : Page<StandardPage>
    {
    }
}