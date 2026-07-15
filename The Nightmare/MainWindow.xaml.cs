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
    /// 

    public partial class MainWindow : Window
    {
        //private DungeonMap dungeon;
        private MapManager mapManager;
        private MapRenderer mapRenderer;

        public MainWindow()
        {
            InitializeComponent();
            KeyUp += MyCanvas_KeyUp;

            mapManager = new MapManager();
            mapRenderer = new MapRenderer(mapManager, MyCanvas);

            mapManager.LoadLayout("Map1.json");
            mapRenderer.Render(MyCanvas);
        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                mapRenderer.MoveMap(new Point(mapRenderer.curIdx.X - 1, mapRenderer.curIdx.Y));
            else if (e.Key == Key.Right)
                mapRenderer.MoveMap(new Point(mapRenderer.curIdx.X + 1, mapRenderer.curIdx.Y));
            else if (e.Key == Key.Up)
                mapRenderer.MoveMap(new Point(mapRenderer.curIdx.X, mapRenderer.curIdx.Y - 1));
            else if (e.Key == Key.Down)
                mapRenderer.MoveMap(new Point(mapRenderer.curIdx.X, mapRenderer.curIdx.Y + 1));
            mapRenderer.Render(MyCanvas);
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //mapRenderer.Render(MyCanvas);
        }
    }
}
