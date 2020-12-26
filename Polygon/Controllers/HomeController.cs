using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Polygon.Models;
using Polygon.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace Polygon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Frequency> frequencies = new List<Frequency>
        {
            new Frequency { Name = "Частота = 1", Value = 1  },
            new Frequency { Name = "Частота = 2", Value = 2  },
            new Frequency { Name = "Частота = 5", Value = 5  },
            new Frequency { Name = "Частота = 10", Value = 10  }
        };
            ViewBag.Frequencies = new SelectList(frequencies, "Value", "Name");
            return View();
        }

        [HttpGet]
        public FileResult GetPolygonOSM(string address, int frequency, string fileName)
        {
            OSM osm = new OSM();
            Root root = new Root();
            string result = osm.GetUrl("\"" + address + "\"");
            var webClient = new WebClient();
            var json = webClient.DownloadString(result);
            root = JsonConvert.DeserializeObject<Root>(json);
            byte[] coordinatesBytes = osm.GetCoordinates(root, frequency).SelectMany(s => Encoding.Default.GetBytes(s)).ToArray();
            return File(coordinatesBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
