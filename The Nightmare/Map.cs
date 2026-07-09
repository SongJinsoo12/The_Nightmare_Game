using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace The_Nightmare
{
    public enum Tile
    {
        E_WALL = 0,
        E_WATER,
        E_TREE,
    }
    public class MapBlock
    {
        Canvas m_canvas = new Canvas();
        public Tile[,] Tiles { get; set; }
        public int Width => (1280 - 256) / 16;
        public int Height => (720 - 16) / 16;

        public MapBlock()
        {
            Tiles = new Tile[Width, Height];
        }
        public MapBlock(Tile[,] tiles)
        {
            Tiles = tiles;
        }
    }

    public class DungeonMap
    {
        public MapBlock[,] Blocks { get; set; }
        public int rows => 3;
        public int cols => 3;
        private const int TileSize = 16;
        public Point cur_pos { get; set; }

        public DungeonMap()
        {
            Blocks = new MapBlock[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    Blocks[r, c] = new MapBlock();
        }

        public void Generate(int p_row, int p_col, MapBlock p_block)
        {
            Blocks[p_row, p_col] = p_block;
        }

        public void MoveMap(Point p_pos)
        {
            cur_pos = p_pos;
        }

        public void Render(Canvas canvas)
        {
            canvas.Children.Clear();

            MapBlock block = Blocks[(int)cur_pos.Y, (int)cur_pos.X];

            for (int y = 0; y < block.Height; y++)
            {
                for (int x = 0; x < block.Width; x++)
                {
                    Tile tile = block.Tiles[y, x];
                    SolidColorBrush brush = null;
                    switch (tile)
                    {
                        case Tile.E_WALL:
                            brush = Brushes.DarkGray; break;
                        case Tile.E_WATER: brush = Brushes.SkyBlue; break;
                        case Tile.E_TREE: brush = Brushes.Gold; break;
                        default: break;
                    }
                    Rectangle rect = new Rectangle
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Fill = brush
                    };

                    double posX = (x * TileSize + 128);
                    double posY = (y * TileSize);

                    Canvas.SetLeft(rect, posX);
                    Canvas.SetTop(rect, posY);

                    canvas.Children.Add(rect);
                }
            }
        }
    }
}
