using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesCrud.Models;

namespace FilmesCrud.src.Filme.Infra.Repository
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<FilmeResponse>> BuscaFilmeAsync();
        Task<FilmeResponse> BuscaFilmeAsyncId(int id);
        Task<bool> AdicionarAsync(FilmeRequest request);
        Task<bool> AtualizarAsync(FilmeRequest request, int id);
        Task<bool> DeletarAsync(int id);

    }
}