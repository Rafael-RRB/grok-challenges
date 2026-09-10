using ImageToChar;

namespace JokenpoTerminal.Game
{
    public class Assets
    {
        public readonly string[] introBGProtagonist;
        public readonly string[] introBGStars;
        public readonly string[] introBGTriangle;
        public readonly string[] introBGSquare;
        public readonly string[] introBGCircle;

        public Assets()
        {
            introBGProtagonist = ImageReader.ToASCII("../../../Assets/Background/banner_intro_layer-1.png");
            introBGStars = ImageReader.ToASCII("../../../Assets/Background/banner_intro_layer-2.png");
            introBGTriangle = ImageReader.ToASCII("../../../Assets/Background/banner_intro_layer-3.png");
            introBGSquare = ImageReader.ToASCII("../../../Assets/Background/banner_intro_layer-4.png");
            introBGCircle = ImageReader.ToASCII("../../../Assets/Background/banner_intro_layer-5.png");
        }
    }
}
