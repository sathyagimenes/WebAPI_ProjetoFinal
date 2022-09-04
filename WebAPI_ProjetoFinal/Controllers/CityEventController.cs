﻿using Microsoft.AspNetCore.Http;
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
        public CityEventController(ICityEventService cityEvent)
        {
            _cityEvent = cityEvent;
        }

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

    }
}
