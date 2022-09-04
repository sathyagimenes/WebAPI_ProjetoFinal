using System.Data;

namespace WebAPI_ProjetoFinal.Core.Interfaces
{
    public interface IConnectionDataBase
    {
        IDbConnection CreateConnection();
    }
}
