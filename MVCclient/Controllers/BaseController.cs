using Microsoft.AspNetCore.Mvc;

namespace MVCclient.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClient _httpClient;

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
