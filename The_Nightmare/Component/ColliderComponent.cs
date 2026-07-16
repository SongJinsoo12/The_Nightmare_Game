using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class ColliderComponent
    {
        public bool IsColliding(GameObject owner, GameObject other)
        {
            if (other == null) return false;
            return owner.X == other.X && owner.Y == other.Y;
        }
    }
}
