using dotnetDapper.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnetDapper.Controllers;
[ApiController]
[Route("api/[controller]")]

    public class FilmesController : ControllerBase
    {
    private readonly IFilmeRepository _repository;

    public FilmesController(IFilmeRepository repository)
    {
        _.repository = repository;
    }

    [HttpGet]
        public async Task<IActionResult> Get(){

            var filmes = await _repository.BuscarFilesAsync();
            return filmes.Any() ? Ok("Funcionando") : NoContent();
        }
    }
