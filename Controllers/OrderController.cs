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
            }
        }
    }
}
