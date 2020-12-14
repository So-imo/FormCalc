using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCalc.Models
{
    public class Order
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public double Cost { get; set; }
    }
}
