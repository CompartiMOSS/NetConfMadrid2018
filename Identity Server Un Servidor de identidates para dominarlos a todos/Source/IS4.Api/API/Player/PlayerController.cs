using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IS4.Api.API.Player
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Player", AuthenticationSchemes = "Bearer")]
    public class PlayerController : ControllerBase
    {
        IEnumerable<Model.Player> playersColection;
        public PlayerController()
        {
            var team = new[] { "Real Madrid", "Juventus", "Espanyol ", "Bayern de Munich", "Milan", "FC Barcelona" };
            var testPlayer = new Faker<Model.Player>()
               .RuleFor(u => u.FistName, f => f.Name.FirstName())
               .RuleFor(u => u.LastName, f => f.Name.LastName())
               .RuleFor(u=>u.Country,f=>f.Person.Address.City)
               .RuleFor(u=>u.DateBirthday,f=>f.Person.DateOfBirth.ToShortDateString())
               .RuleFor(u=>u.Equipo,f => f.PickRandom(team))
               .RuleFor(u => u.Photo, f => f.Internet.Avatar());
          
            playersColection = testPlayer.Generate(50);
        }
        [HttpGet]
        public IEnumerable<Model.Player> GetPlayers()
        {
           
            return playersColection;
        }
        [HttpGet("{equipo}")]

        public IEnumerable<Model.Player> GetPlayersTeam(string equipo)
        {
            return playersColection.Where(x => x.Equipo.Equals(equipo));
        }
    }
}