using Microsoft.Extensions.Logging;

namespace Leisure.EquationsWithOneVariable.Core;

public class Solver(ILogger<Solver> logger)
{
    public double SolveByDichotomyMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        var a = interval.Infimum;
        var b = interval.Supremum;
        var xi = (a + b) / 2;

        var i = 1;
        var intervalLength = (b - a) / 2;
        var fxi = function(xi);
        logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);
        while (!(fxi.AreEqualWithinAccuracy(0, accuracy.ByY) && intervalLength < accuracy.ByX))
        {
            if (function(a) * fxi <= 0)
                b = xi;
            else
                a = xi;
            xi = (a + b) / 2;
            
            intervalLength = (b - a) / 2;
            fxi = function(xi);

            i++;
            
            logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);
        }

        return xi;
    }
}