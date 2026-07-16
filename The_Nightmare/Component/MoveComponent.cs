using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class MoveComponent
    {
        public void MoveBy(GameObject owner, int deltaX, int deltaY, int[,] map)
        {
            int nextX = owner.X + deltaX;
            int nextY = owner.Y + deltaY;

            if(nextX >= 0 && nextX < map.GetLength(0) && nextY >= 0 && nextY < map.GetLength(1))
            {
                if(map[nextX, nextY] == 0)
                {
                    owner.X = nextX;
                    owner.Y = nextY;
                }
            }
        }
    }
}
