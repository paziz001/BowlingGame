using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Web.Api.Commands;
using Web.Api.Domain;
using Web.Api.Domain.Models;
using Xunit;

namespace Web.Api.Tests.AcceptanceTests
{
    public class CalculateScoreTests {
        private readonly HttpClient _client;
        public CalculateScoreTests()
        {
            _client = new TestServer(
                new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>()).CreateClient();
        }

        [Fact]
        public async Task CalculateScoreShouldBeSuccessful()
        {
            var apiEndpoint = "api/game/round-scores/calculate";
            var command = new CalculateRoundScores
            {
                Rounds = new List<(int FirstRoll, int SecondRoll)>
                {
                    (FirstRoll: 5, SecondRoll: 4)
                }
            };
            var bodyContent = JsonConvert.SerializeObject(command);
            var body = new StringContent(bodyContent, Encoding.UTF8, "application/json");

            var response = await  _client.PostAsync(apiEndpoint, body);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            
            var expectedScores = RoundScoresCalculator.Calculate(
                command.Rounds.Select(round => new Round(round.FirstRoll, round.SecondRoll, new RoundScore(false, 0))).ToList());
            var roundScores = await response.Content.ReadAsAsync<IEnumerable<RoundScore>>();
            roundScores.Should().BeEquivalentTo(expectedScores);
        }
    }
}