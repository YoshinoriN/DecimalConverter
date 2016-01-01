using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecimalConverter;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {

        private DecimalConverter.ViewModels.MainWindowViewModel vm = new DecimalConverter.ViewModels.MainWindowViewModel();

        /// <summary>
        /// 10進数に値を入れたときのテスト
        /// </summary>
        [TestMethod, TestCategory("ViewModelProperty")]
        public void TestDecimalNumber()
        {
            vm.DecimalNumber = 0;
            Assert.AreEqual("0", vm.BinaryNumber, "2進数:0");
            Assert.AreEqual("0", vm.OctDecimalNumber, "8進数:0");
            Assert.AreEqual("0", vm.HexaDecimalNumber, "16進数:0");
        }
    }
}
