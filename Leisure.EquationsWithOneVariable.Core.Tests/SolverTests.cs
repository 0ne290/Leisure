using System.Globalization;
using Xunit.Abstractions;

namespace Leisure.EquationsWithOneVariable.Core.Tests;

public class SolverTests(ITestOutputHelper testOutputHelper)
{
    [Theory]
    [MemberData(nameof(SolveByDichotomyMethod_Data))]
    public void SolveByDichotomyMethod(Func<double, double> function, Accuracy accuracy, Interval interval)
    {
        // Act
        var x = Solver.SolveByDichotomyMethod(function, accuracy, interval);
        
        // Assert
        testOutputHelper.WriteLine(x.ToString(CultureInfo.InvariantCulture));
    }
    
    // ReSharper disable once InconsistentNaming
    public static TheoryData<Func<double, double>, Accuracy, Interval> SolveByDichotomyMethod_Data =>
        new()
        {
            {
                (x) => 2 * Math.Pow(x, 2) - 5 - Math.Pow(2, x),
                new Accuracy(1E-6, 1E-6),
                new Interval(-10, 10)
            }
        };
}