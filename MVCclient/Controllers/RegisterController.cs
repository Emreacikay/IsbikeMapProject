using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft;
using System.Text;
using MVCclient.Models;

namespace MVCclient.Controllers
{
    public class RegisterController : BaseController
    {
        public RegisterController(HttpClient httpClient) : base(httpClient)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IndexAsync(UserDto model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                return BadRequest("Şifreler Uyuşmuyor");
            }

            var modelJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var jsonString = new StringContent(modelJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7037/api/Auth/Register",jsonString);
            var responseString = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode == false)
            { 
                return BadRequest("Bu email kullanılamaz"); 
            }

            return Redirect("/register/sucessful");
            
        }

        public IActionResult sucessful()
        {
            return View();
        }

    }
}
