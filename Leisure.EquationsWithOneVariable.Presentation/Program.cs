using Leisure.EquationsWithOneVariable.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Leisure.EquationsWithOneVariable.Presentation;

internal class Program
{
    private static async Task<int> Main()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .MinimumLevel.Information()
            .CreateLogger();
        
        try
        {
            Log.Information("Starting host");

            var builder = Host.CreateApplicationBuilder();
            builder.Services
                .AddTransient<Solver>()
                .AddHostedService<SolverService>()
                .AddSerilog();

            var app = builder.Build();
    
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}