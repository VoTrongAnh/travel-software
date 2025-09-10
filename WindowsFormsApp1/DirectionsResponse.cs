using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DirectionsResponse
    {
        public List<Route> routes { get; set; }
    }

    public class Route
    {
        public List<Leg> legs { get; set; }
    }

    public class Leg
    {
        public List<Step> steps { get; set; }
    }

    public class Step
    {
        public Polyline polyline { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }
}
