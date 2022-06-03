namespace TestinWithDependencies.Api.Options
{
    public class DbConnectionOptionsSqlite : IDbConnectionOptions
    {
        public string DataSource { get; init; }

        public string ConnectionString
        {
            get
            {
                StringBuilder builder = new();
                builder.Append("Data Source=").Append(DataSource);
                return builder.ToString();
            }
        }
    }
}
