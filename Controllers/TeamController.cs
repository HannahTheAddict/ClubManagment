using HannahElSayed0523003.DTOs.TeamDTOs;
using HannahElSayed0523003.Models;
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
    public class TeamController : ControllerBase
    {
        private readonly ICoachRepo coachRepo;
        private readonly IPlayerRepo playerRepo;
        private readonly ITeamRepo teamRepo;
        private readonly ICompetitionRepo comRepo;

        public TeamController(ICoachRepo coachRepo, IPlayerRepo playerRepo, ITeamRepo teamRepo, ICompetitionRepo comRepo)
        {
            this.coachRepo = coachRepo;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.comRepo = comRepo;
        }


        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamDTO dto)
        {

            var exi = await coachRepo.GetByIDAsync(dto.CoachID);
            if (exi == null) return BadRequest("coach id doesnt exist");

            var coachexist = await coachRepo.GetCoachDetailsAsync(dto.CoachID);
            if(coachexist == null) return NotFound("coach id msh magood");
            //if (coachexist.Team.TeamName != dto.TeamName) return BadRequest("coach already has a team");

            //var allplayers = await playerRepo.GetAllAsync();
            //var players = allplayers.Where(x => dto.Players.Contains(x.PlayerID)).ToList();
            //if (players.Count() != dto.Players.Count()) return BadRequest("one player or more desont exist");

            //var allcomp = await comRepo.GetAllAsync();
            //var comps = allcomp.Where(x => dto.Competitions.Contains(x.CompetitionID)).ToList();
            //if (comps.Count() != dto.Competitions.Count()) return BadRequest("one compettion or more desont exist");

            var team = new Team
            {
                TeamName = dto.TeamName,
                City = dto.City,
                CoachID = dto.CoachID,
                coach = exi,
            };

            await teamRepo.AddAsync(team);
            await teamRepo.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetNonCompetitionTeams()
        {
            var all = await teamRepo.GetNonComeptitionsDetailsAsync();
            var shaped = all
                .Where(p => !p.Competitions.Any())
                .Select(x => new GetNonCompetitionsDTO
                {
                    PlayersCount = x.Players.Count(),
                    City = x.City,
                    TeamID = x.TeamID,
                    TeamName = x.TeamName,
                }).OrderByDescending(c => c.PlayersCount).ToList();

            return Ok(shaped);
        }

    }
}
