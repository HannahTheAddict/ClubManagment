using HannahElSayed0523003.DatabaseConnection;
using HannahElSayed0523003.Models;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.Repos.CompetitionRepos
{
    public class CompetitionRepo : GenericRepo<Competition>, ICompetitionRepo
    {
        public CompetitionRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Competition>> GetCompetitionsWithDetailsAsync()
        {
            return await db.Competitions.Include(x => x.Teams).ThenInclude(x => x.Players).ToListAsync();
        }
    }
}
