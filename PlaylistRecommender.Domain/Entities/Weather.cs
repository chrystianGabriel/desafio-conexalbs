using PlaylistRecommender.Domain.Core;

namespace PlaylistRecommender.Domain.Entities
{
    public class Weather : Entity
    {
        public Weather(float temperature)
        {
            this.Temperature = temperature;
        }

        public float Temperature { get; private set; }
    }
}