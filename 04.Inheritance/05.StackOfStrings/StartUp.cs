using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stack = new StackOfStrings();

            stack.Push("Something1");
            stack.Push("Something2");
            stack.Push("Something3");
            stack.Push("Something4");
            stack.Push("Something5");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.IsEmpty());

        }
    }
}
