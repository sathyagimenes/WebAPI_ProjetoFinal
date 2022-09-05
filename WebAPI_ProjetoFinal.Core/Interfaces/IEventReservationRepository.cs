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
        EventReservation SearchReservation(long id);
        bool InsertReservation(EventReservation reservation);
        bool UpdateReservation(long id, EventReservation reservation);
        bool DeleteReservation(long id);
    }
}
