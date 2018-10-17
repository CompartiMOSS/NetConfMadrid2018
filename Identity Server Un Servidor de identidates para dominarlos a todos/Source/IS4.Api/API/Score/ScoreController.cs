using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IS4.Api.API.Score
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Score", AuthenticationSchemes = "Bearer")]
    public class ScoreController : ControllerBase
    {
        IEnumerable<Model.Score> scoreColection;
        public ScoreController()
        {
            Model.Score score = new Model.Score
            {
                Competition = "Champions League",
                Team1 = "Real Madrid",
                Team2 = "Liverpool"
            };
            this.scoreColection = new List<Model.Score> { score };
        }

        private string GetResult(string score)
        {
            if (score == null)
            {
                return "0:0";
            }
             if (score == "0:0")
            {
                return  "1:0";
            }
            if (score == "1:0")
            {
                return "1:1";
            }
            if (score == "1:1")
            {
                return  "2:1";
            };
            if (score == "2:1")
            {
                return  "3:1";
            };
            return score;
        }
        [HttpGet]
        public IEnumerable<Model.Score> GetScores()
        {
            var score = scoreColection.FirstOrDefault();
            score.Result = GetResult(score.Result);         
            this.scoreColection = new List<Model.Score> { score };
            return this.scoreColection;
        }
    }
}