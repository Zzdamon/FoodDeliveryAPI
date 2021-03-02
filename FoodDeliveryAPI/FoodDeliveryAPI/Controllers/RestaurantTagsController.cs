using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryAPI.Models;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTagsController : ControllerBase
    {
        private readonly FoodDeliveryDbContext _context;

        public RestaurantTagsController(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantTag>>> GetRestaurantTag()
        {
            return await _context.RestaurantTag.ToListAsync();
        }

        // GET: api/RestaurantTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantTag>> GetRestaurantTag(int id)
        {
            var restaurantTag = await _context.RestaurantTag.FindAsync(id);

            if (restaurantTag == null)
            {
                return NotFound();
            }

            return restaurantTag;
        }

        // PUT: api/RestaurantTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantTag(int id, RestaurantTag restaurantTag)
        {
            if (id != restaurantTag.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(restaurantTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantTagExists(id))
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

        // POST: api/RestaurantTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RestaurantTag>> PostRestaurantTag(RestaurantTag restaurantTag)
        {
            _context.RestaurantTag.Add(restaurantTag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantTagExists(restaurantTag.RestaurantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRestaurantTag", new { id = restaurantTag.RestaurantId }, restaurantTag);
        }

        // DELETE: api/RestaurantTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RestaurantTag>> DeleteRestaurantTag(int id)
        {
            var restaurantTag = await _context.RestaurantTag.FindAsync(id);
            if (restaurantTag == null)
            {
                return NotFound();
            }

            _context.RestaurantTag.Remove(restaurantTag);
            await _context.SaveChangesAsync();

            return restaurantTag;
        }

        private bool RestaurantTagExists(int id)
        {
            return _context.RestaurantTag.Any(e => e.RestaurantId == id);
        }
    }
}
