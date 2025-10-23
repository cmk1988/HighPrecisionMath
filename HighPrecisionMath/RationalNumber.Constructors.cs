using System.Numerics;

namespace CMK.HighPrecisionMath
{
    public partial class RationalNumber
    {
        public RationalNumber(long numerator, long denominator)
        {
            (Numerator, Denominator) = Normalize(numerator, denominator);
        }

        public RationalNumber(BigInteger numerator, BigInteger denominator)
        {
            (Numerator, Denominator) = Normalize(numerator, denominator);
        }

        public RationalNumber(decimal value)
        {
            int[] bits = decimal.GetBits(value);
            int decimalPlaces = (bits[3] >> 16) & 0x000000FF;
            BigInteger factor = BigInteger.Pow(10, decimalPlaces);
            BigInteger numerator = (BigInteger)(value * (decimal)factor);
            BigInteger denominator = factor;

            (Numerator, Denominator) = Normalize(numerator, denominator);
        }

        public RationalNumber(RationalNumber numerator, RationalNumber denominator)
        {
            if (denominator == Zero) throw new DivideByZeroException();
            RationalNumber result = numerator / denominator;
            Numerator = result.Numerator;
            Denominator = result.Denominator;
        }
    }
}
