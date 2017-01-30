using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesignLecture.Test
{
    [TestClass]
    public class UnitTest1
    {        
        [TestMethod]
        public void Pocket_ShouldAddContent()
        {
            var pocket = new Pocket(4, 4, 4);
            var content = new Content(3, 3, 3);

            var add = pocket.Add(content);

            Assert.IsTrue(add);
            Assert.IsTrue(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_ShouldAddMulitpleContent()
        {
            var pocket = new Pocket(4, 4, 4);
            var contentOne = new Content(1, 1, 1);
            var contentTwo = new Content(2, 2, 2);
          
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            
            Assert.IsTrue(add);
            Assert.IsTrue(pocket.Check(contentOne));
            Assert.IsTrue(pocket.Check(contentTwo));
       

        }

        [TestMethod]
        public void Pocket_ShouldNotAdd()
        {
            var pocket = new Pocket(2, 2, 2);
            var contentOne = new Content(4, 5, 6);
            var contentTwo = new Content(1, 1, 1);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);

            Assert.IsTrue(add);
            Assert.IsFalse(pocket.Check(contentOne));
            Assert.IsTrue(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_ShouldRemove()
        {
            var content = new Content(3, 3, 3);
            var pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);
            var remove = pocket.Remove(content);

            Assert.IsTrue(remove);
            Assert.IsFalse(pocket.Check(content));

        }
        [TestMethod]
        public void Pocket_ShouldRemoveMultipleContent()
        {
            var pocket = new Pocket(3, 3, 3);
            var contentOne = new Content(1, 1, 1);
            var contentTwo = new Content(1, 1, 1);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            var remove = pocket.Remove(contentOne);
            remove = pocket.Remove(contentTwo);

            Assert.IsTrue(remove);
            Assert.IsFalse(pocket.Check(contentOne));
            Assert.IsFalse(pocket.Check(contentTwo));

        }
        [TestMethod]
        public void Pocket_ShouldCheck()
        {
            var content = new Content(3, 3, 3);
            var pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);
            var check = pocket.Check(content);

            Assert.IsTrue(check);
            Assert.IsTrue(pocket.Check(content));

        }

        [TestMethod]
        public void Pocket_ShouldDump()
        {
            var pocket = new Pocket(4, 4, 4);
            var contentOne = new Content(2, 2, 2);
            var contentTwo = new Content(2, 2, 2);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            var dump = pocket.Dump();

            Assert.IsTrue(true);

        }

        [TestMethod]
        public void Bag_ShouldAdd()
        {
            var bag = new Bag(12, 12, 12);
            var content = new Content(12, 12, 12);
            var volume = new Volume(12, 12, 12);

            var add = bag.Add(content);
            
            Assert.IsTrue(add);
            Assert.IsTrue(bag.Add(content));

        }

        [TestMethod]
        public void Bag_ShouldAddMultiple()
        {
            var bag = new Bag(12, 8, 12);
            var contentOne = new Content(5, 3, 4);
            var contentTwo = new Content(1, 2, 3);
            var contentThree = new Content(2, 2, 2);

            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            add = bag.Add(contentThree);

            Assert.IsTrue(add);
            Assert.IsTrue(bag.Add(contentOne));
            Assert.IsTrue(bag.Add(contentTwo));
            Assert.IsTrue(bag.Add(contentThree));
        }

        [TestMethod]
        public void Bag_ShouldNotAdd()
        {
            var bag = new Bag(4, 5, 6);
            var content = new Content(6, 3, 8);

            var add = bag.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(bag.Add(content));

        }

        [TestMethod]
        public void Bag_contents()
        {
            var bag = new Bag(6, 7, 8);
            var content = new Content(4,5,6);
            var add = bag.Add(content);
            var check = bag.Check(content);

            Assert.IsTrue(check);
            Assert.IsTrue(bag.Check(content));

        }

        [TestMethod]
        public void Bag_ShouldRemove()
        {
            var bag = new Bag(4, 5, 6);
            var content = new Content(1, 2, 3);
            var add = bag.Add(content);
            var remove = bag.Remove(content);

            Assert.IsTrue(remove);
            Assert.IsFalse(bag.Check(content));      
        }

        [TestMethod]
        public void Bag_ShouldRemoveMultiple()
        {
            var bag = new Bag(10, 12, 14);
            var contentOne = new Content(3, 5, 7);
            var contentTwo = new Content(4, 5, 7);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            var remove = bag.Remove(contentTwo);
            remove = bag.Remove(contentOne);

            Assert.IsTrue(remove);
            Assert.IsFalse(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
        }

        [TestMethod]
        public void Bag_shouldDump()
        {
            var bag = new Bag(1, 3, 3);
            var content = new Content(1, 2, 3);
            var add = bag.Add(content);
            var dump = bag.Dump();

            Assert.IsTrue(true);            
        }
    }
}
