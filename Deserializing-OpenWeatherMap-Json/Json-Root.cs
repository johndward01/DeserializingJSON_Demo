using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deserializing_OpenWeatherMap_Json
{
    class Json_Root
    {
        public List<Weather> WeatherList { get; set; } = new List<Weather>();
    }
}
