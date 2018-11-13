using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniList<string> softUniList = new SoftUniList<string>();

            softUniList.Add("Gosho");
            softUniList.Add("Pesho");
            softUniList.Add("Ivan");
            softUniList.Remove("Iv12314214an");

            foreach (var item in softUniList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----");

            softUniList[0] = "Pavel";

            for (int i = 0; i < softUniList.Count; i++)
            {
                Console.WriteLine(softUniList[i]);
            }

            
        }
    }
}
