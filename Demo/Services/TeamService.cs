using Demo.Interface;
using Demo.Models;

namespace Demo.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;

        public TeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
