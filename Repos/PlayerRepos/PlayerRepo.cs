using HannahElSayed0523003.DatabaseConnection;
using HannahElSayed0523003.Models;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.Repos.PlayerRepos
{
    public class PlayerRepo : GenericRepo<Player>, IPlayerRepo
    {
        public PlayerRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Player>> GetTopYoungAsync()
        {
            return await db.Players.Include(x=>x.Team).ToListAsync();
        }
    }
}
