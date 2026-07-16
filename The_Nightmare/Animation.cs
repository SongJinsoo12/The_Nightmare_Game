using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace The_Nightmare
{
    public class Animation
    {
        // 애니메이션 이미지 리스트
        public List<ImageSource> Frames { get; private set; } = new List<ImageSource>();
        // 각 프레임의 지속 시간 (초)
        public double FrameDuration { get; private set; }
        public bool isLoop { get; private set; }

        public Animation(string[] imagePaths, double frameDuration, bool loop=true)
        {
            FrameDuration = frameDuration;
            isLoop = loop;

            foreach (var imagePath in imagePaths)
            {
                Frames.Add(new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)));
            }
        }

        public Animation(string imagePath, int width, int height, int imageNumber, double frameDuration, bool loop = true)
        {
            FrameDuration = frameDuration;
            isLoop = loop;

            BitmapImage originBitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            for (int i = 1; i <= imageNumber; i++)
            {
                Int32Rect croptImage = new Int32Rect(width * (i - 1), 0, width, height);
                Frames.Add(new CroppedBitmap(originBitmap, croptImage));
            }
        }
    }
}
