using System.Numerics;

namespace CMK.HighPrecisionMath
{
    public partial class RationalNumber : IEquatable<RationalNumber>
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }
    }
}
