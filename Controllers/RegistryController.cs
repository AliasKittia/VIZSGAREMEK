﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName_Backend.Models;

namespace ProjectName_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistryController : ControllerBase
    {
        [HttpPost]

        public async Task<IActionResult> Registry(User user)
        {
            using (var cx = new TftdatabaseContext())
            {
                try
                {
                    if (cx.Users.FirstOrDefault(f => f.LoginName == user.LoginName) != null)
                    {
                        return Ok("Már létezik ilyen felhasználónév!");
                    }
                    if (cx.Users.FirstOrDefault(f => f.Email == user.Email) != null)
                    {
                        return Ok("Ezzel az e-mail címmel már regisztráltak!");
                    }
                    user.PermissionId = 1;
                    user.Active = false;
                    user.Hash = Program.CreateSHA256(user.Hash);
                    await cx.Users.AddAsync(user);
                    await cx.SaveChangesAsync();

                    Program.SendEmail(user.Email, "Regisztráció", $"https://localhost:7225/api/Registry?felhasznaloNev={user.LoginName}&email={user.Email}");

                    return Ok("Sikeres regisztráció. Fejezze be a regisztrációját az e-mail címére küldött link segítségével!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]

        public async Task<IActionResult> EndOfTheRegistry(string felhasznaloNev, string email)
        {
            using (var cx = new TftdatabaseContext())
            {
                try
                {
                    User user = await cx.Users.FirstOrDefaultAsync(f => f.LoginName == felhasznaloNev && f.Email == email);
                    if (user == null)
                    {
                        return Ok("Sikertelen a regisztráció befejezése!");
                    }
                    else
                    {
                        user.Active = true;
                        cx.Users.Update(user);
                        await cx.SaveChangesAsync();
                        return Ok("A regisztráció befejezése sikeresen megtörtént.");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}
