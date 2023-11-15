using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusQuadraticSolver
{
    public class QuadraticEquationSolver
    {
        public double[] Solve(double a, double b, double c, double Epsilon = 1e-10)
        {
            Action<double, bool> checkCoeff = (coeff, zeroAllow) =>
            {
                if (double.IsNaN(coeff) || double.IsInfinity(coeff) || (Math.Abs(coeff) < Epsilon && !zeroAllow))
                    throw new ArgumentException("Houston! We have a problem with coeff!");
            };
            checkCoeff(a, false);
            checkCoeff(b, true);
            checkCoeff(c, true); 

            double discriminant = b * b - 4 * a * c;

            if (discriminant < -Epsilon)
            {
                return new double[0];
            }

            if (Math.Abs(discriminant) <= Epsilon)
            {
                return new double[] { -b / (2 * a) };
            }

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            return new double[]
            {
            (-b - sqrtDiscriminant) / (2 * a),
            (-b + sqrtDiscriminant) / (2 * a)
            };
        }
    }
}
