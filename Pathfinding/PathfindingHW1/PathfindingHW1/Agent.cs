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

        private double distanceScoreRight;
        private double distanceScoreLeft;
        private double distanceScoreUp;
        private double distanceScoreDown;

        private double[] distanceArray;


        private List<Node> solutionList;

        void fillMap()
        {
            map = new Node[10,10];
            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
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

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
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

        public Agent(Node[,] map, Node startingPos, Node endPos)
        {
            path = new List<Node>();
            this.map = map;
            currentPoint = new Node(startingPos.x,startingPos.y);
            currentPoint = startingPos;
            startPoint = startingPos;
            endPoint = endPos;
            distanceArray = new double[4];
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


            if (map[currentPoint.x, currentPoint.y + 1].isPassable == 0)
            {
                if (!path.Contains(nextPos))
                {
                    //Passable
                    //distanceArray[2] = CheckDistanceRight();
                    nextPos = map[currentPoint.x, currentPoint.y + 1];
                    path.Add(currentPoint);
                    Move("Right");
                }
            }
            //Right
            else if (map[currentPoint.x + 1, currentPoint.y].isPassable == 0)
            {
                if(!path.Contains(nextPos))
                {
                    //Passable                               
                    // distanceArray[0] = CheckDistanceDown();
                    nextPos = map[currentPoint.x + 1, currentPoint.y];
                    path.Add(currentPoint);
                    Move("Down");
                }               
            }
            else if (map[currentPoint.x, currentPoint.y - 1].isPassable == 0)
            {
                if (!path.Contains(nextPos))
                {
                    //Passable
                    //distanceArray[3] = CheckDistanceLeft();
                    nextPos = map[currentPoint.x, currentPoint.y - 1];
                    path.Add(currentPoint);
                    Move("Left");
                }                   
            }

            else if (map[currentPoint.x - 1, currentPoint.y].isPassable == 0)
            {
                if(!path.Contains(nextPos))
                {
                    //Passable
                    //distanceArray[1] = CheckDistanceUp();
                    nextPos = map[currentPoint.x - 1, currentPoint.y];
                    Move("Up");
                    path.Add(currentPoint);
                }                          
            }


            
   
           

           

           // CheckForLowestDistance();
        }
        /*
        double CheckDistanceDown()
        {
            Node downPoint = new Node(currentPoint.x + 1, currentPoint.y);
            //return Math.Pow(rightPoint,2) - Math.Pow(endPoint,2) 
            return distanceScoreRight = CalculateDistanceFromExit(downPoint, endPoint);
        }

        double CheckDistanceUp()
        {
            Node upPoint = new Node(currentPoint.x - 1, currentPoint.y);
            return distanceScoreLeft = CalculateDistanceFromExit(upPoint, endPoint);
        }

        double CheckDistanceLeft()
        {
            Node leftPoint = new Node(currentPoint.x, currentPoint.y-1);
            return distanceScoreUp = CalculateDistanceFromExit(leftPoint, endPoint);
        }

        double CheckDistanceRight()
        {
            Node rightPoint = new Node(currentPoint.x, currentPoint.y+1);
            return distanceScoreDown = CalculateDistanceFromExit(rightPoint, endPoint);
        }

        void CheckForLowestDistance()
        {
            double min = distanceArray.Min();
            if(distanceArray[0] == min)
            {
                //Move to right
                Move("Down");
                Console.WriteLine("Down");
            }
            else if(distanceArray[1] == min)
            {
                //Move left
                Move("Up");
                Console.WriteLine("Up");
            }
            else if(distanceArray[2] == min)
            {
                //move up
                Move("Left");
                Console.WriteLine("Left");
            }
            else
            {
                //move down
                Move("Right");
                Console.WriteLine("Right");
            }
            
        }

     
        */

        Node Move(string direction)
        {
            if(!path.Contains(nextPos))
            {
                if (direction.Equals("Down"))
                {
                    //Move Down                  
                    currentPoint = nextPos;
                    Console.WriteLine("Moved Down");
                    return currentPoint;
                }
                else if (direction.Equals("Up"))
                {
                    //Move Up
                    
                    currentPoint = nextPos;
                    Console.WriteLine("Moved Up");
                    return currentPoint;
                }
                else if (direction.Equals("Left"))
                {
                    // Move Left
                    currentPoint = nextPos;
                    Console.WriteLine("Moved Left");
                    return currentPoint;
                }
                else
                {
                    //Move Right
                    currentPoint = nextPos;
                    Console.WriteLine("Moved Right");
                    return currentPoint;
                }
            }        
            else
            {
                Console.WriteLine("Path contained next position");
                return currentPoint;
            }
        }

    

            public static void Main(string[] args)
            {
            
            
            Node[,] aLocals = new Node[10, 10];
            Node start = new Node(2,1);
            Node end = new Node(8,6);

            Agent agent = new Agent(aLocals, start, end);
            agent.fillMap();


            Console.WriteLine(agent.CalculateDistanceFromExit(start, end));
            //agent.currentPoint.Offset(0, 1);
            Console.WriteLine(agent.SolvePath());
            Console.Read();

        }

    }
}

