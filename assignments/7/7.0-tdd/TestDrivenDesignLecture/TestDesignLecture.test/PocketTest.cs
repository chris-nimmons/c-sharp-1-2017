using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace TestDesignLecture.test
{
    [TestClass]
    public class PocketTest
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
        public void Content_Should_Not_Add_To_Bag1()
        {
            Content content = new Content(6, 3, 3);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag2()
        {
            Content content = new Content(3, 6, 3);
            Bag bag = new Bag(4, 4, 4);
            var add = bag.Add(content);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Bag3()
        {
            Content content = new Content(3, 3, 6);
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
        public void Content_Should_Not_Be_In_Bag1()
        {
            Content content = new Content(6, 3, 3);
            Bag bag = new Bag(4, 4, 4);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Bag2()
        {
            Content content = new Content(3, 6, 3);
            Bag bag = new Bag(4, 4, 4);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Be_In_Bag3()
        {
            Content content = new Content(3, 3, 6);
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

        //[TestMethod]
        //public void Bag_Should_Have_A_Color()
        //{
        //    Bag bag = new Bag(5, 5, 5);
        //    bag.Color = true;

        //    Assert.IsTrue(bag.Color.Equals(true));
        //}

        //[TestMethod]
        //public void Bag_Should_Not_Have_A_Color()
        //{
        //    Bag bag = new Bag(5, 5, 5);
        //    bag.Color = false;

        //    Assert.IsFalse(bag.Color.Equals(true));
        //}

        //[TestMethod]
        //public void Bag_Should_Have_A_Weight()
        //{
        //    Bag bag = new Bag(5, 5, 5);
        //    bag.Weight = 50;

        //    Assert.IsNotNull(bag.Weight);
        //}

        //[TestMethod]
        //public void Bag_Should_Be_In_Excellent_Condition()
        //{
        //    Bag bag = new Bag(4, 4, 4);
        //    bag.Condition = Condition.Excellent;

        //    Assert.AreEqual(bag.Condition, Condition.Excellent);
        //}

        //[TestMethod]
        //public void Bag_Should_Not_Be_In_Excellent_Condition()
        //{
        //    Bag bag = new Bag(4, 4, 4);
        //    bag.Condition = Condition.Poor;
        //    bag.Condition = Condition.Excellent;

        //    Assert.AreNotEqual(Condition.Poor, Condition.Excellent);
        //}

    }
}
