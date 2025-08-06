using Leisure.Libraries.Exceptions;

namespace Leisure.EquationsWithOneVariable.Core;

public class Accuracy
{
    public Accuracy(double byX, double byY)
    {
        if (byX < 0) 
            byX = Math.Abs(byX);
        if (byY < 0)
            byY = Math.Abs(byY);

        if (byX < Constants.DefaultAccuracy || byY < Constants.DefaultAccuracy)
            throw new InvariantViolationException($"Accuracy error: accuracy cannot be less than \"{Constants.DefaultAccuracy}\".");

        ByX = byX;
        ByY = byY;
    }
    
    public double ByX { get; }

    public double ByY { get; }
}