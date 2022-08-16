using Demo.Models;

namespace Demo.Interface
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
    }
}
