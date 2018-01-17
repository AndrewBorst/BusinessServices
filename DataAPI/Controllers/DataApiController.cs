using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataApi.Models;
using System.Linq;

namespace DataApi.Controllers
{
    [Route("api/[controller]")]
    public class DataApiController : Controller
    {
        private readonly DataContext _context;

        public DataApiController(DataContext context)
        {
            _context = context;

            if (_context.ShipConfirms.Count() == 0)
            {
                _context.ShipConfirms.Add(new ShipConfirm { OrderID = "BorstItem1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<ShipConfirm> GetAll()
        {
            return _context.ShipConfirms.ToList();
        }

        [HttpGet("{id}", Name = "GetShipConfirm")]
        public IActionResult GetById(string OrderID)
        {
            var item = _context.ShipConfirms.FirstOrDefault(t => t.OrderID == OrderID);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShipConfirm item)
        {
            if (item == null)
            {
                return BadRequest();                    
            }

            _context.ShipConfirms.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetShipConfirm", new { id = item.OrderID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string OrderID, [FromBody] ShipConfirm item)
        {
            if (item == null || item.OrderID != OrderID)
            {
                return BadRequest();
            }

            var sc = _context.ShipConfirms.FirstOrDefault(t => t.OrderID == OrderID);
            if (sc == null)
            {
                return NotFound();
            }

            sc.HasSent = item.HasSent;
            sc.OrderID = item.OrderID;

            _context.ShipConfirms.Update(sc);
            _context.SaveChanges();
            return new NoContentResult(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string OrderID)
        {
            var sc = _context.ShipConfirms.FirstOrDefault(t => t.OrderID == OrderID);
            if (sc == null)
            {
                return NotFound();
            }

            _context.ShipConfirms.Remove(sc);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
