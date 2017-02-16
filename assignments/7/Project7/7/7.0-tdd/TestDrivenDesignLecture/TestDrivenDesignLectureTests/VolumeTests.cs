using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture.Tests
{
    [TestClass()]
    public class VolumeTests
    {
        [TestMethod]
        public void Pocket_ShouldAddContent()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);
            var added = pocket.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Pocket_ShouldNotOversizeContent()
        {
            var pocket = new Pocket(13, 17, 23);
            var content = new Content(20, 20, 20);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }
    }
}