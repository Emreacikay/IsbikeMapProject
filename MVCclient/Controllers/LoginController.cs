using Microsoft.AspNetCore.Mvc;
using MVCclient.Models;
using RestSharp;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace MVCclient.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(HttpClient httpClient) : base(httpClient)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserLoginDto model)
        {
            var modelJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var jsonString = new StringContent(modelJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7037/api/Auth/Login", jsonString);
            var Token = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TokenSet", "Isbike", new
                {
                    Token = Token
                }); ;
            }
            else
                return BadRequest("Kullanıcı bulunamadı.");
        }

    }
}
