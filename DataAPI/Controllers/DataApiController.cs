using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using DataApi.Models;
using System.Text;
using System;

namespace DataApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DataApiController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public DataApiController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

            if (_context.ShipConfirms.Count() == 0)
            {
                _context.ShipConfirms.Add(new ShipConfirm {
                    OrderID = "Order1",
                    ClientID = "TheClient",
                    TrackNum = "9999911111",
                    HasSent = false 
                });
                _context.SaveChanges();
            }
        }

        [HttpGet("ship/")]
        public IEnumerable<ShipConfirm> GetAll()
        {
            return _context.ShipConfirms.ToList();
        }

        [HttpGet("ship/order/{OrderID}", Name = "GetShipConfirm")]
        public IActionResult GetById(string OrderID)
        {
            var item = _context.ShipConfirms.FirstOrDefault(t => t.OrderID == OrderID);

            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPut("order/{OrderID}")]
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

        [HttpDelete("order/{OrderID}")]
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
        [AllowAnonymous]
        [HttpPost("token/")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (request.Username == "logistics" && request.Password == "testpassword")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }

        public class TokenRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
