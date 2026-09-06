using JokenpoGame.Enum;
using JokenpoGame.Structs;

namespace JokenpoGame.Render
{
    public class Layer
    {
        public string[] Content = Array.Empty<string>();
        public Position Position = Position.Zero;
        public ConsoleColor Color = ConsoleColor.White;
        public XAlign HorizontalAlign = XAlign.Left;
        public YAlign VerticalAlign = YAlign.Top;
        public bool IsVisible { get; set; } = true;

        public int GetWidth()
        {
            int width = 0;
            foreach (string line in Content)
            {
                if (line.Length > width)
                {
                    width = line.Length;
                }
            }
            return width;
        }
    }
}