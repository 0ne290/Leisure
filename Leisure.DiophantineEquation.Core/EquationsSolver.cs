namespace Leisure.DiophantineEquation.Core;

public class LinearEquationSolver(int a, int b)
{
    public List<Solution> Solve()
    {
        throw new NotImplementedException();
    }

    private static int CalculateGcdUsingEuclideanAlgorithm(int a, int b)
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

    public int A { get; } = a;

    public int B { get; } = b;
}