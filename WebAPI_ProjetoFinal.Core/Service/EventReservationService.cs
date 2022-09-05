using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Service
{
    public class EventReservationService : IEventReservationService
    {
        private readonly IEventReservationRepository _eventReservationRepository;
        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }
        public List<EventReservation> SearchReservations()
        {
            return _eventReservationRepository.SearchReservations();
        }
        public EventReservation SearchReservation(long id)
        {
            return _eventReservationRepository.SearchReservation(id);
        }
        public bool InsertReservation(EventReservation reservation)
        {
            return _eventReservationRepository.InsertReservation(reservation);
        }
        public bool UpdateReservation(long id, EventReservation reservation)
        {
            return _eventReservationRepository.UpdateReservation(id, reservation);
        }
        public bool DeleteReservation(long id)
        {
            return _eventReservationRepository.DeleteReservation(id);
        }
    }
}
