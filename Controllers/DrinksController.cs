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
    public class DrinksController : ControllerBase
    {
        private readonly BrotenderContext _context;

        public DrinksController(BrotenderContext context)
        {
            _context = context;
        }

        // GET: api/Drinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks()
        {
            var drinks = await _context.Drinks.ToListAsync();

            foreach (var drink in drinks)
            {
                drink.DrinkIngredients = await _context.DrinkIngredients.Where(x => x.DrinkId == drink.Id).ToListAsync();
                foreach (var drinkIngredient in drink.DrinkIngredients)
                {
                    drinkIngredient.Ingredient = await _context.Ingredients.FindAsync(drinkIngredient.IngredientId);
                }
                drink.DrinkTools = await _context.DrinkTools.Where(x => x.DrinkId == drink.Id).ToListAsync();
                foreach (var drinkTool in drink.DrinkTools)
                {
                    drinkTool.Tool = await _context.Tools.FindAsync(drinkTool.ToolId);
                }
                drink.DrinkRatings = await _context.DrinkRatings.Where(x => x.DrinkId == drink.Id).ToListAsync();
            }

            return drinks;
        }

        // GET: api/Drinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrink(int id)
        {
            var drink = await _context.Drinks.FindAsync(id);

            drink.DrinkIngredients = await _context.DrinkIngredients.Where(x => x.DrinkId == id).ToListAsync();
            foreach (var drinkIngredient in drink.DrinkIngredients)
            {
                drinkIngredient.Ingredient = await _context.Ingredients.FindAsync(drinkIngredient.IngredientId);
            }
            drink.DrinkTools = await _context.DrinkTools.Where(x => x.DrinkId == id).ToListAsync();
            foreach (var drinkTool in drink.DrinkTools)
            {
                drinkTool.Tool = await _context.Tools.FindAsync(drinkTool.ToolId);
            }
            drink.DrinkRatings = await _context.DrinkRatings.Where(x => x.DrinkId == id).ToListAsync();
            

            if (drink == null)
            {
                return NotFound();
            }

            return drink;
        }

        // PUT: api/Drinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrink(int id, Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest();
            }

            _context.Entry(drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
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

        // POST: api/Drinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drink>> PostDrink(Drink drink)
        {
            _context.Drinks.Add(drink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrink", new { id = drink.Id }, drink);
        }

        // DELETE: api/Drinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            var drink = await _context.Drinks.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }

            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkExists(int id)
        {
            return _context.Drinks.Any(e => e.Id == id);
        }
    }
}
