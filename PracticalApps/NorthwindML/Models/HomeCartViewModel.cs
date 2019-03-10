using System.Collections.Generic;
using Packt.Shared;

namespace NorthwindML.Models
{
  public class HomeCartViewModel
  {
    public Cart Cart { get; set; }
    
    public List<EnrichedRecommendation> Recommendations { get; set; }
  }
}