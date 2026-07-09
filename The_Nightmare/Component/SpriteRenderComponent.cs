using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace The_Nightmare
{
    public class SpriteRenderComponent
    {
        public ImageSource SpriteImage { get; private set; }

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
