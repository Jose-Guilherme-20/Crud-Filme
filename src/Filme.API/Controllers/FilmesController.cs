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
            return Ok(filmes);
        }
    }
