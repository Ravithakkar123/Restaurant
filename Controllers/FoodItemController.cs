using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly RestaurantDataContext _context;

        public FoodItemController(RestaurantDataContext context)
        {
            _context = context;
        }

        // GET: api/FoodItem
        [HttpGet]

        public IActionResult GetFoodItem()
        {
            try
            {
                var fooditem = _context.FoodItem.ToList();
                return Ok(fooditem);
            }
            catch
            {
                return BadRequest();
            }
        }
        // GET: api/FoodItem/5
        [HttpGet("{id}")]

        public IActionResult GetFoodItem(int id)
        {
            try
            {
                var subject = _context.FoodItem.Find(id);
                return Ok(subject);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/FoodItem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(int id, FoodItem foodItem)
        {
            if (id != foodItem.FoodItemId)
            {
                return BadRequest();
            }

            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(id))
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

        // POST: api/FoodItem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItem foodItem)
        {
            try
            {
                _context.FoodItem.Add(foodItem);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetFoodItem", new { id = foodItem.FoodItemId }, foodItem);
            }
            catch
            {
                return BadRequest();
            }
        }


        // DELETE: api/FoodItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodItem>> DeleteFoodItem(int id)
        {
            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItem.Remove(foodItem);
            await _context.SaveChangesAsync();

            return foodItem;
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItem.Any(e => e.FoodItemId == id);
        }
    }
}
