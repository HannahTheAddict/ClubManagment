using HannahElSayed0523003.Models;

namespace HannahElSayed0523003.Repos.TeamRepos
{
    public interface ITeamRepo : IGenericRepo<Team>
    {
        public Task<IEnumerable<Team>> GetNonComeptitionsDetailsAsync();
    }
}
