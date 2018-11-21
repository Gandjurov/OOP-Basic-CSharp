using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("First element");
            list.Add("Second element");
            list.Add("Third element");
            list.Add("Fourth element");
            list.Add("Fifth element");

            foreach (var item in list)
            {
                Console.WriteLine(list.RemoveRandomElement());
            }
        }
    }
}
