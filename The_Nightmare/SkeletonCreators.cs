using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_Nightmare.Creators
{
    public partial class SkeletonCreator : ICreator
    {
        private const string filePath = "pack://application:,,/assets/Skeleton_With_VFX/";
        private const int width = 96;
        private const int height = 64;

        public SkeletonCreator(GameObject player, Canvas canvas)
        {
            _playerRef = player;
            _canvasRef = canvas;
        }

        public override GameObject Create(int x, int y)
        {
            GameObject skeleton = new GameObject(x, y);

            // 컴포넌트 조립
            CreateBaseComponent(skeleton);
            skeleton.Stats = new StatsComponent(50, 10, 5, 2);

            Animation idleAnim = new Animation(filePath +
                "Skeleton_01_White_Idle.png", width, height, 8, 0.1, true);
            skeleton.Animator.AddAnimation(AnimState.Idle_Right, idleAnim);

            Animation walkAnim = new Animation(filePath +
                "Skeleton_01_White_Walk.png", width, height, 10, 0.08, true);
            skeleton.Animator.AddAnimation(AnimState.Moving_Right, walkAnim);

            Animation dieAnim = new Animation(filePath +
                "Skeleton_01_White_Die.png", width, height, 13, 0.08, true);
            skeleton.Animator.AddAnimation(AnimState.Dead, dieAnim);


            //임시
            skeleton.Animator.Play(AnimState.Idle_Right);

            return skeleton;
        }
    }

    public partial class SkeletonCreator
    {
    }
}
