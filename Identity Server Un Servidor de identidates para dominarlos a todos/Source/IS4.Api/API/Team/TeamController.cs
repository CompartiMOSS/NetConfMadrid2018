using System.Collections.Generic;
using Bogus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IS4.Api.API.Team
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Team", AuthenticationSchemes = "Bearer")]
    public class TeamController : ControllerBase
    {
        IEnumerable<Model.Team> teamCollection;
        public TeamController()
        {
            var competion = new[] { "Liga", "Copa", "Supercopa " };
            var team = new[] { "Real Madrid", "Juventus", "Espanyol ", "Bayern de Munich", "Milan", "FC Barcelona" };
            var country = new[] { "España", "Italia", "Francia", "Inglaterra", "Alemania" };
            var testPlayer = new Faker<Model.Team>()
                .RuleFor(x => x.Foundation, u => u.Person.DateOfBirth)
                .RuleFor(x => x.Name, u => u.PickRandom(team));                

            teamCollection = testPlayer.Generate(6);
        }
        [HttpGet]
        public IEnumerable<Model.Team> GetTeams()
        {
            return teamCollection;
        }


    }
}