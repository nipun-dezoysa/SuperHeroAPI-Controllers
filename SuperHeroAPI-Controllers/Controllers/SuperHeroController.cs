using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_Controllers.Data;
using SuperHeroAPI_Controllers.Dtos;
using SuperHeroAPI_Controllers.Entities;
using SuperHeroAPI_Controllers.Mapping;

namespace SuperHeroAPI_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(AddDto hero)
        {
            _context.SuperHeroes.Add(hero.ToEntity());
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var exhero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (exhero == null)
            {
                return NotFound("Hero not found.");
            }
            _context.Entry(exhero).CurrentValues.SetValues(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            await _context.SuperHeroes.Where(game=> game.Id == id).ExecuteDeleteAsync();
            return Ok("Hero deleted");
        }
    }
}
