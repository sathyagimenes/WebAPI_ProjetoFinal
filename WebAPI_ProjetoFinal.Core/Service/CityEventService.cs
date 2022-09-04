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

        public List<CityEvent> ConsultarEvento()
        {
            return _cityEventRepository.ConsultarEvento();
        }
    }
}