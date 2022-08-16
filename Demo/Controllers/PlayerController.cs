using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PlayerController : BaseController
    {
       

        public PlayerController(HttpClient httpClient):base(httpClient)
        {
          
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
