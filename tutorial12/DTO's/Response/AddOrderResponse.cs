using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.DTO_s.Response
{
    public class AddOrderResponse
    {
        public int IdOrder { get; set; }
        public List<int> ConfenctioneryIdList { get; set; }
    }
}