using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();

            var accounts = new Dictionary<int, BankAccount>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var cmArgs = command.Split();
                var cmType = cmArgs[0];
                var id = int.Parse(cmArgs[1]);

                switch (cmType)
                {
                    case "Create":
                        Create(cmArgs, accounts);
                        break;
                    case "Deposit":
                        Deposit(cmArgs, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(cmArgs, accounts);
                        break;
                    case "Print":
                        Print(cmArgs, accounts);
                        break;


                        //case "Create":
                        //    if (accounts.ContainsKey(accountId))
                        //    {
                        //        Console.WriteLine("Account already exists");
                        //    }
                        //    else
                        //    {
                        //        var account = new BankAccount { Id = accountId };
                        //    }
                        //    break;

                        //case "Deposit":
                        //    if (!accounts.ContainsKey(accountId))
                        //    {
                        //        Console.WriteLine("Account does not exist");
                        //    }
                        //    else
                        //    {
                        //        decimal amount = decimal.Parse(cmArgs[2]);
                        //        accounts[accountId].Deposit(amount);
                        //    }
                        //    break;
                        //case "Withdraw":
                        //    if (!accounts.ContainsKey(accountId))
                        //    {
                        //        Console.WriteLine("Account does not exist");
                        //    }
                        //    else
                        //    {
                        //        decimal amount = decimal.Parse(cmArgs[2]);

                        //        if (accounts[accountId].Balance < amount)
                        //        {
                        //            Console.WriteLine("Insufficient balance");
                        //        }
                        //        else
                        //        {
                        //            accounts[accountId].Withdraw(amount);
                        //        }
                        //    }
                        //    break;

                        //case "Print":
                        //    if (!accounts.ContainsKey(accountId))
                        //    {
                        //        Console.WriteLine("Account does not exist");
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine(accounts[accountId]);
                        //    }
                        //    break;
                }
            }



        }

        private static void Create(string[] cmArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmArgs[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }

        }

        private static void Deposit(string[] cmArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmArgs[1]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                decimal amount = decimal.Parse(cmArgs[2]);
                accounts[id].Deposit(amount);
            }
        }

        private static void Withdraw(string[] cmArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmArgs[1]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                decimal amount = decimal.Parse(cmArgs[2]);

                if (accounts[id].Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
            }
        }

        private static void Print(string[] cmArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmArgs[1]);

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(accounts[id]);
            }
        }
    }
}
