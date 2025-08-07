using Leisure.EquationsWithOneVariable.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Leisure.EquationsWithOneVariable.Presentation;

public class SolverService(ILogger<SolverService> logger, Solver solver) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var function = (double x) => 2 * Math.Pow(x, 2) - 5 - Math.Pow(2, x);
        var accuracy = new Accuracy(1E-6, 1E-6);
        var interval = new Interval(-10, 10);
        var x = solver.SolveByDichotomyMethod(function, accuracy, interval);
        logger.LogInformation("equation: 2x^2 - 5 - 2^x = 0; accuracy: {@accuracy}, interval: {@interval}; x: {x}; f(x): {fx}.", accuracy, interval, x, function(x));
        
        /*while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken); // Wait for 1 second
        }*/

        return Task.CompletedTask;
    }
}