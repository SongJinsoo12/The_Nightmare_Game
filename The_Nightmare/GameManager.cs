using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using The_Nightmare.Creators;

namespace The_Nightmare
{
    public class GameManager
    {
        // deltaTime은 이것을 사용!
        public static double DeltaTime { get; private set; }

        public Player CurPlayer { get; private set; }
        public List<GameObject> Monsters { get; private set; } = new List<GameObject>();
        public Canvas MyCanvas { get; private set; }
        public int[,] Map { get; private set; }
        // 플레이어 & 몬스터 갖고오기

        public GameManager(Canvas canvas)
        {
            MyCanvas = canvas;

            Map = new int[20,20];
            // 초기화

            // 플레이어
            CurPlayer = new Player(50, 50, 20, 100, MyCanvas);

            //몬스터
            ObjectFactory.Initialize(CurPlayer, "Skeleton", new SkeletonCreator(CurPlayer, MyCanvas));
            GameObject skeleton1 = ObjectFactory.Spawn("Skeleton", 5, 5);
            GameObject skeleton2 = ObjectFactory.Spawn("Skeleton", 0, 0);

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
                p.UpdateMovement(dx, dy, Map);
            }
        }

        // 단일 입력 처리 - 예시: 공격
        public void ProcessSingleInput(Key key)
        {
            // 입력 처리
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
            foreach (var enemy in Monsters)
            {
                enemy.AI?.Update(enemy);
                enemy.Animator?.Update(enemy, deltaTime);
                enemy.Render?.Update(enemy); // 좌표 갱신 및 프레임 교체
            }
        }
    }
}
