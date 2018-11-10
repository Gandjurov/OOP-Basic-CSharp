using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person()
        {

        }

        public Person(string name, int age) : this()
        {
            this.name = name;
            this.age = age;
        }

        public Person(string name, int age, List<BankAccount> accounts) : this(name, age)
        {
            this.accounts.AddRange(accounts);
        }

        public decimal GetBalance()
        {
            return this.accounts.Sum(a => a.Balance);
        }

    }
}
