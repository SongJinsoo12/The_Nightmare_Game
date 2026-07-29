using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_Nightmare
{
    public class Player : GameObject
    {
        // 추가 스탯
        public double m_stamina { get; private set; } = 100;
        public int m_mana { get; private set; } = 100;

        public PlayerState CurrentState { get; private set; } = PlayerState.Idle;
        public Direction FacingDirection { get; private set; } = Direction.Right;

        // 무기 공격력
        public int WeaponAtk { get; private set; } = 0;
        public int TotalAtk => (Stats?.Atk ?? 0) + WeaponAtk;

        private const string filePath = "pack://application:,,/assets/Soldier/";
        private const int imgSize = 100;

        public Player(int _x, int _y, double _stamina, int _mana, Canvas canvas) : base(_x, _y)
        {
            this.X = _x;
            this.Y = _y;

            this.Move = new MoveComponent();
            this.Stats = new StatsComponent(100, 10, 5, 50.0);
            m_stamina = _stamina;
            m_mana = _mana;
            
            this.Collider = new ColliderComponent();

            this.Render = new SpriteRenderComponent();
            canvas.Children.Add(this.Render.SpriteControl);

            this.Render.SetSize(150, 150);

            this.Animator = new AnimatorComponent<AnimState>();
            LoadAnimation();

            UpdateAnimation();
        }

        public void TryMove(double dx, double dy, int[,] map)
        {
            if (dx == 0 && dy == 0)
            {
                ChangeState(PlayerState.Idle);
                return;
            }
            if(CurrentState == PlayerState.Dead) return;

            if (CurrentState == PlayerState.Attacking ||
                CurrentState == PlayerState.Hit)
                return;

            // 이동 방향에 따른 방향 전환
            if (dx > 0) FacingDirection = Direction.Right;
            else if ((dx < 0)) FacingDirection = Direction.Left;
            else if (dy > 0) FacingDirection = Direction.Down;
            else if (dy < 0) FacingDirection = Direction.Up;

            ChangeState(PlayerState.Moving);
            Move.MoveBy(this, dx, dy, map);
            UpdateAnimation();
        }

        public void Update(double deltaTime)
        {
            // 스테미나 회복
            m_stamina += 5 * deltaTime;
            if (m_stamina > 100) m_stamina = 100;

            // 상태 업데이트
            if (CurrentState == PlayerState.Hit && Stats.Health <= 0)
            {
                ChangeState(PlayerState.Dead);
                Console.WriteLine("플레이어가 사망했습니다.");
            }
        }

        public void ChangeState(PlayerState newState)
        {
            if (CurrentState == PlayerState.Dead) return;

            // 애니메이션이 끝나기 전에 상태가 바뀌는 것을 방지
            if (CurrentState == PlayerState.Attacking && newState == PlayerState.Idle)
            {
                return;
            }
            CurrentState = newState;
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            // 예: CurrentState가 Moving이고 FacingDirection이 Left라면 "Moving_Left" 문자열 생성
            string animKeyStr = $"{CurrentState}_{FacingDirection}";

            // 문자열을 PlayerAnimState Enum으로 안전하게 변환하여 재생
            if (Enum.TryParse(animKeyStr, out AnimState animState))
            {
                Animator?.Play(animState);
            }
        }

        private void LoadAnimation()
        {
            Animation walkRight = new Animation(filePath + "Soldier_Walk.png", imgSize, imgSize, 6, 0.1);
            Animation idleRight = new Animation(filePath + "Soldier_Idle.png", imgSize, imgSize, 6, 0.1);
            Animation walkLeft = new Animation(filePath + "Soldier_Walk.png", imgSize, imgSize, 6, 0.1, true, true);
            Animation idleLeft = new Animation(filePath + "Soldier_Idle.png", imgSize, imgSize, 6, 0.1, true, true);

            this.Animator.AddAnimation(AnimState.Moving_Right, walkRight);
            this.Animator.AddAnimation(AnimState.Idle_Right, idleRight);
            this.Animator.AddAnimation(AnimState.Moving_Left, walkLeft);
            this.Animator.AddAnimation(AnimState.Idle_Left, idleLeft);
        }

        public void Attack(List<GameObject> enemies)
        {
            if (CurrentState == PlayerState.Attacking ||
                CurrentState == PlayerState.Hit)
                return;
            ChangeState(PlayerState.Attacking);

            // 범위 계산
            double targetX = X;
            double targetY = Y;

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
