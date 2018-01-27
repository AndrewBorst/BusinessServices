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

        [HttpGet("ship/order/{orderID}", Name = "GetShipConfirm")]
        public IActionResult GetById(string orderID)
        {
            var item = _context.ShipConfirms.FirstOrDefault(t => t.orderID == orderID);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPut("order/{orderID}")]
        public IActionResult Update(string orderID, [FromBody] ShipConfirm item)
        {
            if (item == null || item.orderID != orderID)
            {
                return BadRequest();
            }

            var sc = _context.ShipConfirms.FirstOrDefault(t => t.orderID == orderID);
            if (sc == null)
            {
                return NotFound();
            }

            sc.hasSent = item.hasSent;
            sc.orderID = item.orderID;

            _context.ShipConfirms.Update(sc);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("order/{orderID}")]
        public IActionResult Delete(string orderID)
        {
            var sc = _context.ShipConfirms.FirstOrDefault(t => t.orderID == orderID);
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
