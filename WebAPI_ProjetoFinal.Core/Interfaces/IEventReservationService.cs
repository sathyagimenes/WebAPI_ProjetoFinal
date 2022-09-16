using WebAPI_ProjetoFinal.Core.Dto;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface IEventReservationService
    {
        List<EventReservation> SearchReservations();
        List<EventReservation> SearchReservation(string personName, string title);
        bool InsertReservation(EventReservation reservation);
        bool UpdateReservationQuantity(long id, DtoUpdateReservationQuantityRequest reservation);
        bool DeleteReservation(long id);
    }
}
