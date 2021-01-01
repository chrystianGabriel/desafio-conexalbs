using Flunt.Notifications;
using PlaylistRecommender.Domain.Commands;
using PlaylistRecommender.Domain.Core;
using PlaylistRecommender.Domain.Entities;
using PlaylistRecommender.Domain.Providers;
using PlaylistRecommender.Domain.ValueObjects;

namespace PlaylistRecommender.Domain.Handlers
{
    public class PlaylistRecommendationHandler :
        Notifiable,
        IHandler<PlaylistRecommendationCommand>
    {
        private readonly WeatherMapsProvider _weatherMapsProvider = new WeatherMapsProvider(); 
        public ICommandResult Handle(PlaylistRecommendationCommand command)
        {
            command.Validate();

            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel obter recomendação de playlist");
            }
            var city = new City(command.CityName,
                       new Coordinates(command.CityLatitude, command.CityLongitude));
            
            var weather = this._weatherMapsProvider.GetCityWeather(city).Result;

            AddNotifications(city, weather);

            return new CommandResult(true, "teste");
        }
    }
}