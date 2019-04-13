using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        //ctor set property values
        //invalid name minLen/maxLen
        //invalid balance
        //deposit invalid amount
        //balance has increased
        //withdraw invalid amount 0
        //insufficient funds
        //balance has decreased
        //correct balance

        [Test]
        public void Constructor_ShouldSetProperValues()
        {
            string name = "Gosho";
            decimal balance = 340.34M;

            var bankAccount = new BankAccount(name, balance);

            Assert.AreEqual(name, bankAccount.Name);
            Assert.AreEqual(balance, bankAccount.Balance);

        }
    }
}