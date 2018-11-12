using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        private int playerPoints;

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }
        
        public bool IsPointOfWall(Point snake)
        {
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

        public void AddPoint(int points)
        {
            this.playerPoints += points;

        }

        //quick example
        private int GetLevel()
        {
            if (this.playerPoints < 10)
            {
                return 1;
            }
            else if (playerPoints >= 10 && playerPoints <= 20)
            {
                return 2;
            }

            return 3;
        }

        public void PlayerInfo()
        {
            Console.SetCursorPosition(this.LeftX + 3, 0);
            Console.Write($"Player Points: {this.playerPoints}");
            Console.SetCursorPosition(this.LeftX + 3, 1);
            Console.WriteLine($"Player level: {this.playerPoints / 20}");
        }

        
    }
}
