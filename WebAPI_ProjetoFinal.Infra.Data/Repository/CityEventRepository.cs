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
        public bool InsertEvent(CityEvent cityEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@IdEvent, @Title, @Description, @DateHourEvent, @Local, @Address, @Price)";
            var parameters = new DynamicParameters();
            parameters.Add("IdEvent", cityEvent.IdEvent);
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("Description", cityEvent.Description);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("Local", cityEvent.Local);
            parameters.Add("Address", cityEvent.Address);
            parameters.Add("Price", cityEvent.Price);

            using var conn = _database.CreateConnection();

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateEvent(long id, CityEvent cityEvent)
        {
            var query = @"UPDATE CityEvent SET 
                        IdEvent = @NovoId,
                        Title = @Title,
                        Description = @Description,
                        DateHourEvent = @DateHourEvent,
                        Local = @Local,
                        Address = @Address,
                        Price = @Price
                        WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("NovoId", cityEvent.IdEvent);
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("Description", cityEvent.Description);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("Local", cityEvent.Local);
            parameters.Add("Address", cityEvent.Address);
            parameters.Add("Price", cityEvent.Price);
            parameters.Add("id", id);
            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteEvent(long id)
        {
            var query = "DELETE FROM CityEvent WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}