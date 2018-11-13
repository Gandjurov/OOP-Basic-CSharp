using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class Obstacle : Point
    {
        private const char obstacleSymbol = '@';
        private List<Point> obstacles;

        public Obstacle()
        {
            this.obstacles = new List<Point>();
        }

        public bool isObstacle(Point snakePoint)
        {
            return this.obstacles.Any(x => x.LeftX == snakePoint.LeftX && x.TopY == snakePoint.TopY);
        }

    }
}
