using Polygon.Models;
using System.Collections.Generic;

namespace Polygon.Service.Abstract
{
    public interface IGeoServices
    {
        string GetUrl(string address);
        List<string> GetCoordinates(Root root, int frequency);

    }
}
