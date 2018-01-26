using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using DataApi.Models;

namespace DataApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public partial class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public AdminController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

            //if (_context.ShipConfirms.Count() == 0)
            //{
            //    _context.ShipConfirms.Add(new ShipConfirm {
            //        OrderID = "Order1",
            //        ClientID = "TheClient",
            //        TrackNum = "9999911111",
            //        HasSent = false 
            //    });
            //    _context.SaveChanges();
            //}
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
                    issuer: "logistics",
                    audience: "client1",
                    claims: claims,
                    //expires: DateTime.Now.AddMinutes(30),
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
