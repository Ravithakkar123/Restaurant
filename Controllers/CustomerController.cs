using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly RestaurantDataContext _context;

        public CustomerController(RestaurantDataContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
     
        public IActionResult GetCustomer([FromQuery]Parameter parameter, string query)
        {
            try
            {
                
                var customers = from c in _context.Customer
                               select c;
                var customer = _context.Customer.Include(s => s.CustomerName).ToList();
                return Ok(customer);
            }
            catch
            {
                return BadRequest();
            }

        }
        public IActionResult GetCustomer()
        {
            try
            {
                List<Customer> customer = _context.Customer.ToList();
            
                return Ok(customer);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            try
            {
                var customername = _context.Customer.Include(s => s.CustomerName).FirstOrDefault(i => i.CustomerId == id); ;
                return Ok(customername);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
         [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
