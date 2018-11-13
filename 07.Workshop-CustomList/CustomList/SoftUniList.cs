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
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[this.Count++] = item;
        }

        private void Resize()
        {
            string[] copyArray = new string[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                copyArray[i] = array[i];
            }

            this.array = copyArray;
        }
    }
}
