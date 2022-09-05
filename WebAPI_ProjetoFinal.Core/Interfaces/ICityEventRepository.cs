using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_ProjetoFinal.Core.Model;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface ICityEventRepository
    {
        List<CityEvent> SearchEvents();
        CityEvent SearchEvent(long id);
        bool DeleteEvent(long id);
        bool InsertEvent(CityEvent cityEvent);
        bool UpdateEvent(long id, CityEvent cityEvent);
    }
}
