using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ProjetoFinal.Core.Dto;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;
using WebAPI_ProjetoFinal.Filters;

namespace WebAPI_ProjetoFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        private readonly IEventReservationService _eventReservationService;
        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }


        [HttpGet("/EventReservation/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Authorize]
        public ActionResult<List<EventReservation>> SearchReservations()
        {
            return Ok(_eventReservationService.SearchReservations());
        }

        [HttpGet("/EventReservation/{personName}/{title}/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Authorize]
        public ActionResult<List<EventReservation>> SearchReservation(string personName, string title)
        {
            var reserva = _eventReservationService.SearchReservation(personName, title);
            if (reserva == null)
            {
                return StatusCode(500);
            }
            else if(reserva.Count == 0)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost("/EventReservation/Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [TypeFilter(typeof(QuantityValidationInsertActionFilter))]
        [Authorize]
        public ActionResult<EventReservation> InsertReservation(EventReservation eventReservation)
        {
            if (!_eventReservationService.InsertReservation(eventReservation))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(InsertReservation), eventReservation);
        }

        [HttpPut("/EventReservation/{id}/Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [TypeFilter(typeof(QuantityValidationActionFilter))]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateReservationQuantity(long id, DtoUpdateReservationQuantityRequest eventReservation)
        {
            if (!_eventReservationService.UpdateReservationQuantity(id, eventReservation))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/EventReservation/{id}/Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteReservation(long id)
        {
            if (!_eventReservationService.DeleteReservation(id))
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
