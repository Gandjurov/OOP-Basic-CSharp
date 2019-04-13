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

        [Test]
        [TestCase("Gosho", -1)]
        [TestCase("Pesho", -5)]
        public void Constructor_ShouldThrowArgumentException_InvalidBalance(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Deposit_ShouldThrowArgumentException_InvalidAmount(decimal amount)
        {
            string name = "Gosho";
            decimal balance = 340.34M;

            var bankAccount = new BankAccount(name, balance);
            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amount));
        }

        [Test]
        public void Deposit_ShouldIncreaseBalance_ValidAmount()
        {
            string name = "Gosho";
            decimal balance = 340.34M;

            var bankAccount = new BankAccount(name, balance);

            bankAccount.Deposit(120);

            var expected = 460.34m;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }
    }
}