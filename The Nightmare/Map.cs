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
        E_GROUND = 0,
        E_WALL,
        E_WATER,
        E_FIRE,
        E_STONE,
        E_TREE,
        E_MAX
    }
    public class MapBlock
    {
        Canvas m_canvas = new Canvas();
        public Tile[,] Tiles { get; set; }
        public int Width => 64;
        public int Height => 44;

        public MapBlock()
        {
            Tiles = new Tile[Height, Width];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (((y == 0 || y == Height - 1) && (x <= Width / 2 - 5 || x >= Width / 2 + 4))
                        || ((x == 0 || x == Width - 1) && (y <= Height / 2 - 3 || y >= Height / 2 + 6)))
                        Tiles[y, x] = Tile.E_WALL;
                    else
                        Tiles[y, x] = Tile.E_GROUND;
                }
            }
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
            cur_pos = new Point(1, 1);
            Blocks = new MapBlock[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    Blocks[r, c] = new MapBlock();
        }

        public void Generate(int p_row, int p_col, MapBlock p_block)
        {
            Blocks[p_row, p_col] = p_block;
        }

        public void AddTile(int p_row, int p_col, int p_x, int p_y, Tile p_tile)
        {
            if (p_row < 0 || p_row >= rows || p_col < 0 || p_col >= cols) return;
            if (p_x < 0 || p_x >= Blocks[p_row, p_col].Width || p_y < 0 || p_y >= Blocks[p_row, p_col].Height) return;

            Blocks[p_row, p_col].Tiles[p_y, p_x] = p_tile;
        }

        public void MoveMap(Point p_pos)
        {
            cur_pos = p_pos;
            if (cur_pos.X < 0) cur_pos = new Point(0, cur_pos.Y);
            if (cur_pos.Y < 0) cur_pos = new Point(cur_pos.X, 0);
            if (cur_pos.X >= cols) cur_pos = new Point(cols - 1, cur_pos.Y);
            if (cur_pos.Y >= rows) cur_pos = new Point(cur_pos.X, rows - 1);
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
                        case Tile.E_GROUND: brush = Brushes.Green; break;
                        case Tile.E_WALL: brush = Brushes.Brown; break;
                        case Tile.E_WATER: brush = Brushes.SkyBlue; break;
                        case Tile.E_FIRE: brush = Brushes.Red; break;
                        case Tile.E_STONE: brush = Brushes.Gray; break;
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
