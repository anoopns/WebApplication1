using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplication1.Models
{
    public class ForecastBusinessLayer
    {
        private string _city;
        private string _countyCode;
        private string _url = ConfigurationManager.AppSettings["URL"];
        private string _cnt = ConfigurationManager.AppSettings["cnt"];
        private string _appId = ConfigurationManager.AppSettings["APPID"];
        public ForecastBusinessLayer(string city, string countryCode)
        {
            this._city = city;
            this._countyCode = countryCode;
        }

        public Object GetWeatherForecast()
        {
            Object forecastData = new object();
            using (var client = new HttpClient())
            {

                UriBuilder builder = new UriBuilder(_url);
                builder.Query = $"q={_city},{_countyCode}&cnt={_cnt}&APPID={_appId}";
                var response = client.GetAsync(builder.Uri);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    dynamic data = JObject.Parse(readTask.Result);
                    forecastData = data.list[0];
                }
                else
                {

                }
            }

            return forecastData;
        }


    }
}