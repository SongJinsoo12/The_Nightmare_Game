using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Nightmare.Component;

namespace The_Nightmare
{
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public StatsComponent Stats { get; set; }
        public SpriteRenderComponent Render { get; set; }
        public MoveComponent Move { get; set; }
        public ColliderComponent Collider { get; set; }
        public AIComponent AI { get; set; }
        public GameObject(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
        public AnimatorComponent Animator { get; set; }
    }
}
