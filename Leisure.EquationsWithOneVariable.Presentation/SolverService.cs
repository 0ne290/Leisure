using Leisure.EquationsWithOneVariable.Core;
using Leisure.Libraries;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Leisure.EquationsWithOneVariable.Presentation;

public class SolverService(ILogger<SolverService> logger, Solver solver) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var accuracy = new Accuracy(1E-6, 1E-6);
        var interval = new Interval(-10, 10);
        
        var solution = solver.SolveByDichotomyMethod(Function, accuracy, interval);
        logger.LogInformation("equation: 2x^2 - 5 - 2^x = 0; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        /*while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken); // Wait for 1 second
        }*/

        return Task.CompletedTask;
        
        double Function(double x) => 2 * Math.Pow(x, 2) - 5 - Math.Pow(2, x);
    }
}