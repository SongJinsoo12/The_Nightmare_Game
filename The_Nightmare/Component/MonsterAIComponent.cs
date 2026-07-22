using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class MonsterAIComponent : AIComponent
    {
        public double DetectRange { get; private set; } = 10.0;
        public double AttackRange { get; private set; } = 2.0;

        public event Action<MonsterState> OnStateChange;

        public void ChangeState(MonsterState newState)
        {
            if (CurState == newState) return;
            CurState = newState;
            OnStateChange?.Invoke(CurState);
        }

        public MonsterAIComponent(GameObject target)
        {
            _target = target;
            CurState = MonsterState.DIE;
        }

        public override void Update(GameObject owner)
        {
            if (_target == null || owner.Move == null) return;

            switch (CurState)
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
                case MonsterState.DIE:
                    UpdateDie(owner);
                    break;
            }
        }

        private void UpdateIdle(GameObject owner)
        {
            if (GetDistance(owner, _target) <= DetectRange)
            {
                ChangeState(MonsterState.CHASE);
            }
        }

        private void UpdatePatrol(GameObject owner)
        {
            //로직 추후 추가
            
        }

        private void UpdateChase(GameObject owner)
        {
            double distance = GetDistance(owner, _target);

            if (distance <= AttackRange)
            {
                ChangeState(MonsterState.ATTACK);
                return;
            }
            else if (distance > DetectRange) 
            {
                ChangeState(MonsterState.IDLE);
                return;
            }

            int mx, my;
            if (owner.X < _target.X) mx = (int)owner.Stats.Speed;
            else mx = (int)-(owner.Stats.Speed);
            if (owner.Y < _target.Y) my = (int)owner.Stats.Speed;
            else my = (int)-(owner.Stats.Speed);

            int[,] tempMap = { { 0, 0, 0, 0 }, }; //임시 맵

            owner.Move.MoveBy(owner, mx, my, tempMap);
        }

        private void UpdateAttack(GameObject owner)
        {
            //데미지 판정 로직

            if (GetDistance(owner, _target) > AttackRange)
            {
                ChangeState(MonsterState.CHASE);
            }
        }

        private void UpdateDie(GameObject owner)
        {
            //죽음 로직
        }

        private double GetDistance(GameObject a, GameObject b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
