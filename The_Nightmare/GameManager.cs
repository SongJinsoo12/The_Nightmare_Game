using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using The_Nightmare.Creators;
using System.Windows.Shapes;
using System.Windows.Media;

namespace The_Nightmare
{
    public class GameManager
    {
        // deltaTime은 이것을 사용!
        public static double DeltaTime { get; private set; }
        public Player CurPlayer { get; private set; }
        private HitboxVisualizer _hitboxVisualizer;
        public List<GameObject> Monsters { get; private set; } = new List<GameObject>();
        public Canvas MyCanvas { get; private set; }
        public int[,] Map { get; private set; }
        // 플레이어 & 몬스터 갖고오기

        public GameManager()
        {
            MyCanvas = canvas;
            _hitboxVisualizer = new HitboxVisualizer(canvas);
            Map = new int[20,20];
            // 초기화

            // 예시
            Player = new GameObject(1, 1);
            Player.Move = new MoveComponent();
            Player.Stats = new StatsComponent(100, 10, 5, 3);
            Player.Render = new SpriteRenderComponent("Assets/Player.png");
            Player.Collider = new ColliderComponent(); */
            CurPlayer = new Player(10, 10, 20, 100, MyCanvas);
            CurPlayer.OnAttacked += (targetX, targetY) =>
            {
                _hitboxVisualizer.ShowAttackArea(targetX, targetY, 1, 1, 3);
            };

            //몬스터
            ObjectFactory.Initialize(CurPlayer, "Skeleton", new SkeletonCreator(CurPlayer, MyCanvas));
            GameObject skeleton1 = ObjectFactory.Spawn("Skeleton", 50, 10);
            GameObject skeleton2 = ObjectFactory.Spawn("Skeleton", 100, 0);

            Monsters.Add(skeleton1);
            Monsters.Add(skeleton2);
        }
        // 연속적인 입력 처리 - 예시: 이동
        public void ProcessContinuousInput()
        {
            // 아무 키도 안 눌렀을 때를 대비해 초기화
            double dx = 0;
            double dy = 0;

            // 프레임당 이동할 실제 거리 계산 (속도 * 델타타임)
            double speed = CurPlayer.Stats.Speed * DeltaTime;

            if (Keyboard.IsKeyDown(Key.W)) dy -= speed;
            if (Keyboard.IsKeyDown(Key.S)) dy += speed;
            if (Keyboard.IsKeyDown(Key.A)) dx -= speed;
            if (Keyboard.IsKeyDown(Key.D)) dx += speed;

            if (CurPlayer is Player p)
            {
                p.TryMove(dx, dy, Map);
            }
        }

        // 단일 입력 처리 - 예시: 공격
        public void ProcessSingleInput(Key key)
        {
            // 입력 처리
            if(key == Key.Space)
            {
                if (CurPlayer is Player p)
                {
                    p.AttackEnemy(Monsters);
                }
            }
        }
        public void Update(double deltaTime)
        {
            DeltaTime = deltaTime;

            ProcessContinuousInput();

            if (CurPlayer != null)
            {
                CurPlayer.Update(deltaTime);
                CurPlayer.Render?.Update(CurPlayer);
            }

            // 게임 로직 업데이트
<<<<<<<<< Temporary merge branch 1
            foreach (var enemy in Monsters)
            {
                enemy.AI?.Update(enemy);
                enemy.Animator?.Update(enemy, deltaTime);
                enemy.Render?.Update(enemy); // 좌표 갱신 및 프레임 교체
            }
        }
    }
    public class HitboxVisualizer
    {
        private Canvas _canvas;
        private const int TileSize = 32; // 타일 크기
        private List<Rectangle> _hitboxes = new List<Rectangle>();

        public HitboxVisualizer(Canvas canvas)
        {
            _canvas = canvas;
        }

        public async void ShowAttackArea(int targetX, int targetY, int width, int height, double duration)
        {
            // 기존 히트박스 제거
            foreach (var rect in _hitboxes)
            {
                _canvas.Children.Remove(rect);
            }
            _hitboxes.Clear();
            // 새로운 히트박스 생성
            Rectangle hitbox = new Rectangle
            {
                Width = width * TileSize,
                Height = height * TileSize,
                Fill = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0)), // 반투명 빨간색
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };
            Canvas.SetLeft(hitbox, targetX);
            Canvas.SetTop(hitbox, targetY);
            _canvas.Children.Add(hitbox);
            _hitboxes.Add(hitbox);
            // 일정 시간 후 히트박스 제거
            await Task.Delay(TimeSpan.FromSeconds(duration));
            _canvas.Children.Remove(hitbox);
            _hitboxes.Remove(hitbox);
        }
        (var enemy in Monsters)
            {
                enemy.AI?.Update(enemy);
                enemy.Animator?.Update(enemy, deltaTime);
                enemy.Render?.Update(enemy); // 좌표 갱신 및 프레임 교체
            }
=========
            player.Update(deltaTime);
        }
        public void Render()
        {
            // 화면 렌더링
>>>>>>>>> Temporary merge branch 2
        }
    }
}
