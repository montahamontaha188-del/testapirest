using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapirest.Data;
using Microsoft.EntityFrameworkCore;

namespace testapirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoriescontroller : ControllerBase
    {
        public Categoriescontroller(AppDbContaxt db)
        {
            _db = db;
        }
        public readonly AppDbContaxt _db;


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cats = await _db.Categories.ToListAsync();
            return Ok(cats);
        }
}
}
