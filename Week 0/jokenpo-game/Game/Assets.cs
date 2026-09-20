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

            introBGProtagonist = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-1.png"), 'X');
            introBGStars = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-2.png"), 'X');
            introBGTriangle = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-3.png"), 'X');
            introBGSquare = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-4.png"), 'X');
            introBGCircle = ImageReader.ToASCII(Path.Combine(backgroundPath, "banner_intro_layer-5.png"), 'X');
        }
    }
}
