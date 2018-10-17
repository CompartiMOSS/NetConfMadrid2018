using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IS4.Api.API.Competition
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Competition", AuthenticationSchemes = "Bearer")]
    public class CompetitionController : ControllerBase
    {
        IEnumerable<Model.Competition> competitionsCollection;
        public CompetitionController()
        {
            var competion = new[] { "Liga", "Copa", "Supercopa " };
            var country = new[] { "España", "Italia", "Francia", "Inglaterra","Alemania" };
            var testPlayer = new Faker<Model.Competition>()
                .RuleFor(x => x.Country, u => u.PickRandom(country))
                .RuleFor(x => x.Name, u => u.PickRandom(competion));

            competitionsCollection = testPlayer.Generate(10);            
        }
        [HttpGet]
        public IEnumerable<Model.Competition> GetCompetition()
        {
            return competitionsCollection;
        }
        
        [HttpGet("{country}")]
        public IEnumerable<Model.Competition> GetCountryCompetition(string country)
        {
            return competitionsCollection.Where(x => x.Country.Equals(country));
        }

    }
}