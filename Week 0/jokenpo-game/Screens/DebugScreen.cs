using JokenpoTerminal.Enum;
using JokenpoTerminal.Render;
using JokenpoTerminal.Structs;
using JokenpoTerminal.Interfaces;
using JokenpoTerminal.Game;

namespace JokenpoTerminal.Screens
{
    public class DebugScreen : IScreen
    {
        private Renderer renderer = null!;
        private Layer behindLayer = null!;
        private Layer topLayer = null!;
        private Layer middleLayer = null!;
        private Layer bottomLayer = null!;
        private int direction = 1;

        public void Enter()
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
                behindLayer!.Content[y] = new string('X', renderer.LogicalWidth);
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
                topLayer.Content[y] = new string('X', renderer.LogicalWidth);
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
                middleLayer.Content[y] = new string('X', 5);
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
                bottomLayer.Content[y] = new string('X', renderer.LogicalWidth);
            }
        }
        public void Update()
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
        }
        public void Draw(Renderer renderer)
        {
            renderer.AddLayer(behindLayer);
            renderer.AddLayer(topLayer);
            renderer.AddLayer(middleLayer);
            renderer.AddLayer(bottomLayer);
        }

        public void Exit()
        {
            middleLayer.Position.X = 0;
            direction = 1;
        }

        public DebugScreen(Renderer assignRenderer, Assets assets)
        {
            renderer = assignRenderer;
        }
    }
}