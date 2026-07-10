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
        private DungeonMap dungeon;

        public MainWindow()
        {
            InitializeComponent();
            KeyDown += MyCanvas_KeyDown;
            dungeon = new DungeonMap();
            dungeon.Generate(1, 1
                , new MapBlock(new Tile[,]
                {
                    { Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, Tile.E_WATER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_FIRE, Tile.E_FIRE, Tile.E_FIRE, Tile.E_FIRE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_FIRE, Tile.E_FIRE, Tile.E_FIRE, Tile.E_FIRE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL },
                    { Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, 0, 0, 0, 0, 0, 0, 0, 0, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, Tile.E_WALL, },
                }
                ));

            dungeon.Generate(1, 2, new MapBlock());
            dungeon.Generate(1, 0, new MapBlock());

            dungeon.Generate(0, 0, new MapBlock());
            dungeon.Generate(0, 1, new MapBlock());
            dungeon.Generate(0, 2, new MapBlock());

            dungeon.Generate(2, 0, new MapBlock());
            dungeon.Generate(2, 1, new MapBlock());
            dungeon.Generate(2, 2, new MapBlock());

            for (int y = 0; y < 44; y++)
            {
                for (int x = 50; x < 58; x++)
                {
                    dungeon.AddTile(0, 2, x, y, Tile.E_WATER);
                    dungeon.AddTile(1, 2, x, y, Tile.E_WATER);
                    dungeon.AddTile(2, 2, x, y, Tile.E_WATER);

                    dungeon.AddTile(0, 0, x, y, Tile.E_FIRE);
                    dungeon.AddTile(1, 0, x, y, Tile.E_FIRE);
                    dungeon.AddTile(2, 0, x, y, Tile.E_FIRE);
                }
            }
            for (int row = 0; row < 3; row++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        dungeon.AddTile(row, 2, x + 10 + row * 3, 10 + y + row * 3, Tile.E_STONE);
                    }
                }
            }
            
            dungeon.Render(MyCanvas);
        }

        private void MyCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                dungeon.MoveMap(new Point (dungeon.cur_pos.X - 1, dungeon.cur_pos.Y));
            else if (e.Key == Key.Right)
                dungeon.MoveMap(new Point(dungeon.cur_pos.X + 1, dungeon.cur_pos.Y));
            if (e.Key == Key.Up)
                dungeon.MoveMap(new Point(dungeon.cur_pos.X, dungeon.cur_pos.Y - 1));
            else if (e.Key == Key.Down)
                dungeon.MoveMap(new Point(dungeon.cur_pos.X, dungeon.cur_pos.Y + 1));
            dungeon.Render(MyCanvas);
        }
    }
}
