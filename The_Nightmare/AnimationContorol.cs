using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace The_Nightmare
{
    public class AnimationContorol
    {
        private Animation _currentAnimation;
        private int _currentFrameIndex;
        private double _timer;

        public bool isFinished { get; private set; }

        public void PlayAnimation(Animation animation)
        {
            if (_currentAnimation == animation) return;

            _currentAnimation = animation;
            _currentFrameIndex = 0;
            _timer = 0;
            isFinished = false;
        }

        public void Update(double deltaTime)
        {
            if (_currentAnimation == null || isFinished) return;
            _timer += deltaTime;

            // 프레임 시간이 지나면
            if (_timer >= _currentAnimation.FrameDuration)
            {
                _timer = 0;
                _currentFrameIndex++;

                // 애니메이션 프레임이 다 돌면
                if (_currentFrameIndex >= _currentAnimation.Frames.Count)
                {
                    if (_currentAnimation.isLoop)
                    {
                        _currentFrameIndex = 0;
                    }
                    else
                    {
                        _currentFrameIndex = _currentAnimation.Frames.Count - 1;
                        isFinished = true;
                    }
                }
            }
        }

        public ImageSource GetCurrentFrame()
        {
            if (_currentAnimation == null || 
                _currentAnimation.Frames.Count == 0) 
                return null;
            return _currentAnimation.Frames[_currentFrameIndex];
        }
    }
}
