using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesignLecture.Tests
{
    [TestClass]
    public class ContentTests
    {
        [TestMethod]
        public void Content_WeightProperty_ShouldSetToAbsoluteValue()
        {
            var content = new Content(1, 1, 1);
            content.Weight = -5;

            Assert.IsTrue(content.Weight == 5);
        }
    }
}
