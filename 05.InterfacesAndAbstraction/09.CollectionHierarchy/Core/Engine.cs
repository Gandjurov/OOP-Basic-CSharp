using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        public void Run()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split();

            foreach (var item in input)
            {
                Console.Write($"{addCollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write($"{addRemoveCollection.Add(item)} ");
            }
            Console.WriteLine();


            foreach (var item in input)
            {
                Console.Write($"{myList.Add(item)} ");
            }
            Console.WriteLine();


            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }
            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
            Console.WriteLine();
        }
    }
}
