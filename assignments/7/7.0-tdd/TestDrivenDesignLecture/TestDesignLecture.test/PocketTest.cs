using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDesignLecture;

namespace TestDesignLecture.test
{
    [TestClass]
    public class PocketTest
    {
        [TestMethod]
        public void Content_Should_Add_To_Pocket()
        {
            Content content = new Content(4, 4, 4);
            Pocket pocket = new Pocket(6, 6, 6);
            var add = pocket.Add(content);

            Assert.IsTrue(add);
            Assert.IsTrue(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Pocket_Because_It_Doesnt_Fit()
        {
            Content content = new Content(8, 8, 8);
            Pocket pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Pocket_Because_Its_Too_Long()
        {
            Content content = new Content(6, 3, 3);
            Pocket pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Pocket_Because_Its_Too_Wide()
        {
            Content content = new Content(3, 6, 3);
            Pocket pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Add_To_Pocket_Because_Its_Too_Tall()
        {
            Content content = new Content(3, 3, 6);
            Pocket pocket = new Pocket(4, 4, 4);
            var add = pocket.Add(content);

            Assert.IsFalse(add);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Remove_From_Bag()
        {
            Content content = new Content(4, 4, 4);
            Pocket pocket = new Pocket(6, 6, 6);
            var add = pocket.Add(content);
            var remove = pocket.Remove(content);

            Assert.IsTrue(remove);
            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]
        public void Content_Should_Not_Remove_From_Pocket_Because_Its_Empty()
        {
            Content content = new Content(4, 4, 4);
            Pocket pocket = new Pocket(6, 6, 6);
            var remove = pocket.Remove(content);

            Assert.IsFalse(pocket.Check(content));
        }


        [TestMethod]
        public void Content_Should_Dump_From_Pocket()
        {
            Content content = new Content(4, 4, 4);
            Pocket pocket = new Pocket(6, 6, 6);
            var add = pocket.Add(content);
            pocket.Dump();

            Assert.IsFalse(pocket.Check(content));
        }

        [TestMethod]

        public void Pocket_Should_Add_Multiple_Content()
        {
            Content content = new Content(4, 4, 4);
            Content content2 = new Content(2, 2, 2);
            Pocket pocket = new Pocket(8, 8, 8);
            var add = pocket.Added(content, content2);

            Assert.IsTrue(pocket.Check(content));
        }

        public void Pocket_Should_Not_Be_Able_To_Add_Content_Because_Its_Full()
        {
            Content content = new Content(4, 4, 4);
            Content content2 = new Content(2, 2, 2);
            Pocket pocket = new Pocket(4, 4, 4);
            var add = pocket.Added(content, content2);

            Assert.IsFalse(pocket.Check(content));
        }
    }
}
