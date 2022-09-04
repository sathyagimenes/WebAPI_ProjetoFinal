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
        List<CityEvent> ConsultarEvento();
    }
}
