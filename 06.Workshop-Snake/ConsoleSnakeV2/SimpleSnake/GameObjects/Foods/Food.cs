using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;

        public Food(char foodSymbol, int points)
        {
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();

        }

        public int FoodPoints { get; private set; }
        

        public bool IsFoodPoint(Point snake)
        {
            return this.LeftX == snake.LeftX && this.TopY == snake.TopY;
        }
    }
}
