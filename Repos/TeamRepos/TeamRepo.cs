using HannahElSayed0523003.DatabaseConnection;
using HannahElSayed0523003.Models;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.Repos.TeamRepos
{
    public class TeamRepo : GenericRepo<Team>, ITeamRepo
    {
        public TeamRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Team>> GetNonComeptitionsDetailsAsync() {

            return await db.Teams.Include(x => x.Competitions)
                .Include(x => x.Players)
                .ToListAsync();
            //return await db.Competitions.Include(x => x.Teams).ThenInclude(x => x.Players)
            //    .ToListAsync();
        }
    }
}
