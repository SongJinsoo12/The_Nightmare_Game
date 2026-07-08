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
    public class MapBlock
    {
        public int[,] Tiles { get; set; }
        public int Width => 1280 / 16;
        public int Height => 720 / 16;

        public MapBlock()
        {
            Tiles = new int[Width, Height];
        }
        public MapBlock(int[,] tiles)
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
        Point cur_pos { get; set; }

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

        public void Render(Canvas canvas)
        {
            canvas.Children.Clear();

            MapBlock block = Blocks[(int)cur_pos.Y, (int)cur_pos.X];

            for (int y = 0; y < block.Tiles.GetLength(0); y++)
            {
                for (int x = 0; x < block.Tiles.GetLength(1); x++)
                {
                    int tile = block.Tiles[y, x];

                    Rectangle rect = new Rectangle
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Fill = (tile == 0) ? Brushes.DarkSlateGray : Brushes.LightGray
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
