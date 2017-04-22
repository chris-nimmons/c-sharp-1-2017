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
            public void Pocket_Should_Add_Content()
            {
                var pocket = new Bag(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Remove()
            {
                var pocket = new Pocket(3, 3, 3);
                var content = new Content(1, 1, 1);
                pocket.Add(content);
                var removed = pocket.Remove(content);

                Assert.IsTrue(removed);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Dump()
            {
                var content = new Content(3, 3, 3);
                var pocket = new Bag(4, 4, 4);
                pocket.Dump();

                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Not_Add_Oversized_Content()
            {
                var pocket = new Pocket(13, 17, 23);
                var content = new Content(20, 20, 20);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void One_Pocket_Should_Exist_For_Contents()
            {
                var pocket = new Pocket(0, 0, 0);
                var content = new Content(2, 2, 2);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));

            }
            [TestMethod]
            public void Pocket_Should_Have_Volume()
            {
                var pocket = new Pocket(1, 1, 1);
                var volume = new Volume(0, 0, 0);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Volume_Should_Be_More_Than_Content()
            {
                var pocket = new Pocket(2, 2, 2);
                var volume = new Volume(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Be_As_Big_As_Volume()
            {
                var pocket = new Pocket(1, 1, 1);
                var volume = new Volume(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Volume_Should_Not_Exist_Without_Pocket()
            {
                var pocket = new Pocket(0, 0, 0);
                var volume = new Volume(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Not_Add_Excess_Volume()
            {
                var pocket = new Pocket(3, 3, 3);
                var volume = new Volume(2, 2, 2);
                var content = new Content(3, 3, 3);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Can_Be_Empty()
            {
                var pocket = new Pocket(1, 1, 1);
                var volume = new Volume(0, 0, 0);
                var content = new Content(0, 0, 0);
                var added = pocket.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(pocket.Check(content));
            }
        }

    }

}