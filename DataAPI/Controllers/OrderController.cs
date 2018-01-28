using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using DataApi.Models;
using System.Collections.Generic;

namespace DataApi.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public OrderController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration; 
            _context = context;

            if (_context.OrderHeaders.Count() == 0)
            {
               _context.OrderHeaders.Add(new OrderHeader {
                   orderID = "Order1",
                   clientID = "TheClient",
                   poNum = "9999911111" 
               });
               _context.SaveChanges();
            }
        }

        [HttpGet("order/")]
        public IEnumerable<OrderHeader> GetAll()
        {
            return _context.OrderHeaders.ToList();
        }

        [HttpGet("order/{orderID}", Name = "GetOrderConfirm")]
        public IActionResult GetById(string orderID)
        {
            var item = _context.OrderHeaders.FirstOrDefault(t => t.orderID == orderID);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost("order/{orderID}")]
        public IActionResult Create([FromBody] OrderHeader item)
        {
            if (item == null)
            {
                return BadRequest();
            }
           _context.OrderHeaders.Add(item);
           _context.SaveChanges();

            return CreatedAtRoute("GetOrderConfirm", new { id = item.orderID }, item);
        }



        [HttpPut("order/{orderID}")]
        public IActionResult Update(string orderID, [FromBody] OrderHeader item)
        {
            if (item == null || item.orderID != orderID)
            {
                return BadRequest();
            }

            var oh = _context.OrderHeaders.FirstOrDefault(t => t.orderID == orderID);
            if (oh == null)
            {
                return NotFound();
            }

            oh.clientID = item.clientID;
            oh.orderID = item.orderID;

            _context.OrderHeaders.Update(oh);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("order/{orderID}")]
        public IActionResult Delete(string orderID)
        {
            var oh = _context.OrderHeaders.FirstOrDefault(t => t.orderID == orderID);
            if (oh == null)
            {
                return NotFound();
            }

            _context.OrderHeaders.Remove(oh);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
