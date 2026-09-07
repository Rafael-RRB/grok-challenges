using JokenpoGame.Enum;
using JokenpoGame.Render;
using JokenpoGame.Structs;

namespace JokenpoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Renderer renderer = new Renderer();

            // Test Layers
            // Background
            Layer behindLayer = new Layer
            {
                Content = new string[renderer.LogicalHeight],
                Position = Position.Zero,
                Color = ConsoleColor.White,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            for (int y = 0; y < renderer.LogicalHeight; y++)
            {
                behindLayer.Content[y] = new string('X', renderer.LogicalWidth);
            }
            // Overlay Top
            Layer topLayer = new Layer
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
            Layer middleLayer = new Layer
            {
                Content = new string[14],
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
            Layer bottomLayer = new Layer
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

            renderer.AddLayer(behindLayer);
            renderer.AddLayer(topLayer);
            renderer.AddLayer(middleLayer);
            renderer.AddLayer(bottomLayer);

            // Loop
            while (true)
            {
                renderer.Clear();
                renderer.Composite();
                renderer.Present();

                Thread.Sleep(50);
            }

        }
    }
}
