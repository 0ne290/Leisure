namespace Leisure.EquationsWithOneVariable.Core;

public static class Solver
{
    public static double SolveByDichotomyMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        var a = interval.Infimum;
        var b = interval.Supremum;
        var c = (a + b) / 2;

        var intervalLength = (b - a) / 2;
        var fc = function(c);
        while (fc.AreEqualWithinAccuracy(0, accuracy.ByY) && intervalLength < accuracy.ByX)
        {
            if (function(a) * fc <= 0)
                b = c;
            else
                a = c;
            c = (a + b) / 2;
            
            intervalLength = (b - a) / 2;
            fc = function(c);
        }

        return c;
    }
}