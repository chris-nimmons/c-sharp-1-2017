using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises1_23
{
    class Program
    {
        static void Main(string[] args)
        {
            var markers = new List<Marker>()
            {
                new Marker() {Color = "Pink" }
                new Marker() {Color = "Brown" }
                new Marker() {Color = "Green" }
                new Marker() {Color = "Red" }
            };

            var markers = new List<Marker>()
           {
               new Marker() { Color = "Pink" },
               new Marker() { Color = "Brown" },
               new Marker() { Color = "Green" },
               new Marker() { Color = "Red" }
           };

            ////var containsNList = markers
            ////    .FirstOrDefault(marker => marker.Color.Contains("f") || marker.Color == "Green");

            ////Func<bool, bool> action = (input) => { return true; };

            ////var output = action(true);
            ////output = Action();

            ////var any = markers.Any(marker => marker.Color == "Brown");
            ////var countn = markers.Count(marker => marker.Color == "Green");

            //int page = 2;
            //int size = 2;
            //var stuff = markers.Skip((page - 1) * size).Take(size);\
        }
    }
}
