using System;
using Flunt.Validations;
using PlaylistRecommender.Domain.Core;
using PlaylistRecommender.Domain.ValueObjects;

namespace PlaylistRecommender.Domain.Entities
{
    public class City : Entity
    {
        public City()
        {
        }

        public City(string name, Coordinates coordinates)
        {
            if(coordinates.Valid)
            {
                Coordinates = coordinates;
            }

            Name = name;

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Name, "City.Name", "O Nome da cidade é obrigario quando as coordenadas não são informadas")
            );
        }

        public string Name { get; private set; }

        public Coordinates Coordinates { get; private set;}
    }
}