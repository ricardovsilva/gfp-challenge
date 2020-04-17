using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using domain.interfaces;
using domain.entities;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> All()
        {
            return this.OrderService.All();
        }

        [HttpPost]
        public IActionResult New([FromBody]inputs.CreateOrder order)
        {
            this.OrderService.Create(order.timeOfDay, order.dishesTypes);

            return Ok();
        }
    }
}