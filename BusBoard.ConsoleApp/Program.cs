﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using BusBoard.Api;

namespace BusBoard.ConsoleApp
{
  public class Program
  {
    static void Main(string[] args)
    {
        Console.Write("Enter your PostCode: ");
        string postcode = Console.ReadLine();
        ApiHelper.CallStopPointAPI(ApiHelper.CallPostcodeAPI(postcode));

        Console.Read();
    }
  }
}
