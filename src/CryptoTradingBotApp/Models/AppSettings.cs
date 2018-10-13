using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoTradingBotApp.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://cryptotradingbotapp.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "quotes_grabbing_bot";

        public static string Key { get; set; } = "630987517:AAFMu_xNCbyDKOt_4t4LeEtk7lvXs5bB_mA";
    }
}