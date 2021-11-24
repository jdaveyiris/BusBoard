using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    public class Arrival
    {
        public string destinationName { get; set; }

        public DateTime expectedArrival { get; set; }

        public string towards { get; set; }

        public override string ToString()
        {
            return $"Bus to {destinationName} arriving at {expectedArrival} heading towards {towards}";
        }
    }




}
