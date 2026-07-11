using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using The_Nightmare.Component;

namespace The_Nightmare
{
    public class SkeletonCreator : ICreator
    {
        private GameObject _playerRef;
        private Canvas _canvasRef;

        private const int width = 96;
        private const int height = 64;
        private const int imgNum = 8;

        public SkeletonCreator(GameObject player, Canvas canvas)
        {
            _playerRef = player;
            _canvasRef = canvas;
        }

        public GameObject Create(int x, int y)
        {
            GameObject skeleton = new GameObject(x, y);

            // 컴포넌트 조립
            skeleton.Move = new MoveComponent();
            skeleton.Stats = new StatsComponent(50, 10, 5, 2);
            /*skeleton.Render = new SpriteRenderComponent("pack://application:,,/assets/Skeleton_With_VFX/" +
                "Skeleton_01_White_Idle.png", 0, 0, width, height);*/

            skeleton.Render = new SpriteRenderComponent();
            _canvasRef.Children.Add(skeleton.Render.SpriteControl);
            skeleton.Animator = new AnimatorComponent();

            Animation idleAnim = new Animation("pack://application:,,/assets/Skeleton_With_VFX/" +
                "Skeleton_01_White_Idle.png", width, height, imgNum, 0.1, true);

            skeleton.Animator.AddAnimation(MonsterState.IDLE, idleAnim);

            skeleton.Collider = new ColliderComponent();

            MonsterAIComponent monsterAI = new MonsterAIComponent(_playerRef);
            monsterAI.OnStateChange += (newState) => skeleton.Animator.Play(newState);

            skeleton.AI = monsterAI;

            skeleton.Animator.Play(MonsterState.IDLE);

            return skeleton;
        }
    }
}
