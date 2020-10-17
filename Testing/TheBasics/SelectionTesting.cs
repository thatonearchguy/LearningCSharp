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
        [Test]
        public static void QuadrantCircleTest()
        {
            Assert.AreEqual(QuadrantCircle(1, 1, 0, 0, 0, 1), 1);
            Assert.AreEqual(QuadrantCircle(-3, -79, 0, 0, 0, 1), 3);
            Assert.AreEqual(QuadrantCircle(3, 0, 3, 0, 0, 2), 1);
            Assert.AreEqual(QuadrantCircle(5, 2, 3, 2, 2, 3), 1);
        }
        [Test]
        public static void StudentGradeTest()
        {
            Assert.AreEqual(StudentGrade(10, 10, 10), "F");
            Assert.AreEqual(StudentGrade(90, 0, 90), "C");
            Assert.AreEqual(StudentGrade(85, 100, 95), "A*");
        }
        [Test]
        public static void TriangleTest()
        {
            Assert.AreEqual(Triangle(3, 3, 3), "Equilateral");
            Assert.AreEqual(Triangle(4, 3, 4), "Isosceles");
            Assert.AreEqual(Triangle(4, 3, 10), "Impossible");
        }
    }
}