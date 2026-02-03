using BlazingPizza.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza
{
    [ApiController]
    [Route("specials")]
    public class SpecialsController : ControllerBase
    {
        private readonly PizzaStoreContext _db;

        public SpecialsController(PizzaStoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            // Load from SQLite WITHOUT ordering (SQLite limitation with decimal)
            var specials = await _db.Specials
                                    .AsNoTracking()
                                    .ToListAsync();

            // Order in memory (safe)
            specials = specials
                        .OrderByDescending(s => s.Price)
                        .ToList();

            return Ok(specials);
        }
    }
}