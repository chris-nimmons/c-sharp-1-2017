using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace UnitTestProject
{

    [TestClass()]
    public class PocketTests
    {
        [TestMethod]
        public void Pocket_Can_Have_Zero_Content()
        {
            var pocket = new Pocket(2, 2, 2);

            Assert.IsNotNull(pocket);
        }
        [TestMethod]
        public void Pocket_Should_Add_Content()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(1, 1, 1);
            var added = pocket.Add(content);

            Assert.IsTrue(added);
            Assert.IsTrue(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Can_Add_Multiple_Content()
        {
            var pocket = new Pocket(4, 4, 4);
            var content = new Content(1, 1, 1);
            var content2 = new Content(2, 2, 2);
            var added = pocket.Added(content, content2);

            Assert.IsTrue(added);
            Assert.IsTrue(pocket.Check(content));
            Assert.IsTrue(pocket.Check(content2));
        }
        [TestMethod]
        public void Pocket_Contents_Must_Both_Be_Small_Enough_To_Fit()
        {
            var pocket = new Pocket(4, 4, 4);
            var content = new Content(3, 3, 3);
            var content2 = new Content(5, 5, 5);
            var added = pocket.Added(content, content2);

            Assert.IsFalse(added);
            Assert.IsTrue(pocket.Check(content));
            Assert.IsFalse(pocket.Check(content2));
        }
        [TestMethod]
        public void Pocket_Cannot_Add_Excess_Content_Length()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(3, 2, 2);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Cannot_Add_Excess_Content_Width()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 3, 2);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Cannot_Add_Excess_Content_Height()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 2, 3);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Should_Remove_Content()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(1, 1, 1);
            pocket.Add(content);
            var removed = pocket.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Should_Not_Remove_Nothing()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(0, 0, 0);
            var removed = pocket.Remove(content);

            Assert.IsFalse(removed);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Can_Dump_Multiple_Contents()
        {
            var pocket = new Pocket(4, 4, 4);
            var content = new Content(3, 3, 3);
            var content2 = new Content(1, 1, 1);
            var added = pocket.Added(content, content2);
            pocket.Dump();

            Assert.IsTrue(added);
            Assert.IsFalse(pocket.Check(content));
            Assert.IsFalse(pocket.Check(content2));
        }
        [TestMethod]
        public void Pocket_Which_Is_Over_Filled_Can_Be_Dumped()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(4, 4, 4);
            pocket.Add(content);
            pocket.Dump();

            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Should_Dump_Content()
        {
            var content = new Content(3, 3, 3);
            var pocket = new Pocket(4, 4, 4);
            pocket.Add(content);
            pocket.Dump();

            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Should_Not_Add_Oversized_Content()
        {
            var pocket = new Pocket(13, 17, 23);
            var content = new Content(20, 20, 24);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }


    }

}

