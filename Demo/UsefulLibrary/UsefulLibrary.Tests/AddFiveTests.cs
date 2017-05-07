using NUnit.Framework;

namespace UsefulLibrary.Tests
{
    [TestFixture]
    public class AddFiveTests
    {
        [Test]
        public void AddsFiveToInteger()
        {
            var expected = 6;
            var input = 1;

            var result = AddFive.ToInt(input);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ConcatsStringWith5()
        {
            var expected = "MamboNumber5";
            var input = "MamboNumber";

            var result = AddFive.ToString(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
