using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_Nightmare.MonsterCreator
{
    public partial class OrcCreator : ICreator
    {
        private const string filePath = "pack://application:,,/assets/Orc with shadows/";
        private const int width = 100;
        private const int height = 100;

        public OrcCreator(GameObject player, Canvas canvas)
        {
            _playerRef = player;
            _canvasRef = canvas;
        }

        public override GameObject Create(int x, int y)
        {
            GameObject orc = new GameObject(x, y);
            CreateBaseComponent(orc);
            orc.Stats = new StatsComponent(50, 10, 5, 50.0);

            //R Animation
            Animation idleRight = new Animation(filePath +
                "Orc_Idle.png", width, height, 6, 0.1, true);
            orc.Animator.AddAnimation(AnimState.Idle_Right, idleRight);

            Animation walkRight = new Animation(filePath +
                "Orc_Walk.png", width, height, 8, 0.1, true);
            orc.Animator.AddAnimation(AnimState.Moving_Right, walkRight);

            Animation attackRight = new Animation(filePath +
                "Orc_Attack01.png", width, height, 6, 0.1, true);
            orc.Animator.AddAnimation(AnimState.Attacking_Right, attackRight);

            Animation hurtRight = new Animation(filePath +
                "Orc_Hurt.png", width, height, 4, 0.1, true);
            orc.Animator.AddAnimation(AnimState.Hit_Right, hurtRight);

            Animation deadRight = new Animation(filePath +
                "Orc_Death.png", width, height, 4, 0.1);
            orc.Animator.AddAnimation(AnimState.Dead_Right, deadRight);

            //L Animation
            Animation idleLeft = new Animation(filePath +
                "Orc_Idle.png", width, height, 6, 0.1, true, true);
            orc.Animator.AddAnimation(AnimState.Idle_Left, idleLeft);

            Animation walkLeft = new Animation(filePath +
                "Orc_Walk.png", width, height, 8, 0.1, true, true);
            orc.Animator.AddAnimation(AnimState.Moving_Left, walkLeft);

            Animation attackLeft = new Animation(filePath +
                "Orc_Attack01.png", width, height, 6, 0.1, true, true);
            orc.Animator.AddAnimation(AnimState.Attacking_Left, attackLeft);

            Animation hurtLeft = new Animation(filePath +
                "Orc_Hurt.png", width, height, 4, 0.1, true, true);
            orc.Animator.AddAnimation(AnimState.Hit_Left, hurtLeft);

            Animation deadLeft = new Animation(filePath +
                "Orc_Death.png", width, height, 4, 0.1, false, true);
            orc.Animator.AddAnimation(AnimState.Dead_Left, deadLeft);

            return orc;
        }
    }
}
