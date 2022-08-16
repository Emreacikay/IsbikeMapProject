using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BaseController : Controller
    {
        private readonly HttpClient _httpClient;

        public BaseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
