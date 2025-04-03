using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Database;
using tftwebapinew.DTO;
using tftwebapinew.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tftwebapinew;

namespace ProjectName_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly tftdatabaseContext _context;
        private static readonly object _lockObject = new object();

        // Constructor to inject the DbContext
        public LoginController(tftdatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("SaltRequest/{loginName}")]
        public async Task<IActionResult> SaltRequest([FromRoute] string loginName)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.LoginName == loginName);
                if (user == null)
                {
                    return NotFound("Felhasználó nem található");
                }
                return Ok(user.Salt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Szerverhiba: " + ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                string hash = Program.CreateSHA256(loginDTO.TmpHash);
                var user = await _context.User.Include(u => u.Permission)
                                              .FirstOrDefaultAsync(u => u.LoginName == loginDTO.LoginName && u.Hash == hash);
                if (user == null || !user.Active)
                {
                    return Unauthorized("Hibás név vagy jelszó / inaktív felhasználó!");
                }

                string token = Guid.NewGuid().ToString();
                lock (_lockObject)
                {
                    Program.LoggedInUsers[token] = user;
                }

                return Ok(new LoggedUser
                {
                    Name = user.Name,
                    Email = user.Email,
                    Permission = user.Permission.Level,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Szerverhiba: " + ex.Message);
            }
        }
    }
}
