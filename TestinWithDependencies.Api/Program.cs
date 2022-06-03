namespace TestinWithDependencies.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var app = CreateHostBuilder(args).Build();
        
        var dbInitialized = app.Services.GetRequiredService<DatabaseInitializer>();
        dbInitialized.InitializeAsync();
        
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
