using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FormCalc.Models
{
    public class Order
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int Cost { get; set; }
    }
}
