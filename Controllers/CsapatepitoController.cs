using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tftwebapinew.Database;
using tftwebapinew.DTO;
using tftwebapinew.Models;

namespace tftwebapinew.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KarakterClass : ControllerBase
    {
        private readonly tftdatabaseContext _context;

        public KarakterClass(tftdatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CsapatepitoBoard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CsapatepitoKarakterDTO>>> GetCharacters()
        {
            var characters = await _context.Character
                .Include(c => c.Classes)
                .Select(c => new CsapatepitoKarakterDTO
                {
                    CharacterID = c.CharacterID,
                    CharacterName = c.CharacterName,
                    AbilityName = c.AbilityName,
                    Ability = c.Ability,
                    Cost = c.Cost,
                    Health = c.Health,
                    Health1 = c.Health1,
                    Health2 = c.Health2,
                    AttackSpeed = c.AttackSpeed,
                    Damage = c.Damage,
                    Damage1 = c.Damage1,
                    Damage2 = c.Damage2,
                    AbilityPower = c.AbilityPower,
                    ManaStart = c.ManaStart,
                    ManaMax = c.ManaMax,
                    Armor = c.Armor,
                    MagicResist = c.MagicResist,
                    Range = c.Range,
                    Characterimageblob = c.Characterimageblob,
                    Karakterek = c.Classes.Select(o => new CsapatepitoOsztalyDTO
                    {
                        ClassID = o.ClassId,
                        ClassName = o.ClassName,
                        BasicEffect = o.BasicEffect,
                        Classimageblob = o.Classimageblob
                    }).ToList()
                }).ToListAsync();

            return Ok(characters);
        }


    }
}
