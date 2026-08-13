 
using System.Data.SqlClient;

namespace WebFormsMejoresPracticas.Infrastructure.Database
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}

