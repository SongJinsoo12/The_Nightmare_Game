using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace The_Nightmare
{
    public class GameManager
    {
        // deltaTime은 이것을 사용!
        public static double DeltaTime { get; private set; }
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
        // 연속적인 입력 처리 - 예시: 이동
        public void ProcessContinuousInput()
        {
            // 입력 처리
            if(Keyboard.IsKeyDown(Key.W)) player.Move.MoveBy(player, 0, 1, Map);
            if(Keyboard.IsKeyDown(Key.S)) player.Move.MoveBy(player, 0, -1, Map);
            if(Keyboard.IsKeyDown(Key.A)) player.Move.MoveBy(player, -1, 0, Map);
            if(Keyboard.IsKeyDown(Key.D)) player.Move.MoveBy(player, 1, 0, Map);
        }

        // 단일 입력 처리 - 예시: 공격
        public void ProcessSingleInput(Key key)
        {
            // 입력 처리
        }
        public void Update(double deltaTime)
        {
            DeltaTime = deltaTime;
            // 게임 로직 업데이트
            player.Update(deltaTime);
        }
        public void Render()
        {
            // 화면 렌더링
        }
    }
}
