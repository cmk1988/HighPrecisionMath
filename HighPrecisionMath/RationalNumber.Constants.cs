using System.Numerics;

namespace CMK.HighPrecisionMath
{
    public partial class RationalNumber
    {
        public static RationalNumber Zero { get; } = new RationalNumber(0, 1);
        public static RationalNumber One { get; } = new RationalNumber(1, 1);

        public static RationalNumber Pi { get; } = new RationalNumber(
            BigInteger.Parse("314159265358979323846264338327950288419716939937510"),
            BigInteger.Pow(10, 50)
        );

        public static RationalNumber E { get; } = new RationalNumber(
            BigInteger.Parse("271828182845904523536028747135266249775724709369995"),
            BigInteger.Pow(10, 50)
        );

        public static RationalNumber Two { get; } = new RationalNumber(2, 1);
        public static RationalNumber Half { get; } = new RationalNumber(1, 2);
    }
}
