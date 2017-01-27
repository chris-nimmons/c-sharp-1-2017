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
    public class BagTests
    {
        [TestMethod()]
        public void Bag_Should_Add()
        {
            var content = new Content(1, 1, 1);
            var bag = new Bag(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Bag_Should_Not_Add_Oversized_Content()
        {
            var content = new Content(6, 6, 17);
            var bag = new Bag(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
    }
}