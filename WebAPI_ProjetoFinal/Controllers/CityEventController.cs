using Microsoft.AspNetCore.Mvc;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityEventController : ControllerBase
    {
        public ICityEventService _cityEvent;
        private readonly IEventReservationService _eventReservationService;
        public CityEventController(ICityEventService cityEvent, IEventReservationService eventReservationService)
        {
            _cityEvent = cityEvent;
            _eventReservationService = eventReservationService;
        }

        #region CityEvent

        [HttpGet("/CityEvent/Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> SearchEvents()
        {
            return Ok(_cityEvent.SearchEvents());
        }

        [HttpGet("/CityEvent/{id}/Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityEvent> SearchEvent(long id)
        {
            var evento = _cityEvent.SearchEvent(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost("/CityEvent/Insert")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CityEvent> InsertEvent(CityEvent cityEvent)
        {
            if (!_cityEvent.InsertEvent(cityEvent))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(InsertEvent), cityEvent);
        }

        [HttpPut("/CityEvent/{id}/Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEvent(long id, CityEvent cityEvent)
        {
            if (!_cityEvent.UpdateEvent(id, cityEvent))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/CityEvent/{id}/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEvent(long id)
        {
            if (!_cityEvent.DeleteEvent(id))
            {
                return NotFound();
            }
            return Ok();
        }
        #endregion

        #region EventReservation

        [HttpGet("/EventReservation/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<EventReservation>> SearchReservations()
        {
            return Ok(_eventReservationService.SearchReservations());
        }

        [HttpGet("/EventReservation/{id}/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EventReservation> SearchReservation(long id)
        {
            var reserva = _eventReservationService.SearchReservation(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost("/EventReservation/Insert")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult InsertReservation(EventReservation eventReservation)
        {
            if (!_eventReservationService.InsertReservation(eventReservation))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(InsertReservation), eventReservation);
        }

        [HttpPut("/EventReservation/{id}/Update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateReservation(long id, EventReservation reservation)
        {
            if (!_eventReservationService.UpdateReservation(id, reservation))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/EventReservation/{id}/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteReservation(long id)
        {
            if (!_eventReservationService.DeleteReservation(id))
            {
                return NotFound();
            }
            return Ok();
        }

        #endregion
    }
}
