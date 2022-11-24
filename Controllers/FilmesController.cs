using Microsoft.AspNetCore.Mvc;

namespace dotnetDapper.Controllers;
[ApiController]
[Route("api/[controller]")]

    public class FilmesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok("Funcionando");
        }
    }
