using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface ICityEventService
    {
        List<CityEvent> ConsultarEvento();
        CityEvent ConsultarEventoPorId(long id);
        bool DeleteEvent(long id);
        bool InsertEvent(CityEvent cityEvent);
    }
}
