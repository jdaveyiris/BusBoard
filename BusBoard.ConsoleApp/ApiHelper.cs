using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class ApiHelper
    {
        public static List<Arrival> CallAPI()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Console.Write("Please enter your bus stop code: ");
            string busStop = Console.ReadLine();

            string apiCall = $"https://api.tfl.gov.uk/StopPoint/{busStop}/Arrivals";

            var client = new RestClient(apiCall);

            var request = new RestRequest();

            var response = client.Get<List<Arrival>>(request).Data;

            return response;
        }


    }
}
