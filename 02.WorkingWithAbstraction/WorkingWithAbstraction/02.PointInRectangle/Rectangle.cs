using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft
        {
            get { return topLeft; }
            set { topLeft = value; }
        }
        
        public Point BottomRight
        {
            get { return bottomRight; }
            set { bottomRight = value; }
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal =
                this.TopLeft.X <= point.X &&
                this.BottomRight.X >= point.X;

            bool isInVertical =
                this.TopLeft.Y <= point.Y &&
                this.BottomRight.Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;
            return isInRectangle;
        }
    }
}
