﻿using RestSharp;
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
        public static List<Arrival> CallArrivalsAPI(StopPoint stopPoint)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string apiString = stopPoint.naptanId.ToString();
            string apiCall = $"https://api.tfl.gov.uk/StopPoint/{apiString}/Arrivals";

            var client = new RestClient(apiCall);

            var request = new RestRequest();

            var response = client.Get<List<Arrival>>(request).Data;

            return response;
        }

        public static void CallStopPointAPI(Postcode latlon)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string apiCall = $"https://api.tfl.gov.uk/StopPoint?stopTypes=NaptanPublicBusCoachTram&lat={latlon.latitude}&lon={latlon.longitude}";

            var client = new RestClient(apiCall);

            var request = new RestRequest();

            var response = client.Get<StopPointWrapper>(request).Data;

            foreach (StopPoint stop in response.stopPoints)
            {
               Arrival.ArrivalGenerator(CallArrivalsAPI(stop));
            }

        }

        public static Postcode CallPostcodeAPI(string postcode)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string apiCall = $"https://api.postcodes.io/postcodes/{postcode}";

            var client = new RestClient(apiCall);

            var request = new RestRequest();

            var response = client.Get<PostcodeWrapper>(request).Data;

            return response.result;
        }
    }
}
