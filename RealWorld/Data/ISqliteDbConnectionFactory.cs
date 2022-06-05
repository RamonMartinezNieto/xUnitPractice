using System.Data;

namespace RealWorld.Data;

public interface ISqliteDbConnectionFactory
{
    Task<IDbConnection> CreateDbConnectionAsync();
}
