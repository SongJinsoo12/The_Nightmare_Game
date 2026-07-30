using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Nightmare.Components;

namespace The_Nightmare
{
    public class GameObject
    {
        public double X { get; set; }
        public double Y { get; set; }

        public StatsComponent Stats { get; set; }
        public SpriteRenderComponent Render { get; set; }
        public MoveComponent Move { get; set; }
        public ColliderComponent Collider { get; set; }
        public AIComponent AI { get; set; }
        public GameObject(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
        public AnimatorComponent<AnimState> Animator { get; set; }
    }
}
