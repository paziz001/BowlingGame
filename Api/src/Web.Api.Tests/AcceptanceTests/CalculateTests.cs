using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Web.Api.Domain;
using Web.Api.Domain.Models;
using Xunit;

namespace Web.Api.Tests.AcceptanceTests
{
    public class CalculateTests {
        private readonly HttpClient _client;
        public CalculateTests()
        {
            _client = new TestServer(
                new WebHostBuilder()
                    .UseEnvironment("Development")
                    .UseStartup<Startup>()).CreateClient();
        }

        [Fact]
        public async Task CalculateScoreShouldReturnRoundScores()
        {
            var apiEndpoint = "round-scores/calculate";
            
            var bodyContent = "{\"rounds\": [{\"firstRoll\": 5, \"secondRoll\": 4}]}";
            var body = new StringContent(bodyContent, Encoding.UTF8, "application/json");

            var response = await  _client.PostAsync(apiEndpoint, body);

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            
            var expectedScores = RoundScoresCalculator.Calculate(
                Enumerable.Repeat(new Round(5, 4, new RoundScore(false, 0)), 1).ToList());
            var roundScores = await response.Content.ReadAsAsync<IEnumerable<RoundScore>>();
            roundScores.Should().BeEquivalentTo(expectedScores);
        }
        
        [Fact]
        public async Task CalculateReturnsBadRequestWhenRequestBodyIsInvalid()
        {
            var apiEndpoint = "round-scores/calculate";
            
            var bodyContent = "{\"rounds\": [{\"firstRoll\": 5, \"secondRoll\": 11}]}";
            var body = new StringContent(bodyContent, Encoding.UTF8, "application/json");

            var response = await  _client.PostAsync(apiEndpoint, body);

            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }
    }
}