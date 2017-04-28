using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;
using System.Linq;

namespace UnitTestProject
{

    [TestClass()]
    public class BagTests
    {
        [TestMethod]
        public void Bag_Should_Add_Content()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(1, 1, 1);
            var added = bag.Add(content);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Can_Add_Multiple_Content()
        {
            var bag = new Bag(4, 4, 4);
            var content = new Content(1, 1, 1);
            var content2 = new Content(2, 2, 2);
            var added = bag.Added(content, content2);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
            Assert.IsTrue(bag.Check(content2));
        }
        [TestMethod]
        public void Bag_Contents_Must_Both_Be_Small_Enough_To_Fit()
        {
            var bag = new Bag(4, 4, 4);
            var content = new Content(3,3,3);
            var content2 = new Content(5, 5, 5);
            var added = bag.Added(content, content2);

            Assert.IsFalse(added);
            Assert.IsTrue(bag.Check(content));
            Assert.IsFalse(bag.Check(content2));
        }
        [TestMethod]
        public void Bag_Cannot_Add_Excess_Content_Length()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(3, 2, 2);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Cannot_Add_Excess_Content_Width()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 3, 2);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Cannot_Add_Excess_Content_Height()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 2, 3);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Remove_Content()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(1, 1, 1);
            bag.Add(content);
            var removed = bag.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Can_Dump_Multiple_Contents()
        {
            var bag = new Bag(4, 4, 4);
            var content = new Content(3, 3, 3);
            var content2 = new Content(1, 1, 1);
            var added = bag.Added(content, content2);
            bag.Dump();

            Assert.IsTrue(added);
            Assert.IsFalse(bag.Check(content));
            Assert.IsFalse(bag.Check(content2));
        }
        [TestMethod]
        public void Bag_Should_Not_Remove_Nothing()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(0, 0, 0);
            var removed = bag.Remove(content);

            Assert.IsFalse(removed);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Which_Is_Over_Filled_Can_Be_Dumped()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(4, 4, 4);
            bag.Add(content);
            bag.Dump();

            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Dump_Content()
        {
            var bag = new Bag(4, 4, 4);
            var content = new Content(3, 3, 3);
            bag.Add(content);
            bag.Dump();

            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Not_Have_Overflow_Content()
        {
            var bag = new Bag(13, 17, 23);
            var content = new Content(20, 20, 24);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
    }

}

