using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityEventController : ControllerBase
    {
        public List<CityEvent> CityEventList { get; set; }
        public ICityEventService _cityEvent;
        public CityEventController(ICityEventService cityEvent)
        {
            CityEventList = new List<CityEvent>();
            _cityEvent = cityEvent;
        }

        [HttpGet("/CityEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CityEvent>> ConsultaCityEvent()
        {
            return Ok(_cityEvent.ConsultarEvento());
        }
    }
}
