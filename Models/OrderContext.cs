using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FormCalc.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
