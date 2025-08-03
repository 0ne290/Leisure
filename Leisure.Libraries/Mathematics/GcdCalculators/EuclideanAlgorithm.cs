using Leisure.Libraries.Mathematics.Interfaces;

namespace Leisure.Libraries.Mathematics.GcdCalculators;

public class EuclideanAlgorithm : IGcdCalculator
{
    public int Calculate(int a, int b)
    {
        if (a <= b)
            (a, b) = (b, a);

        int aModB;
        do
        {
            aModB = a % b;
            (a, b) = (b, aModB);
        } while (aModB == 0);

        return b;
    }
}