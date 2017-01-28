using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.test
{


    [TestClass]
    public class TestOurBags

    {
        ///////******bag tests******///////

        [TestMethod]
        public void Bag_Add_PocketsAndContent()
        {
            var content = new Content(1, 1, 1, "Pencil", 3);
            var bag = new Bag("Brown", 5, 5, 5, 4, Condition.Great);
            var add = bag.Add(content);
            var pocket = new Pocket(2, 2, 2);
            var addPockets = bag.AddPocket(pocket);

            Assert.IsTrue(add);
            Assert.IsTrue(bag.Check(content));
            Assert.AreSame(bag.Color, "Brown");
            Assert.AreEqual(bag.Weight, (decimal)4);
            Assert.AreEqual((int)bag.Condition, 4);
            Assert.IsTrue(addPockets);
        }
        [TestMethod]

        public void Bag_VariablesCanBeStoredWhenCreated()
        {
            var bag = new Bag("Brown", 5, 5, 5, 4, Condition.Fair);
        }

        [TestMethod]

        public void Dump_BagcanbeEmptiedandAdded()
        {
            var bag = new Bag("Green", 2, 2, 2, 4, Condition.Poor);
            var content1 = new Content(1, 1, 1, "Pencil", 3);
            var content2 = new Content(1, 1, 1, "Pencil", 3);
            var content3 = new Content(1, 1, 1, "Pencil", 3);
            var add = bag.Add(content1);
            var add2 = bag.Add(content2);
            var add3 = bag.Add(content3);

            //remove all contents
            var dump = bag.Dump();
            Assert.IsFalse(bag.Check(content1));

            //add new contents to empty bag and check
            var content4 = new Content(1, 1, 1, "Pencil", 3);
            var add4 = bag.Add(content4);
            Assert.IsTrue(bag.Check(content4));
        }

        [TestMethod]

        public void Remove_SpecificContent_Bag()
        {
            var bag = new Bag("Green", 2, 2, 2, 4, Condition.Poor);
            var content1 = new Content(1, 1, 1, "Pencil", 3);
            var content2 = new Content(1, 1, 1, "Pencil", 3);
            var content3 = new Content(1, 1, 1, "Pencil", 3);
            var add = bag.Add(content1);
            var add2 = bag.Add(content2);
            var add3 = bag.Add(content3);
            var remove = bag.Remove(content2);

            Assert.IsFalse(bag.Check(content2));
        }

        [TestMethod]

        public void Remove_SpecificContent_NotInPocket()
        {
            var pocket = new Pocket(2, 2, 2);
            var content2 = new Content(1, 1, 1, "Pencil", 3);
            var remove = pocket.Remove(content2);

            Assert.IsFalse(pocket.Check(content2));
        }


        [TestMethod]
        public void Bag_AddContent_ShoudlNotAddOversizedContent()
        {
            var bag = new Bag("Blue", 2, 4, 7, 4, Condition.Poor);
            var content = new Content(5, 5, 5, "Pencil", 3);
            var add = bag.Add(content);

            Assert.IsFalse(false);
        }

        ///////******pocket tests******///////
        [TestMethod]
        public void Pocket_AddContent()
        {
            var content = new Content(1, 1, 1, "Pencil", 3);
            var pocket = new Pocket(2, 2, 2);
            var add = pocket.Add(content);

            Assert.IsTrue(add);
            Assert.IsTrue(pocket.Check(content));
        }

        [TestMethod]
        public void Dump_EmptyPocket()
        {
            var pocket = new Pocket(2, 2, 2);
            var dump = pocket.Dump();
        }

        [TestMethod]
        public void Pocket_ShoudlNotAddOversizedContent()
        {
            var pocket = new Pocket(2, 4, 7);
            var content = new Content(5, 5, 5, "Pencil", 3);
            var contentVolume = new Volume(5, 5, 5);
            var add = pocket.Add(content);

            Assert.IsFalse(add);
        }

        [TestMethod]

        //this test found the add method allowed adding content with negative measurement variables
        public void Pocket_ShoudlNotAddUndersizedContent()
        {
            var pocket = new Pocket(2, 4, 7);
            var content = new Content(-1, 0, 5, "Pencil", 3);
            var add = pocket.Add(content);

            Assert.IsFalse(add);
        }

        [TestMethod]

        //this test caught the add function preventing half inch items, changed float to decimal in classes and covert in test
        public void Content_ItemsAllowedWithHalfMeasurements()
        {
            var pocket = new Pocket(1, 2, 2);
            var content = new Content((Convert.ToDecimal(.5)), 1, 1, "Pencil", 3);
            var add = pocket.Add(content);
            var name = content.Name;
            var weight = content.Weight;


            Assert.IsTrue(pocket.Check(content));
        }

        [TestMethod]

        //this test caught content being added with 0 or negative values
        public void Volume_Prevent0Calculation()
        {
            var bag = new Bag("Blue", 2, -2, 7, 4, Condition.Poor);
            var content = new Content(1, 0, 2, "Pencil", 3);
            var add = bag.Add(content);
            Assert.IsFalse(add);
        }
        [TestMethod]
        //this test caught content being added with more volume than the pocket could hold
        public void Volume_Add_ContentMeasuredinVolume_LikeSand()
        {
            var pocket = new Pocket(4, 2, 1);
            var content = new Content(3, 3, 3, "Pencil", 3);
            var contentValue = content.Value;
            var pocketValue = pocket.Value;
            var add = pocket.Add(content);

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        //code coverage tool showed that I was not testing value on the volume class. I do use the caluclation.
        public void Volume_Value_CalculatesGet()
        {
            var volume = new Volume(4, 3, 2);
            var value = volume.Value;
            var height = volume.Height;
            var width = volume.Width;
            var length = volume.Length;

            Assert.AreEqual((decimal)value , 24);
        }
        [TestMethod]
        //code coverage tool showed that I was not testing value on the volume class. I do use the caluclation.
        public void Volume_Value_CanBeSet()
        {
            var content = new Content(3, 3, 3, "Pencil", 3);
            var volume = new Volume(4, 3, 2);
            var value = volume.Value;
            var height = volume.Height;
            var width = volume.Width;
            var length = volume.Length;
            var contentValue = content.Value = 25;
            Assert.AreEqual((decimal)contentValue , 25);
            var contentValueUpdated = volume.Value = 30;
            Assert.AreEqual((decimal)contentValueUpdated , 30);
        }
    }
}
