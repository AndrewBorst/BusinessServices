using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BorstDo.Models;
using System.Linq;

namespace BorstDo.Controllers
{
    [Route("api/[controller]")]
    public class BorstDoController : Controller
    {
        private readonly BorstDoContext _context;

        public BorstDoController(BorstDoContext context)
        {
            _context = context;

            if (_context.BorstItems.Count() == 0)
            {
                _context.BorstItems.Add(new BorstDoItem { Name = "BorstItem1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<BorstDoItem> GetAll()
        {
            return _context.BorstItems.ToList();
        }

        [HttpGet("{id}", Name = "GetBorstDo")]
        public IActionResult GetById(long id)
        {
            var item = _context.BorstItems.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BorstDoItem item)
        {
            if (item == null)
            {
                return BadRequest();                    
            }

            _context.BorstItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBorstDo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] BorstDoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.BorstItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.BorstItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.BorstItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.BorstItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
