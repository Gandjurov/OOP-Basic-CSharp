using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class SoftUniList
    {
        private const int initialCapacity = 2;
        //add
        //remove
        //read

        private string[] array;

        public SoftUniList()
        {
            this.array = new string[initialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(string item)
        {
            this.array[this.Count] = item;
            this.Count++;
        }
    }
}
