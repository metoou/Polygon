using System.Collections.Generic;

namespace Polygon.Models
{
    public class Member
    {      
        public string type { get; set; }     
        public long @ref { get; set; }      
        public string role { get; set; }     
        public List<Geometry> geometry { get; set; }
    }
}
