using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_Nightmare
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager _gameManager;

        // 프레임 간의 시간 간격(DeltaTime)을 계산하기 위한 변수
        private DateTime _lastTick;

        public MainWindow()
        {
            InitializeComponent();

            // 1. GameManager 초기화 (Canvas 전달)
            _gameManager = new GameManager(MyCanvas);

            // 2. 현재 시간 기록
            _lastTick = DateTime.Now;

            // 3. WPF의 렌더링 파이프라인에 게임 루프 메서드 등록 (매 프레임마다 실행됨)
            CompositionTarget.Rendering += GameLoop;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // 매 프레임이 실행될 때마다 지난 프레임과의 시간 차이(초 단위) 계산
            DateTime now = DateTime.Now;
            double deltaTime = (now - _lastTick).TotalSeconds;
            _lastTick = now;

            // 너무 큰 deltaTime이 들어오는 것을 방지 (예: 창을 드래그하고 있을 때 렉 방지)
            if (deltaTime > 0.1) deltaTime = 0.1;

            // 4. 게임 로직 및 렌더링 연속 업데이트
            _gameManager.ProcessInput();
            _gameManager.Update(deltaTime);
            _gameManager.Render();
        }
    }
}
