using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    public class Arrival
    {
        public string destinationName { get; set; }

        public DateTime expectedArrival { get; set; }

        public string towards { get; set; }

        public string stationName { get; set; }

        public override string ToString()
        {
            return $"Stop: {stationName}. Bus to {destinationName} arriving in {TimeConverter(expectedArrival)} minutes, heading towards {towards}";
        }

        public static void ArrivalGenerator(List<Arrival> response)
        {
            var arrivalSortedList = response.OrderBy(x => x.expectedArrival).ToList();
            for (int i = 0; i < Math.Min(5, arrivalSortedList.Count()); i++)
            {
                Console.WriteLine(arrivalSortedList[i].ToString());
            }
        }

        public static int TimeConverter(DateTime expectedArrival)
        {
            DateTime b = DateTime.Now;
            double minutesToArrival = expectedArrival.Subtract(b).TotalMinutes;
            return Convert.ToInt32(minutesToArrival);
        }
       
        public int MinutesToArrival()
        {
            return TimeConverter(expectedArrival);
        }
        
    }






}
