using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Infra.Data.Repository 
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConfiguration _configuration;
        public CityEventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CityEvent> ConsultarEvento()
        {
            var query = "SELECT * FROM CityEvent";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));    
            return conn.Query<CityEvent>(query).ToList();
        }
    }
}