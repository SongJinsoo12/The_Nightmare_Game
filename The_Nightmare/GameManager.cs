using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class GameManager
    {
        public int[,] Map { get; private set; }
        // 플레이어 & 몬스터 갖고오기
        public Player player = new Player(1, 1, 100, 100);

        public GameManager()
        {
            Map = new int[20,20];
            // 초기화

            // 예시
            player.Move = new MoveComponent();
            player.Stats = new StatsComponent(100, 10, 5, 1.0);
            player.Render = new SpriteRenderComponent("Assets/Player.png");
            player.Collider = new ColliderComponent();
        }
        public void ProcessInput()
        {
            // 입력 처리
        }
        public void Update()
        {
            // 게임 로직 업데이트
        }
        public void Render()
        {
            // 화면 렌더링
        }
    }
}
