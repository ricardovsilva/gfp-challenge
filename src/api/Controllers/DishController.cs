using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using domain.interfaces;
using domain.entities;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService DishService;

        public DishController(IDishService DishService)
        {
            this.DishService = DishService;
        }

        [HttpGet]
        public IEnumerable<Dish> All()
        {
            return this.DishService.All();
        }
    }
}