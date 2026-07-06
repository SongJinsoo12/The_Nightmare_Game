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
    }
}
