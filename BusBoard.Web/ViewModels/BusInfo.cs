using System;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode)
        {
            PostCode = postCode;

        }

        public string PostCode { get; set; }

        public string destinationName { get; set; }

        public string expectedArrival { get; set; }

        public string towards { get; set; }

    }
}