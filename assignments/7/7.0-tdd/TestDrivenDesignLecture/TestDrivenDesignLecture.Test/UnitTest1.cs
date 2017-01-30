using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace TestDrivenDesignLecture.Test
{
    [TestClass]
    public class Bag_Test
    {
        [TestMethod]
        public void Bag_should_add()
        {
            var content = new Content(1, 1, 1);
            var content2 = new Content(0, 0, 0);
            var bag = new Bag(10, 10, 10);
            var added = bag.Add(content, content2);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
        }
        [TestMethod]
        public void Bag_should_not_add()
        {
            var content = new Content(23, 12, 10);
            var content2 = new Content(0, 0, 0);
            var bag = new Bag(10, 10, 10);
            var added = bag.Add(content, content2);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_should_remove()
        {
            var content = new Content(1, 1, 1);
            var content2 = new Content(0, 0, 0);
            var bag = new Bag(20, 20, 20);
            bag.Add(content, content2);
            var removed = bag.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(bag.Check(content));
        }
        //[TestMethod]
        //public void Bag_should_not_remove() //if something expanded in the bag, like an umbrella
        //{
        //    var content = new Content(20, 20, 20);
        //    var bag = new Bag(10, 10, 10);
        //    var removed = bag.Remove(content);
          
        //    Assert.IsFalse(removed); //false positive. Didn't remove b/c nothing in there
        //    //Assert.IsTrue(bag.Check(content)); //the content isn't adding in the first place
        //}
        [TestMethod]
        public void Bag_should_dump()
        {
            var content = new Content(5, 5, 5);
            var bag = new Bag(10, 10, 10);
            bag.Dump();
 
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_should_not_add_oversized() //if there is already something added, it will not overflow
        {
            var content = new Content(5, 5, 5);
            var content2 = new Content(6, 6, 6);
            var bag = new Bag(10, 10, 10);
            
            var added = bag.Add(content, content2);

            Assert.IsFalse(added);
            Assert.IsTrue(bag.Check(content));
            Assert.IsFalse(bag.Check(content2));
        }
        [TestMethod]
        public void Bag_should_add_oversized() 
        {
            var content = new Content(5, 5, 5);
            var content2 = new Content(2, 2, 2);
            var bag = new Bag(10, 10, 10);

            var added = bag.Add(content, content2);

            Assert.IsTrue(added);
            Assert.IsTrue(bag.Check(content));
            Assert.IsTrue(bag.Check(content2));
        }
    }

    [TestClass]
    public class Pocket_Test
    {
        [TestMethod]
        public void Pocket_should_add()
        {
            var content = new Content(1, 1, 1);
            var content2 = new Content(0, 0, 0);
            var pocket = new Pocket(10, 10, 10);
            var added = pocket.Add(content, content2);

            Assert.IsTrue(added);
            Assert.IsTrue(pocket.Check(content));
        }
        [TestMethod]
        public void pocket_should_not_add()
        {
            var content = new Content(13, 12, 11);
            var content2 = new Content(0, 0, 0);
            var pocket = new Pocket(10, 10, 10);
            var added = pocket.Add(content, content2);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content));
        }
        //[TestMethod]
        //public void pocket_should_remove()
        //{
        //    var content = new Content(5, 5, 5);
        //    var pocket = new Pocket(20, 20, 20);
        //    var removed = pocket.Remove(content);

        //    Assert.IsTrue(removed);
        //    Assert.IsFalse(pocket.Check(content));
        //}
        [TestMethod]
        public void Pocket_should_not_remove()
        {
            var content = new Content(15, 15, 15);
            var pocket = new Pocket(10, 10, 10);
            var removed = pocket.Remove(content);

            Assert.IsFalse(removed);
            //Assert.IsTrue(bag.Check(content)); //maybe I don't know hwat happening in my code
        }
        [TestMethod]
        public void Pocket_should_dump()
        {
            var content = new Content(5, 5, 5);
            var pocket = new Pocket(10, 10, 10);
            pocket.Dump();

            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_should_not_add_oversized()
        {
            var content = new Content(5, 5, 5);
            var content2 = new Content(6, 6, 6);
            var pocket = new Pocket(10, 10, 10);

            var added = pocket.Add(content, content2);

            Assert.IsFalse(added);
            Assert.IsTrue(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_should_add_oversized()
        {
            var content = new Content(5, 5, 5);
            var content2 = new Content(2, 2, 2);
            var pocket = new Pocket(10, 10, 10);

            var added = pocket.Add(content, content2);

            Assert.IsTrue(added);
            Assert.IsTrue(pocket.Check(content));
            Assert.IsTrue(pocket.Check(content2));
        }
    }

    [TestClass]
    public class Volume_test
    {
        [TestMethod]
        public void Volume_Is_not_null()
        {
            var volume = new Volume(10, 10, 10);

            Assert.IsNotNull(volume);
        }
    }

    [TestClass]
    public class Content_test
    {
        [TestMethod]
        public void Content_Is_not_null()
        {
            var content = new Content(10, 10, 10);

            Assert.IsNotNull(content);
        }
    }

    [TestClass]
    public class Condition_test
    {
        [TestMethod]
        public void Condition_is_not_null()
        {
            Assert.AreEqual((int)Condition.Excellent, 5);
            Assert.AreEqual((int)Condition.VeryGood, 4);
            Assert.AreEqual((int)Condition.Good, 3);
            Assert.AreEqual((int)Condition.Fair, 2);
            Assert.AreEqual((int)Condition.Poor, 1);
            
        }
    }
}

        

    

   

