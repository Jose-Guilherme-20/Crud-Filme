using FilmesCrud.Models;
using FilmesCrud.src.Filme.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FilmesCrud.Controllers;
[ApiController]
[Route("api[Controller]")]
 public class FilmesController: ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        
public FilmesController(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

        [HttpGet]
    public async Task<IActionResult> ObterFilmes()
        {
            var filmes = await _filmeRepository.BuscaFilmeAsync();
            if(filmes == null)
            NoContent();

            return Ok(filmes);
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObterFilmeId(int id)
        {
            var filme = await _filmeRepository.BuscaFilmeAsyncId(id);
            if(filme == null)
            NoContent();
            
            return Ok(filme);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FilmeRequest request)
        {
            if(string.IsNullOrEmpty(request.Nome) || request.Ano <=0 || request.ProdutoraId <= 0)
            {
                return BadRequest("Informações inválidas");
            };
            var filme = await _filmeRepository.AdicionarAsync(request);
            return Ok(filme);
        }
        [HttpPut("id")]
        public async Task<IActionResult> Put(FilmeRequest request, int id)
        {
            var filme = await _filmeRepository.BuscaFilmeAsyncId(id);

            if(string.IsNullOrEmpty(request.Nome)) request.Nome = filme.Nome;
            if(request.Ano<=0) request.Ano = filme.Ano;

            var update = await _filmeRepository.AtualizarAsync(request, filme.Id);
            if(!update)
            return BadRequest("Filme não encontrado");

            return Ok(update);
        }

        [HttpDelete("id")]

        public async Task<IActionResult> delete(int id)
        {
            var filme = await _filmeRepository.BuscaFilmeAsyncId(id);
            if(filme == null)
            NotFound("filme não encontrado");

            var query = await _filmeRepository.DeletarAsync(id);
            if(query)
            {
                return Ok("filme excluido com sucesso");
            }
            return BadRequest("erro o filme não foi excluido");
        }
    }
