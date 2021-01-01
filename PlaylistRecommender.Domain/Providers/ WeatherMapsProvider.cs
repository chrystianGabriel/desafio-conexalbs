using System.Threading.Tasks;
using PlaylistRecommender.Domain.Core;
using PlaylistRecommender.Domain.Entities;

namespace PlaylistRecommender.Domain.Providers
{
    public class  WeatherMapsProvider : Provider<Weather>
    {
        private const string API_KEY = "";

        private const string ROUTE_GET_WEATHER = "/weather";
        public WeatherMapsProvider() : base("https://api.openweathermap.org/data/2.5/") 
        {
            this.AddUrlParams("API_KEY", API_KEY);
        }

        public async Task<Weather> GetCityWeather(City city)
        {
            this.AddUrlParams("q", city.Name);
            
            if(city.Coordinates.Valid)
            {
                this.AddUrlParams("lat", city.Coordinates.Latitude);
                this.AddUrlParams("lon", city.Coordinates.Longitude);
            }

            return await this.Get(ROUTE_GET_WEATHER);
        }
    }
}