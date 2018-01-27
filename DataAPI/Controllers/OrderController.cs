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
    [Authorize]
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

            if (_context.ShipConfirms.Count() == 0)
            {
               _context.ShipConfirms.Add(new ShipConfirm {
                   orderID = "Order1",
                   clientID = "TheClient",
                   trackNum = "9999911111",
                   hasSent = false 
               });
               _context.SaveChanges();
            }
        }

        [HttpGet("ship/")]
        public IEnumerable<ShipConfirm> GetAll()
        {
            return _context.ShipConfirms.ToList();
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

            sc.HasSent = item.HasSent;
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
