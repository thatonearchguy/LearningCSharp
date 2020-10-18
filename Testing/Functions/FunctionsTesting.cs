using NUnit.Framework;
using System;
using static Code.Functions.Week3Functions;

namespace Testing.Functions
{
    public class FunctionsTesting
    {
        [Test]
        public static void SumTest()
        {
            Assert.AreEqual(Sum(3, 4), 7);
            Assert.AreEqual(Sum(4, 4), 8);
        }
        [Test]
        public static void SumDigitsTest()
        {
            Assert.AreEqual(SumDigits(32456239), 34);
            Assert.AreEqual(SumDigits(303), 6);
        }
        [Test]
        public static void IsPrimeTest()
        {
            Assert.AreEqual(IsPrime(7883), true);
            Assert.AreEqual(IsPrime(102013), true);
            Assert.AreEqual(IsPrime(104729), true);
        }
        [Test]
        public static void SpacesTest()
        {
            Assert.AreEqual(Spaces("T h  i s is a STRANGE test st r    i n g"), 16);
            Assert.AreEqual(Spaces("          "), 10);
            Assert.AreEqual(Spaces("%%^^£$24594@@@   271  37"), 5); 
        }
        [Test]
        public static void BinaryHexTest()
        {
            Assert.AreEqual(BinaryHex(26), "Bin: 11010, Hex: 1A");
            Assert.AreEqual(BinaryHex(35), "Bin: 100011, Hex: 23");
        }
    }
}