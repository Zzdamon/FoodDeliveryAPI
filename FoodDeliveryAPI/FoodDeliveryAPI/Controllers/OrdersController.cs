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
    public class OrdersController : ControllerBase
    {
        private readonly FoodDeliveryDbContext _context;

        public OrdersController(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Order orders)
        {
            if (id != orders.orderId)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders(Order orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.orderId }, orders);
        }

        //[HttpPost("fullOrder")]
        //public async Task<ActionResult<Order>> PostOrders(Order order, List<OrderItem> items)
        //{
        //    Order orderToReturn = _context.Orders.Add(order).Entity;
        //    await _context.SaveChangesAsync();


        //    foreach (var item in items)
        //    {
        //        item.orderId = orderToReturn.orderId;
        //        //_context.OrderItems.Add(item);
        //    }

        //    _context.OrderItems.AddRange(items);

        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrders", new { id = order.orderId }, order);
        //}


        //[HttpPost("fullOrder")]
        //public async Task<ActionResult<Order>> PostOrders(Order order, Item[] items)
        //{
        //    _context.Orders.Add(order);
        //    var orderItems = new OrderItem[items.Length];


        //    for(int i=0;i<items.Length;i++)
        //    {
        //        orderItems[i].itemId = items[i].itemId;
        //        orderItems[i].orderId = order.orderId;
        //    }


        //    _context.OrderItems.AddRange(orderItems);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrders", new { id = order.orderId }, order);
        //}

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return orders;
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.orderId == id);
        }
    }
}
