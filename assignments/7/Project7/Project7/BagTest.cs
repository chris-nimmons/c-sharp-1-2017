using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class BagTest
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
            public void Bag_Should_Remove()
            {
                var bag = new Bag(3, 3, 3);
                var content = new Content(1, 1, 1);
                bag.Add(content);
                var removed = bag.Remove(content);

                Assert.IsTrue(removed);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Dump()
            {
                var content = new Content(3, 3, 3);
                var bag = new Bag(4, 4, 4);
                bag.Dump();

                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Not_Add_Oversized_Content()
            {
                var bag = new Bag(13, 17, 23);
                var content = new Content(20, 20, 20);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void One_Bag_Should_Exist_For_Contents()
            {
                var bag = new Bag(0, 0, 0);
                var content = new Content(2, 2, 2);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));

            }
            [TestMethod]
            public void Bag_Should_Have_Volume()
            {
                var bag = new Bag(1, 1, 1);
                var volume = new Volume(0,0,0);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Volume_Should_Be_More_Than_Content()
            {
                var bag = new Bag(2, 2, 2);
                var volume = new Volume(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Be_As_Big_As_Volume()
            {
                var bag = new Bag(1, 1, 1);
                var volume = new Volume(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Volume_Should_Not_Exist_Without_Bag()
            {
                var bag = new Bag(0, 0, 0);
                var volume = new Volume(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Not_Add_Excess_Volume()
            {
                var bag = new Bag(3, 3, 3);
                var volume = new Volume(2, 2, 2);
                var content = new Content(3, 3, 3);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Can_Be_Empty()
            {
                var bag = new Bag(1, 1, 1);
                var volume = new Volume(0, 0, 0);
                var content = new Content(0, 0, 0);
                var added = bag.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(bag.Check(content));
            }
        }

    }

}