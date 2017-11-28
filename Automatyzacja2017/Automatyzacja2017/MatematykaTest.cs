using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Automatyzacja2017
{
    public class MatematykaTest
    {
        [Fact]
        public void Method_add_returns_sum_of_given_values()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.Add(10, 20);
            // assert
            Assert.Equal(30, result);
        }
        [Fact]
        public void Method_add_returns_sum_of_given_values_one_negativ()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.Add(-10, 20);
            // assert
            Assert.Equal(10, result);
        }
        [Fact]
        public void Method_subtraction_returns_sub_of_given_values()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.subtraction(10, 20);
            // assert
            Assert.Equal(-10, result);
        }
        [Fact]
        public void Method_subtraction_returns_subtraction_of_given_values_one_negativ()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.subtraction(-10, 20);
            // assert
            Assert.Equal(-30, result);
        }
        [Fact]
        public void Method_multiplication_returns_multi_of_given_values()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.multiplication(10, 20);
            // assert
            Assert.Equal(200, result);
        }
        [Fact]
        public void Method_multiplication_returns_multiplication_of_given_values_one_negativ()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.multiplication(-10, 20);
            // assert
            Assert.Equal(-200, result);
        }
        [Fact]
        public void Method_division_returns_div_of_given_values()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.division(10, 20);
            // assert
            Assert.Equal(0.5, result);
        }
        [Fact]
        public void Method_division_returns_div_of_given_values_one_negativ()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.division(-10, 20);
            // assert
            Assert.Equal(0.5, result);
        }
        [Fact]
        public void Method_division_returns_div_of_given_values_second_zero()
        {
            // arrange
            var math = new Matematyka();
            // act
            double result = math.division(-10, 0);
            // assert
            Assert.Equal(Double.MaxValue, result);
        }
    }
}
