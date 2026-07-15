using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
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

    public class Room
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<List<Tile>> Tiles { get; set; }
    }

    public class MapFile
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public List<Room> Rooms { get; set; }
    }

    public class MapManager
    {
        public MapFile Map { get; set; }

        public void LoadLayout(string path)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonEnumIntConverter<Tile>());

            string json = File.ReadAllText(path);
            Map = JsonSerializer.Deserialize<MapFile>(json, options);
        }


        public void SaveLayout(string path)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            string json = JsonSerializer.Serialize(Map, options);
            File.WriteAllText(path, json);
        }
    }

    public class MapRenderer
    {
        private MapManager manager;
        private const int TileSize = 16;
        private Rectangle[,] rects;
        public bool isEdit = false;
        public Point curIdx;

        public MapRenderer(MapManager p_manager, Canvas p_canvas)
        {
            curIdx = new Point(0, 0);
            manager = p_manager;

            ToggleButton toggleButton = new ToggleButton
            {
                Content = "Edit Mode",
                Width = 100,
                Height = 30,
                Margin = new Thickness(10)
            };
            toggleButton.Click += (s, e) => ToggleEditMode();

            Canvas.SetLeft(toggleButton, 10);
            Canvas.SetTop(toggleButton, 10);
            Canvas.SetZIndex(toggleButton, 999);
            p_canvas.Children.Add(toggleButton);

            p_canvas.MouseLeftButtonDown += (s, e) =>
            {
                if (!isEdit || rects == null) return;

                Point pos = e.GetPosition(p_canvas);

                int tileX = (int)(pos.X - 128) / TileSize % manager.Map.RoomWidth;
                int tileY = (int)(pos.Y / TileSize) % manager.Map.RoomHeight;

                Room room = manager.Map.Rooms[(int)curIdx.Y * manager.Map.Cols + (int)curIdx.X];
                room.Tiles[tileY][tileX] = (Tile)(((int)room.Tiles[tileY][tileX] + 1) % (int)Tile.E_MAX);

                rects[tileY, tileX].Fill = GetBrush(room.Tiles[tileY][tileX]);
            };
        }

        public async void ToggleEditMode()
        {
            if (isEdit)
            {
                await Task.Run(() => manager.SaveLayout("Map1.json"));
                Console.WriteLine(File.ReadAllText("Map1.json"));
            }
            isEdit = !isEdit;
        }
        public Brush GetBrush(Tile tile)
        {
            Brush brush;
            switch (tile)
            {
                case Tile.E_GROUND: brush = Brushes.Green; break;
                case Tile.E_WALL: brush = Brushes.Brown; break;
                case Tile.E_WATER: brush = Brushes.SkyBlue; break;
                case Tile.E_FIRE: brush = Brushes.Red; break;
                case Tile.E_STONE: brush = Brushes.Gray; break;
                case Tile.E_TREE: brush = Brushes.Gold; break;
                default: brush = Brushes.Transparent; break;
            }
            ;
            return brush;
        }
        public void MoveMap(Point p_pos)
        {
            curIdx = p_pos;
            if (curIdx.X < 0) curIdx = new Point(0, curIdx.Y);
            if (curIdx.Y < 0) curIdx = new Point(curIdx.X, 0);
            if (curIdx.X >= manager.Map.Cols) curIdx = new Point(manager.Map.Cols - 1, curIdx.Y);
            if (curIdx.Y >= manager.Map.Rows) curIdx = new Point(curIdx.X, manager.Map.Rows - 1);
        }

        public void Render(Canvas p_canvas)
        {
            for (int i = p_canvas.Children.Count - 1; i >= 0; i--)
            {
                if (p_canvas.Children[i] is Rectangle)
                    p_canvas.Children.RemoveAt(i);
            }

            rects = new Rectangle[manager.Map.RoomHeight, manager.Map.RoomWidth];
            int roomIndex = (int)curIdx.Y * manager.Map.Cols + (int)curIdx.X;

            for (int y = 0; y < manager.Map.RoomHeight; y++)
            {
                for (int x = 0; x < manager.Map.RoomWidth; x++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = TileSize,
                        Height = TileSize,
                        Stroke = Brushes.Black,
                        Fill = GetBrush(manager.Map.Rooms[roomIndex].Tiles[y][x])
                    };

                    double posX = x * TileSize + 128;
                    double posY = y * TileSize;

                    Canvas.SetLeft(rect, posX);
                    Canvas.SetTop(rect, posY);

                    p_canvas.Children.Add(rect);
                    rects[y, x] = rect;
                }
            }
        }
    }


    public class JsonEnumIntConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                int intValue = reader.GetInt32();
                return (T)Enum.ToObject(typeof(T), intValue);
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                string strValue = reader.GetString();
                return (T)Enum.Parse(typeof(T), strValue, ignoreCase: true);
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Convert.ToInt32(value));
        }
    }

}
