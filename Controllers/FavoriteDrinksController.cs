using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brotender.Context;
using Brotender.Models;

namespace Brotender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteDrinksController : ControllerBase
    {
        private readonly BrotenderContext _context;

        public FavoriteDrinksController(BrotenderContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteDrinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteDrink>>> GetFavoriteDrink()
        {
            return await _context.FavoriteDrink.ToListAsync();
        }

        // GET: api/FavoriteDrinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDrink>> GetFavoriteDrink(int id)
        {
            var favoriteDrink = await _context.FavoriteDrink.FindAsync(id);

            if (favoriteDrink == null)
            {
                return NotFound();
            }

            return favoriteDrink;
        }

        // PUT: api/FavoriteDrinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteDrink(int id, FavoriteDrink favoriteDrink)
        {
            if (id != favoriteDrink.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteDrink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteDrinkExists(id))
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

        // POST: api/FavoriteDrinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteDrink>> PostFavoriteDrink(FavoriteDrink favoriteDrink)
        {
            _context.FavoriteDrink.Add(favoriteDrink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteDrink", new { id = favoriteDrink.Id }, favoriteDrink);
        }

        // DELETE: api/FavoriteDrinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteDrink(int id)
        {
            var favoriteDrink = await _context.FavoriteDrink.FindAsync(id);
            if (favoriteDrink == null)
            {
                return NotFound();
            }

            _context.FavoriteDrink.Remove(favoriteDrink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteDrinkExists(int id)
        {
            return _context.FavoriteDrink.Any(e => e.Id == id);
        }
    }
}
