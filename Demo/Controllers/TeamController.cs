using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class TeamController : BaseController
    {
        

        public TeamController(HttpClient httpClient):base(httpClient)
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
