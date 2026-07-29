using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class MonsterAIComponent : AIComponent
    {
        public double DetectRange { get; private set; } = 200.0;
        public double AttackRange { get; private set; } = 2.0;
        public static double DeltaTime {  get; private set; }

        public event Action<AnimState> OnStateChange;

        public bool Facing { get; private set; } //L or R

        public void ChangeAnimState(AnimState newState)
        {
            if (CurAnimState == newState) return;
            CurAnimState = newState;
            OnStateChange?.Invoke(CurAnimState);
        }

        public MonsterAIComponent(GameObject target)
        {
            _target = target;
            CurState = MonsterState.CHASE;
        }

        public override void Update(GameObject owner, double deltaTime)
        {
            DeltaTime = deltaTime; 
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
                //임시
                ChangeAnimState(AnimState.Idle_Right);
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
                if (Facing) ChangeAnimState(AnimState.Attacking_Right);
                else ChangeAnimState(AnimState.Attacking_Left);
                return;
            }
            else if (distance > DetectRange) 
            {
                //임시
                if (Facing) ChangeAnimState(AnimState.Idle_Right);
                else ChangeAnimState(AnimState.Idle_Left);
                return;
            }
            double speed = owner.Stats.Speed * DeltaTime;
            double dx = 0;
            double dy = 0;
            if (owner.X < _target.X)
            {
                Facing = true;
                //mx = (int)owner.Stats.Speed;
                dx += speed;
                ChangeAnimState(AnimState.Moving_Right);
            }
            else
            {
                Facing = false;
                dx -= speed;
                ChangeAnimState(AnimState.Moving_Left);
            }
            if (owner.Y < _target.Y) dy += speed;
            else dy -= speed;

            int[,] tempMap = { { 0, 0, 0, 0 }, }; //임시 맵


            owner.Move.MoveBy(owner, dx, dy, tempMap);
        }

        private void UpdateAttack(GameObject owner)
        {
            //데미지 판정 로직

            if (GetDistance(owner, _target) > AttackRange)
            {
                //임시
                ChangeAnimState(AnimState.Attacking_Right);
            }
        }

        private void UpdateDie(GameObject owner)
        {
            //죽음 로직
        }

        private double GetDistance(GameObject a, GameObject b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
