using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void Ternaries()
        {
            string animal = "dog";
            string cat = animal != "dog" ? "Cat" : "Dog";
        }
        public void BagShouldAdd()
        {
            var content = var content = new Content(1, 1, 1);
            var bag = new Bag(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void BagShouldNotAddOversizedContent()
        {
            var content = new Content(6, 6, 17);
            var bag = new Bag(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsTrue(added);
            Assert.IsTrue(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_ShouldAddContent()
        {
            var pocket = new Pocket(1, 1, 1);
            var content = new Content(1, 1, 1);
            var added = pocket.Add(content);


            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Pocket_ShouldNotOversizeContent()
        {
            var pocket = new Pocket(13, 17, 23);
            var content = new Content(20, 20, 20);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(pocket.Check(content)); 
        }
    }
}
