using Leisure.Libraries.Exceptions;

namespace Leisure.Libraries;

public class Accuracy
{
    public Accuracy(double byX, double byY)
    {
        byX = Math.Abs(byX);
        byY = Math.Abs(byY);

        if (byX < Constants.DefaultAccuracy || byY < Constants.DefaultAccuracy)
            throw new InvariantViolationException($"Accuracy error: accuracy cannot be less than \"{Constants.DefaultAccuracy}\".");

        ByX = byX;
        ByY = byY;
    }
    
    public double ByX { get; }

    public double ByY { get; }
}