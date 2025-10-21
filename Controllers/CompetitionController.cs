using HannahElSayed0523003.DTOs.CompetitionDTOs;
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
    public class CompetitionController : ControllerBase
    {
        private readonly ICoachRepo coachRepo;
        private readonly IPlayerRepo playerRepo;
        private readonly ITeamRepo teamRepo;
        private readonly ICompetitionRepo comRepo;

        public CompetitionController(ICoachRepo coachRepo, IPlayerRepo playerRepo, ITeamRepo teamRepo, ICompetitionRepo comRepo)
        {
            this.coachRepo = coachRepo;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.comRepo = comRepo;
        }

        [HttpDelete("deleteby/{id}")]
        public async Task<IActionResult> DeleteCompetitionByID(int id)
        {
            var ex = await comRepo.GetByIDAsync(id);
            if (ex == null) return NotFound("no competition by that id");

            await comRepo.Delete(id);
            await comRepo.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("Team-Count")]
        public async Task<IActionResult> GetTeamCounts()
        {
            var all = await comRepo.GetCompetitionsWithDetailsAsync();
            var shaped = all.GroupBy(l => l.Location).Select(x => new CompetitionCountDTO
            {
                Location = x.Key,
                totalnumberofteams = x.Select(x => x.Teams).Count(),
                //TeamsPlayersNumber = x.SelectMany(x=>x.Teams).SelectMany(x=>x.Players).Select(n => new TotalNumberOfPlayersDTO
                //{
                //    TotalNumberOfPlayers = x.SelectMany(x => x.Teams).Count(),
                //})
            }).ToList();

            return Ok(shaped);
        }

    }
}
