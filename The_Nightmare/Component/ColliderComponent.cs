using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class ColliderComponent
    {
        public int Width { get; set; } = 1;
        public int Height { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public bool IsColliding(GameObject owner, GameObject other)
        {
            if (other == null) return false;
            return owner.X == other.X && owner.Y == other.Y;
        }
        public bool Intersects(int ownerX, int ownerY, int targetX, int targetY)
        {
            if (!IsActive) return false;

            bool xOverlap = ownerX + Width > targetX && ownerX <= targetX;
            bool yOverlap = ownerY + Height > targetY && ownerY <= targetY;

            return xOverlap && yOverlap;
        }
    }
}
