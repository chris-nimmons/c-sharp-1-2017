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
        public void Bag_Can_Add_Zero_Content()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(0, 0, 0);
            var added = bag.Add(content);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
        }
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
        public void Bag_Should_Remove_Content()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(1, 1, 1);
            bag.Add(content);
            var removed = bag.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Which_Is_Over_Filled_Can_Be_Dumped()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(4, 4, 4);
            bag.Add(content);
            bag.Dump();

            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Dump_Content()
        {
            var bag = new Bag(4, 4, 4);
            var content = new Content(3, 3, 3);
            bag.Add(content);
            bag.Dump();

            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Not_Add_Oversized_Content()
        {
            var bag = new Bag(13, 17, 23);
            var content = new Content(20, 20, 24);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }

        // New:
        [TestMethod]
        public void Bag_And_Contents_Added_Are_Not_Equal_Type()
        {
            var bag = new Bag(12, 12, 12);
            var content = new Content(11, 1, 11);

            var added = bag.Add(content);

            var bagType = bag.GetType();
            var contentType = content.GetType();

            Assert.IsTrue(added);
            Assert.AreNotEqual(bagType, contentType);
        }
        [TestMethod]
        public void Contents_With_Same_Dimensions_As_Bag_Will_Not_Add_To_Bag()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 2, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_With_Insufficient_Length_For_Contents_Will_Not_Add_Contents()
        {
            var bag = new Bag(1, 2, 2);
            var content = new Content(2, 2, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_With_Insufficient_Width_For_Contents_Will_Not_Add_Contents()
        {
            var bag = new Bag(2, 1, 2);
            var content = new Content(2, 2, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_With_Insufficient_Height_For_Contents_Will_Not_Add_Contents()
        {
            var bag = new Bag(2, 2, 1);
            var content = new Content(2, 2, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Content_With_Oversized_Length_For_Bag_Will_Not_Add_To_Bag()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(3, 2, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Content_With_Oversized_Width_For_Bag_Will_Not_Add_To_Bag()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 3, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Content_With_Oversized_Height_For_Bag_Will_Not_Add_To_Bag()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 2, 3);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Content_And_Bag_Do_Not_Have_Equal_Volume_Given_Same_Dimensions()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(2, 2, 2);

            var bagVolume = bag.Volume;
            var contentVolume = content.Volume;

            Assert.AreNotEqual(bagVolume, contentVolume);
        }
    }

}

