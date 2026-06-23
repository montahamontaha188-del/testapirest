using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapirest.Data;

namespace testapirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(AppDbContaxt db)

        {
           _db = db; 
        }
        private readonly AppDbContaxt _db;
    }
}
