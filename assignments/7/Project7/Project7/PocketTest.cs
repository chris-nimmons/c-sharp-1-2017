using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace UnitTestProject
{
    [TestClass]
    public class PocketTest
    {
        [TestClass()]
        public class PocketTests
        {
            [TestMethod]
            public void Pocket_Should_Remove()
            {
                var content2 = new Content(0, 0, 0);
                var pocket = new Pocket(3, 3, 3);
                var content = new Content(1, 1, 1);
                pocket.Add(content, content2);
                var removed = pocket.Remove(content);

                Assert.IsTrue(removed);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Remove()
            {
                var content2 = new Content(0, 0, 0);
                var pocket = new Pocket(3, 3, 3);
                var content = new Content(1, 1, 1);
                pocket.Add(content, content2);
                var removed = pocket.Remove(content);

                Assert.IsTrue(removed);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Dump()
            {
                var content = new Content(3, 3, 3);
                var pocket = new Bag(4, 4, 4);
                pocket.Dump();

                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Bag_Should_Not_Add_Oversized_Content()
            {
                var content2 = new Content(0, 0, 0);
                var pocket = new Pocket(13, 17, 23);
                var content = new Content(20, 20, 20);
                var added = pocket.Add(content, content2);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void One_Bag_Should_Exist_For_Contents()
            {
                var content2 = new Content(0, 0, 0);
                var pocket = new Pocket(0, 0, 0);
                var content = new Content(2, 2, 2);
                var added = pocket.Add(content, content2);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));

            }
            [TestMethod]
            public void Bag_Should_Not_Add_Oversized()
            {

                var pocket = new Pocket(3, 3, 3);
                var content = new Content(2, 2, 2);
                var content2 = new Content(2, 2, 2);
                var added = pocket.Add(content, content2);


                Assert.IsFalse(added);
                Assert.IsTrue(pocket.Check(content));
                Assert.IsFalse(pocket.Check(content2));
            }

        }

    }

}