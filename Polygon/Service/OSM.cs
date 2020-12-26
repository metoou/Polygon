using Polygon.Service.Abstract;
using System.Collections.Generic;
using Polygon.Models;
namespace Polygon.Service
{
    public class OSM:IGeoServices
    {
        readonly string query = "https://www.overpass-api.de/api/interpreter?data=[out:json];nwr[name~";
        readonly string queryFormat = "];out geom;";
        public string GetUrl(string address)
        {
            return query + address + queryFormat;
        }       
        public List<string> GetCoordinates(Root root, int frequency)
        {
            List<string> coordinates = new List<string>();

            foreach (var item in root.elements)
            {
                if (item.members != null)
                {
                    foreach (var item2 in item.members)
                    {
                        if (item2.geometry != null)
                        {
                            foreach (var item3 in item2.geometry)
                            {
                                for (int i = 0; i < item2.geometry.Count; i = i + frequency)
                                {
                                    coordinates.Add("[" + item3.lat.ToString() + " " + item3.lon.ToString() + "]");
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            return coordinates;
        }
    }
}
