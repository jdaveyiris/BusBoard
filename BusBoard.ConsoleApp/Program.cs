using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Console.Write("Please enter your bus stop code: ");
            string busStop = Console.ReadLine();

            string apiCall = $"https://api.tfl.gov.uk/StopPoint/{busStop}/Arrivals";

            var client = new RestClient(apiCall);

            var request = new RestRequest();

            var response = client.Get<List<Arrival>>(request).Data;

            foreach (Arrival arrival in response)
            {
                Console.WriteLine(arrival.ToString());
            }

            Console.ReadLine();

        }
  }
}
