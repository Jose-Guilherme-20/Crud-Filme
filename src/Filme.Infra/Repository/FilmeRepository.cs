using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FilmesCrud.Models;
using Microsoft.Data.SqlClient;

namespace FilmesCrud.src.Filme.Infra.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public async Task<bool> AdicionarAsync(FilmeRequest request, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarAsync(FilmeRequest request, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FilmeResponse>> BuscaFilmeAsync()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sql = @"SELECT f.id Id,
                            f.nome Nome,
                            f.ano Ano,
                            p.nome Produtora
                            FROM tb_filme f 
                            JOIN tb_produtora p ON f.id_produtora = p.id";
                return await con.QueryAsync<FilmeResponse>(sql);
            }
        }

        public Task<FilmeResponse> BuscaFilmeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}