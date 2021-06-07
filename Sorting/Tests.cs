using System;
using System.Linq;
using NUnit.Framework;

namespace Sorting
{
    [TestFixture]
    public class Tests
    {

        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(200000)]
        [TestCase(3000000)]
        public void RightLengthArrayInGeneratorArraysTest(long expectedLengthArray)
        {
            var generator = new GeneratorArrays(expectedLengthArray, 2);
            var array = generator.GenerateArray();
            Assert.AreEqual(expectedLengthArray, array.Length);
        }

        [TestCase(10000)]
        [TestCase(400000)]
        [TestCase(900000)]
        public void RightLengthStrInArrayInGeneratorArraysTest(long expectedLengthStr)
        {
            var generator = new GeneratorArrays(1, expectedLengthStr);
            var str = generator.GenerateArray()[0];
            Assert.AreEqual(expectedLengthStr, str.Length);
        }
        
        [Test]
        public void SortTest()
        {
            var expectedArray = new string[] {"a", "b", "c", "d", "e", "f"};
            var unsortedArray = new string[] {"f", "c", "a", "e", "b", "d"};
            var sorter = new Sorter(unsortedArray);
            sorter.Sorted();
            Assert.IsTrue(expectedArray.SequenceEqual(unsortedArray));
        }
        
    }
}