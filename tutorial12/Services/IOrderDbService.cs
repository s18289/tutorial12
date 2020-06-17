using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial12.DTO_s.Request;
using tutorial12.DTO_s.Response;

namespace tutorial12.Services
{
   public interface IOrderDbService
    {
        public List<GetOrderResponse> GetOrdersByName(GetOrderRequest request);
        public AddOrderResponse AddOrder(int IdClient, AddOrderRequest request);
    }
}