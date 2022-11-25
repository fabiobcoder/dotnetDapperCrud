using dotnetDapper.Repository;
using dotnetDapper.Models;
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
    [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {

            var filme = await _repository.BuscarFileAsync(id);
            
            return filme != null 
                    ? Ok(filme) 
                    : NotFound("Filme Não Encontrado");
        }
    
    [HttpPost]
        public async Task<IActionResult> Post(FilmeRequest request)
        {

         if (string.IsNullOrEmpty(request.Nome) || request.Ano <= 0 || request.ProdutoraId <= 0)   
         {
            return BadRequest("Informações Invalidas");

         }

         var adicionado = await _repository.AdicionaAsync(request);

         return adicionado 
                 ? Ok("Filme adicionado com sucesso") 
                 : BadRequest("Erro ao Adicionar");


        }
    [HttpPut("id")]

        public async Task<IActionResult> Put(FilmeRequest request, int id)
    {
        if (id <= 0) return BadRequest("Filme inválido");

        var filme = await _repository.BuscarFileAsync(id);

        if (filme == null) NotFound("Filme não Existe!!!");

        if (string.IsNullOrEmpty(request.Nome)) request.Nome = filme.Nome;
        if (request.Ano <= 0) request.Ano = filme.Ano;

        var atualizado = await _repository.AtualizarAsync(request, id);

        return atualizado
             ? Ok("Filme atualizado com sucesso")
             : BadRequest("Erro ao Atualizar");
    }

    
    }
