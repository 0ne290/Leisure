using Leisure.EquationsWithOneVariable.Core;
using Leisure.Libraries;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Leisure.EquationsWithOneVariable.Presentation;

public class SolverService(ILogger<SolverService> logger, Solver solver) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        /*while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken); // Wait for 1 second
        }*/
        
        Function1();
        Function2();
        Function3();

        return Task.CompletedTask;
    }

    private void Function1()
    {
        var accuracy = new Accuracy(1E-6, 1E-6);
        var interval = new Interval(-10, 10);
        var functionInstance = Function;
        
        var solution = solver.SolveByDichotomyMethod(functionInstance, accuracy, interval);
        logger.LogInformation("equation: 2x^2 - 5 - 2^x = 0; method: dichotomy; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        solution = solver.SolveByGoldenRatioMethod(functionInstance, accuracy, interval);
        logger.LogInformation("equation: 2x^2 - 5 - 2^x = 0; method: golden ratio; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        return;
        
        double Function(double x) => 2 * Math.Pow(x, 2) - 5 - Math.Pow(2, x);
    }
    
    private void Function2()
    {
        var accuracy = new Accuracy(1E-6, 1E-6);
        var interval = new Interval(-4 * Math.PI, 4 * Math.PI);
        var functionInstance = Function;
        
        var solution = solver.SolveByDichotomyMethod(functionInstance, accuracy, interval);
        logger.LogInformation("equation: (0.2x)^3 - cos(x) = 0; method: dichotomy; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        solution = solver.SolveByGoldenRatioMethod(functionInstance, accuracy, interval);
        logger.LogInformation("equation: (0.2x)^3 - cos(x) = 0; method: golden ratio; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        return;

        double Function(double x) => Math.Pow(0.2 * x, 3) - 5 - Math.Cos(x);
    }
    
    private void Function3()
    {
        var accuracy = new Accuracy(1E-6, 1E-6);
        var interval = new Interval(-10, 2);
        var functionInstance = Function;
        
        var solution = solver.SolveByDichotomyMethod(functionInstance, accuracy, interval);
        logger.LogInformation("equation: 1.2x^4 + 2x^3 - 13x^2 - 14.2x - 24.1 = 0; method: dichotomy; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        solution = solver.SolveByGoldenRatioMethod(functionInstance, accuracy, interval);
        logger.LogInformation("equation: 1.2x^4 + 2x^3 - 13x^2 - 14.2x - 24.1 = 0; method: golden ratio; accuracy: {@accuracy}, interval: {@interval}; solution: {@solution}; f(x): {fx}.", accuracy, interval, solution, Function(solution.X));
        
        return;

        double Function(double x) => 1.2 * Math.Pow(x, 4) + 2 * Math.Pow(x, 3) - 13 * Math.Pow(x, 2) - 14.2 * x - 24.1;
    }
}