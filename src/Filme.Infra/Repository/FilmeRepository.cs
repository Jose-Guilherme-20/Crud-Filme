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

        public async Task<bool> AdicionarAsync(FilmeRequest request)
        {
             using var con = new SqlConnection(connectionString);
            var sql = @"INSERT INTO tb_filme(
                nome,
                ano,
                id_produtora)
                VALUES(
                    @Nome,
                    @Ano,
                    @ProdutoraId
                )";
            var exec = await con.ExecuteAsync(sql, new {
                request.Nome,
                request.Ano,
                request.ProdutoraId
            });
            if(exec == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AtualizarAsync(FilmeRequest request, int id)
        {
            using var con = new SqlConnection(connectionString);
            var sql = @"UPDATE tb_filme
            SET nome =  @Nome,
                ano = @Ano
                WHERE id = @id";
            
                 var exec = await con.ExecuteAsync(sql, new {
                    request.Nome,
                    request.Ano,
                     id
                 });
                  if(exec == 1)
            {
                return true;
            }
            return false;

        }

        public async Task<IEnumerable<FilmeResponse>> BuscaFilmeAsync()
        {
            using var con = new SqlConnection(connectionString);
            var sql = @"SELECT f.id Id,
                            f.nome Nome,
                            f.ano Ano,
                            p.nome Produtora
                            FROM tb_filme f 
                            JOIN tb_produtora p ON f.id_produtora = p.id";
            return await con.QueryAsync<FilmeResponse>(sql);
        }

        public async Task<FilmeResponse> BuscaFilmeAsyncId(int id)
        {
            using var con = new SqlConnection(connectionString);
            var sql = @"SELECT f.id Id,
                            f.nome Nome,
                            f.ano Ano,
                            p.nome Produtora
                            FROM tb_filme f 
                            JOIN tb_produtora p ON f.id_produtora = p.id
                            WHERE f.id = @id";
                            return await con.QueryFirstOrDefaultAsync<FilmeResponse>(sql, new {id = id});
        }

        public async Task<bool> DeletarAsync(int id)
        {
            using var con = new SqlConnection(connectionString);
            var sql = @"DELETE tb_filme
                        WHERE id = @id";
                    var exec = await con.ExecuteAsync(sql, new{id});
                    if(exec > 0)
                    {
                        return true;
                    }
                    return false;
        }
    }
}