using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface ICityEventService
    {
        List<CityEvent> SearchEvents();
        CityEvent SearchEvent(long id);
        bool DeleteEvent(long id);
        bool InsertEvent(CityEvent cityEvent);
        bool UpdateEvent(long id, CityEvent cityEvent);
    }
}
