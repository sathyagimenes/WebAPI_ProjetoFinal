using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI_ProjetoFinal.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 500,
                Title = "Erro inesperado",
                Detail = "Ocorreu um erro inesperado na solitação",
                Type = context.Exception.GetType().Name
            };

            switch (context.Exception)
            {
                case SqlException:
                    problem.Status = StatusCodes.Status503ServiceUnavailable;
                    problem.Detail = "Erro ao tentar conectar ao banco de dados";
                    context.Result = new ObjectResult(problem);
                    break;
                case ArgumentNullException:
                    problem.Status = StatusCodes.Status501NotImplemented;
                    context.Result = new ObjectResult(problem);
                    break;
                case ArgumentException:
                    problem.Status = StatusCodes.Status501NotImplemented;
                    context.Result = new ObjectResult(problem);
                    break;
                default:
                    context.Result = new ObjectResult(problem);
                    break;
            }

            Console.WriteLine($"Tipo da exceção: {context.Exception.GetType().Name};\nMensagem: {context.Exception.Message};\nStack Trace: {context.Exception.StackTrace}");
        }

    }
}
