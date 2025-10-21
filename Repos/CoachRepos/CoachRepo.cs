using HannahElSayed0523003.DatabaseConnection;
using HannahElSayed0523003.Models;
using Microsoft.EntityFrameworkCore;

namespace HannahElSayed0523003.Repos.CoachRepos
{
    public class CoachRepo : GenericRepo<Coach>, ICoachRepo
    {
        public CoachRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Coach>> GetAllWithDetailsAsync()
        {
            return  await db.Coaches.Include(x => x.Team).ToListAsync();
        }

        public async Task<Coach?> GetCoachDetailsAsync(int id)
        {
            return await db.Coaches.Include(X => X.Team).ThenInclude(x=>x.Players).FirstOrDefaultAsync(x => x.CoachID == id);
        }
    }
}
