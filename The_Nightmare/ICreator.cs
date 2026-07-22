using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_Nightmare
{
    public abstract class ICreator
    {
        protected GameObject _playerRef;
        protected Canvas _canvasRef;
        public abstract GameObject Create(int x, int y);

        public void CreateBaseComponent(GameObject _object)
        {
            _object.Move = new MoveComponent();
            _object.Collider = new ColliderComponent();
            _object.Render = new SpriteRenderComponent();
            _canvasRef.Children.Add(_object.Render.SpriteControl);
            _object.Animator = new AnimatorComponent<AnimState>();
            MonsterAIComponent monsterAI = new MonsterAIComponent(_playerRef);
            //임시
            //monsterAI.OnStateChange += (newState) => _object.Animator.Play(newState);
            _object.AI = monsterAI;
        }
    }
}
