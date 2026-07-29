using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace The_Nightmare
{
    public class SpriteRenderComponent
    {
        public ImageSource SpriteImage { get; private set; }
        public Image SpriteControl { get; private set; }
        public int width { get; private set; } = 0;
        public int height { get; private set; } = 0;
        public SpriteRenderComponent()
        {
            SpriteControl = new Image();
        }
        public const int TileSize = 32; // 타일 크기 상수
        public void Update(GameObject owner)
        {
            Canvas.SetLeft(SpriteControl, owner.X);
            Canvas.SetTop(SpriteControl, owner.Y);

            if (owner.Animator != null)
            {
                SpriteControl.Source = owner.Animator.Controller.GetCurrentFrame();
            }
        }

        public SpriteRenderComponent(string imagePath)
        {
            try
            {
                // 이미지 로드 시도
                SpriteImage = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));


            }
            catch (Exception ex)
            {
                // 이미지 로드 실패 시 예외 처리
                Console.WriteLine($"Error loading image: {ex.Message}");
                SpriteImage = null;
            }
        }

        public SpriteRenderComponent(string imagePath, int x, int y, int width, int height)
        {
            try
            {
                // 이미지 로드 시도
                BitmapImage originBitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));

                Int32Rect croptImage = new Int32Rect(x, y, width, height);

                SpriteImage = new CroppedBitmap(originBitmap, croptImage);
            }
            catch (Exception ex)
            {
                // 이미지 로드 실패 시 예외 처리
                Console.WriteLine($"Error loading image: {ex.Message}");
                SpriteImage = null;
            }
        }

        public SpriteRenderComponent(Canvas canvas, string imageName, int width, int height) {
            string wpfPath = "pack://application:,,/" + imageName;
            Image img = new Image();
            img.Width = width;
            img.Height = height;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(wpfPath);
            bitmap.EndInit();
            img.Source = bitmap;

            Canvas.SetLeft(img, 0);
            Canvas.SetTop(img, 0);

            canvas.Children.Add(img);
        }
    }
}
