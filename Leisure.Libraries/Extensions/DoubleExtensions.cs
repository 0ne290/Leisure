namespace Leisure.Libraries.Extensions;

public static class DoubleExtensions
{
    public static bool AreEqualWithinAccuracy(this double a, double b, double accuracy) => Math.Abs(a - b) <= accuracy;
}