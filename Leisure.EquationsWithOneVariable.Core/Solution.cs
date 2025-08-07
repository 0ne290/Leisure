namespace Leisure.EquationsWithOneVariable.Core;

public record Solution(double X, int IterationsNumber, int FunctionEvaluationsNumber, long ComputationTimeInMs, double ConvergenceParameter);