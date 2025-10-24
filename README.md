**HighPrecisionMath**

HighPrecisionMath is a lightweight, high-precision arithmetic library for .NET, providing a RationalNumber type built on BigInteger. It allows exact fractional calculations, avoiding the precision issues of standard floating-point and decimal types.

### Features

Arbitrary-precision rational numbers using BigInteger.

Fractional arithmetic: addition, subtraction, multiplication, division.

Comparison operators: <, >, <=, >=, ==, !=.

Conversion to decimal with configurable precision.

Optional exact fraction display (numerator/denominator).

Predefined constants like Zero, One, and high-precision approximation of Pi.

Unit tests with xUnit for reliability.

Designed for both scientific calculations and financial applications.

### Installation

Clone the repository:

git clone https://github.com/cmk1988/HighPrecisionMath.git


Or include it as a submodule in your project:

git submodule add https://github.com/cmk1988/HighPrecisionMath.git

### Usage
Creating Rational Numbers
using HighPrecisionMath;
using System.Numerics;

// Using integers
var a = new RationalNumber(1, 2); // 1/2
var b = new RationalNumber(3, 4); // 3/4

// Using decimals
var c = new RationalNumber(0.75m); // 3/4

### Arithmetic
var sum = a + b;        // 5/4
var diff = b - a;       // 1/4
var product = a * b;    // 3/8
var quotient = a / b;   // 2/3

### Comparison
if (a < b) { /* ... */ }
if (b >= a) { /* ... */ }

### Conversion
decimal value = sum.Value;             // Approximate decimal value
string fraction = sum.ToString(true);  // Exact fraction "5/4"

### Constants
var zero = RationalNumber.Zero;
var one = RationalNumber.One;
var pi = RationalNumber.Pi(); // High-precision approximation

### Testing

Unit tests are implemented with xUnit. To run tests:

dotnet test


Tests cover arithmetic, comparison, conversion, and edge cases.

### Contributing

Contributions are welcome! Please fork the repo, make your changes, and submit a pull request.

Ensure new code is covered by tests.

Follow existing coding style.

### License

This project is licensed under the MIT License. See the LICENSE
 file for details.
Advanced functions: power, roots, logarithms

Extended fraction formatting options
