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

        // GET: api/Orders
        [HttpGet("waiting")]
        public async Task<ActionResult<IEnumerable<Order>>> GetWaitingOrders()
        {
            var orders= await _context.Orders.Where(order=>order.CourierId==null).ToListAsync();
            foreach (var order in orders)
            {
                order.Restaurant = await _context.Restaurants.FindAsync(order.RestaurantId);
                order.OrderItems = await _context.OrderItems.Where(orderItem => orderItem.OrderId == order.OrderId).ToListAsync();
                foreach (var orderItem in order.OrderItems)
                {
                    orderItem.Item = await _context.Items.FindAsync(orderItem.ItemId);
                }
            }
            return orders;
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
            if (id != orders.OrderId)
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


            return CreatedAtAction("GetOrders", new { id = orders.OrderId }, orders);
        }

        //[HttpPost("fullOrder")]
        //public async Task<ActionResult<Order>> PostOrders(Order order, Item[] items)
        //{
        //    Order orderToReturn = _context.Orders.Add(order).Entity;
        //    await _context.SaveChangesAsync();

        //    List<OrderItem> orderItems = new List<OrderItem>();
        //    foreach (var item in items)
        //    {
        //        OrderItem orderItem = new OrderItem();
        //        orderItem.ItemId = item.ItemId;
        //        orderItem.OrderId = order.OrderId;
        //        orderItem.Item = item;
        //        //item.orderId = orderToReturn.orderId;
        //        orderItems.Add(orderItem);
        //        //_context.OrderItems.Add(item);
        //    }
        //    order.OrderItems = orderItems;
        //    _context.OrderItems.AddRange(orderItems);

        //    await _context.SaveChangesAsync();

        //    return order;
        //}


        //[HttpPost("fullOrder")]
        //public async Task<ActionResult<Order>> PostOrders(Order order, Item[] items)
        //{
        //    _context.Orders.Add(order);
        //    var orderItems = new OrderItem[items.Length];


        //    //for (int i = 0; i < items.Length; i++)
        //    //{
        //    //    orderItems[i].itemId = items[i].itemId;
        //    //    orderItems[i].orderId = order.orderId;
        //    //}


        //    _context.OrderItems.AddRange(orderItems);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrders", new { id = order.OrderId }, order);
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
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
