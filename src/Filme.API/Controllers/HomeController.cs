using Microsoft.AspNetCore.Mvc;

namespace FilmesCrud.src.Filme.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Home()
        {
            return Ok("Funcionando");
        }
    }
}