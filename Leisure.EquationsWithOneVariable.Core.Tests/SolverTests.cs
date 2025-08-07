using Leisure.Libraries;
using Microsoft.Extensions.Logging;
using Moq;

namespace Leisure.EquationsWithOneVariable.Core.Tests;

public class SolverTests
{
    [Theory]
    [MemberData(nameof(SolveByDichotomyMethod_Data))]
    public void SolveByDichotomyMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        // Arrange
        var logger = Mock.Of<ILogger<Solver>>();

        var solver = new Solver(logger);
        
        // Act
        var _ = solver.SolveByDichotomyMethod(function, accuracy, interval);
        
        // Assert
        Assert.True(false);
    }
    
    // ReSharper disable once InconsistentNaming
    public static TheoryData<Func<double, double>, Accuracy, Interval> SolveByDichotomyMethod_Data =>
        new()
        {
            {
                x => 2 * Math.Pow(x, 2) - 5 - Math.Pow(2, x),
                new Accuracy(1E-6, 1E-6),
                new Interval(-10, 10)
            }
        };
}