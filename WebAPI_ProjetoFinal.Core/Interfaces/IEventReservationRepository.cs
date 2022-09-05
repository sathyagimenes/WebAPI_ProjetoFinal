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
        bool InsertReservation(EventReservation reservation);
        List<EventReservation> SearchEvents();
        EventReservation SearchEvent(long id);
        bool UpdateReservation(long id, EventReservation reservation);
    }
}
