using HannahElSayed0523003.Models;

namespace HannahElSayed0523003.Repos.CompetitionRepos
{
    public interface ICompetitionRepo : IGenericRepo<Competition>
    {
        public  Task<IEnumerable<Competition>> GetCompetitionsWithDetailsAsync();
    }
}
