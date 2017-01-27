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
    public class PocketTests
    {
        [TestMethod]
        public void Pocket_Should_Add_Content()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(1, 1, 1);
            var added = pocket.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Pocket_Should_Not_Oversize_Content()
        {
            var pocket = new Pocket(13, 17, 23);
            var content = new Content(20, 20, 20);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }
    }
}