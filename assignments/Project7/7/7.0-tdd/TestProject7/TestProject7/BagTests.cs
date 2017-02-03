using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture.Tests
{
    [TestClass()]
    public class BagTests
    {
        [TestMethod]
        public void Bag_Should_Add()
        {
            var content = new Content(1, 1, 1);
            var bag = new Bag(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Bag_Should_Be_Big()
        {
            var volume = new Volume(5, 5, 5);
            var bag = new Bag(7, 7, 7);
            var content = new Content(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Bag_Should_Not_Add_Oversized_Content()
        {
            var content = new Content(6, 6, 17);
            var bag = new Bag(5, 5, 5);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));
        }
        [TestMethod]
        public void Bag_Should_Not_Have_Too_Many_Pockets()
        {
            var bag = new Bag(5, 5, 5);
            var content = new Content(6, 6, 6);
            var added = bag.Add(content);

            Assert.IsFalse(added);
            Assert.IsFalse(bag.Check(content));

        }
        [TestMethod]
        public void Bag_Should_Have_Volume()
        {
            var bag = new Bag(2, 2, 2);
            var volume = new Volume(1, 1, 1);
            var content = new Content(1, 1, 1);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Bag_Can_Overflow()
        {
            var bag = new Bag(3, 3, 3);
            var volume = new Volume(4, 4, 4);
            var content = new Content(1, 1, 1);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
        [TestMethod]
        public void Bag_Can_Contain_Nothing()
        {
            var bag = new Bag(3, 3, 3);
            var volume = new Volume(0,0,0);
            var content = new Content(1, 1, 1);
            var added = bag.Add(content);

            Assert.IsTrue(added);
        }
    }
}