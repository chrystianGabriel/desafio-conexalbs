using System;
using Flunt.Notifications;
using Flunt.Validations;
using PlaylistRecommender.Domain.Core;

namespace PlaylistRecommender.Domain.Commands
{
    public class PlaylistRecommendationCommand : Notifiable, ICommand
    {
        public string CityName { get; set; }

        public string CityLatitude { get; set; }

        public string CityLongitude { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
              .Requires()
              .HasMaxLen(CityName, 70, "City.Name", "O nome da cidade não pode ter mais que ")
            );
        }
    }
}