using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IEntityRepository<Menu> menuRepository;

        public MenuController(IEntityRepository<Menu> menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        [HttpGet]
        public IEnumerable<Menu> All()
        {
            return this.menuRepository.All();
        }

        [HttpPost]
        public async Task<string> Save()
        {
            return "Saved";
        }
    }
}