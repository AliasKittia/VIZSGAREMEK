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
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(LoggedUser), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                // Retrieve the user by login name
                var user = await _context.User.Include(u => u.Permission)
                                              .FirstOrDefaultAsync(u => u.LoginName == loginDTO.LoginName);
                if (user == null || !user.Active)
                {
                    return Unauthorized("Hibás név vagy jelszó / inaktív felhasználó!");
                }

                // Compute hash using the provided plain-text password and the user's stored salt
                string computedHash = Program.CreateSHA256(loginDTO.Password + user.Salt);
                if (computedHash != user.Hash)
                {
                    return Unauthorized("Hibás név vagy jelszó!");
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

        // NEW ENDPOINT: Generate a hash from password and salt
        [HttpPost("GenerateHash")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult GenerateHash([FromBody] PasswordSaltDTO dto)
        {
            var combined = dto.Password + dto.Salt;
            var hash = Program.CreateSHA256(combined);
            return Ok(hash);
        }
    }

    // DTO for password and salt input
    public class PasswordSaltDTO
    {
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
