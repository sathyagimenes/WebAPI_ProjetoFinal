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

        public List<EventReservation> SearchReservations() //excluir
        {
            var query = "SELECT * FROM EventReservation";
            try
            {
                using var conn = _database.CreateConnection();
                return conn.Query<EventReservation>(query).ToList();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Erro na execução da query.\nTipo da exceção: {ex.GetType().Name}.\nMensagem: {ex.Message}.\nStack trace: {ex.StackTrace}");
                return null;
            }
        }

        public List<EventReservation> SearchReservation(string personName, string title)
        {
            var query = @"SELECT IdReservation, res.IdEvent, PersonName, Quantity
                        FROM EventReservation AS res INNER JOIN CityEvent AS eve 
                        ON res.IdEvent = eve.IdEvent AND eve.Title LIKE CONCAT('%',@title,'%') 
                        AND res.PersonName = @personName";
            var parameters = new DynamicParameters();
            parameters.Add("personName", personName);
            parameters.Add("title", title);
            try
            {
                using var conn = _database.CreateConnection();
                return conn.Query<EventReservation>(query, parameters).ToList();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Erro na execução da query.\nTipo da exceção: {ex.GetType().Name}.\nMensagem: {ex.Message}.\nStack trace: {ex.StackTrace}");
                return null;
            }
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
        public bool UpdateReservationQuantity(long idReservation, EventReservation reservation)
        {
            var query = @"UPDATE EventReservation SET
                            Quantity = @Quantity
                            WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters();
            parameters.Add("Quantity", reservation.Quantity);
            parameters.Add("idReservation", idReservation);

            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) == 1;

        }

        public bool DeleteReservation(long id)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = _database.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
