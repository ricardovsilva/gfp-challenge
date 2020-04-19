using Microsoft.AspNetCore.Mvc;

using domain.entities;
using domain.interfaces;
using api.filters;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public ICollection<Order> All()
        {
            return this.OrderService.All()
                .Include(_ => _.OrderDishes)
                .ThenInclude(_ => _.Dish)
                .ToList();
        }

        [HttpPost]
        [UnitOfWork]
        public IActionResult New([FromBody]inputs.CreateOrder order)
        {
            this.OrderService.Create(order.timeOfDay, order.dishesTypes);
            return Ok();
        }
    }
}