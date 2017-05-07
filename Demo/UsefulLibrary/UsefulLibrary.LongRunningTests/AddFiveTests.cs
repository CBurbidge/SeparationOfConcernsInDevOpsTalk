using NUnit.Framework;

namespace UsefulLibrary.LongRunningTests
{
    [TestFixture]
    public class AddFiveTests
    {
        [Test]
        public void TestWithWait()
        {
            var expected = "MamboNumber5";
            var input = "MamboNumber";

            var result = AddFive.WithWait(input);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
