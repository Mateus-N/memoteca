using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MemotecaApi.Data;
using MemotecaApi.services;
using Serilog;

namespace MemotecaApi;

public class Startup
{
    private readonly IConfiguration configuration;
    
    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = configuration
            .GetConnectionString("ContextConnection")!;

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySQL(connectionString);
        });

        AddServicesInjetables(services);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    public void AddServicesInjetables(IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type interfaceType = typeof(IInjetable);

        List<Type>? classesImplementandoInterface = assembly.GetTypes()
            .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface)
            .ToList();

        foreach (Type classType in classesImplementandoInterface)
        {
            Type interfaceTypes = classType.GetInterfaces()
                .First(i => i.Name == $"I{classType.Name}");

            services.AddScoped(interfaceTypes, classType);
        }
    }

    public void AddJsonFiles(IConfigurationBuilder builder, IWebHostEnvironment env)
    {
        builder
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
            .AddJsonFile("applogger.json")
            .AddJsonFile($"applogger.{env.EnvironmentName}.json");
    }
}
