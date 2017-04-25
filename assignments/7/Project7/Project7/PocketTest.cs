using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace UnitTestProject
{
    [TestClass]
    public class PocketTest
    {
        [TestClass()]
        public class PocketTests
        {
            [TestMethod]
            public void Pocket_Should_Add_Content()
            {
                var pocket = new Bag(2, 2, 2);
                var content = new Content(1, 1, 1);
                var added = pocket.Add(content);

                Assert.IsTrue(added);
                Assert.IsTrue(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Remove()
            {
                var pocket = new Bag(3, 3, 3);
                var content = new Content(1, 1, 1);
                pocket.Add(content);
                var removed = pocket.Remove(content);

                Assert.IsTrue(removed);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Dump()
            {
                var content = new Content(3, 3, 3);
                var pocket = new Pocket(4, 4, 4);
                pocket.Dump();
                var dumped = pocket.Dump();

                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Should_Not_Overflow()
            {
                var pocket = new Pocket(13, 17, 23);
                var content = new Content(20, 20, 20);
                var added = pocket.Add(content);

                Assert.IsFalse(added);
                Assert.IsFalse(pocket.Check(content));
            }
            [TestMethod]
            public void Pocket_Can_Not_Be_Equal_To_Content()
            {
                var pocket = new Pocket(4, 4, 4);
                var content = new Content(4, 4, 4);

                Assert.IsFalse(pocket.Equals(content));
            }
            [TestMethod]
            public void Pocket_Must_Be_Black_By_Default()
            {
                var pocket = new Pocket(3, 3, 3);
                var content = new Content(9, 9, 9);
                var color = pocket.Color;

                Assert.IsTrue(color == "black");
                Assert.IsFalse(color != "black");
            }
            [TestMethod]
            public void Pocket_Must_Have_Volume()
            {
                var pocket = new Pocket(3, 3, 3);
                var content = new Content(2, 2, 2);
                var volume = pocket.Volume;

                Assert.IsFalse(volume == null);
                Assert.IsTrue(volume != null);
            }
            [TestMethod]
            public void Multiple_Pockets_Can_Exist()
            {
                var bag = new Bag(2, 2, 2);
                var count = bag.Pockets.Count;

                count = 2;
                Assert.IsTrue(count > 0);
            }
            [TestMethod]
            public void Pocket_Must_Have_Weight()
            {
                var pocket = new Pocket(2, 2, 2);
                var weight = pocket.Weight;

                Assert.IsFalse(weight < 0);
                Assert.IsTrue(weight >= 0);
            }
            [TestMethod]
            public void Empty_Pocket_Holds_Weight_Of_Zero()
            {
                var pocket = new Pocket(2, 2, 2);
                var content = new Content(0, 0, 0);
                var weight = pocket.Weight;

                Assert.IsTrue(weight == 0);
            }
            [TestMethod]
            public void Pocket_Must_Be_Closed_By_Default()
            {
                var pocket = new Pocket(2, 2, 2);
                var content = new Content(1, 1, 1);
                var opened = pocket.Opened;

                Assert.IsFalse(opened);
            }
        }

    }

}