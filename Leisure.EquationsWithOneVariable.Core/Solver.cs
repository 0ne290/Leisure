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
        var functionEvaluationsNumber = 0;
        var ai = interval.Infimum;
        var bi = interval.Supremum;
        var halfDeltai = (bi - ai) / 2;
        var xi = (ai + bi) / 2;
        var lastCalculatedRoots = new ClosedArray<double>(3)
        {
            [i] = xi
        };
        var fxi = FunctionWrapper(xi);
        var fai = FunctionWrapper(ai);

        logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);

        while (!fxi.AreEqualWithinAccuracy(0, accuracy.ByY) || halfDeltai >= accuracy.ByX)
        {
            i++;

            if (fai * fxi <= 0)
                bi = xi;
            else
            {
                ai = xi;
                fai = FunctionWrapper(ai);
            }
            halfDeltai = (bi - ai) / 2;

            xi = (ai + bi) / 2;
            lastCalculatedRoots[i] = xi;
            fxi = FunctionWrapper(xi);

            logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);
        }

        stopwatch.Stop();

        return new Solution(xi, i + 1, functionEvaluationsNumber, stopwatch.ElapsedMilliseconds, CalculateConvergenceParameter(lastCalculatedRoots, i));

        double FunctionWrapper(double arg)
        {
            functionEvaluationsNumber++;
            return function(arg);
        }
    }
    
    public Solution SolveByGoldenRatioMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var i = 0;
        var functionEvaluationsNumber = 0;
        var ai = interval.Infimum;
        var bi = interval.Supremum;
        var deltai = bi - ai;
        var halfDeltai = deltai / 2;
        var xi = (ai + bi) / 2;
        var lastCalculatedRoots = new ClosedArray<double>(3)
        {
            [i] = xi
        };
        var fxi = FunctionWrapper(xi);
        var fai = FunctionWrapper(ai);

        logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);

        while (!fxi.AreEqualWithinAccuracy(0, accuracy.ByY) || halfDeltai >= accuracy.ByX)
        {
            i++;
            
            var deltaiPlus1 = deltai / Constants.GoldenRatio;
            var di = ai + deltaiPlus1;
            if (fai * FunctionWrapper(di) <= 0)
                bi = di;
            else
            {
                var deltaiPlus2 = deltaiPlus1 / Constants.GoldenRatio;
                var ci = ai + deltaiPlus2;
                ai = ci;
                fai = FunctionWrapper(ai);
            }
            deltai = bi - ai;
            halfDeltai = deltai / 2;

            xi = (ai + bi) / 2;
            lastCalculatedRoots[i] = xi;
            fxi = FunctionWrapper(xi);

            logger.LogDebug("i: {i}; x[i]: {xi}; f(x[i]): {fxi}.", i, xi, fxi);
        }

        stopwatch.Stop();

        return new Solution(xi, i + 1, functionEvaluationsNumber, stopwatch.ElapsedMilliseconds, CalculateConvergenceParameter(lastCalculatedRoots, i));

        double FunctionWrapper(double arg)
        {
            functionEvaluationsNumber++;
            return function(arg);
        }
    }

    private static double CalculateConvergenceParameter(ClosedArray<double> lastCalculatedRoots, int i)
    {
        var xiMinus1 = lastCalculatedRoots[i - 1];
        
        return Math.Abs((lastCalculatedRoots[i] - xiMinus1) / (xiMinus1 - lastCalculatedRoots[i - 2]));
    }
}