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
    [Authorize("Player", AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {

            return new Player[] {
            new Player {
                Name="Cristiano Ronaldo",
                Number=7,
                Position="DC",
                Team="Real Madrid"
            },
                        new Player {
                Name="Luka Modrid",
                Number=19,
                Position="MC",
                Team="Real Madrid"
            },
                                  new Player {
                Name="Mohamed Salah",
                Number=10,
                Position="ED",
                Team="Liverpool"
            },
            };
        }

    }
}
