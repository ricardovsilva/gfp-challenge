using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using domain.entities;
using domain.interfaces;
using utils.extensions;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet]
        public IEnumerable<Menu> All()
        {
            return this.menuService.GetDefaultMenu().asArray();
        }

        [HttpGet("/{id}")]
        public Menu Find(int id)
        {
            return this.menuService.FindById(id);
        }
    }
}