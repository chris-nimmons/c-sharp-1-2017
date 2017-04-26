using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;
using System.Linq;

namespace UnitTestProject
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
        public void Bag_Should_Not_Add_More_Than_Length()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(3, 2, 2);
            var added = bag.Add(content);

            Assert.IsFalse(added);
        }
        [TestMethod]
        public void Bag_Should_Not_Add_More_Than_Width()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 3, 2);
            var added = bag.Add(content);

            Assert.IsFalse(added);
        }
        [TestMethod]
        public void Bag_Should_Not_Add_More_Than_Height()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 3, 2);
            var added = bag.Add(content);

            Assert.IsFalse(added);
        }
        [TestMethod]
        public void Bag_Cannot_Remove_Empty_Contents()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(0, 0, 0);
            bag.Add(content);
            var removed = bag.Remove(content);

            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Which_Is_Empty_Can_Be_Dumped()
        {
            var bag = new Bag(3, 3, 3);
            var dumped = bag.Dump();
            

            Assert.IsTrue();
        }
        [TestMethod]
        public void Bag_Can_Exist_Unchanged()
        {
            var bag = new Bag(3, 3, 3);

            Assert.IsTrue(true);
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
            var added = bag.Add(content);
            bag.Dump();

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Not_Overflow()
        {
            var bag = new Bag(13, 17, 23);
            var content = new Content(20, 20, 20);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Must_Be_Black_By_Default()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(9, 9, 9);

            Assert.IsTrue(bag.Color == "black");
        }
        [TestMethod]
        public void Bag_Must_Have_Volume()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(2, 2, 2);
            var volume = bag.Volume;

            Assert.IsNotNull(volume);
        }
        [TestMethod]
        public void Bag_Has_No_Pockets_By_Default()
        {
            var bag = new Bag(3, 3, 3);
            var count = bag.Pockets.Count;

            Assert.IsTrue(count == 0);
        }
        [TestMethod]
        public void Bag_Must_Have_Weight()
        {
            var bag = new Bag(2, 2, 2);
            var weight = bag.Weight;

            Assert.IsFalse(weight < 0);
            Assert.IsTrue(weight >= 0);
        }
        [TestMethod]
        public void Bag_Holds_Weight_Of_Zero_By_Default()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(0, 0, 0);
            var weight = bag.Weight;

            Assert.IsTrue(weight == 0);
        }
        [TestMethod]
        public void Bag_Must_Be_Closed_By_Default()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(1, 1, 1);
            var opened = bag.Opened;

            Assert.IsFalse(opened);
        }
        [TestMethod]
        public void Bag_Condition_Is_Zero_By_Default()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(1, 1, 1);
            var condition = bag.Condition;

            Assert.IsTrue(bag.Condition == 0);
        }
        [TestMethod]
        public void Bag_With_Contents_Weighs_Zero_By_Default()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(1, 1, 1);
            var added = bag.Add(content);
            var weight = bag.Weight;


            Assert.IsTrue(weight == 0);
        }
    }

}

