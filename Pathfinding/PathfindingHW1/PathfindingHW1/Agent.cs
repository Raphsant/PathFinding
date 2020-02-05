using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingHW1
{
    class Agent
    {
        public List<Node> path;

        private Node nextPos;
        public Node currentPoint;
        public Node startPoint;
        public Node endPoint;
        private Node[,] map;
        public int mapSize;

        private List<Node> solutionList;


        void fillMap(string input, bool usingDefault)
        {
            if(usingDefault) //use the default 10x10 stuff w/e
            {
                mapSize = 10;
                fillMap();
                return;
            }
            mapSize = (int)Math.Sqrt(input.Length);

            map = new Node[mapSize, mapSize];
            for (int a = 0; a < mapSize; a++)
            {
                for (int b = 0; b < mapSize; b++)
                {
                    map[a, b] = new Node(a,b);
                    map[a, b].isPassable = input.ElementAt(a * mapSize + b); //oh jesus christ
                }
            }
        }
        void fillMap()
        {
            map = new Node[mapSize, mapSize];
            for (int a = 0; a < mapSize; a++)
            {
                for (int b = 0; b < mapSize; b++)
                {
                    map[a, b] = new Node(a,b);
                }
            }

            map[0, 0].isPassable = 1;
            map[0, 1].isPassable = 1;
            map[0, 2].isPassable = 1;
            map[0, 3].isPassable = 1;
            map[0, 4].isPassable = 1;
            map[0, 5].isPassable = 1;
            map[0, 6].isPassable = 1;
            map[0, 7].isPassable = 1;
            map[0, 8].isPassable = 1;
            map[0, 9].isPassable = 1;

            map[1, 0].isPassable = 1;
            map[1, 1].isPassable = 0;
            map[1, 2].isPassable = 1;
            map[1, 3].isPassable = 1;
            map[1, 4].isPassable = 1;
            map[1, 5].isPassable = 1;
            map[1, 6].isPassable = 1;
            map[1, 7].isPassable = 1;
            map[1, 8].isPassable = 1;
            map[1, 9].isPassable = 1;

            map[2, 0].isPassable = 1;
            map[2, 1].isPassable = 0;
            map[2, 2].isPassable = 1;
            map[2, 3].isPassable = 1;
            map[2, 4].isPassable = 1;
            map[2, 5].isPassable = 1;
            map[2, 6].isPassable = 1;
            map[2, 7].isPassable = 1;
            map[2, 8].isPassable = 1;
            map[2, 9].isPassable = 1;

            map[3, 0].isPassable = 1;
            map[3, 1].isPassable = 0;
            map[3, 2].isPassable = 1;
            map[3, 3].isPassable = 1;
            map[3, 4].isPassable = 1;
            map[3, 5].isPassable = 1;
            map[3, 6].isPassable = 1;
            map[3, 7].isPassable = 1;
            map[3, 8].isPassable = 1;
            map[3, 9].isPassable = 1;

            map[4, 0].isPassable = 1;
            map[4, 1].isPassable = 0;
            map[4, 2].isPassable = 0;
            map[4, 3].isPassable = 0;
            map[4, 4].isPassable = 0;
            map[4, 5].isPassable = 0;
            map[4, 6].isPassable = 0;
            map[4, 7].isPassable = 0;
            map[4, 8].isPassable = 0;
            map[4, 9].isPassable = 1;

            map[5, 0].isPassable = 1;
            map[5, 1].isPassable = 1;
            map[5, 2].isPassable = 1;
            map[5, 3].isPassable = 1;
            map[5, 4].isPassable = 1;
            map[5, 5].isPassable = 1;
            map[5, 6].isPassable = 1;
            map[5, 7].isPassable = 1;
            map[5, 8].isPassable = 0;
            map[5, 9].isPassable = 1;

            map[6, 0].isPassable = 1;
            map[6, 1].isPassable = 1;
            map[6, 2].isPassable = 1;
            map[6, 3].isPassable = 1;
            map[6, 4].isPassable = 1;
            map[6, 5].isPassable = 1;
            map[6, 6].isPassable = 1;
            map[6, 7].isPassable = 1;
            map[6, 8].isPassable = 0;
            map[6, 9].isPassable = 1;

            map[7, 0].isPassable = 1;
            map[7, 1].isPassable = 1;
            map[7, 2].isPassable = 1;
            map[7, 3].isPassable = 1;
            map[7, 4].isPassable = 1;
            map[7, 5].isPassable = 1;
            map[7, 6].isPassable = 0;
            map[7, 7].isPassable = 0;
            map[7, 8].isPassable = 0;
            map[7, 9].isPassable = 1;

            map[8, 0].isPassable = 1;
            map[8, 1].isPassable = 1;
            map[8, 2].isPassable = 1;
            map[8, 3].isPassable = 1;
            map[8, 4].isPassable = 1;
            map[8, 5].isPassable = 1;
            map[8, 6].isPassable = 0;
            map[8, 7].isPassable = 1;
            map[8, 8].isPassable = 1;
            map[8, 9].isPassable = 1;

            map[9, 0].isPassable = 1;
            map[9, 1].isPassable = 1;
            map[9, 2].isPassable = 1;
            map[9, 3].isPassable = 1;
            map[9, 4].isPassable = 1;
            map[9, 5].isPassable = 1;
            map[9, 6].isPassable = 1;
            map[9, 7].isPassable = 1;
            map[9, 8].isPassable = 1;
            map[9, 9].isPassable = 1;
        }

        void printMap()
        {

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if(currentPoint.x == i && currentPoint.y == j)
                    {
                        Console.Write("O");
                    }
                    else if (map[i, j].isPassable == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("X");
                    }

                    if (j == 9)
                        Console.Write("\n");
                }

            }
        }

        public Agent(int mapSize, Node startingPos, Node endPos)
        {
            this.mapSize = mapSize;
            path = new List<Node>();
            currentPoint = new Node(startingPos.x,startingPos.y);
            currentPoint = startingPos;
            startPoint = startingPos;
            endPoint = endPos;

        }

        public List<Node> SolvePath()
        {
            while(currentPoint != endPoint)
            {
                CheckTerrain();
            }
            return solutionList;
        }

        public double CalculateDistanceFromExit(Node current, Node end)
        {
            int distanceX = current.x - end.x;
            int distanceY = current.y - end.y;

            double c = Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2);
            c = Math.Sqrt(c);

            double endDistance = c;
            return endDistance;
        }
      
        private void CheckTerrain()
        {

            if(!path.Contains(currentPoint))
            {
                path.Add(currentPoint);
            }
            
            //Up
            if (map[currentPoint.x, currentPoint.y + 1].isPassable == 0 )
            {
                nextPos = map[currentPoint.x, currentPoint.y + 1];
                if (!path.Contains(nextPos))
                {
                    Move("Right");
                }
            }

            //Right
            else if (map[currentPoint.x + 1, currentPoint.y].isPassable == 0)
            {
                nextPos = map[currentPoint.x + 1, currentPoint.y];
                if (!path.Contains(nextPos))
                {
                    Move("Down");
                }               
            }

            //Down
            else if (map[currentPoint.x, currentPoint.y - 1].isPassable == 0) 
            {
                nextPos = map[currentPoint.x, currentPoint.y - 1];
                if (!path.Contains(nextPos))
                {
                   Move("Left");
                }                  
            }

            //Left
            else if (map[currentPoint.x - 1, currentPoint.y].isPassable == 0)
            {
                nextPos = map[currentPoint.x - 1, currentPoint.y];
                if (!path.Contains(nextPos))
                { 
                    Move("Up"); 
                }                      
            }
            







        }
       
        Node Move(string direction)
        {
     
                if (direction.Equals("Down"))
                {
                //Move Down      
                map[currentPoint.x, currentPoint.y].isPassable = 1;
                    currentPoint = nextPos;
                    Console.WriteLine("Moved Down");
                    
                    return currentPoint;
                }
                else if (direction.Equals("Up"))
                {
                //Move Up
                map[currentPoint.x, currentPoint.y].isPassable = 1;
                currentPoint = nextPos;
                    Console.WriteLine("Moved Up");
                    return currentPoint;
                }
                else if (direction.Equals("Left"))
                {
                // Move Left
                map[currentPoint.x, currentPoint.y].isPassable = 1;
                currentPoint = nextPos;
                    Console.WriteLine("Moved Left");
                    return currentPoint;
                }
                else
                {
                //Move Right
                map[currentPoint.x, currentPoint.y].isPassable = 1;
                currentPoint = nextPos;
                    Console.WriteLine("Moved Right");
                    return currentPoint;
                }

        }

    

            public static void Main(string[] args)
            {
            Agent agent;
            Console.WriteLine("Input your list (Enter to use default 10x10 test area)");
            string input = Console.ReadLine();
            if(input.Length == 0)
            {
                Node start = new Node(2, 1);
                Node end = new Node(8, 6);

                agent = new Agent(10, start, end);
                agent.fillMap(String.Empty,true);
            } else
            {
                //make sure it's in the correct format

                Console.WriteLine("Input the X coordinate of the start tile");
                Int32.TryParse(Console.ReadLine(), out int startX);
                Console.WriteLine("Input the Y coordinate of the start tile");
                Int32.TryParse(Console.ReadLine(), out int startY);
                Console.WriteLine("Input the X coordinate of the end tile");
                Int32.TryParse(Console.ReadLine(), out int endX);
                Console.WriteLine("Input the Y coordinate of the end tile");
                Int32.TryParse(Console.ReadLine(), out int endY);


                agent = new Agent((int)Math.Sqrt(input.Length), new Node(startX,startY), new Node(endX,endY));
                agent.fillMap(input, true);
            }

           


            Console.WriteLine(agent.SolvePath());
            Console.Read();

            }

    }
}

