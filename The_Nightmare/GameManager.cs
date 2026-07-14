using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace The_Nightmare
{
    public class GameManager
    {
        public GameObject Player { get; private set; }
        public List<GameObject> Monsters { get; private set; } = new List<GameObject>();
        public Canvas MyCanvas { get; private set; }

        public int[,] Map { get; private set; }
        // 플레이어 & 몬스터 갖고오기

        public GameManager(Canvas canvas)
        {
            MyCanvas = canvas;

            Map = new int[20,20];
            // 초기화

            // 예시
            Player = new GameObject(1, 1);
            Player.Move = new MoveComponent();
            Player.Stats = new StatsComponent(100, 10, 5, 3);
            Player.Render = new SpriteRenderComponent("Assets/Player.png");
            Player.Collider = new ColliderComponent();

            //몬스터
            ObjectFactory.Initialize(Player, "Skeleton", new SkeletonCreator(Player, MyCanvas));
            GameObject skeleton1 = ObjectFactory.Spawn("Skeleton", 5, 5);
            GameObject skeleton2 = ObjectFactory.Spawn("Skeleton", 0, 0);

            Monsters.Add(skeleton1);
            Monsters.Add(skeleton2);
        }
        public void ProcessInput()
        {
            // 입력 처리
        }
        public void Update(double deltaTime)
        {
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
