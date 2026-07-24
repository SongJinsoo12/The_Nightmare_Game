using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class MoveComponent
    {
        public void MoveBy(GameObject owner, double deltaX, double deltaY, int[,] map)
        {
            int nextX = (int)(owner.X + deltaX);
            int nextY = (int)(owner.Y + deltaY);

            //if(nextX >= 0 && nextX < map.GetLength(0) && nextY >= 0 && nextY < map.GetLength(1))
            //{
            //    if(map[nextX, nextY] == 0)
            //    {
            //        owner.X = nextX;
            //        owner.Y = nextY;
            //    }
            //}
            owner.X = nextX;
            owner.Y = nextY;
        }
    }
}
