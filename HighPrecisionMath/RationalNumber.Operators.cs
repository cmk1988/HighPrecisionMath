using System.Numerics;

namespace CMK.HighPrecisionMath
{
    public partial class RationalNumber
    {
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            BigInteger commonDenominator = a.Denominator * b.Denominator;
            BigInteger numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            return new RationalNumber(numerator, commonDenominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            BigInteger commonDenominator = a.Denominator * b.Denominator;
            BigInteger numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            return new RationalNumber(numerator, commonDenominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (b == Zero) throw new DivideByZeroException();
            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static implicit operator RationalNumber(decimal value) => new RationalNumber(value);
        public static implicit operator RationalNumber(int value) => new RationalNumber(value, 1);
        public static implicit operator RationalNumber(long value) => new RationalNumber(value, 1);


        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b) => !(a == b);

        public int CompareTo(RationalNumber other)
        {
            if (other is null) return 1; // null < this
            return (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
        }

        public static bool operator <(RationalNumber a, RationalNumber b) => a.CompareTo(b) < 0;

        public static bool operator >(RationalNumber a, RationalNumber b) => a.CompareTo(b) > 0;

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return a < b || a == b;
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return a > b || a == b;
        }

        public override bool Equals(object? obj) => Equals(obj as RationalNumber);

        public bool Equals(RationalNumber? other)
        {
            return Numerator == other?.Numerator && Denominator == other?.Denominator;
        }

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
    }
}
