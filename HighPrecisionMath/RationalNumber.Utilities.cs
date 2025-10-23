using System.Globalization;
using System.Numerics;

namespace CMK.HighPrecisionMath
{
    public partial class RationalNumber
    {
        private static (BigInteger numerator, BigInteger denominator) Normalize(BigInteger numerator, BigInteger denominator)
        {
            if (denominator.IsZero)
                throw new ArgumentException("Denominator cannot be zero.");

            BigInteger gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;

            if (denominator.Sign < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            return (numerator, denominator);
        }

        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return BigInteger.Abs(a);
        }

        public decimal Value => BigIntegerToDecimal(Numerator, Denominator);

        public decimal GetValue(int digits)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits));
            BigInteger factor = BigInteger.Pow(10, digits);
            BigInteger scaled = (Numerator * factor) / Denominator;
            return (decimal)scaled / (decimal)factor;
        }

        public RationalNumber Truncate(int digits)
        {
            decimal factor = (decimal)Math.Pow(10, digits);
            decimal truncated = Math.Truncate(Value * factor) / factor;
            return new RationalNumber(truncated);
        }

        public RationalNumber Invert() => new RationalNumber(Denominator, Numerator);

        public static RationalNumber Min(RationalNumber a, RationalNumber b) => a.Value <= b.Value ? a : b;
        public static RationalNumber Max(RationalNumber a, RationalNumber b) => a.Value >= b.Value ? a : b;

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

        private static decimal BigIntegerToDecimal(BigInteger numerator, BigInteger denominator)
        {
            int numeratorDigits = (int)BigInteger.Log10(BigInteger.Abs(numerator)) + 1;
            int denominatorDigits = (int)BigInteger.Log10(BigInteger.Abs(denominator)) + 1;

            int allowedDigits = 28;
            int reduction = Math.Max(Math.Max(numeratorDigits - allowedDigits, 0), Math.Max(denominatorDigits - allowedDigits, 0));

            numerator /= BigInteger.Pow(10, reduction);
            denominator /= BigInteger.Pow(10, reduction);

            return (decimal)numerator / (decimal)denominator;
        }
    }
}
