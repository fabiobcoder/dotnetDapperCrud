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
        _repository = repository;
    }

    [HttpGet]
        public async Task<IActionResult> Get(){

            var filmes = await _repository.BuscarFilesAsync();
            return filmes.Any() ? Ok(filmes) : NoContent();
        }
    }
