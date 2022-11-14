using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brotender;
using Brotender.Context;

namespace Brotender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkRatingsController : ControllerBase
    {
        private readonly BrotenderContext _context;

        public DrinkRatingsController(BrotenderContext context)
        {
            _context = context;
        }

        // GET: api/DrinkRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkRating>>> GetDrinkRatings()
        {
            return await _context.DrinkRatings.ToListAsync();
        }

        // GET: api/DrinkRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrinkRating>> GetDrinkRating(int id)
        {
            var drinkRating = await _context.DrinkRatings.FindAsync(id);

            if (drinkRating == null)
            {
                return NotFound();
            }

            return drinkRating;
        }

        // PUT: api/DrinkRatings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinkRating(int id, DrinkRating drinkRating)
        {
            if (id != drinkRating.Id)
            {
                return BadRequest();
            }

            _context.Entry(drinkRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkRatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DrinkRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrinkRating>> PostDrinkRating(DrinkRating drinkRating)
        {
            _context.DrinkRatings.Add(drinkRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinkRating", new { id = drinkRating.Id }, drinkRating);
        }

        // DELETE: api/DrinkRatings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinkRating(int id)
        {
            var drinkRating = await _context.DrinkRatings.FindAsync(id);
            if (drinkRating == null)
            {
                return NotFound();
            }

            _context.DrinkRatings.Remove(drinkRating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkRatingExists(int id)
        {
            return _context.DrinkRatings.Any(e => e.Id == id);
        }
    }
}
