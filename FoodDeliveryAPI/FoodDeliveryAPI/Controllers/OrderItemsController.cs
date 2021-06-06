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
    public class OrderItemsController : ControllerBase
    {
        private readonly FoodDeliveryDbContext _context;

        public OrderItemsController(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int orderId)
        {
            var orderItems = await _context.OrderItems.Where(orderItem => orderItem.OrderId == orderId).ToListAsync(); 
            foreach(var orderItem in orderItems)
            {
                orderItem.Item = await _context.Items.FindAsync(orderItem.ItemId);
            }

            if (orderItems == null)
            {
                return NotFound();
            }

            return orderItems;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems(int id, OrderItem orderItems)
        {
            if (id != orderItems.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemsExists(id))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItems(OrderItem orderItems)
        {
            _context.OrderItems.Add(orderItems);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderItemsExists(orderItems.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderItems", new { id = orderItems.ItemId }, orderItems);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> PostOrderItems(List<OrderItem> orderItems)
        {
            _context.OrderItems.AddRange(orderItems);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            { 
                    throw;                
            }

            return orderItems;
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> DeleteOrderItems(int id)
        {
            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return orderItems;
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.ItemId == id);
        }
    }
}
