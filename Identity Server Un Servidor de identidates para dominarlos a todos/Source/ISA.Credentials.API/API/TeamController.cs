using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISA.Credentials.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISA.Credentials.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Team", AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Team>> Get()
        {

            return new Team[] {
            new Team {
                Name="Real Madrid",
                ChampionsLeague=13
            },
             new Team {
                Name="Milan",
                ChampionsLeague=6
            },
             new Team
             {
                 Name="Atletico de Madrid",
                 ChampionsLeague=0
             },
             new Team
             {
                 Name="F.C. Barcelona",
                 ChampionsLeague=5
             }
            };
        }

    }
}
