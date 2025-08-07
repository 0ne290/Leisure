using System.Diagnostics;
using Leisure.Libraries;
using Leisure.Libraries.Extensions;
using Microsoft.Extensions.Logging;

namespace Leisure.EquationsWithOneVariable.Core;

public class Solver(ILogger<Solver> logger)
{
    public Solution SolveByDichotomyMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var i = 0;
        var ai = interval.Infimum;
        var bi = interval.Supremum;
        var halfDeltai = (bi - ai) / 2;
        var xi = (ai + bi) / 2;
        var lastCalculatedRoots = new ClosedArray<double>(3)
        {
            [i] = xi
        };
        var fxi = function(xi);

        logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);

        while (!fxi.AreEqualWithinAccuracy(0, accuracy.ByY) || halfDeltai >= accuracy.ByX)
        {
            i++;

            if (function(ai) * fxi <= 0)
                bi = xi;
            else
                ai = xi;
            halfDeltai = (bi - ai) / 2;

            xi = (ai + bi) / 2;
            lastCalculatedRoots[i] = xi;
            fxi = function(xi);

            logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);
        }

        stopwatch.Stop();

        return new Solution(xi, i + 1, 1 + 2 * i, stopwatch.ElapsedMilliseconds, CalculateConvergenceParameter(lastCalculatedRoots, i));
    }
    
    public Solution SolveByGoldenRatioMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var i = 0;
        var ai = interval.Infimum;
        var bi = interval.Supremum;
        var deltai = bi - ai;
        var halfDeltai = deltai / 2;
        var xi = (ai + bi) / 2;
        var lastCalculatedRoots = new ClosedArray<double>(3)
        {
            [i] = xi
        };
        var fxi = function(xi);

        logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);

        while (!fxi.AreEqualWithinAccuracy(0, accuracy.ByY) || halfDeltai >= accuracy.ByX)
        {
            i++;
            
            var deltaiPlus1 = deltai / Constants.GoldenRatio;
            var di = ai + deltaiPlus1;
            if (function(ai) * function(di) <= 0)
                bi = di;
            else
            {
                var deltaiPlus2 = deltaiPlus1 / Constants.GoldenRatio;
                ai = ai + deltaiPlus2;
            }
            
            intervalLength = (b - a) / 2;

            xi = (a + b) / 2;
            lastCalculatedRoots[i] = xi;
            fxi = function(xi);

            logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);
        }

        stopwatch.Stop();

        return new Solution(xi, i + 1, 1 + 2 * i, stopwatch.ElapsedMilliseconds, CalculateConvergenceParameter(lastCalculatedRoots, i));
    }

    private static double CalculateConvergenceParameter(ClosedArray<double> lastCalculatedRoots, int i)
    {
        var xiMinus1 = lastCalculatedRoots[i - 1];
        
        return Math.Abs((lastCalculatedRoots[i] - xiMinus1) / (xiMinus1 - lastCalculatedRoots[i - 2]));
    }
}