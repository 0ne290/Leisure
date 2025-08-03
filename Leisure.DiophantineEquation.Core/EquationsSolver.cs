using Leisure.Libraries.Exceptions;
using Leisure.Libraries.Mathematics.Interfaces;

namespace Leisure.DiophantineEquation.Core;

public class EquationsSolver
{
    public LinearEquation.GeneralSolution Solve(IGcdCalculator gcdCalculator, LinearEquation equation)
    {
        var gcd = gcdCalculator.Calculate(equation.A, equation.B);
        if (equation.C % gcd != 0)
            throw new InvariantViolationException("Equation has no solutions.");
        
        
        
        throw new NotImplementedException();
    }
}