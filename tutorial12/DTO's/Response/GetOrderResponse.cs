using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.DTO_s.Response
{
    public class GetOrderResponse
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public string ConfectioneryName { get; set; }
        public double ConfectioneryPricePerItem { get; set; }
        public string ConfectioneryType { get; set; }
        public int ConfectioneryOrderQuantity { get; set; }
        public string ConfectioneryOrderNotes { get; set; }
    }
}