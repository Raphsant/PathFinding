using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Program
    {
        static int[] map = new int[100] {
            0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 1, 1, 1, 0,
            0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 1, 0, 0, 0
        }; //0 is impassable, 1 is passable

        

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public static Point startPoint = new Point(1,0);

        public static Point endPoint = new Point(6, 9);

        public static List<int> path = new List<int>();

        static List<int> visited = new List<int>();

        public static Random rand = new Random();

        static void Main(string[] args)
        {
            bool pathComplete = false;

            //start from the starting position
            Point head = startPoint;

            //find out what directions we can go

            List<Direction> directionsWeCanGo = new List<Direction>();

            for(int i = 0; i < 3; i++)
            {
                //loop through all the directions to see if we can go there
                if (getPassable(head, (Direction)i))
                {
                    directionsWeCanGo.Add((Direction)i);
                }
            }

            //pick a direction and go to it IF you can



            

            
        }

        static bool getPassable(int x, int y)
        {
            //check to see if out of bounds
            int maxSize = (int)Math.Sqrt(map.Length) - 1;

            if((x < 0) || (y < 0) || (x > maxSize) || (y > maxSize))
            {
                return false;
            }

            int index = y * 10 + x;
            if(index == 1)
            {
                return true;
            } if (index == 0)
            {
                return false;
            }

            return false;
        }

        static bool getPassable(Point point)
        {
            return getPassable(point.X, point.Y);
           
        }

        static Direction? getRandomDirection(List<Direction> availableDirections)
        {
            if(availableDirections.Count > 0)
            {
                int chosen = rand.Next(0, availableDirections.Count + 1);
                return availableDirections[chosen];
            } else
            {
                return null;
            }
        }

        static bool getPassable(Point currentCell, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return getPassable(currentCell.X, currentCell.Y - 1);
                case Direction.Down:
                    return getPassable(currentCell.X, currentCell.Y + 1);
                case Direction.Left:
                    return getPassable(currentCell.X - 1, currentCell.Y);
                case Direction.Right:
                    return getPassable(currentCell.X + 1, currentCell.Y);
                default:
                    return false;
            }
        }
    }
}
