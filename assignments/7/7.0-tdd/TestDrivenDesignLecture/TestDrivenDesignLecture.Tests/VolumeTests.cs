using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesignLecture.Tests
{
    [TestClass]
    public class VolumeTests
    {
        [TestMethod]
        public void Volume_Constructor_ShouldSetAbsoluteValueOfLengthsWithNegativeValues()
        {
            var volume = new Volume(-1, 1, 1);

            Assert.IsTrue(volume.Length == 1);
        }

        [TestMethod]
        public void Volume_Constructor_ShouldSetAbsoluteValueOfWidthsWithNegativeValues()
        {
            var volume = new Volume(1, -1, 1);

            Assert.IsTrue(volume.Width == 1);
        }

        [TestMethod]
        public void Volume_Constructor_ShouldSetAbsoluteValueOfHeightsWithNegativeValues()
        {
            var volume = new Volume(1, 1, -1);

            Assert.IsTrue(volume.Height == 1);
        }

        [TestMethod]
        public void Volume_LengthProperty_ShouldSetWithAbsoluteValue()
        {
            var volume = new Volume(1, 1, 1);

            volume.Length = -5;

            Assert.IsTrue(volume.Length == 5);
        }

        [TestMethod]
        public void Volume_WidthProperty_ShouldSetWithAbsoluteValue()
        {
            var volume = new Volume(1, 1, 1);

            volume.Width = -5;

            Assert.IsTrue(volume.Width == 5);
        }

        [TestMethod]
        public void Volume_HeightProperty_ShouldSetWithAbsoluteValue()
        {
            var volume = new Volume(1, 1, 1);

            volume.Height = -5;

            Assert.IsTrue(volume.Height == 5);
        }

        [TestMethod]
        public void Volume_ValueProperty_ShouldReturnProductOfAllDimensions()
        {
            var volume = new Volume(2, 3, 4);

            Assert.IsTrue(volume.Value == 24);
        }
    }
}
