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
        public void Bag_Should_Dump_Added_Content()
        {
            var bag = new Bag(4, 4, 4);
            var content = new Content(3, 3, 3);
            var added = bag.Add(content);
            bag.Dump();

            Assert.IsTrue(added);
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
        public void Bag_And_Content_Are_At_Different_In_Volume_At_Equal_Dimensions()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1,1,1);

            var bagVolume = bag.Volume;
            var contentVolume = content.Volume;
            
            Assert.AreNotEqual(bagVolume, contentVolume);
        }
        [TestMethod]
        public void Bag_Must_Have_Length_To_Hold_Items()
        {
            var bag = new Bag(0, 2, 2);
            var content = new Content(0, 1, 1);

            var added = bag.Add(content);
            var contentVolume = content.Volume;

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Must_Have_Width_To_Hold_Items()
        {
            var bag = new Bag(2, 0, 2);
            var content = new Content(1, 0, 1);

            var added = bag.Add(content);
            var contentVolume = content.Volume;

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Must_Have_Height_To_Hold_Items()
        {
            var bag = new Bag(2, 2, 0);
            var content = new Content(1, 1, 0);

            var added = bag.Add(content);
            var contentVolume = content.Volume;

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
    }

}

