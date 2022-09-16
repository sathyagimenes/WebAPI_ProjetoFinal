using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI_ProjetoFinal.Core.Dto;

namespace WebAPI_ProjetoFinal.Filters
{
    public class QuantityValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            DtoUpdateReservationQuantityRequest eventReservation = (DtoUpdateReservationQuantityRequest)context.ActionArguments["eventReservation"];

            if (eventReservation.Quantity < 1)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
