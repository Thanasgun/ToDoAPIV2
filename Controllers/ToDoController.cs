using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPIV2.Data;
using ToDoAPIV2.Models;

namespace ToDoAPIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDo()
        {
            return await _context.ToDo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(int id)
        {
            var product = await _context.ToDo.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo(ToDo product)
        {
            _context.ToDo.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetToDo), new { id = product.id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDo(int id, ToDo product)
        {
            if (id != product.id) return BadRequest();
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var product = await _context.ToDo.FindAsync(id);
            if (product == null) return NotFound();
            _context.ToDo.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
