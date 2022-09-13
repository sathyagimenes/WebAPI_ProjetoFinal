using Dapper;
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
        public List<CityEvent> SearchEvents()
        {
            var query = "SELECT * FROM CityEvent";
            using var conn = _database.CreateConnection();    
            return conn.Query<CityEvent>(query).ToList();
        }
        public CityEvent SearchEvent(long id)
        {
            var query = "SELECT * FROM CityEvent WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var conn = _database.CreateConnection();
            return conn.QueryFirstOrDefault<CityEvent>(query, parameters);
        }
        public List<CityEvent> SearchEventTitle(string title)
        {
            var query = "SELECT * FROM CityEvent WHERE Title LIKE CONCAT('%',@title,'%');";
            var parameters = new DynamicParameters();
            parameters.Add("title", title);
            using var conn = _database.CreateConnection();
            return conn.Query<CityEvent>(query, parameters).ToList();
        }
        public CityEvent SearchEventLocalDate(string local, DateTime dateTime)
        {
            var query = "SELECT * FROM CityEvent WHERE Local = @local AND CONVERT(DATE, dateHourEvent) = @dateTime";
            var parameters = new DynamicParameters();
            parameters.Add("local", local);
            parameters.Add("dateTime", dateTime);
            using var conn = _database.CreateConnection();
            return conn.QueryFirstOrDefault<CityEvent>(query, parameters);
        }

        public List<CityEvent> SearchByPrice(decimal minPrice, decimal maxPrice, DateTime dateTime)
        {
            var query = "SELECT * FROM CityEvent WHERE CONVERT(DATE, dateHourEvent) = @dateTime AND Price BETWEEN @minPrice AND @maxPrice";
            var parameters = new DynamicParameters();
            parameters.Add("dateTime", dateTime);
            parameters.Add("minPrice", minPrice);
            parameters.Add("maxPrice", maxPrice);
            using var conn = _database.CreateConnection();
            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public bool InsertEvent(CityEvent cityEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("Description", cityEvent.Description);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("Local", cityEvent.Local);
            parameters.Add("Address", cityEvent.Address);
            parameters.Add("Price", cityEvent.Price);
            parameters.Add("Status", cityEvent.Status);

            using var conn = _database.CreateConnection();

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateEvent(long id, CityEvent cityEvent)
        {
            var query = @"UPDATE CityEvent SET 
                        Title = @Title,
                        Description = @Description,
                        DateHourEvent = @DateHourEvent,
                        Local = @Local,
                        Address = @Address,
                        Price = @Price,
                        Status = @Status
                        WHERE IdEvent = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Title", cityEvent.Title);
            parameters.Add("Description", cityEvent.Description);
            parameters.Add("DateHourEvent", cityEvent.DateHourEvent);
            parameters.Add("Local", cityEvent.Local);
            parameters.Add("Address", cityEvent.Address);
            parameters.Add("Price", cityEvent.Price);
            parameters.Add("Status", cityEvent.Status);
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