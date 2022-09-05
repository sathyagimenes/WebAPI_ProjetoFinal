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
        public ActionResult<List<CityEvent>> ConsultaCityEvent()
        {
            return Ok(_cityEvent.ConsultarEvento());
        }

        [HttpGet("/CityEvent/{id}/Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityEvent> ConsultarEventoPorId(long id)
        {
            var evento = _cityEvent.ConsultarEventoPorId(id);
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


        #endregion
    }
}
