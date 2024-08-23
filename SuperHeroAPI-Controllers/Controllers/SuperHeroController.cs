using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_Controllers.Entities;

namespace SuperHeroAPI_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Superman",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "Metropolis",
                }
            };
            return Ok(heroes);
        }
    }
}
