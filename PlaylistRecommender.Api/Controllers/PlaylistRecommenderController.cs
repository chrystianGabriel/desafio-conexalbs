using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaylistRecommender.Domain.Commands;
using PlaylistRecommender.Domain.Handlers;

namespace PlaylistRecommender.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistRecommenderController : ControllerBase
    {
        private readonly PlaylistRecommendationHandler _handler;

        public PlaylistRecommenderController(PlaylistRecommendationHandler handler){
            _handler = handler;
        }

        [HttpGet]
        public IActionResult City(string cityName, string longitude, string latitude)
        {
            try
            {
                var command = new PlaylistRecommendationCommand() 
                {
                    CityName = cityName,
                    CityLongitude = longitude,
                    CityLatitude = latitude,
                };

                var result = _handler.Handle(command);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500,new CommandResult(false, "Ocorreu um erro ao processar sua requisição, por favor, tente mais tarde."));
            }
        }
    }
}
