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
        private string _lat;
        private string _lon;
        private string _units;
        private string _url; 
        private string _exclude; 
        private string _appId; 
        public ForecastBusinessLayer()
        {
           _lat = ConfigurationManager.AppSettings["lat"];
           _lon = ConfigurationManager.AppSettings["lon"];
           _url = ConfigurationManager.AppSettings["URL"];
           _exclude = ConfigurationManager.AppSettings["exclude"];
           _appId = ConfigurationManager.AppSettings["APPID"];
            _units = ConfigurationManager.AppSettings["units"];
        }

        public List<Forecast> GetWeatherForecast()
        {

            using (var client = new HttpClient())
            {

                UriBuilder builder = new UriBuilder(_url);
                builder.Query = $"units={_units}&lat={_lat}&lon={_lon}&exclude={_exclude}&APPID={_appId}";
                var response = client.GetAsync(builder.Uri);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    dynamic data = JObject.Parse(readTask.Result);
                    var forecastData = (IEnumerable<Object>)data.daily;
                    List<Forecast> processedData = new List<Forecast>();
                    foreach(var item in data.daily)
                    {
                        if((double)item.temp.max > 10.00)
                        {
                            Forecast fc = new Forecast()
                            {
                                Date = UnixTimeStampToDateTime((double)item.dt).ToString("ddd d MMM"),
                                Temperature = item.temp.max,
                                Weather = item.weather[0].description
                            };
                            processedData.Add(fc);
                        }

                    }
                    return processedData;
                }
                else
                {
                    return null;
                }
            }

        }

        //Copied UnixTimeStampToDateTime from Stackoverflow https://stackoverflow.com/questions/249760/how-can-i-convert-a-unix-timestamp-to-datetime-and-vice-versa
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}