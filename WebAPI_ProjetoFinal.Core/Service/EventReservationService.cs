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
        public List<EventReservation> SearchReservation(string personName, string title)
        {
            return _eventReservationRepository.SearchReservation(personName, title);
        }
        public bool InsertReservation(EventReservation reservation)
        {
            return _eventReservationRepository.InsertReservation(reservation);
        }
        public bool UpdateReservationQuantity(long id, EventReservation reservation)
        {
            return _eventReservationRepository.UpdateReservationQuantity(id, reservation);
        }
        public bool DeleteReservation(long id)
        {
            return _eventReservationRepository.DeleteReservation(id);
        }
    }
}
