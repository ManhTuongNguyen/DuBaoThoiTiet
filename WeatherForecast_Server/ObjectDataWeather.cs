using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast_Server
{
    public class ObjectDataWeather
    {
        private string cityName;
        private string dataWeather;
        private string timeGetData;

        public ObjectDataWeather()
        {

        }

        public string CityName { get => cityName; set => cityName = value; }
        public string DataWeather { get => dataWeather; set => dataWeather = value; }
        public string TimeGetData { get => timeGetData; set => timeGetData = value; }
    }
}
