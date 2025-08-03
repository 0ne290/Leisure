namespace Leisure.DiophantineEquation.Core;

public record LinearEquation(int A, int B, int C)
{
    public record ParticularSolution(int X, int Y);

    public delegate ParticularSolution GeneralSolution(int t);
};