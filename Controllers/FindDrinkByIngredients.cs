using Brotender.Context;
using Brotender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brotender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindDrinkByIngredients : ControllerBase
    {
        private readonly BrotenderContext _context;
        
        public FindDrinkByIngredients(BrotenderContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Drink>>> GetDrinksByIngredients(List<int> ingredientIds)
        {

            // Retrieve the Drink objects that contain all of the specified ingredients
            var drinks = await (from d in _context.Drinks
                    join di in _context.DrinkIngredients on d.Id equals di.DrinkId
                    where ingredientIds.Contains(di.IngredientId)
                    group d by d.Id
                    into g
                    where g.Count() == ingredientIds.Count()
                    select g.First())
                .ToListAsync();

            foreach (var drink in drinks)
            {
                drink.DrinkIngredients = await _context.DrinkIngredients.Where(x => x.DrinkId == drink.Id).ToListAsync();
                foreach (var drinkIngredient in drink.DrinkIngredients)
                {
                    drinkIngredient.Ingredient = await _context.Ingredients.FindAsync(drinkIngredient.IngredientId);
                }
                drink.DrinkTools = await _context.DrinkTools.Where(x => x.DrinkId == drink.Id).ToListAsync();
                drink.DrinkRatings = await _context.DrinkRatings.Where(x => x.DrinkId == drink.Id).ToListAsync();
            }
            return drinks;

        }
    }
}