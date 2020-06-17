using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.Models
{
    public class Confectionery_Order
    {
        public int IdConfectionery { get; set; }
        public int IdOrder { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public virtual Order IdOrderNav { get; set; }
        public virtual Confectionery IdConfectioneryNav { get; set; }
    }
}