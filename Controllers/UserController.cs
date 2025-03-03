using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models;
using ProjectName_Backend.DTOs;

namespace ProjectName_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("/Korlevel/{token}")]

        public async Task<IActionResult> GetKorlevel(string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level == 9)
            {
                using (var cx = new TftdatabaseContext())
                {
                    try
                    {
                        return Ok(await cx.Users.Include(f=>f.Permission).Select(f=> (new KorlevelDTO { Name=f.Name, Email=f.Email, PermissionName=f.Permission.Name})).ToListAsync());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                        return StatusCode(200, ex.InnerException?.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultsága!");
            }
        }

        [HttpGet("{token}")]

        public async Task<IActionResult> Get(string token)
        { 
            if(Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level==9)
            {
                using(var cx=new TftdatabaseContext())
                {
                    try
                    {
                        return Ok(await cx.Users.Include(f => f.Permission).ToListAsync());
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                        return StatusCode(200, ex.InnerException?.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultsága!");
            }
        }

        [HttpGet("{token},{id}")]

        public async Task<IActionResult> GetId(string token,int id)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level == 9)
            {
                using (var cx = new TftdatabaseContext())
                {
                    try
                    {
                        return Ok(await cx.Users.Include(f => f.Permission).FirstOrDefaultAsync(f=>f.Id == id));
                    }
                    catch (Exception ex)
                    {
                        //return BadRequest(ex.Message);
                        return StatusCode(200, ex.InnerException?.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultsága!");
            }
        }


        [HttpPost("{token}")]

        public async Task<IActionResult> Post(string token,User user)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level == 9)
            {
                using (var cx = new TftdatabaseContext())
                {
                    try
                    {
                        cx.Add(user);
                        await cx.SaveChangesAsync();
                        return Ok("Új felhasználó adatai eltárolva.");
                    }
                    catch (Exception ex)
                    {
                        //return BadRequest(ex.Message);
                        return StatusCode(200, ex.InnerException?.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultsága!");
            }
        }

        [HttpPut("{token}")]

        public async Task<IActionResult> Put(string token, User user)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level == 9)
            {
                using (var cx = new TftdatabaseContext())
                {
                    try
                    {
                        cx.Update(user);
                        await cx.SaveChangesAsync();
                        return Ok("A felhasználó adatai módosítva lettek.");
                    }
                    catch (Exception ex)
                    {
                        //return BadRequest(ex.Message);
                        return StatusCode(200, ex.InnerException?.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultsága!");
            }
        }

        [HttpDelete("{token},{id}")]

        public async Task<IActionResult> Delete(string token, int id)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].Permission.Level == 9)
            {
                using (var cx = new TftdatabaseContext())
                {
                    try
                    {
                        cx.Remove(new User { Id=id});
                        await cx.SaveChangesAsync();
                        return Ok("A felhasználó adatai törölve lettek.");
                    }
                    catch (Exception ex)
                    {
                        //return BadRequest(ex.Message);
                        return StatusCode(200, ex.InnerException?.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Nincs jogosultsága!");
            }
        }
    }
}
