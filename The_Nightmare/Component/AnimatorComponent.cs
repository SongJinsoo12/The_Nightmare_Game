using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare.Component
{
    public class AnimatorComponent
    {
        public AnimationControl Controller { get; private set; }

        private Dictionary<MonsterState, Animation> _animations;

        public AnimatorComponent()
        {
            Controller = new AnimationControl();
            _animations = new Dictionary<MonsterState, Animation>();
        }

        public void AddAnimation(MonsterState state, Animation anima)
        {
            _animations[state] = anima;
        }

        public void Play(MonsterState state)
        {
            if (_animations.TryGetValue(state, out Animation anima))
            {
                Controller.PlayAnimation(anima);
            }
        }

        public void Update(GameObject owner, double deltaTime)
        {
            Controller.Update(deltaTime);
        }
    }
}
