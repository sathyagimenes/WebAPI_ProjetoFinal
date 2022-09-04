using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebAPI_ProjetoFinal.Core.Interfaces;

namespace WebAPI_ProjetoFinal.Infra.Data
{
    public class ConnectionDataBase : IConnectionDataBase
    {
        private readonly IConfiguration _configuration;
        public ConnectionDataBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
