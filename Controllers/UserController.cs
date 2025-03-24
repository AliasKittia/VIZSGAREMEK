using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapi.Models;
using tftwebapi.DTO;
using tftwebapi.Data;
using System.Threading.Tasks;

namespace tftwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool HasPermission(string token) =>
            Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level == 9;

        [HttpGet("{token}")]
        public async Task<IActionResult> Get(string token)
        {
            if (!HasPermission(token))
                return BadRequest("Nincs jogosultsága!");

            try
            {
                var users = await _context.User.Include(f => f.Permission).ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{token}/{id}")]
        public async Task<IActionResult> GetId(string token, int id)
        {
            if (!HasPermission(token))
                return BadRequest("Nincs jogosultsága!");

            try
            {
                var user = await _context.User.Include(f => f.Permission).FirstOrDefaultAsync(f => f.Id == id);
                if (user == null)
                    return NotFound("Felhasználó nem található.");
                
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> Post(string token, PostUser user)
        {
            if (!HasPermission(token))
                return BadRequest("Nincs jogosultsága!");

            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return Ok("Új felhasználó adatai eltárolva.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{token}")]
        public async Task<IActionResult> Put(string token, PostUser user)
        {
            if (!HasPermission(token))
                return BadRequest("Nincs jogosultsága!");

            try
            {
                var existingUser = await _context.User.FindAsync(user.Id);
                if (existingUser == null)
                    return NotFound("Felhasználó nem található.");

                _context.Entry(existingUser).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();

                return Ok("A felhasználó adatai módosítva lettek.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{token}/{id}")]
        public async Task<IActionResult> Delete(string token, int id)
        {
            if (!HasPermission(token))
                return BadRequest("Nincs jogosultsága!");

            try
            {
                var user = await _context.User.FindAsync(id);
                if (user == null)
                    return NotFound("Felhasználó nem található.");

                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return Ok("A felhasználó adatai törölve lettek.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
