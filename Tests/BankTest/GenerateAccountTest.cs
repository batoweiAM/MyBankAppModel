using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBankAppModel;
using System;

namespace BankTest
{
    [TestClass]
    public class GenerateAccountTest
    {
        [TestMethod]
        public void TestAccountGenerator()
        {
            var account = new OpenAccount();

            var expect = "0123456789";

            var actual = account.GenerateAccount();

            Assert.AreEqual(expect, actual);
        }
    }
}
