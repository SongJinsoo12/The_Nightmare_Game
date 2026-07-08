using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare.Component
{
    public class ChaseComponent : AIComponent
    {
        private GameObject _target;

        public ChaseComponent(GameObject target)
        {
            _target = target;
        }

        public override void Update(GameObject owner)
        {
            if (_target == null || owner.Move == null) return;

            int mx, my;
            if (owner.X < _target.X) mx = owner.Stats.Speed;
            else mx = -(owner.Stats.Speed);
            if (owner.Y < _target.Y) my = owner.Stats.Speed;
            else my = -(owner.Stats.Speed);

            int[,] tempMap = { { 0, 0, 0, 0 }, }; //임시 맵

            owner.Move.Move(owner, mx, my, tempMap);
        }
    }
}
