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
    public class DrinkToolsController : ControllerBase
    {
        private readonly BrotenderContext _context;

        public DrinkToolsController(BrotenderContext context)
        {
            _context = context;
        }

        // GET: api/DrinkTools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkTool>>> GetDrinkTools()
        {
            return await _context.DrinkTools.ToListAsync();
        }

        // GET: api/DrinkTools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrinkTool>> GetDrinkTool(int id)
        {
            var drinkTool = await _context.DrinkTools.FindAsync(id);

            if (drinkTool == null)
            {
                return NotFound();
            }

            return drinkTool;
        }

        // PUT: api/DrinkTools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinkTool(int id, DrinkTool drinkTool)
        {
            if (id != drinkTool.Id)
            {
                return BadRequest();
            }

            _context.Entry(drinkTool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkToolExists(id))
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

        // POST: api/DrinkTools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrinkTool>> PostDrinkTool(DrinkTool drinkTool)
        {
            _context.DrinkTools.Add(drinkTool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinkTool", new { id = drinkTool.Id }, drinkTool);
        }

        // DELETE: api/DrinkTools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinkTool(int id)
        {
            var drinkTool = await _context.DrinkTools.FindAsync(id);
            if (drinkTool == null)
            {
                return NotFound();
            }

            _context.DrinkTools.Remove(drinkTool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkToolExists(int id)
        {
            return _context.DrinkTools.Any(e => e.Id == id);
        }
    }
}
