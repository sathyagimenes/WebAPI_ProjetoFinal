using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface IEventReservationRepository
    {
        List<EventReservation> SearchReservations();
        List<EventReservation> SearchReservation(string personName, string title);
        bool InsertReservation(EventReservation reservation);
        bool UpdateReservationQuantity(long id, EventReservation reservation);
        bool DeleteReservation(long id);
    }
}
