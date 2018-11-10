using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        private int leftX;
        private int topY;

        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return leftX;
            }
            private set
            {
                //TODO think about directions
                if (value < 0 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }
                leftX = value;
            }
        }
        
        public int TopY
        {
            get
            {
                return topY;
            }
            private set
            {
                if (value < 0 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }
                topY = value;
            }
        }

    }
}
