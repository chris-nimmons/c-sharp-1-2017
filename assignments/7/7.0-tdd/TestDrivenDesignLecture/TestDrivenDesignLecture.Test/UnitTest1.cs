using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesignLecture.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Bag_Should_Add()
        {
            var contentOne = new Content(5, 7, 9);
            var bag = new Bag(6, 12, 11);
            var add = bag.Add(contentOne);

            Assert.IsTrue(add);
            Assert.IsTrue(bag.Check(contentOne));

        }

        [TestMethod]
        public void Bag_Should_Add_Multiple_Items()
        {
            var contentOne = new Content(2, 2, 2);
            var contentTwo = new Content(1, 3, 2);
            var bag = new Bag(6, 7, 8);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo); 

            Assert.IsTrue(add);
            Assert.IsTrue(bag.Check(contentOne));
            Assert.IsTrue(bag.Check(contentTwo));
            
        }

        [TestMethod]
        public void Bag_Should_Not_Add_OverSized_Object()
        {
            var bag = new Bag(3, 3, 3);
            var content = new Content(5, 2, 3);
            var add = bag.Add(content);

            Assert.IsFalse(add);
        }

        [TestMethod]
        public void Bag_Should_Not_Add_Same_Item_Twice()   //MAYBE ISSUE HERE
        {
            var bag = new Bag(5, 72, 9);
            var contentOne = new Content(1, 2, 1);
            var contentTwo = new Content(1, 1, 1);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            add = bag.Add(contentOne);
            var remove = bag.Remove(contentOne);

            Assert.IsTrue(remove);
            Assert.IsTrue(bag.Check(contentOne));

        }


        [TestMethod]
        public void Bag_Should_Dump()
        {
            var bag = new Bag(2, 2, 20);

            var contentOne = new Content(1, 1, 4);
            var contentTwo = new Content(1, 1, 5);
            var add = bag.Add(contentOne);
            bag.Add(contentTwo);
            var dump = bag.Dump();


            Assert.IsTrue(add);
            Assert.IsFalse(bag.Check(contentOne));

        }

        [TestMethod]
        public void Bag_Should_Dump_All_Items()
        {
            var bag = new Bag(93, 45, 12);
            var contentOne = new Content(2, 3, 4);
            var contentTwo = new Content(4, 5, 7);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            var dump = bag.Dump();

            Assert.IsFalse(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
        }

        [TestMethod]
        public void Bag_Should_Dump_Then_Be_Able_To_Add_A_Different_Item()
        {
            var bag = new Bag(19, 15, 22);
            var contentOne = new Content(12, 5, 14);
            var contentTwo = new Content(14, 15, 17);
            var contentThree = new Content(1, 2, 3);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            var dump = bag.Dump();
            add = bag.Add(contentThree);
            

            Assert.IsFalse(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
            Assert.IsTrue(bag.Check(contentThree));
        }

        [TestMethod]
        public void Bag_Should_Dump_Then_Be_Able_To_Add_The_Same_Item()
        {
            var bag = new Bag(19, 15, 22);
            var contentOne = new Content(2, 5, 4);
            var contentTwo = new Content(1, 11, 11);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            var dump = bag.Dump();
            add = bag.Add(contentOne);


            Assert.IsTrue(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
        }

        [TestMethod]
        public void Bag_Should_Remove()
        {
            var content = new Content(1, 2, 3);
            var bag = new Bag(5, 6, 7);
            var add = bag.Add(content);
            var remove = bag.Remove(content);

            Assert.IsTrue(remove);
            Assert.IsFalse(bag.Check(content));
        }

        [TestMethod]
        public void Bag_Should_Remove_Multiple_Items()
        {
            var bag = new Bag(10, 11, 12);
            var contentOne = new Content(4, 4, 1);
            var contentTwo = new Content(5, 6, 7);
            var add = bag.Add(contentOne);
            bag.Add(contentTwo);

            var remove = bag.Remove(contentOne);
            bag.Remove(contentTwo);

            Assert.IsFalse(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
        }

        [TestMethod]
        public void Bag_Should_Remove_Only_Items_Told_To_Remove()
        {
            var bag = new Bag(10, 11, 12);
            var contentOne = new Content(4, 4, 1);
            var contentTwo = new Content(5, 6, 7);
            var contentThree = new Content(1, 1, 1);
            var add = bag.Add(contentOne);
            bag.Add(contentTwo);
            bag.Add(contentThree);

            var remove = bag.Remove(contentOne);
            bag.Remove(contentTwo);

            Assert.IsFalse(bag.Check(contentOne));
            Assert.IsFalse(bag.Check(contentTwo));
            Assert.IsTrue(bag.Check(contentThree));
        }


        [TestMethod]
        public void Bag_Should_Not_Be_Able_To_Remove_Items_That_Are_Not_There()  // may be an issue
        {
            var bag = new Bag(33, 44, 55);
            var contentOne = new Content(1, 2, 3);
            var contentTwo = new Content(9, 20, 4);
            var add = bag.Add(contentOne);
            var remove = bag.Remove(contentTwo);

            Assert.IsTrue(bag.Check(contentOne));
            Assert.IsTrue(remove);
            Assert.IsFalse(bag.Check(contentTwo));

        }

        [TestMethod]
        public void Bag_Should_Check_if_it_Contains_Contents()
        {
            var content = new Content(49, 51, 3);
            var bag = new Bag(50, 55, 4);
            var add = bag.Add(content);

            Assert.IsTrue(bag.Check(content));
        }


        [TestMethod]
        public void Bag_Should_Add_Then_Remove_Then_Add_Same_Object_Again()
        {
            var bag = new Bag(5, 4, 20);
            var contentOne = new Content(1, 2, 3);
            var contentTwo = new Content(2, 3, 5);
            var add = bag.Add(contentOne);
            add = bag.Add(contentTwo);
            var remove = bag.Remove(contentOne);
            add = bag.Add(contentOne);

            Assert.IsTrue(bag.Check(contentOne));
            Assert.IsTrue(bag.Check(contentTwo));
        }

        [TestMethod]
        public void Bag_Should_Not_Be_Able_To_Contain_Content_If_Contents_Dimensions_Are_000()
        {
            var bag = new Bag(3, 4, 6);
            var contentOne = new Content(0, 0, 0);
            var add = bag.Add(contentOne);

            Assert.IsFalse(add);
            Assert.IsFalse(bag.Check(contentOne));
        }



        // POCKET TIME
        
 
        [TestMethod]
        public void Pocket_Should_Add_Content()
        {
            var pocket = new Pocket(4, 4, 7);
            var contentOne = new Content(1, 2, 5);
            var add = pocket.Add(contentOne);

            Assert.IsTrue(add);

        }

        [TestMethod]
        public void Pocket_Should_Add_Multiple_Items()
        {
            var pocket = new Pocket(9, 8, 9);
            var contentOne = new Content(3, 3, 2);
            var contentTwo = new Content(7, 1, 6);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);

            Assert.IsTrue(pocket.Check(contentOne));
            Assert.IsTrue(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_Should_Not_Add_Items_If_Too_HUGE()
        {
            var pocket = new Pocket(8, 9, 19);
            var contentOne = new Content(9, 12, 20);
            var add = pocket.Add(contentOne);

            Assert.IsFalse(add);
            Assert.IsFalse(pocket.Check(contentOne));
        }

        [TestMethod]
        public void Pocket_Should_Remove()
        {
            var pocket = new Pocket(9, 9, 9);
            var contentOne = new Content(3, 2, 4);
            var add = pocket.Add(contentOne);
            var remove = pocket.Remove(contentOne);

            Assert.IsTrue(remove);
            Assert.IsFalse(pocket.Check(contentOne));

        }

        [TestMethod]
        public void Pocket_Should_Remove_Multiple_Items()
        {
            var pocket = new Pocket(99, 7, 47);
            var contentOne = new Content(4, 1, 19);
            var contentTwo = new Content(88, 4, 11);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            var remove = pocket.Remove(contentOne);
            remove = pocket.Remove(contentTwo);

            Assert.IsFalse(pocket.Check(contentOne));
            Assert.IsFalse(pocket.Check(contentTwo));
        }


        [TestMethod]
        public void Pocket_Should_Not_Be_Able_To_Remove_Item_That_Is_Not_There()
        {
            var pocket = new Pocket(9, 9, 9);
            var contentOne = new Content(5, 5, 5);
            var contentTwo = new Content(4, 5, 3);
            var add = pocket.Add(contentOne);
            var remove = pocket.Remove(contentTwo);

            Assert.IsTrue(remove);
            Assert.IsFalse(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_Should_Be_Able_To_Add_Then_Remove_Then_Add_Same_Item_Again()
        {
            var pocket = new Pocket(8, 9, 11);
            var contentOne = new Content(2, 3, 1);
            var add = pocket.Add(contentOne);
            var remove = pocket.Remove(contentOne);
            add = pocket.Add(contentOne);

            Assert.IsTrue(pocket.Check(contentOne));
        }

        [TestMethod]
        public void Pocket_Shold_Remove_Only_Items_Told_To_Remove_But_Keep_Others()
        {
            var pocket = new Pocket(8, 8, 8);
            var contentOne = new Content(3, 2, 3);
            var contentTwo = new Content(2, 3, 2);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            var remove = pocket.Remove(contentOne);

            Assert.IsFalse(pocket.Check(contentOne));
            Assert.IsTrue(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_Should_Check_Contents()
        {
            var pocket = new Pocket(111, 7, 92);
            var contentOne = new Content(3, 4, 5);
            var add = pocket.Add(contentOne);

            Assert.IsTrue(pocket.Check(contentOne));
        }


        [TestMethod]
        public void Pocket_Should_Not_Add_Same_Item_Multiple_Times() //not sure about this one
        {
            var pocket = new Pocket(19, 18, 17);
            var contentOne = new Content(5, 6, 3);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentOne);
            var remove = pocket.Remove(contentOne);

            Assert.IsTrue(pocket.Check(contentOne));
         
        }

        [TestMethod]
        public void Pocket_Should_Dump_Item()
        {
            var pocket = new Pocket(17, 16, 15);
            var contentOne = new Content(1, 2, 3);
            var add = pocket.Add(contentOne);
            var dump = pocket.Dump();

            Assert.IsFalse(pocket.Check(contentOne));
        }


        [TestMethod]
        public void Pocket_Should_Dump_Multiple_Items()
        {
            var pocket = new Pocket(33, 14, 27);
            var contentOne = new Content(5, 4, 9);
            var contentTwo = new Content(6, 4, 17);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            var dump = pocket.Dump();

            Assert.IsFalse(pocket.Check(contentOne));
            Assert.IsFalse(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_Should_Be_Able_To_Dump_Then_Add_Back_Dumped_Item()
        {
            var pocket = new Pocket(17, 17, 17);
            var contentOne = new Content(5, 6, 5);
            var contentTwo = new Content(8, 8, 9);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);
            var dump = pocket.Dump();
            add = pocket.Add(contentOne);

            Assert.IsTrue(pocket.Check(contentOne));
            Assert.IsFalse(pocket.Check(contentTwo));
        }

        [TestMethod]
        public void Pocket_Should_Be_Able_To_Dump_Then_Add_Different_Item()
        {
            var pocket = new Pocket(27, 19, 21);
            var contentOne = new Content(6, 7, 15);
            var contentTwo = new Content(4, 18, 7);
            var add = pocket.Add(contentOne);
            var dump = pocket.Dump();
            add = pocket.Add(contentTwo);

            Assert.IsTrue(pocket.Check(contentTwo));
            Assert.IsFalse(pocket.Check(contentOne));
        }

        [TestMethod]
        public void Pocket_Should_Not_Add_Item_That_Does_Not_Have_Diminsions()
        {
            var pocket = new Pocket(39, 41, 11);
            var contentOne = new Content(11, 21, 9);
            var contentTwo = new Content(0, 0, 0);
            var add = pocket.Add(contentOne);
            add = pocket.Add(contentTwo);

            Assert.IsTrue(pocket.Check(contentOne));
            Assert.IsFalse(pocket.Check(contentTwo));
        }



    }


}
