using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Commands;
using Web.Api.Domain.Models;

namespace Web.Api.Controllers
{
    [Route("round-scores")]
    [ApiController]
    public class RoundScoresController : ControllerBase
    {
        private readonly CommandHandler _handler;
        public RoundScoresController(CommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [Route("calculate")]
        public ActionResult<IEnumerable<RoundScore>> Calculate([FromBody] CalculateRoundScores calculateRoundScores)
        {
            return Ok(_handler.Handle(calculateRoundScores));
        }
    }
}