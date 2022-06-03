namespace TestinWithDependencies.Api.Data;

public class DatabaseInitializer
{
    private readonly SqliteDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(SqliteDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        SqlMapper.AddTypeHandler(new SqLiteGuidTypeHandler());
        SqlMapper.RemoveTypeMap(typeof(Guid));
        SqlMapper.RemoveTypeMap(typeof(Guid?));

        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        await connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS Users (Id TEXT PRIMARY KEY, FullName TEXT NOT NULL)");
        var ramon =
            await connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM Users where FullName = @FullName",
                new { FullName = "Ramón Martínez" });

        if (ramon is null)
        {
            await connection.ExecuteAsync("INSERT INTO Users (Id, FullName) VALUES (@Id, @FullName)"
                , new { Id = Guid.NewGuid().ToString(), FullName = "Ramón Martínez" });
        }
    }
}
