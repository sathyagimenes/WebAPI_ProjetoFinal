using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Infra.Data.Repository 
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConnectionDataBase _database;
        public CityEventRepository(IConnectionDataBase database)
        {
            _database = database;
        }
        public List<CityEvent> ConsultarEvento()
        {
            var query = "SELECT * FROM CityEvent";
            using var conn = _database.CreateConnection();    
            return conn.Query<CityEvent>(query).ToList();
        }
        public CityEvent ConsultarEventoPorId(long id)
        {
            var query = "SELECT * FROM CityEvent WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var conn = _database.CreateConnection();
            return conn.QueryFirstOrDefault<CityEvent>(query, parameters);
        }
    }
}