using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class ColliderComponent
    {
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;
        public bool IsActive { get; set; } = true;
        public bool IsColliding(GameObject owner, GameObject other)
        {
            if (other == null || !IsActive) return false;
            if(other.Collider == null || !other.Collider.IsActive) return false;

            int otherWidth = other.Collider != null ? other.Collider.Width : 1;
            int otherHeight = other.Collider != null ? other.Collider.Height : 1;

            bool xOverlap = owner.X < other.X + otherWidth && owner.X + Width > other.X;
            bool yOverlap = owner.Y < other.Y + otherHeight && owner.Y + Height > other.Y;

            return xOverlap && yOverlap;
        }
        public bool Intersects(int ownerX, int ownerY, int targetX, int targetY, int targetWidth = 1,int targetHeight = 1)
        {
            if (!IsActive) return false;

            bool xOverlap = ownerX < targetX + targetWidth && ownerX + Width > targetX;
            bool yOverlap = ownerY < targetY + targetHeight && ownerY + Height > targetY;

            return xOverlap && yOverlap;
        }
    }
}
