using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface IEventReservationService
    {
        List<EventReservation> SearchReservations();
        EventReservation SearchReservation(long id);
        bool InsertReservation(EventReservation reservation);
        bool UpdateReservation(long id, EventReservation reservation);
        bool DeleteReservation(long id);
    }
}
