using CMK.HighPrecisionMath;
using System.Numerics;

namespace HighPrecisionMathTests
{
    public class RationalNumberTests
    {
        [Fact]
        public void Constructor_BigIntegerValues_Normalizes()
        {
            var r = new RationalNumber(4, 6); // sollte gekürzt werden zu 2/3
            Assert.Equal(new BigInteger(2), r.Numerator);
            Assert.Equal(new BigInteger(3), r.Denominator);
        }

        [Fact]
        public void Constructor_DecimalValue_CreatesCorrectFraction()
        {
            var r = new RationalNumber(0.75m); // 3/4
            Assert.Equal(new BigInteger(3), r.Numerator);
            Assert.Equal(new BigInteger(4), r.Denominator);
        }

        [Fact]
        public void Addition_Works()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(1, 3);
            var sum = a + b;
            Assert.Equal(new RationalNumber(5, 6), sum);
        }

        [Fact]
        public void Subtraction_Works()
        {
            var a = new RationalNumber(3, 4);
            var b = new RationalNumber(1, 2);
            var diff = a - b;
            Assert.Equal(new RationalNumber(1, 4), diff);
        }

        [Fact]
        public void Multiplication_Works()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(3, 4);
            var product = a * b;
            Assert.Equal(new RationalNumber(1, 2), product);
        }

        [Fact]
        public void Division_Works()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(4, 5);
            var quotient = a / b;
            Assert.Equal(new RationalNumber(5, 6), quotient);
        }

        [Fact]
        public void Comparisons_Work()
        {
            var a = new RationalNumber(1, 2);
            var b = new RationalNumber(2, 4);
            var c = new RationalNumber(3, 4);

            Assert.True(a == b);
            Assert.False(a != b);
            Assert.True(a < c);
            Assert.True(c > a);
            Assert.True(a <= b);
            Assert.True(c >= b);
        }

        [Fact]
        public void Constants_Work()
        {
            var zero = RationalNumber.Zero;
            var one = RationalNumber.One;
            var pi = RationalNumber.Pi;

            Assert.Equal(0, zero.Numerator);
            Assert.Equal(1, zero.Denominator);

            Assert.Equal(1, one.Numerator);
            Assert.Equal(1, one.Denominator);

            Assert.True(pi.Numerator > 3 * pi.Denominator); // π > 3
        }

        [Fact]
        public void DecimalConversion_Works()
        {
            var r = new RationalNumber(3, 4);
            decimal val = r.Value;
            Assert.Equal(0.75m, val);
        }
    }
}