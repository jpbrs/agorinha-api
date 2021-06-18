using System.Collections.Generic;
using agorinha_api.Entities;
using agorinha_api.Entities.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace agorinha_api.ExternalInterfaces
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class EncontrosRepository : IEncontrosRepository
    {

        private readonly string _connectionString;

        public EncontrosRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<EncontrosDTO> GetAllEncontros()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var results = connection.Query<EncontrosDTO>("SELECT * FROM Encontros");

                return results;
            }
        }

        public string AddEncontro(string data)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    connection.Query(@"INSERT INTO ENCONTROS VALUES (@Data)", new { Data = data });
                    return "Insertion Succeeded";

                } catch { return "Insertion Failed"; }
            }
        }

        public string DeleteEncontroByNumber(int number)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    connection.Query(@"DELETE FROM ENCONTROS WHERE Numero=@Numero", new { Numero = number });
                    return "Deletion Succeeded";

                }
                catch { return "Deletion Failed"; }
            }
        }
    }

}
