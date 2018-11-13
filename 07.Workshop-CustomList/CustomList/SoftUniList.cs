using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class SoftUniList : IEnumerable
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

        //Add
        public void Add(string item)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }
            this.array[this.Count++] = item;
        }

        //Remove
        internal void Remove(string item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i] == item)
                {
                    this.array[i] = null;
                    this.Count--;
                    this.Shrink(i);
                }
            }
        }
        
        public string this[int number]
        {
            get
            {
                if (number >= 0 && number < this.Count)
                {
                    return this.array[number];
                }
                return "Error";
            }
            set
            {
                if (number >= 0 && number < this.Count)
                {
                    this.array[number] = value;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        //Resize
        private void Resize()
        {
            string[] newArray = new string[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = array[i];
            }

            this.array = newArray;
        }

        //Shrink
        private void Shrink(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }
    }
}
