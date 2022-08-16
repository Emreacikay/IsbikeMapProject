using Demo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ITeamService _teamService;

        public ManagerController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllTeamsAsync();

            return View();
        }
    }
}
