using NUnit.Framework;

namespace WikipediaAutomation.Tests
{
    [TestFixture]
    public class TextProcessingTests
    {
        [Test]
        public void TestProcessText()
        {
            string input = "Test-first manual. Code [4]";
            var result = Program.ProcessText(input);

            Assert.AreEqual(1, result["test"]);
            Assert.AreEqual(1, result["first"]);
            Assert.AreEqual(1, result["manual"]);
            Assert.AreEqual(1, result["code"]);
            Assert.IsFalse(result.ContainsKey("[4]"));
        }
    }
}
