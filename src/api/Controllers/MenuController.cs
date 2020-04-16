using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        public async Task<string> All()
        {
            return "Hello Stranger";
        }

        [HttpPost]
        public async Task<string> Save()
        {
            return "Saved";
        }
    }
}