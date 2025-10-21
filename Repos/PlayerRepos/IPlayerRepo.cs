using HannahElSayed0523003.Models;

namespace HannahElSayed0523003.Repos.PlayerRepos
{
    public interface IPlayerRepo : IGenericRepo<Player>
    {
        public  Task<IEnumerable<Player>> GetTopYoungAsync();
    }
}
