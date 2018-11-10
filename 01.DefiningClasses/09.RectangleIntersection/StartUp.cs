using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int[] operations = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rectanglesCount = operations[0];
            int intersectCount = operations[1];

            for (int i = 0; i < rectanglesCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double x = double.Parse(input[3]);
                double y = double.Parse(input[4]);

                Rectangle rectangle = new Rectangle(name, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < intersectCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string firstId = input[0];
                string secondId = input[1];

                Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == firstId);
                Rectangle secondRectangle = rectangles.FirstOrDefault(x => x.Id == secondId);

                if (firstRectangle.Intersect(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
