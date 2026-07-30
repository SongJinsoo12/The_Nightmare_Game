using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class AnimatorComponent<T> where T : Enum
    {
        public AnimationContorol Controller { get; private set; }

        private Dictionary<T, Animation> _animations;

        public AnimatorComponent()
        {
            Controller = new AnimationContorol();
            _animations = new Dictionary<T, Animation>();
        }

        public void AddAnimation(T state, Animation anima)
        {
            _animations[state] = anima;
        }

        public void Play(T state)
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
