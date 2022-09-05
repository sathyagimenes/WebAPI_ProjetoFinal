using Dapper;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConnectionDataBase _database;
        public EventReservationRepository(IConnectionDataBase database)
        {
            _database = database;
        }

        public List<EventReservation> SearchEvents()
        {
            var query = "SELECT * FROM EventReservation";
            using var conn = _database.CreateConnection();
            return conn.Query<EventReservation>(query).ToList();
        }

        public EventReservation SearchEvent(long id)
        {
            var query = "SELECT * FROM EventReservation WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using var conn = _database.CreateConnection();
            return conn.QueryFirstOrDefault<EventReservation>(query, parameters);
        }

        public bool InsertReservation(EventReservation reservation)
        {
            var query = @"INSERT INTO EventReservation VALUES(
                            @IdEvent, @PersonName, @Quantity)";
            var parameters = new DynamicParameters();
            parameters.Add("IdEvent", reservation.IdEvent);
            parameters.Add("PersonName", reservation.PersonName);
            parameters.Add("Quantity", reservation.Quantity);
            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
        public bool UpdateReservation(long id, EventReservation reservation)
        {
            var query = @"UPDATE EventReservation SET
                            IdEvent = @IdEvent,
                            PersonName = @PersonName,
                            Quantity = @Quantity
                            WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("IdEvent", reservation.IdEvent);
            parameters.Add("PersonName", reservation.PersonName);
            parameters.Add("Quantity", reservation.Quantity);
            parameters.Add("id", id);
            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
