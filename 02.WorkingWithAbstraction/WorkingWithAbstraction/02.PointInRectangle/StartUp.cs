using System;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Point topLeft = new Point(input[0], input[1]);
            Point bottomRight = new Point(input[2], input[3]);

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] inputCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Point currentPoint = new Point(inputCommands[0], inputCommands[1]);

                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}
