﻿using Dapper;
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

        public List<EventReservation> SearchReservations()
        {
            var query = "SELECT * FROM EventReservation";
            using var conn = _database.CreateConnection();
            return conn.Query<EventReservation>(query).ToList();
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
            using var conn = _database.CreateConnection();
            return conn.Query<EventReservation>(query, parameters).ToList();
        }

        public bool InsertReservation(EventReservation reservation)
        {
            var query = @"INSERT INTO EventReservation VALUES(
                            @IdEvent, @PersonName, @Quantity)";
            var parameters = new DynamicParameters();
            parameters.Add("IdEvent", reservation.IdEvent);
            parameters.Add("PersonName", reservation.PersonName);
            parameters.Add("Quantity", reservation.Quantity);
            try
            {
                using var conn = _database.CreateConnection();
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco de dados. Mensagem: {ex.Message}. Stack trace: {ex.StackTrace}");
                return false;
            }
        }
        public bool UpdateReservationQuantity(long idReservation, EventReservation reservation)
        {
            var query = @"UPDATE EventReservation SET
                            Quantity = @Quantity
                            WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters();
            parameters.Add("Quantity", reservation.Quantity);
            parameters.Add("idReservation", idReservation);
            try
            {
                using var conn = _database.CreateConnection();
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco de dados. Mensagem: {ex.Message}. Stack trace: {ex.StackTrace}");
                return false;
            }
        }

        public bool DeleteReservation(long id)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            try
            {
                using var conn = _database.CreateConnection();
                return conn.Execute(query, parameters) == 1;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao comunicar com o banco de dados. Mensagem: {ex.Message}. Stack trace: {ex.StackTrace}");
                return false;
            }
        }
    }
}
