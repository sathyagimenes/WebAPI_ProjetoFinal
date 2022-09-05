using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface IEventReservationService
    {
        bool InsertReservation(EventReservation reservation);
        List<EventReservation> SearchEvents();
        EventReservation SearchEvent(long id);
        bool UpdateReservation(long id, EventReservation reservation);
    }
}
