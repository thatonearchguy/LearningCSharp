using System;
using NUnit.Framework;
using static Code.Iteration.Week3Iteration;

namespace Testing.Iteration
{
    class IterationTesting
    {
        [Test]
        public void TriangularTest()
        {
            Assert.AreEqual(Triangular(6), 21);
            Assert.AreEqual(Triangular(12), 78);
        }
        [Test]
        public void ISBNTest()
        {
            Assert.AreEqual(ISBN("030?406152"), 6);
            Assert.AreEqual(ISBN("0?06406152"), 3);
        }
        //Rest of the functions are either non quiet so untestable or in the case of Count Von Count I don't know if it's actually a correct solution. 
    }
}
