using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace TestDesignLecture.test
{
    [TestClass]
    public class BagTest
    {
        [TestMethod]
        public void Content_Should_Add_To_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var add = bag.Add(content);

            Assert.IsTrue(add);
            Assert.IsTrue(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag_Because_It_Doesnt_Fit()
        {
            Content content = new Content(6, 6, 6);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag_Because_Its_Too_Long()
        {
            Content content = new Content(6, 3, 3);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag_Because_Its_Too_Wide()
        {
            Content content = new Content(3, 6, 3);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag_Because_Its_Too_Tall()
        {
            Content content = new Content(3, 3, 6);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Remove_From_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var add = bag.Add(content);
            var remove = bag.Remove(content);

            Assert.IsTrue(remove);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Remove_From_Bag_Because_Its_Empty()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var remove = bag.Remove(content);

            Assert.IsFalse(bag.Check(content));
        }


        [TestMethod]
        public void Content_Should_Dump_From_Bag()
        {
            Content content = new Content(4, 4, 4);
            Bag bag = new Bag(6, 6, 6);
            var add = bag.Add(content);
            bag.Dump();

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]

        public void Bag_Should_Add_Multiple_Content()
        {
            Content content = new Content(4, 4, 4);
            Content content2 = new Content(2, 2, 2);
            Bag bag = new Bag(8, 8, 8);
            var add = bag.Added(content, content2);

            Assert.IsTrue(bag.Check(content)); 
        }

        public void Bag_Should_Not_Be_Able_To_Add_Content_Because_Its_Full()
        {
            Content content = new Content(4, 4, 4);
            Content content2 = new Content(2, 2, 2);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Added(content, content2);

            Assert.IsFalse(bag.Check(content));
        }
    }
}
