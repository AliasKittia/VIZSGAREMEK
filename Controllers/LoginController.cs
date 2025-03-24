using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi;
using System.Collections.Concurrent;
using tftwebapi.Data;
using tftwebapi.DTO;
using tftwebapi.Models;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("SaltRequest/{loginName}")]
        public async Task<IActionResult> SaltRequest(string loginName)
        {
            try
            {
                var response = await _context.User.FirstOrDefaultAsync(f => f.LoginName == loginName);
                if (response == null)
                {
                    return BadRequest("User not found");
                }
                return Ok(response.Salt);
            }
            catch (Exception)
            {
                return StatusCode(500, "Hiba történt a kérés feldolgozása során.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDTO?.TmpHash) || string.IsNullOrEmpty(loginDTO?.LoginName))
                {
                    return BadRequest("Hibás bejelentkezési adatok!");
                }

                string hash = Program.CreateSHA256(loginDTO.TmpHash);
                var loggedUser = await _context.User.Include(f => f.Permission)
                                                     .FirstOrDefaultAsync(f => f.LoginName == loginDTO.LoginName && f.Hash == hash);

                if (loggedUser != null && loggedUser.Active)
                {
                    string token = Guid.NewGuid().ToString();
                    lock (Program.LoggedInUsers)
                    {
                        if (!Program.LoggedInUsers.ContainsKey(token))
                        {
                            Program.LoggedInUsers.Add(token, loggedUser);
                        }
                    }
                    return Ok(new LoggedUser
                    {
                        Name = loggedUser.Name,
                        Email = loggedUser.Email,
                        Permission = loggedUser.Permission.Level,
                        ProfilePicturePath = loggedUser.ProfilePicturePath,
                        Token = token
                    });
                }
                else
                {
                    return BadRequest("Hibás felhasználónév vagy jelszó, vagy a felhasználó inaktív!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Hiba történt a bejelentkezés során.");
            }
        }
    }
}
