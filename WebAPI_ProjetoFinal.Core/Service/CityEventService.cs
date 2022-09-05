using WebAPI_ProjetoFinal.Core.Interfaces;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Service
{
    public class CityEventService : ICityEventService
    {
        public ICityEventRepository _cityEventRepository;
        public CityEventService(ICityEventRepository cityEventRepository)
        {
            _cityEventRepository = cityEventRepository;
        }

        public List<CityEvent> SearchEvents()
        {
            return _cityEventRepository.SearchEvents();
        }
        public CityEvent SearchEvent(long id)
        {
            return _cityEventRepository.SearchEvent(id);
        }
        public bool DeleteEvent(long id)
        {
            return _cityEventRepository.DeleteEvent(id);
        }
        public bool InsertEvent(CityEvent cityEvent)
        {
            return _cityEventRepository.InsertEvent(cityEvent);
        }
        public bool UpdateEvent(long id, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateEvent(id, cityEvent);
        }
    }
}