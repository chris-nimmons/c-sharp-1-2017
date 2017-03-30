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
                var content2 = new Content(0,0,0);
                var bag = new Bag(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = bag.Add(content, content2);

                Assert.IsTrue(added);
                Assert.IsTrue(bag.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Remove()
            {
                var content2 = new Content(0, 0, 0);
                var bag = new Bag(3, 3, 3);
                var content = new Content(1, 1, 1);
                bag.Add(content, content2);
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
                var content2 = new Content(0, 0, 0);
                var bag = new Bag(13, 17, 23);
                var content = new Content(20, 20, 20);
                var added = bag.Add(content, content2);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));
            }
            [TestMethod]
            public void One_Bag_Should_Exist_For_Contents()
            {
                var content2 = new Content(0, 0, 0);
                var bag = new Bag(0, 0, 0);
                var content = new Content(2, 2, 2);
                var added = bag.Add(content, content2);

                Assert.IsFalse(added);
                Assert.IsFalse(bag.Check(content));

            }
            [TestMethod]
            public void Bag_Should_Not_Add_Oversized()
            {

                var bag = new Bag(3, 3, 3);
                var content = new Content(2,2,2);
                var content2 = new Content(2,2,2);
                var added = bag.Add(content, content2);
                

                Assert.IsFalse(added);
                Assert.IsTrue(bag.Check(content));
                Assert.IsFalse(bag.Check(content2));
            }
        }

    }

}