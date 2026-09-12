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
            string backgroundPath = Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "Background"
            );

            introBGProtagonist = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-1.png"));
            introBGStars = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-2.png"));
            introBGTriangle = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-3.png"));
            introBGSquare = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-4.png"));
            introBGCircle = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-5.png"));
        }
    }
}
