using HannahElSayed0523003.DTOs.CoachDTOs;
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
    public class CoachController : ControllerBase
    {
        private readonly ICoachRepo coachRepo;
        private readonly IPlayerRepo playerRepo;
        private readonly ITeamRepo teamRepo;
        private readonly ICompetitionRepo comRepo;

        public CoachController(ICoachRepo coachRepo, IPlayerRepo playerRepo, ITeamRepo teamRepo, ICompetitionRepo comRepo)
        {
            this.coachRepo = coachRepo;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.comRepo = comRepo;
        }

        [HttpGet("GetAllCoaches")]
        public async Task<IActionResult> GetAll()
        {
            var all = await coachRepo.GetAllWithDetailsAsync();
            
            var shaped = all.GroupBy(c => c.Specialization).Select(x => new GetCoachesWithDetailsDTO
            {
                Specialization = x.Key,
                //TeamName = x.Select(d=>d.Team.TeamName),
            }).ToList();

            
            return Ok(shaped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoachDetailsById(int id)
        {
            var exi = await coachRepo.GetCoachDetailsAsync(id);
            if(exi == null) return NotFound("id doesnt exist");

            
            var shaped = new GetCoachWithDetailsDTO
            {
                CoachID = exi.CoachID,
                CoachName = exi.CoachName,
                ExperienceYears = exi.ExperienceYears,
                Specialization = exi.Specialization,
                NumberOfPlayers = exi.Team.Players.Count,
                TeamID= exi.Team.TeamID,
            };

            return Ok(shaped);
                
        }

    }

}
