using System;
using System.Linq;
using agorinha_api.Entities.DTO;
using agorinha_api.Entities.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace agorinha_api.ExternalInterfaces
{
    public class LivroAtualRepository : ILivroAtualRepository
    {
        private readonly string _connectionString;

        public LivroAtualRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public LivroDTO GetLivroAtual()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var results = connection.Query<LivroDTO>("SELECT * FROM LivroAtual");
                var result = results.First();


                return result;
            }
        }

        public bool UpdateLivroAtual(LivroDTO livro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                            DELETE FROM LivroAtual;
                            Insert into LivroAtual Values (@Name, @Autor, @Ano, @Genero, @Sinopse)
                        ";

                connection.Query(query, new { Name = livro.Name, Autor = livro.Autor, Ano = livro.Ano, Genero = livro.Genero, Sinopse = livro.Sinopse });
                return true;

            }
        }
    }
}
