using HannahElSayed0523003.DTOs.PlayerDTOs;
using HannahElSayed0523003.Repos.CoachRepos;
using HannahElSayed0523003.Repos.CompetitionRepos;
using HannahElSayed0523003.Repos.PlayerRepos;
using HannahElSayed0523003.Repos.TeamRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HannahElSayed0523003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ICoachRepo coachRepo;
        private readonly IPlayerRepo playerRepo;
        private readonly ITeamRepo teamRepo;
        private readonly ICompetitionRepo comRepo;

        public PlayerController(ICoachRepo coachRepo, IPlayerRepo playerRepo, ITeamRepo teamRepo, ICompetitionRepo comRepo)
        {
            this.coachRepo = coachRepo;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.comRepo = comRepo;
        }

        [HttpPut("{id}")]
        //make sure when it's ok it says ok
        public async Task<IActionResult> EditPlayerPosition(int id, EditPlayerPositionDTO dto)
        {
            if (dto == null) return BadRequest("dto is null");

            var exist = await playerRepo.GetByIDAsync(id);
            if (exist == null) { return BadRequest("the player isnt mawgood"); }

            if (exist.Position == dto.Position) { return BadRequest("no update et3ml"); }
            else if (exist.Position != dto.Position)

            exist.Position = dto.Position;
            playerRepo.Update(exist);
            return Ok();

        }

        [HttpGet] // DONE
        public async Task<IActionResult> GetTopYoung()
        {
            var all = await playerRepo.GetTopYoungAsync();

            var shaped = all.GroupBy(x => x.TeamID).Select(c => new
            {
                YoungestPlayer = c.OrderBy(x => x.Age).First().PlayerName,

            }).ToList();
            return Ok(shaped);
        }


    }
}
