using Newtonsoft.Json;
using System.Collections.Generic;

namespace Polygon.Models
{
    public class Element
    {        
        public string type { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public long id { get; set; }    
        public Bounds bounds { get; set; }  
        public List<Member> members { get; set; }      
        public Tags tags { get; set; }
    }
}
