using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace The_Nightmare
{
    public class SpriteRenderComponent
    {
        public ImageSource SpriteImage { get; private set; }

        // 사이즈 및 각도 변수
        public double Width { get; set; }
        public double Height { get; set; }
        public double RotationAngle { get; set; }
        public bool Flip { get; set; }

        public SpriteRenderComponent(string imagePath,
            double defaultWidth = 32, double defaultHeight = 32)
        {
            Width = defaultWidth;
            Height = defaultHeight;
            RotationAngle = 0;
            Flip = false;

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

        public void Rotate(double angle)
        {
            RotationAngle = angle % 360;
        }

        public void FlipSprite()
        {
            Flip = !Flip;
        }
        public void SetSize(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
