namespace TestinWithDependencies.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestinWithDependencies.Api", Version = "v1" });
        });

        services.Configure<DbConnectionOptionsSqlite>(Configuration.GetSection("Sqlite"));
        services.AddSingleton<DatabaseInitializer>();
        services.AddSingleton<SqliteDbConnectionFactory>();
        services.AddSingleton<IUserRepository,UserRepository>();
        services.AddSingleton<UsersServices>();

        services.AddTransient<IUserRepository, UserRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestinWithDependencies.Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}
