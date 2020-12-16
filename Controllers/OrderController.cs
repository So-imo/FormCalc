using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FormCalc.Models;
using System.Threading.Tasks;

namespace FormCalc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderContext db;
        public OrderController(OrderContext context)
        {
            db = context;
            if (!db.Orders.Any())
            {
                db.Orders.Add(new Order { ClientId = 0, ClientName = "Best Company", Cost = 1000.0});
                db.Orders.Add(new Order { ClientId = 1, ClientName = "Worst Company", Cost = 100.0 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await db.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await db.Orders.FirstOrDefaultAsync(x => x.ClientId == id);
            if (order == null)
                return NotFound();
            return new ObjectResult(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<Order>> Put(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            if (!db.Orders.Any(x => x.ClientId == order.ClientId))
            {
                return NotFound();
            }

            db.Update(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int clientId)
        {
            Order order= db.Orders.FirstOrDefault(x => x.ClientId == clientId);
            if (order == null)
            {
                return NotFound();
            }
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return Ok(order);
        }
    }
}
