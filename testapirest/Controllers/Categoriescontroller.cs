using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapirest.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using testapirest.Data.models;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpPost]
        public async Task<IActionResult> AddCategories(Category category)
        {

            await _db.Categories.AddAsync(category);

            await _db.SaveChangesAsync();
            return Ok(category);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if (c == null)
            { return NotFound($"category id {category.Id} not exist"); }
            c.Name = category.Name;
            await _db.SaveChangesAsync();
            return Ok(c);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            { return NotFound($"category id {id} not exist"); }
            _db.Categories.Remove(c);
            await _db.SaveChangesAsync();
            return Ok($"category with id {id} deleted sucsessfully! ");
        }
        [HttpPatch ("{id}")]
        public async Task<IActionResult> UpdateCategoryPatch( [FromBody] JsonPatchDocument<Category> category, [FromRoute] int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            { return NotFound($"category id {id} not exist"); }
            category.ApplyTo(c);
            await _db.SaveChangesAsync();
            return Ok(c);
        }
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetOneCategories(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            { return NotFound($"category id {id} not exist"); }
           
            return Ok(c);
        }
    }
}
