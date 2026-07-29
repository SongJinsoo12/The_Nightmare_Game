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
            skeleton.Stats = new StatsComponent(50, 10, 5, 50.0);

            //R Anim
            Animation idleRight = new Animation(filePath +
                "Skeleton_01_White_Idle.png", width, height, 8, 0.1, true);
            skeleton.Animator.AddAnimation(AnimState.Idle_Right, idleRight);

            Animation walkRight = new Animation(filePath +
                "Skeleton_01_White_Walk.png", width, height, 10, 0.08, true);
            skeleton.Animator.AddAnimation(AnimState.Moving_Right, walkRight);

            Animation attackRight = new Animation(filePath +
                "Skeleton_01_White_Attack1.png", width, height, 10, 0.08, true);
            skeleton.Animator.AddAnimation(AnimState.Attacking_Right, attackRight);

            //L Anim
            Animation idleLeft = new Animation(filePath +
                "Skeleton_01_White_Idle.png", width, height, 8, 0.1, true, true);
            skeleton.Animator.AddAnimation(AnimState.Idle_Left, idleLeft);

            Animation walkLeft = new Animation(filePath +
                "Skeleton_01_White_Walk.png", width, height, 10, 0.08, true, true);
            skeleton.Animator.AddAnimation(AnimState.Moving_Left, walkLeft);

            Animation attackLeft = new Animation(filePath +
                "Skeleton_01_White_Attack1.png", width, height, 10, 0.08, true, true);
            skeleton.Animator.AddAnimation(AnimState.Attacking_Left, attackLeft);

            //Dead Anim
            Animation dieAnim = new Animation(filePath +
                "Skeleton_01_White_Die.png", width, height, 13, 0.08, true);
            skeleton.Animator.AddAnimation(AnimState.Dead, dieAnim);

            

            return skeleton;
        }
    }

    public partial class SkeletonCreator
    {
    }
}
