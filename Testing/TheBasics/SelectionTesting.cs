using System;
using NUnit.Framework;
using static Code.TheBasics.Week2Selection;

namespace Testing.TheBasics
{
    public class SelectionTesting
    {
        [Test]
        public static void IsEqualTest()
        {
            Assert.AreEqual(IsEqual(3, 3), true);
            Assert.AreEqual(IsEqual(0, -1), false);
        }
        [Test]
        public static void IsEvenTest()
        {
            Assert.AreEqual(IsEven(2), true);
            Assert.AreEqual(IsEven(123456), true);
        }
        [Test]
        public static void IsLeapYearTest()
        {
            Assert.AreEqual(IsLeapYear(2020), true);
            Assert.AreEqual(IsLeapYear(2022), false);
            Assert.AreEqual(IsLeapYear(0), true);
        }
        [Test]
        public static void GreatestThreeTest()
        {
            Assert.AreEqual(GreatestThree(2, 5, 3), 5);
            Assert.AreEqual(GreatestThree(234, 546, 78788), 78788);
            Assert.AreEqual(GreatestThree(0, 0, 1), 1);
        }
    }
}