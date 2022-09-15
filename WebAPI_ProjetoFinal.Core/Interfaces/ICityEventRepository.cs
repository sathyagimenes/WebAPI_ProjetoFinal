using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface ICityEventRepository
    {
        List<CityEvent> SearchEvents();
        CityEvent SearchEvent(long id);
        List<CityEvent> SearchEventTitle(string title);
        CityEvent SearchEventLocalDate(string local, DateTime dateTime);
        List<CityEvent> SearchByPrice(decimal minPrice, decimal maxPrice, DateTime dateTime);
        bool DeleteEvent(long id);
        bool InsertEvent(CityEvent cityEvent);
        bool UpdateEvent(long id, CityEvent cityEvent);
    }
}
