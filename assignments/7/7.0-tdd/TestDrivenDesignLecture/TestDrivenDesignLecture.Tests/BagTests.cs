using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Bag_WeightProperty_ShouldSetToAbsoluteValue()
        {
            var bag = new Bag(1, 1, 1);
            bag.Weight = -5;

            Assert.IsTrue(bag.Weight == 5);
        }

        [TestMethod]
        public void Bag_Check_ShouldReturnFalseIfContentNotInList()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 1, 1);

            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Check_ShouldReturnTrueIfContentInList()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 1, 1);
            bag.Add(content);

            Assert.IsTrue(bag.Check(content));
        }
        
        [TestMethod]
        public void Bag_Add_ShouldAddContentOfSameDimensions()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 1, 1);

            var added = bag.Add(content);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Add_ShouldAddContentWithSmallerDimensions()
        {
            var bag = new Bag(2, 2, 2);
            var content = new Content(1, 1, 1);

            var added = bag.Add(content);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Add_ShouldNotAddContentWithOversizedLength()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(2, 1, 1);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Add_ShouldNotAddContentWithOversizedWidth()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 2, 1);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Add_ShouldNotAddContentWithOversizedHeight()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 1, 2);

            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Remove_ShouldNotReturnFalseForUnaddedContent()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 1, 1);

            var removed = bag.Remove(content);

            Assert.IsFalse(removed);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Remove_ShouldReturnTrueWhenContentRemoved()
        {
            var bag = new Bag(1, 1, 1);
            var content = new Content(1, 1, 1);

            var added = bag.Add(content);

            var removed = bag.Remove(content);

            Assert.IsTrue(added);
            Assert.IsTrue(removed);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Dump_ShouldRemoveContentsAndReturnListOfRemovedContents()
        {
            var bag = new Bag(1, 1, 1);
            var contentOne = new Content(1, 1, 1);
            var contentTwo = new Content(1, 1, 1);

            bag.Add(contentOne);
            bag.Add(contentTwo);

            var dumped = bag.Dump();

            Assert.IsTrue(dumped.Contains(contentOne));
            Assert.IsTrue(dumped.Contains(contentTwo));
            Assert.IsFalse(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
        }

        [TestMethod]
        public void Bag_Dump_ShouldReturnEmptyListIfNoContentWasAdded()
        {
            var bag = new Bag(1, 1, 1);

            var dumped = bag.Dump();

            Assert.IsTrue(dumped.Count == 0);
        }

        [TestMethod]
        public void Bag_Dump_ShouldReturnEmptyListAfterSecondDump()
        {
            var bag = new Bag(1, 1, 1);
            var contentOne = new Content(1, 1, 1);
            var contentTwo = new Content(1, 1, 1);

            bag.Add(contentOne);
            bag.Add(contentTwo);

            var firstDump = bag.Dump();
            var secondDump = bag.Dump();

            Assert.IsTrue(firstDump.Count > 0);
            Assert.IsTrue(secondDump.Count == 0);
        }
    }
}
