using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OtusQuadraticSolver
{
    public class QuadraticEquationSolverTests
    {
        private readonly QuadraticEquationSolver _solver = new QuadraticEquationSolver();

        [Fact]
        public void NoRootsTest()
        {
            Assert.Empty(_solver.Solve(1, 0, 1));
        }

        [Fact]
        public void TwoRootsTest()
        {
            Assert.Equal(new double[] { -1, 1 }, _solver.Solve(1, 0, -1));
        }

        [Fact]
        public void OneRootTest()
        {
            Assert.Equal(new double[] { -1 }, _solver.Solve(1, 2, 1));
        }

        [Fact]
        public void ZeroACoefficientTest()
        {
            Assert.Throws<ArgumentException>(() => _solver.Solve(0, 2, 1));
        }

        [Fact]
        public void NonNumericCoefficientsTest()
        {
            Assert.Throws<ArgumentException>(() => _solver.Solve(double.NaN, 2, 1));
            Assert.Throws<ArgumentException>(() => _solver.Solve(double.PositiveInfinity, 2, 1));
            Assert.Throws<ArgumentException>(() => _solver.Solve(double.NegativeInfinity, 2, 1));
        }

    }
}
