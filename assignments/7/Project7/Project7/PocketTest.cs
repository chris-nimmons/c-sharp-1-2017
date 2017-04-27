using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace UnitTestProject
{

    [TestClass()]
    public class PocketTests
    {
        [TestMethod]
        public void Bag_Is_A_Different_Hash_Code_Than_Volume()
        {
            var bag = new Bag(2, 2, 2);
            var volume = new Volume(2, 2, 2);
            var type = bag.GetHashCode();
            var voltype = volume.GetHashCode();

            Assert.AreNotEqual(type, voltype);

        }
        [TestMethod]
        public void Pocket_Is_A_Different_Hash_Code_Than_Content()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 2, 2);
            var type = pocket.GetHashCode();
            var contype = content.GetHashCode();

            Assert.AreNotEqual(type, contype);

        }
        [TestMethod]
        public void Pocket_Is_A_Different_Type_Than_Content()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 2, 2);
            var type = pocket.GetType();
            var contype = content.GetType();

            Assert.AreNotEqual(type, contype);

        }
        [TestMethod]
        public void Pocket_Is_A_Different_Type_Than_Volume()
        {
            var pocket = new Pocket(2, 2, 2);
            var volume = new Volume(2, 2, 2);
            var type = pocket.GetType();
            var voltype = volume.GetType();

            Assert.AreNotEqual(type, voltype);

        }
        [TestMethod]
        public void Pocket_With_Contents_Weighs_The_Same_As_Content()
        {
            var pocket = new Pocket(3,3,3);
            var content = new Content(2, 2, 2);
            pocket.Add(content);

            Assert.IsTrue(pocket.Weight == content.Weight);
        }
        [TestMethod]
        public void Pocket_And_Content_Volume_Are_Not_Equal_By_Default()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 2, 2);

            Assert.IsFalse(pocket.Volume == content.Volume);
        }
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
        public void Pocket_Cannot_Add_Excess_Length()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(3, 2, 2);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
        }
        [TestMethod]
        public void Pocket_Cannot_Add_Excess_Width()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 3, 2);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
        }
        [TestMethod]
        public void Pocket_Cannot_Add_Excess_Height()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(2, 3, 2);
            var added = pocket.Add(content);

            Assert.IsFalse(added);
        }
        [TestMethod]
        public void Pocket_Should_Remove()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(1, 1, 1);
            pocket.Add(content);
            var removed = pocket.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Cannot_Remove_Empty_Contents()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(0, 0, 0);
            pocket.Add(content);
            var removed = pocket.Remove(content);

            Assert.IsTrue(removed);
            Assert.IsFalse(pocket.Check(content));
        }
        [TestMethod]
        public void Pocket_Which_Is_Empty_Can_Be_Dumped()
        {
            var pocket = new Pocket(3, 3, 3);
            var dumped = pocket.Dump();

            Assert.IsTrue(dumped.Count == 0);
        }
        [TestMethod]
        public void Pocket_Can_Exist_Without_Content()
        {
            var pocket = new Pocket(3, 3, 3);

            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Pocket_Should_Dump()
        {
            var content = new Content(3, 3, 3);
            var pocket = new Pocket(4, 4, 4);
            pocket.Add(content);
            pocket.Dump();

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
        public void Pocket_Must_Be_Black_By_Default()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(9, 9, 9);

            Assert.IsTrue(pocket.Color == "black");
        }
        [TestMethod]
        public void Pocket_Must_Have_Volume()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(2, 2, 2);
            var volume = pocket.Volume;

            Assert.IsNotNull(volume);
        }
        [TestMethod]
        public void Pockets_Do_Not_Exist_By_Default()
        {
            var bag = new Bag(2, 2, 2);
            var count = bag.Pockets.Count;

            Assert.IsTrue(count == 0);
        }
        [TestMethod]
        public void Pocket_Must_Have_Weight()
        {
            var pocket = new Pocket(2, 2, 2);
            var weight = pocket.Weight;

            Assert.IsTrue(weight >= 0);
        }
        [TestMethod]
        public void Pocket_Holds_Weight_Of_Zero_By_Default()
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
        [TestMethod]
        public void Pocket_Condition_Is_Zero_By_Default()
        {
            var pocket = new Pocket(3, 3, 3);
            var content = new Content(1, 1, 1);
            var condition = pocket.Condition;

            Assert.IsTrue(pocket.Condition == 0);
        }
        [TestMethod]
        public void Pocket_With_Contents_Weighs_Zero_By_Default()
        {
            var pocket = new Pocket(2, 2, 2);
            var content = new Content(1, 1, 1);
            var added = pocket.Add(content);
            var weight = pocket.Weight;


            Assert.IsTrue(weight == 0);
        }
    }

}

