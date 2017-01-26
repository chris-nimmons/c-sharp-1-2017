using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesignLecture.Tests
{
    [TestClass]
    public class PocketTests
    {
        [TestMethod]
        public void Pocket_Check_ShouldReturnFalseWhenContentListDoesNotContainPassedContent()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);

            var found = pocket.Check(content);

            Assert.IsFalse(found);
        }

        [TestMethod]
        public void Pocket_Check_ShouldReturnTrueWhenContentListContainsPassedContent()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);
            pocket.Add(content);

            var found = pocket.Check(content);

            Assert.IsTrue(found);
        }

        [TestMethod]
        public void Pocket_Add_ShouldAddContent()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);

            var added = pocket.Add(content);

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void Pocket_Add_ShouldNotAddContentWithOversizedLength()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(2, 1, 1);

            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Pocket_Add_ShouldNotAddContentWithOversizedWidth()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 2, 1);

            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Pocket_Add_ShouldNotAddContentWithOversizedHeight()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 2);

            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Pocket_Remove_ShouldRemoveContentFromContentsList()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(1, 1, 1);
            pocket.Add(content);

            var removed = pocket.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Pocket_Remove_ShouldNotRemoveUnaddedContent()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(1, 1, 1);

            var removed = pocket.Remove(content);

            Assert.IsFalse(removed);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Pocket_Dump_ShouldReturnListOfTypePocket()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);
            pocket.Add(content);

            var dumped = pocket.Dump();

            Assert.IsInstanceOfType(dumped, new List<Content>().GetType());
        }

        [TestMethod]
        public void Pocket_Dump_ShouldReturnFullListOfContents()
        {
            var pocket = new Pocket(2, 2, 2);
            var contentOne = new Content(1, 1, 1);
            var contentTwo = new Content(1, 1, 2);
      
            pocket.Add(contentOne);
            pocket.Add(contentTwo);

            var dumped = pocket.Dump();

            Assert.IsTrue(dumped.Contains(contentOne));
            Assert.IsTrue(dumped.Contains(contentTwo));
            Assert.IsFalse(pocket.Check(contentOne));
            Assert.IsFalse(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_Dump_ShouldReturnEmptyListIfNoContentWasAdded()
        {
            var pocket = new Pocket(2, 2, 2);

            var dumped = pocket.Dump();

            Assert.IsTrue(dumped.Count == 0);
        }

        [TestMethod]
        public void Pocket_Dump_ShouldReturnEmptyListOnSecondDump()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);
            pocket.Add(content);

            var firstDump = pocket.Dump();
            var secondDump = pocket.Dump();

            Assert.IsTrue(firstDump.Count > 0);
            Assert.IsTrue(secondDump.Count == 0);
        }
    }
}
