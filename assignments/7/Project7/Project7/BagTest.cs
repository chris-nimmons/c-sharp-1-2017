using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;
using System.Linq;

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
                Assert.IsTrue(bag.Check(content));
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
                bag.Dump();
                var dumped = bag.Dump();

                Assert.IsFalse(bag.Check(content));
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
            public void Bag_Can_Not_Be_Equal_To_Content()
            {
                var bag = new Bag(4, 4, 4);
                var content = new Content(4, 4, 4);

                Assert.IsFalse(bag.Equals(content));
            }
            [TestMethod]
            public void Bag_Must_Be_Black_By_Default()
            {
                var bag = new Bag(3, 3, 3);
                var content = new Content(9, 9, 9);
                var color = bag.Color;

                Assert.IsTrue(color == "black");
                Assert.IsFalse(color != "black");
            }
            [TestMethod]
            public void Bag_Must_Have_Volume()
            {
                var bag = new Bag(3, 3, 3);
                var content = new Content(2, 2, 2);
                var volume = bag.Volume;

                Assert.IsNotNull(volume);
                Assert.IsTrue(volume != null);
            }
            [TestMethod]
            public void Bag_Can_Have_No_Pockets()
            {
                var bag = new Bag(3, 3, 3);
                var count = bag.Pockets.Count;

                Assert.IsTrue(count == 0);
            }
            [TestMethod]
            public void Bag_Can_Have_Multiple_Pockets()
            {
                var bag = new Bag(2, 2, 2);
                var count = bag.Pockets.Count;

                count = 2;
                Assert.IsTrue(count > 0);
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
            public void Empty_Bag_Holds_Weight_Of_Zero()
            {
                var bag = new Bag(2, 2, 2);
                var content = new Content(0,0,0);
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
        }

    }

}