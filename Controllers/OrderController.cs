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
    public class OrderController : ControllerBase
    {
        private readonly RestaurantDataContext _context;

        public OrderController(RestaurantDataContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var order = _context.Order.ToList();
                return Ok(order);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var order = _context.Order.Find(id);
                return Ok(order);
            }
            catch
            {
                return BadRequest();
            }
        }

   /*     public IActionResult GetOrderData()
        {
            

        }*/

        // PUT: api/Order/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
    /*    public IActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return Ok(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        */

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }
        // POST: Add item to existing order
        public IActionResult EditOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            else
            {
                try
                {

                    _context.Order.Update(order);
                    _context.SaveChanges();
                    return CreatedAtAction("GetOrder", new { id = order.OrderId}, order);
                    return Ok(order);
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _context.Order.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Order.Remove(result);

            try
            {
                _context.SaveChanges();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }

    }
}
