using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.DTO_s.Request
{
    public class AddConfectioneryRequest
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }   
    }
}