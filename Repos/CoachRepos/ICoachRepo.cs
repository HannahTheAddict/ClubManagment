using HannahElSayed0523003.Models;

namespace HannahElSayed0523003.Repos.CoachRepos
{
    public interface ICoachRepo : IGenericRepo<Coach>
    {
        public  Task<IEnumerable<Coach>> GetAllWithDetailsAsync();
        public  Task<Coach?> GetCoachDetailsAsync(int id);
    }
}
