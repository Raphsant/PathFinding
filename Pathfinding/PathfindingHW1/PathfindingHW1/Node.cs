using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingHW1
{
    class Node
    {
        public int isPassable;
        public int x;
        public int y;
        
        public Node(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
     
    }
}
