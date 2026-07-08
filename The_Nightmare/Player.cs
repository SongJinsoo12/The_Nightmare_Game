using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public enum PlayerState
    {
        Idle,
        Moving,
        Attacking,
        Hit,
        Dead
    }
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Player : GameObject
    {
        public PlayerState CurrentState { get; private set; } = PlayerState.Idle;
        public Direction FacingDirection { get; private set; } = Direction.Down;

        // 무기 공격력
        public int WeaponAtk { get; private set; } = 0;
        public int TotalAtk => (Stats?.Atk ?? 0) + WeaponAtk;

        public Player(int _x, int _y) : base(_x, _y)
        {
            this.Move = new MoveComponent();
            this.Stats = new StatsComponent(100, 10, 5);
        }

        public void TryMove(int dx, int dy, int[,] map)
        {
            if (CurrentState == PlayerState.Attacking ||
                CurrentState == PlayerState.Hit)
                return;

            // 이동 방향에 따른 방향 전환
            if (dx > 0) FacingDirection = Direction.Right;
            else if ((dx < 0)) FacingDirection = Direction.Left;
            else if (dy > 0) FacingDirection = Direction.Down;
            else if (dy < 0) FacingDirection = Direction.Up;

            ChangeState(PlayerState.Moving);
            Move.Move(this, dx, dy, map);

            ChangeState(PlayerState.Idle);
        }

        public void ChangeState(PlayerState newState)
        {
            if (CurrentState == PlayerState.Dead) return;

            // 애니메이션이 끝나기 전에 상태가 바뀌는 것을 방지
            if (CurrentState == PlayerState.Attacking && newState == PlayerState.Idle)
            {

            }
            CurrentState = newState;
        }

        public void Attack(List<GameObject> enemies)
        {
            if (CurrentState == PlayerState.Attacking ||
                CurrentState == PlayerState.Hit)
                return;
            ChangeState(PlayerState.Attacking);

            // 범위 계산
            int targetX = X;
            int targetY = Y;

            switch (FacingDirection)
            {
                case Direction.Up: targetY -= 1; break;
                case Direction.Down: targetY += 1; break;
                case Direction.Left: targetX -= 1; break;
                case Direction.Right: targetX += 1; break;
            }

            foreach (var enemy in enemies)
            {
                if (enemy.X == targetX && enemy.Y == targetY)
                {
                    if (enemy.Stats != null)
                    {
                        enemy.Stats.TakeDamage(TotalAtk);
                        Console.WriteLine($"몬스터에게 {TotalAtk}의 데미지를 입혔습니다.");
                    }
                }
            }
            ChangeState(PlayerState.Idle);
        }

        public void OnHit(int damage)
        {
            if (CurrentState == PlayerState.Dead) return;
            
            if(CurrentState != PlayerState.Hit && CurrentState != PlayerState.Attacking) 
                ChangeState(PlayerState.Hit);
            Stats.TakeDamage(damage);
        }

        // 무기 장착
        public void EquipWeapon(int weaponAtk)
        {
            WeaponAtk = weaponAtk;
        }
    }
}
