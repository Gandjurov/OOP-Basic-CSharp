using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }
        
        public bool IsPointOfWall(Point snake)
        {
            //TODO check borders
            return snake.LeftX == 0 || snake.LeftX == this.LeftX ||
                snake.TopY == 0 || snake.TopY == this.TopY - 1;
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY - 1);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX);
        }
    }
}
