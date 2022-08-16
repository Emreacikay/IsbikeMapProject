using Microsoft.AspNetCore.Mvc;
using MVCclient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace MVCclient.Controllers
{

    public class IsbikeController : BaseController
    {
        static string token = string.Empty;
        
        public IsbikeController(HttpClient httpClient) : base(httpClient)
        {
        }

        ListIsbikeViewModel List = new ListIsbikeViewModel();
        IsbikeVievModel isbike = new IsbikeVievModel();


        [HttpGet]
        public async Task<IActionResult> TokenSet(string Token)
        {
            token = Token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            if (token != null)
                return RedirectToAction("Index", "Isbike");
            else
                return RedirectToAction("Index","Login");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStreamAsync("https://localhost:7037/api/Isbike");
            using (response)
            {
                StreamReader stream = new StreamReader(response);
                // Read and parse stream
                JArray array = JArray.Parse(stream.ReadToEnd());
                // Deserialize it
                List.isbike = JsonConvert.DeserializeObject<List<IsbikeVievModel>>(array.ToString());
            };
            return View(List);
        } 

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IsbikeVievModel model)
        {
            
            var LatString = model.lat.ToString();
            LatString = LatString.Insert(2, ",");
            model.lat = float.Parse(LatString);

            var LonString = model.lon.ToString();
            LonString = LonString.Insert(2, ",");
            model.lon = float.Parse(LonString);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var modelJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var jsonString = new StringContent(modelJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7037/api/Isbike/", jsonString);

            return Redirect("/Isbike/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"https://localhost:7037/api/Isbike/{id}");
            var responseRead = await response.Content.ReadAsStringAsync();
            isbike = JsonConvert.DeserializeObject<IsbikeVievModel>(responseRead);

            return View(isbike);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IsbikeVievModel model)
        {

            var LatString = model.lat.ToString();
            LatString = LatString.Insert(2, ",");
            model.lat = float.Parse(LatString); 
            
            var LonString = model.lon.ToString();
            LonString = LonString.Insert(2, ",");
            model.lon = float.Parse(LonString);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var modelJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var jsonString = new StringContent(modelJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://localhost:7037/api/Isbike/", jsonString);

            return Redirect("/Isbike/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _httpClient.GetAsync($"https://localhost:7037/api/Isbike/{id}");
            var responseRead = await response.Content.ReadAsStringAsync();
            isbike = JsonConvert.DeserializeObject<IsbikeVievModel>(responseRead);

            return View(isbike);
        }

        [HttpGet]       
        public async Task<IActionResult> Delete(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var temp = await _httpClient.GetAsync($"https://localhost:7037/api/Isbike/{id}");
            var tempRead = await temp.Content.ReadAsStringAsync();
            var response = await _httpClient.DeleteAsync($"https://localhost:7037/api/Isbike/{id}");
            isbike = JsonConvert.DeserializeObject<IsbikeVievModel>(tempRead);

            if (response.IsSuccessStatusCode)
                return View(isbike);
            else
                return BadRequest("Delete Failed.");

        }

        public async Task<IActionResult> Map()
        {
            
            var response = await _httpClient.GetStreamAsync("https://localhost:7037/api/Isbike");
            using (response)
            {
                StreamReader stream = new StreamReader(response);
                // Read and parse stream
                JArray array = JArray.Parse(stream.ReadToEnd());
                // Deserialize it
                List.isbike = JsonConvert.DeserializeObject<List<IsbikeVievModel>>(array.ToString());
            };

            //GEOJSONA ÇEVİRME
            //Sabit satır
            var first ="{ \"type\": \"FeatureCollection\", \"features\": [";
            foreach ( var item in List.isbike)
            {
                first += "{ \"type\":\"Feature\",\"geometry\": { \"type\":\"Point\", \"coordinates\": [";
                first += (item.lon.ToString().Replace(',', '.'));
                first += (",");
                first += (item.lat.ToString().Replace(',', '.')); 
                first += ( "] }, " + "\"properties\": {");
                first += ("\"St_Id\": \"" + item.Id.ToString() + "\"");
                first += (",\"St_No\": \"" + item.istasyon_no.ToString() + "\"");
                first += (",\"St_Name\": \"" + item.adi.ToString()) + "\"";
                first += (",\"isActive\": \"" +  item.aktif.ToString()) + "\"";
                first += (",\"emptyCycles\": \"" + item.bos.ToString()) + "\"";
                first += (",\"fullCycles\": \"" + item.dolu.ToString()) + "\"";
                first += (",\"lastConnection\": \"" + item.sonBaglanti.ToString()) + "\""; first += "} },";
            }
            /*virgülü sil*/ 
            first = first.TrimEnd(','); 
            /*kapat*/ 
            first += "] }";

            IsbikeGeoJson geo = new IsbikeGeoJson();
            geo.GeoJson = first;
            return View(geo);
        }
    }
}
