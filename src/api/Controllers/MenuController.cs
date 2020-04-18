using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using domain.entities;
using domain.interfaces;
using utils.extensions;
using System;

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
        public IEnumerable<Menu> GetAllMenus()
        {
            return this.menuService.GetDefaultMenu().asArray();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Menu> GetMenuById(int id)
        {
            try
            {
                return this.menuService.FindById(id);
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
        }
    }
}