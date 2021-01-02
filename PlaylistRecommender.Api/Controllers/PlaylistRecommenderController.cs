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
        public IActionResult Get(string cityName)
        {
            try
            {
                var command = new PlaylistRecommendationCommand() 
                {
                    CityName = cityName,
                };

                var result = _handler.Handle(command);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
