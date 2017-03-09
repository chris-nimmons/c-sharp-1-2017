using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

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
            }
            [TestMethod]
            public void Bag_Should_Not_Oversize_Content()
            {
                var bag = new Bag(13, 17, 23);
                var content = new Content(20, 20, 20);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Not_Be_Too_Small()
            {
                var bag = new Bag(1, 1, 1);
                var volvume = new Volume(0, 1, 0);
                var content = new Content(1, 2, 1);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void One_Bag_Should_Exist_For_Contents()
            {
                var bag = new Bag(0, 0, 0);
                var volume = new Volume(3, 3, 3);
                var content = new Content(2, 2, 2);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));

            }
            [TestMethod]
            public void Bag_Should_Have_Volume()
            {
                var bag = new Bag(2, 2, 2);
                var volume = new Volume(1, 1, 1);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsTrue(added);

            }
            [TestMethod]
            public void Bag_Can_Overflow()
            {
                var bag = new Bag(3, 3, 3);
                var volume = new Volume(4, 4, 4);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsTrue(added);
            }
            [TestMethod]
            public void Bag_Can_Contain_Nothing()
            {
                var bag = new Bag(3, 3, 3);
                var volume = new Volume(0, 0, 0);
                var content = new Content(0, 0, 0);
                var added = bag.Add(content);

                Assert.IsTrue(added);
            }
            [TestMethod]
            public void Bag_Can_Be_Too_Big()
            {
                var bag = new Bag(3, 3, 3);
                var volume = new Volume(20, 20, 20);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content);

                Assert.IsTrue(added);
            }
            [TestMethod]
            public void Bag_Should_Have_Pockets()
            {
                var bag = new Bag(3, 3, 3);
                var volume = new Volume(20, 20, 20);
                var content = new Content(1, 1, 1);
                var pocket = new Pocket(2, 1, 1);
                var added = bag.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Not_Be_Too_Heavy()
            {
                var bag = new Bag(30, 30, 30);
                var volume = new Volume(20, 20, 20);
                var content = new Content(30,30, 30);
                var pocket = new Pocket(2, 1, 1);
                var added = bag.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }

        }

    }

}