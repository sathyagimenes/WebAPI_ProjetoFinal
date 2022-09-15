﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
        public ICityEventService _cityEvent;
        public CityEventController(ICityEventService cityEvent)
        {
            _cityEvent = cityEvent;
        }

        [HttpGet("/CityEvent/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CityEvent>> SearchEvents()
        {
            return Ok(_cityEvent.SearchEvents());
        }

        [HttpGet("/CityEvent/{id}/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> SearchEvent(long id)
        {
            var evento = _cityEvent.SearchEvent(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("/CityEvent/{title}/SearchTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CityEvent>> SearchEventTitle(string title)
        {
            var evento = _cityEvent.SearchEventTitle(title);
            if (evento == null)
            {
                return BadRequest();
            }
            else if (evento.Count == 0)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("/CityEvent/SearchLocalDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> SearchEventLocalDate(string local, DateTime dateTime)
        {
            var evento = _cityEvent.SearchEventLocalDate(local, dateTime);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpGet("/CityEvent/SearchByPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CityEvent> SearchByPrice(decimal minPrice, decimal maxPrice, DateTime date)
        {
            var evento = _cityEvent.SearchByPrice(minPrice, maxPrice, date.Date);
            if (evento == null)
            {
                return BadRequest();
            }
            else if (evento.Count == 0)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost("/CityEvent/Insert")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "admin")]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateEvent(long id, CityEvent cityEvent)
        {
            if (!_cityEvent.UpdateEvent(id, cityEvent))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("/CityEvent/{id}/Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteEvent(long id)
        {
            var result = _cityEvent.DeleteEvent(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
