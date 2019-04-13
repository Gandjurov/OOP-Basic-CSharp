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

        [Test]
        [TestCase("1", 3450.34)]
        [TestCase("StringWithLengthMoreThan25Symbols", 3450.34)]
        public void Constructor_ShouldThrowArgumentException_InvalidNameLength(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }
    }
}