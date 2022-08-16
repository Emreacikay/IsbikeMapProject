using JsonWebTokenAPI.Data;
using JsonWebTokenAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonWebTokenAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IsbikeController : ControllerBase
    {
        private DataContext _context;
        public IsbikeController(DataContext dataContext) 
        {
            _context = dataContext;
        }


        //GET
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()  //bütün isbike'ları döndür 
        {
            //Task<ActionResult<List<Isbike>>>
            var model = await _context.Isbikes.ToListAsync<Isbike>();
            var isbikeListJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            
            return Ok(isbikeListJson);
        }

        //GET

       
       [HttpGet("{id}")]
        public async Task<ActionResult<Isbike>> Get(int id)    //id isbike döndür
        {

            var bsc = await _context.Isbikes.FindAsync(id);
            if (bsc == null)
                return BadRequest("Isbike not found !");

            return Ok(bsc);
        }


        //POST

       
       [HttpPost] // id isbike ekle 
        public async Task<ActionResult<Isbike>> Add(Isbike isbike)
        {

            _context.Isbikes.Add(isbike);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //PUT

       [HttpPut] // id isbike update et
        public async Task<ActionResult<Isbike>> Update(Isbike request)
        {
            var dbBsc = await _context.Isbikes.FindAsync(request.Id);
            if (dbBsc == null)
                return BadRequest("Isbike not found !");

            dbBsc.Id = request.Id;
            dbBsc.istasyon_no = request.istasyon_no;
            dbBsc.adi = request.adi;
            dbBsc.aktif = request.aktif;
            dbBsc.dolu = request.dolu;
            dbBsc.bos = request.bos;
            dbBsc.lat = request.lat;
            dbBsc.lon = request.lon;
            dbBsc.sonBaglanti = request.sonBaglanti;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE 
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Isbike>> Delete(int id) //id isbike sil
        {
            var dbBsc = await _context.Isbikes.FindAsync(id);
            if (dbBsc == null)
                return BadRequest("Isbike not found !");

            _context.Isbikes.Remove(dbBsc);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
