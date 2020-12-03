using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {

        private Math _math = new Math();

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnsTheSumOfArguments()
        {
           var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        //NUnit Paramaterized tests
        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnsGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //Non-paramaterized tests
        [Test]
        public void Max_SecondArgumentIsGreater_ReturnsSecondArgument()
        {
            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnsSameArgument()
        {
            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //There is something in the array
            Assert.That(result, Is.Not.Empty);

            //There are the right number of items in the array
            Assert.That(result.Count(), Is.EqualTo(3));

            //There are the correct values in the array
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            //There are only the correct values in the array
            Assert.That(result, Is.EquivalentTo(new[] {1, 3, 5}));

            //The array is ordered or unique
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
