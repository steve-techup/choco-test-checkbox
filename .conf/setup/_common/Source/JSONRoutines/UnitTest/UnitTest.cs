using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TinyJson;

namespace UnitTest
{


    [TestClass]
    public class UnitTest
    {
        private static string json = @"{
  ""Serilog"": {
    ""Using"": [ ""Serilog.Sinks.Console"", ""Serilog.Sinks.File"" ],
    ""MinimumLevel"": ""Debug"",
    ""WriteTo"": [
      { ""Name"": ""Console"" },
      {
        ""Name"": ""File"",
        ""Args"": { ""path"": ""Logs/log.txt"" }
      }
    ],
    ""Enrich"": [ ""FromLogContext"", ""WithMachineName"", ""WithThreadId"" ]
  },
  ""ConnectionStrings"": {
    ""SQLServer"": ""__ Must be overridden locally or set from installer. __""
  },
  ""UILanguage"": ""en-US"",
  ""StationUniqueID"": ""__ Must be overridden locally or set from installer. __"",
  ""RFID"": {
    ""SimulatedMode"": true
  }
}";

        private static string replacedjson = @"{""Serilog"":{""Using"":[""Serilog.Sinks.Console"",""Serilog.Sinks.File""],""MinimumLevel"":""Debug"",""WriteTo"":[{""Name"":""Console""},{""Name"":""File"",""Args"":{""path"":""Logs/log.txt""}}],""Enrich"":[""FromLogContext"",""WithMachineName"",""WithThreadId""]},""ConnectionStrings"":{""SQLServer"":""LAPTOP-K48AE8RE\\SQLEXPRESS""},""UILanguage"":""en-US"",""StationUniqueID"":""__ Must be overridden locally or set from installer. __"",""RFID"":{""SimulatedMode"":true}}";
        [TestMethod]
        public void TestReplacement()
        {
            var value = "LAPTOP-K48AE8RE\\SQLEXPRESS";
            var replaced = JSONRoutines.JSONRoutines.ReplaceToken(json, "ConnectionStrings.SQLServer", value);
            
            Assert.AreEqual(replacedjson, replaced);
        }
    }
}
