using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class PocketTest
    {
        [TestMethod]
        public void TestMethod1()
        { }[TestClass()]
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
            [TestMethod]
            public void Pocket_Should_Not_Be_Too_Small()
            {
                var pocket = new Pocket(1, 1, 1);
                var content = new Content(1, 2, 1);
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
                var pocket = new Pocket(2, 2, 2);
                var volume = new Volume(1, 1, 1);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsTrue(added);

            }
            [TestMethod]
            public void Pocket_Can_Overflow()
            {
                var pocket = new Pocket(3, 3, 3);
                var volume = new Volume(4, 4, 4);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsTrue(added);
            }
            [TestMethod]
            public void Pocket_Can_Contain_Nothing()
            {
                var pocket = new Pocket(3, 3, 3);
                var volume = new Volume(0, 0, 0);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsTrue(added);
            }
        }

    }

}

