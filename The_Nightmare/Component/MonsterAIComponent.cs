using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare.Component
{
    public class MonsterAIComponent : AIComponent
    {
        private GameObject _target;
        private MonsterState _curState;

        public double DetectRange { get; private set; } = 10.0;
        public double AttackRange { get; private set; } = 2.0;

        public MonsterAIComponent(GameObject target)
        {
            _target = target;
            _curState = MonsterState.IDLE;
        }

        public override void Update(GameObject owner)
        {
            if (_target == null || owner.Move == null) return;

            switch (_curState)
            {
                case MonsterState.IDLE:
                    UpdateIdle(owner);
                    break;
                case MonsterState.PATROL:
                    UpdatePatrol(owner);
                    break;
                case MonsterState.CHASE:
                    UpdateChase(owner);
                    break;
                case MonsterState.ATTACK:
                    UpdateAttack(owner);
                    break;
            }
        }

        private void UpdateIdle(GameObject owner)
        {
            //제자리 애니메이션 추후 추가

            if (GetDistance(owner, _target) <= DetectRange)
            {
                _curState = MonsterState.CHASE;
            }
        }

        private void UpdatePatrol(GameObject owner)
        {
            //순찰 애니메이션 및 로직 추후 추가
        }

        private void UpdateChase(GameObject owner)
        {
            double distance = GetDistance(owner, _target);

            if (distance <= AttackRange)
            {
                _curState = MonsterState.ATTACK;
                return;
            }
            else if (distance > DetectRange) 
            {
                _curState = MonsterState.IDLE;
                return;
            }

            int mx, my;
            if (owner.X < _target.X) mx = owner.Stats.Speed;
            else mx = -(owner.Stats.Speed);
            if (owner.Y < _target.Y) my = owner.Stats.Speed;
            else my = -(owner.Stats.Speed);

            int[,] tempMap = { { 0, 0, 0, 0 }, }; //임시 맵

            owner.Move.Move(owner, mx, my, tempMap);
        }

        private void UpdateAttack(GameObject owner)
        {
            //공격 애니메이션 및 데미지 판정 로직

            if (GetDistance(owner, _target) > AttackRange)
            {
                _curState = MonsterState.CHASE;
            }
        }

        private double GetDistance(GameObject a, GameObject b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
