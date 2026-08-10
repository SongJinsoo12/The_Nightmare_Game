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

        public Animation(string imagePath, int width, int height, int imageNumber, double frameDuration, bool loop = false,
                         bool flipHorizontal = false, bool flipVertical = false, double rotationAngle = 0)
        {
            FrameDuration = frameDuration;
            isLoop = loop;

            BitmapImage originBitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            for (int i = 1; i <= imageNumber; i++)
            {
                Int32Rect croptImage = new Int32Rect(width * (i - 1), 0, width, height);
                CroppedBitmap croppedBitmap = new CroppedBitmap(originBitmap, croptImage);
                Frames.Add(ApplyTransform(croppedBitmap, flipHorizontal, flipVertical, rotationAngle));
            }
        }

        private ImageSource ApplyTransform(BitmapSource source, bool flipHorizontal, bool flipVertical, double rotationAngle)
        {
            if (!flipHorizontal && !flipVertical && rotationAngle == 0)
                return source;

            TransformGroup transformGroup = new TransformGroup();

            // 1. 좌우/상하 반전 (ScaleTransform 적용)
            if (flipHorizontal || flipVertical)
            {
                transformGroup.Children.Add(new ScaleTransform(
                    flipHorizontal ? -1 : 1,
                    flipVertical ? -1 : 1));
            }

            // 2. 회전 (RotateTransform 적용)
            if (rotationAngle != 0)
            {
                transformGroup.Children.Add(new RotateTransform(rotationAngle));
            }

            // TransformedBitmap으로 원본 소스에 변환 그룹 적용
            return new TransformedBitmap(source, transformGroup);
        }
    }
}
