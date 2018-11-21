using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;
        
        public RandomList()
        {
            this.Random = new Random();
        }

        public Random Random
        {
            get { return rnd; }
            set { rnd = value; }
        }

        public string RemoveRandomElement()
        {
            if (this.Count < 1)
            {
                return "No elements available";
            }

            int index = rnd.Next(0, this.Count - 1);
            string str = this[index];
            this.RemoveAt(index);

            return str;
        }

    }
}
