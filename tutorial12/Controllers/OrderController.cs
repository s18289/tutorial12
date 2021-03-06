﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tutorial12.DTO_s.Request;
using tutorial12.DTO_s.Response;
using tutorial12.Services;

namespace tutorial12.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderDbService dbService;

        public OrderController(IOrderDbService orderDbService)
        {
            dbService = orderDbService;
        }

        [HttpGet]
        public IActionResult GetOrdersByName(GetOrderRequest request)
        {
            return Ok(dbService.GetOrdersByName(request));
        }

        [HttpPost("/api/clients/{IdClient}/orders")]
        public IActionResult AddOrder(int IdClient, AddOrderRequest request)
        {
            return Ok(dbService.AddOrder(IdClient, request));
        }
    }
}