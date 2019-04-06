using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Commands;
using Web.Api.Domain.Models;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly CommandHandler _handler;
        public GameController(CommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("round-scores/calculate")]
        public ActionResult<IEnumerable<RoundScore>> Calculate([FromBody] CalculateRoundScores calculateRoundScores)
        {
            return Ok(_handler.Handle(calculateRoundScores));
        }
    }
}