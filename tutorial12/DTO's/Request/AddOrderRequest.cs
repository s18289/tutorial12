using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.DTO_s.Request
{
    public class AddOrderRequest
    {
        public DateTime DateAccepted { get; set; }
        public string Notes { get; set; }
        public int IdEmployee { get; set; }
        public ICollection<AddConfectioneryRequest> Confectionery { get; set; }
    }
}