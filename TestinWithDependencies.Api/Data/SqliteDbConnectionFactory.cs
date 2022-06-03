namespace TestinWithDependencies.Api.Data;

public class SqliteDbConnectionFactory 
{
    private readonly IDbConnectionOptions _connectionOptions;

    public SqliteDbConnectionFactory(IOptions<DbConnectionOptionsSqlite> connectionOptions)
    {
        _connectionOptions = connectionOptions.Value;
    }

    public async Task<IDbConnection> CreateDbConnectionAsync()
    {
        SqliteConnection connection = new (_connectionOptions.ConnectionString);
        await connection.OpenAsync();   
        return connection;
    }
}
