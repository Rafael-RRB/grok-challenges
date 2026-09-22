using JokenpoTerminal.Enums;
using JokenpoTerminal.Render;
using JokenpoTerminal.Structs;
using JokenpoTerminal.Game;

namespace JokenpoTerminal.Screens
{
    public class DebugScreen : Screen
    {
        private Layer behindLayer = null!;
        private Layer topLayer = null!;
        private Layer middleLayer = null!;
        private Layer bottomLayer = null!;
        private int direction = 1;
        private ConsoleColor[] consoleColors = Enum.GetValues<ConsoleColor>();
        private int colorIndex = (int)ConsoleColor.Green;

        public override void Enter(Renderer renderer, Assets assets)
        {
            // Background
            behindLayer = new Layer
            {
                Content = new string[renderer.LogicalHeight],
                Position = Position.Zero,
                Color = ConsoleColor.White,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            for (int y = 0; y < renderer.LogicalHeight; y++)
            {
                behindLayer!.Content[y] = new string('#', renderer.LogicalWidth);
            }
            // Overlay Top
            topLayer = new Layer
            {
                Content = new string[5],
                Position = Position.Zero,
                Color = ConsoleColor.Red,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Top,
            };
            for (int y = 0; y < 5; y++)
            {
                topLayer.Content[y] = new string('#', renderer.LogicalWidth);
            }
            // Overlay Middle
            middleLayer = new Layer
            {
                Content = new string[renderer.LogicalHeight - 10],
                Position = Position.Zero,
                Color = ConsoleColor.Green,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            for (int y = 0; y < renderer.LogicalHeight - 10; y++)
            {
                middleLayer.Content[y] = new string('#', 5);
            }
            // Overlay Bottom
            bottomLayer = new Layer
            {
                Content = new string[5],
                Position = Position.Zero,
                Color = ConsoleColor.Blue,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Bottom,
            };
            for (int y = 0; y < 5; y++)
            {
                bottomLayer.Content[y] = new string('#', renderer.LogicalWidth);
            }
        }
        public override void Update(Renderer renderer, Assets assets, double deltaTime)
        {
            int halfLogicalWidth = renderer.LogicalWidth / 2;
            int halfLayerWidth = middleLayer.GetWidth() / 2;
            int maxX = halfLogicalWidth - halfLayerWidth;
            int minX = -halfLogicalWidth + halfLayerWidth + (middleLayer.GetWidth() % 2);

            middleLayer.Position.X += direction;
            if (middleLayer.Position.X >= maxX)
            {
                direction = -1;
            }
            else if (middleLayer.Position.X <= minX)
            {
                direction = 1;
            }

            // Track middle layer color
            middleLayer.Color = consoleColors[colorIndex];
        }

        public override void Draw(Renderer renderer, Assets assets)
        {
            renderer.AddLayer(behindLayer);
            renderer.AddLayer(topLayer);
            renderer.AddLayer(middleLayer);
            renderer.AddLayer(bottomLayer);
        }

        public override void Exit(Renderer renderer, Assets assets)
        {
            middleLayer.Position.X = 0;
            direction = 1;
        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                colorIndex = (colorIndex - 1 + consoleColors.Length) % consoleColors.Length;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                colorIndex = (colorIndex + 1) % consoleColors.Length;
            }
        }

        public DebugScreen() { }
    }
}