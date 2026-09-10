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
        private int ocillation = 0;

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
            if (ocillation >= 0)
            {
                ocillation++;
                middleLayer.Position.X = 2;
            }
            else
            {
                ocillation--;
                middleLayer.Position.X = -2;
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
            ocillation = 0;
        }

        public DebugScreen(Renderer assignRenderer, Assets assets)
        {
            renderer = assignRenderer;
        }
    }
}