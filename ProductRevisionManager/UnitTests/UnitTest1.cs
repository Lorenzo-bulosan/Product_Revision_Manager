using NUnit.Framework;
using BussinessManager;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int result = Program.Test();
            Assert.AreEqual(0, result);
        }
    }
}