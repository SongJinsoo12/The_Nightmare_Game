using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Nightmare.Component;

namespace The_Nightmare
{
    public class SkeletonCreator : ICreator
    {
        private GameObject _playerRef;

        public SkeletonCreator(GameObject player)
        {
            _playerRef = player;
        }

        public GameObject Create(int x, int y)
        {
            GameObject skeleton = new GameObject(x, y);

            // 컴포넌트 조립
            skeleton.Move = new MoveComponent();
            skeleton.Stats = new StatsComponent(50, 10, 5, 2);
            skeleton.Render = new SpriteRenderComponent("SkeletonSprite");
            skeleton.Collider = new ColliderComponent();
            skeleton.AI = new ChaseComponent(_playerRef);

            return skeleton;
        }
    }
}
