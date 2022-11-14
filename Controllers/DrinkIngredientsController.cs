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
    public class DrinkIngredientsController : ControllerBase
    {
        private readonly BrotenderContext _context;

        public DrinkIngredientsController(BrotenderContext context)
        {
            _context = context;
        }

        // GET: api/DrinkIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkIngredient>>> GetDrinkIngredients()
        {
            return await _context.DrinkIngredients.ToListAsync();
        }

        // GET: api/DrinkIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrinkIngredient>> GetDrinkIngredient(int id)
        {
            var drinkIngredient = await _context.DrinkIngredients.FindAsync(id);

            if (drinkIngredient == null)
            {
                return NotFound();
            }

            return drinkIngredient;
        }

        // PUT: api/DrinkIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinkIngredient(int id, DrinkIngredient drinkIngredient)
        {
            if (id != drinkIngredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(drinkIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkIngredientExists(id))
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

        // POST: api/DrinkIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrinkIngredient>> PostDrinkIngredient(DrinkIngredient drinkIngredient)
        {
            _context.DrinkIngredients.Add(drinkIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinkIngredient", new { id = drinkIngredient.Id }, drinkIngredient);
        }

        // DELETE: api/DrinkIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinkIngredient(int id)
        {
            var drinkIngredient = await _context.DrinkIngredients.FindAsync(id);
            if (drinkIngredient == null)
            {
                return NotFound();
            }

            _context.DrinkIngredients.Remove(drinkIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkIngredientExists(int id)
        {
            return _context.DrinkIngredients.Any(e => e.Id == id);
        }
    }
}
