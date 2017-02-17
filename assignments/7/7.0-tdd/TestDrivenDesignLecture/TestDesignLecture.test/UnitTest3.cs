using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace TestDesignLecture.test
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Contents_Should_Add_To_Pocket()
        {
            Content content = new Content(1, 1, 1 );
            Pocket pocket = new Pocket(2, 2, 2);
            var add = pocket.Add(content);

            Assert.IsTrue(pocket.Check(content));
        }

        [TestMethod]
        public void Contents_Should_Not_Add_To_Pocket()
        {
            Content content = new Content(2, 2, 2);
            Pocket pocket = new Pocket(1, 1, 1);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Contents_Should_Not_Add_To_Pocket1()
        {
            Content content = new Content(3, 1, 1);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Contents_Should_Not_Add_To_Pocket2()
        {
            Content content = new Content(1, 3, 1);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Contents_Should_Not_Add_To_Pocket3()
        {
            Content content = new Content(1, 1, 3);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Contents_Should_Remove_From_Pocket()
        {
            Content content = new Content(1, 1, 1);
            Pocket pocket = new Pocket(2, 2, 2);
            var add = pocket.Add(content);
            var remove = pocket.Remove(content);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Remove_From_Pocket()
        {
            Content content = new Content(2, 2, 2);
            Pocket pocket = new Pocket(4, 4, 4);
            var remove = pocket.Remove(content);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Be_In_Pocket()
        {
            Content content = new Content(2, 2, 2);
            Pocket pocket = new Pocket(4, 4, 4);

            pocket.Check(content);
            Assert.IsNotNull(pocket);
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Pocket()
        {
            Content content = new Content(4, 4, 4);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Pocket1()
        {
            Content content = new Content(4, 1, 1);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Pocket2()
        {
            Content content = new Content(1, 4, 1);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Pocket3()
        {
            Content content = new Content(1, 1, 4);
            Pocket pocket = new Pocket(2, 2, 2);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Dump_From_Pocket()
        {
            Content content = new Content(2, 2, 2);
            Pocket pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);

            Equals(pocket.Dump());
        }

        [TestMethod]
        public void Content_Should_Not_Dump_From_Pocket()
        {
            Content content = new Content(4, 4, 4);
            Pocket pocket = new Pocket(2, 2, 2);
            var add = pocket.Add(content);

            Assert.IsFalse(pocket.Check(content));
        }
    }
}
