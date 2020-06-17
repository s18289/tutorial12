using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial12.DTO_s.Request;
using tutorial12.DTO_s.Response;
using tutorial12.Exeptions;
using tutorial12.Models;

namespace tutorial12.Services
{
    public class SqlServerOrderDbService : IOrderDbService
    {
        public readonly Context context;
        public List<GetOrderResponse> ordersResponse;
        public SqlServerOrderDbService(Context _context)
        {
            context = _context;
        }

        public List<GetOrderResponse> GetOrdersByName(GetOrderRequest request)
        {
            int idClient = context.Customer.Where(c => c.Name == request.Name).Select(c => c.IdClient).FirstOrDefault();

            if(idClient > 0)
            {
                ordersResponse = context.Confectionery_Order
                .Join(context.Confectionery, co => co.IdConfectionery, c => c.IdConfectionery, (co, c)
                 => new { Confectionery_Order = co, Confectionery = c })
                .Join(context.Order, co => co.Confectionery_Order.IdOrder, o => o.IdOrder, (co, o)
                 => new { Confectionery_Order = co, Order = o })
                .Where(x => x.Order.IdClient == idClient && x.Order.IdOrder == x.Confectionery_Order.Confectionery_Order.IdOrder)
                .Select(x => new GetOrderResponse()
                {
                    IdOrder = x.Order.IdOrder,
                    DateAccepted = x.Order.DateAccepted,
                    DateFinished = x.Order.DateFinished,
                    Notes = x.Order.Notes,
                    ConfectioneryName = x.Confectionery_Order.Confectionery.Name,
                    ConfectioneryPricePerItem = x.Confectionery_Order.Confectionery.PricePerItem,
                    ConfectioneryType = x.Confectionery_Order.Confectionery.Type,
                    ConfectioneryOrderQuantity = x.Confectionery_Order.Confectionery_Order.Quantity,
                    ConfectioneryOrderNotes = x.Confectionery_Order.Confectionery_Order.Notes
                }).ToList();
            }
            else
            {
                throw new ClientDoesNotExistsExeption("Client with such name doesn't exists!");
            }

            if(request.Name == null)
            {
                ordersResponse = context.Confectionery_Order
                .Join(context.Confectionery, co => co.IdConfectionery, c => c.IdConfectionery, (co, c)
                 => new { Confectionery_Order = co, Confectionery = c })
                .Join(context.Order, co => co.Confectionery_Order.IdOrder, o => o.IdOrder, (co, o)
                 => new { Confectionery_Order = co, Order = o })
                .Select(x => new GetOrderResponse()
                {
                    IdOrder = x.Order.IdOrder,
                    DateAccepted = x.Order.DateAccepted,
                    DateFinished = x.Order.DateFinished,
                    Notes = x.Order.Notes,
                    ConfectioneryName = x.Confectionery_Order.Confectionery.Name,
                    ConfectioneryPricePerItem = x.Confectionery_Order.Confectionery.PricePerItem,
                    ConfectioneryType = x.Confectionery_Order.Confectionery.Type,
                    ConfectioneryOrderQuantity = x.Confectionery_Order.Confectionery_Order.Quantity,
                    ConfectioneryOrderNotes = x.Confectionery_Order.Confectionery_Order.Notes
                }).ToList();
            }
            return ordersResponse;
        }

        public AddOrderResponse AddOrder(int IdClient, AddOrderRequest request)
        {
            AddOrderResponse response = new AddOrderResponse()
            {
                ConfenctioneryIdList = new List<int>()
            };



            int UserIdCounter = context.Customer.Where(c => c.IdClient == IdClient).Count();
            if (UserIdCounter != 1)
            {
                throw new NoSuchCustomerException("Customer with such id was not found!");
            }
            foreach (AddConfectioneryRequest item in request.Confectionery)
            {
                if (context.Confectionery.Select(co => co.Name).Where(n => n == item.Name).Count() != 1)
                { 
                    throw new NoSuchConfectioneryException("Confectionary with such name was not found!");
                }
            }

            using (var trans = context.Database.BeginTransaction())
            {
                Order order = new Order()
                {
                    DateAccepted = request.DateAccepted,
                    Notes = request.Notes,
                    IdClient = IdClient,
                    IdEmployee = request.IdEmployee
                };

                context.Add<Order>(order);
                context.SaveChanges();
                response.IdOrder = order.IdOrder;

                foreach (AddConfectioneryRequest item in request.Confectionery)
                {
                    int id = context.Confectionery.Where(co => co.Name == item.Name).Select(co => co.IdConfectionery).FirstOrDefault();
                    response.ConfenctioneryIdList.Add(id);
                    context.Add<Confectionery_Order>(new Confectionery_Order()
                    {
                        IdConfectionery = id,
                        IdOrder = order.IdOrder,
                        Quantity = item.Quantity,
                        Notes = item.Notes
                    });
                }
                context.SaveChanges();
                trans.Commit();
            }
            return response;
        }
    }
}