using Leisure.Libraries.Exceptions;

namespace Leisure.EquationsWithOneVariable.Core;

public class Interval
{
    public Interval(double a, double b)
    {
        if (a.AreEqualWithinAccuracy(b, Constants.DefaultAccuracy))
            throw new InvariantViolationException("Interval error: boundaries cannot be equal.");

        if (a > b)
            (a, b) = (b, a);
        
        Infimum = a; 
        Supremum = b;
    }
    
    public double Infimum { get; }

    public double Supremum { get; }
}