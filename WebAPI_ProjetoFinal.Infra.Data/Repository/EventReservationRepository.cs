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
    }
}
