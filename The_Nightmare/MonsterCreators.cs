using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class SkeletonCreator : ICreator
    {
        public GameObject Create(int x, int y)
        {
            GameObject skeleton = new GameObject(x, y);

            // 컴포넌트 조립
            skeleton.Move = new MoveComponent();
            skeleton.Stats = new StatsComponent(50, 10, 5, 1.0);
            skeleton.Render = new SpriteRenderComponent("SkeletonSprite");
            skeleton.Collider = new ColliderComponent();

            return skeleton;
        }
    }
}
