using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace TestDesignLecture.test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Content_Should_Add_To_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var add = bag.Add(content);

            Assert.IsTrue(bag.Check(content));
            
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag()
        {
            Content content = new Content(6, 6, 6);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Remove_From_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var add = bag.Add(content);
            var remove = bag.Remove(content);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Remove_From_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var remove = bag.Remove(content);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Be_In_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);

            bag.Check(content);
            Assert.IsNotNull(bag);
            
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Bag()
        {
            Content content = new Content(6, 6, 6);
            Bag bag = new Bag(4, 4, 4);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Dump_From_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var add = bag.Add(content);

            Equals(bag.Dump());
        }

        [TestMethod]
        public void Content_Should_Not_Dump_From_Bag()
        {
            Content content = new Content(6, 6, 6);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(bag.Check(content));
        }
    }
}
