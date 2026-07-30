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
        // Timer
        private System.Diagnostics.Stopwatch _gameClock = new System.Diagnostics.Stopwatch();
        private double _lastTotalSeconds = 0.0;

        // 시간 저금통 원리
        private double _accumlator = 0.0;
        private const double TargetFrameTime = 1.0 / 60.0;

        private GameManager _gameManager;
        public MainWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager(MyCanvas);

            this.Loaded += Window_Loaded;
        }

        // 게임 루프 시작
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _gameClock.Start();
            _lastTotalSeconds = 0.0;
            CompositionTarget.Rendering += GameLoop;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _gameManager.ProcessSingleInput(e.Key);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // deltaTime 계산
            double currentTotalSeconds = _gameClock.Elapsed.TotalSeconds;
            double deltaTime = currentTotalSeconds - _lastTotalSeconds;
            _lastTotalSeconds = currentTotalSeconds;

            // deltaTime 제한 (너무 큰 값 방지)
            if (deltaTime > 0.05)
                deltaTime = 0.05;

            if (deltaTime < 0) return;

            // 누적 시간 계산
            _accumlator += deltaTime;
            // 프레임 시간에 따라 게임 업데이트
            while (_accumlator >= TargetFrameTime)
            {
                _gameManager.ProcessContinuousInput();

                _gameManager.Update(TargetFrameTime);
                _accumlator -= TargetFrameTime;
            }

        }
    }
}
