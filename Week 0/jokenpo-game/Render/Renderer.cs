using JokenpoTerminal.Enum;
using System.Reflection.Emit;

namespace JokenpoTerminal.Render
{
    public class Renderer
    {
        // Internal Resolution of the screen
        public int LogicalWidth { get; } = 80;
        public int LogicalHeight { get; } = 24;
        public int lastTerminalWidth = Console.WindowWidth;
        public int lastTerminalHeight = Console.WindowHeight;
        public bool shouldShowCursor = false;
        private readonly List<Layer> _layers = new List<Layer>();
        private char[,] _buffer = new char[0, 0];
        private ConsoleColor[,] _colors = new ConsoleColor[0, 0];

        public Renderer()
        {
            _buffer = new char[LogicalHeight, LogicalWidth];
            _colors = new ConsoleColor[LogicalHeight, LogicalWidth];
        }

        // Adds a layer to the layer list
        public void AddLayer(Layer layer)
        {
            _layers.Add(layer);
        }

        // Removes a layer from the layer list
        public void RemoveLayer(Layer layer)
        {
            _layers.Remove(layer);
        }

        // Removes all layers from the layer list
        public void ClearLayers()
        {
            _layers.Clear();
        }

        // Fills buffer with empty spaces
        public void Clear()
        {
            for (int y = 0; y < LogicalHeight; y++)
            {
                for (int x = 0; x < LogicalWidth; x++)
                {
                    _buffer[y, x] = ' ';
                    _colors[y, x] = ConsoleColor.White;
                }
            }
        }

        // Composites all layers into the buffer
        public void Composite()
        {
            foreach (Layer layer in _layers)
            {
                // Skip invisible, null, or empty layers
                if (!layer.IsVisible || layer.Content == null || layer.Content.Length == 0)
                {
                    continue;
                }

                // Horizontal offset
                int offsetX = 0;
                if (layer.HorizontalAlign == XAlign.Center)
                {
                    offsetX = (LogicalWidth - layer.GetWidth()) / 2;
                }
                else if (layer.HorizontalAlign == XAlign.Right)
                {
                    offsetX = LogicalWidth - layer.GetWidth();
                }
                // Else left stays at 0

                // Vertical offset
                int offsetY = 0;
                if (layer.VerticalAlign == YAlign.Middle)
                {
                    offsetY = (LogicalHeight - layer.Content.Length) / 2;
                }
                else if (layer.VerticalAlign == YAlign.Bottom)
                {
                    offsetY = LogicalHeight - layer.Content.Length;
                }
                // Else top stays at 0

                // Extra offset
                offsetX += layer.Position.X;
                offsetY += layer.Position.Y;

                // Then run a xy for loop with those offsets
                for (int y = 0; y < layer.Content.Length; y++)
                {
                    string line = layer.Content[y];
                    for (int x = 0; x < line.Length; x++)
                    {
                        int finalX = x + offsetX;
                        int finalY = y + offsetY;

                        // Clipping
                        if (finalX < 0 || finalX >= LogicalWidth || finalY < 0 || finalY >= LogicalHeight)
                        {
                            continue;
                        }

                        _buffer[finalY, finalX] = line[x];
                        _colors[finalY, finalX] = layer.Color;
                    }
                }
            }
        }

        // Centers the buffer on the terminal window
        public void Present()
        {
            try
            {
                // Get the terminal size
                int terminalWidth = Console.WindowWidth;
                int terminalHeight = Console.WindowHeight;

                if (terminalWidth != lastTerminalWidth || terminalHeight != lastTerminalHeight)
                {
                    Console.Clear();
                    Console.CursorVisible = shouldShowCursor;
                    lastTerminalWidth = terminalWidth;
                    lastTerminalHeight = terminalHeight;
                }

                // Error message if the terminal is smaller than the logical resolution
                if (terminalWidth < LogicalWidth || terminalHeight < LogicalHeight)
                {
                    // Clear screen and display an error message in the center of the terminal
                    Console.ForegroundColor = ConsoleColor.White;
                    string message = $"- Please increase Terminal size! Minimum: {LogicalWidth} by {LogicalHeight}. Current size: {terminalWidth} by {terminalHeight} -";
                    int messageX = Math.Max(0, (terminalWidth - message.Length) / 2);
                    int messageY = terminalHeight / 2;
                    Console.SetCursorPosition(messageX, messageY);
                    Console.WriteLine(message);
                    return;
                }

                int offsetX = (terminalWidth - LogicalWidth) / 2;
                int offsetY = (terminalHeight - LogicalHeight) / 2;
                ConsoleColor lastColor = (ConsoleColor)(-1); // Invalid color to ensure the first color is always set

                for (int y = 0; y < LogicalHeight; y++)
                {
                    Console.SetCursorPosition(offsetX, offsetY + y);
                    for (int x = 0; x < LogicalWidth; x++)
                    {
                        if (_colors[y, x] != lastColor)
                        {
                            Console.ForegroundColor = _colors[y, x];
                            lastColor = _colors[y, x];
                        }
                        Console.Write(_buffer[y, x]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine($"- Error while rendering: {ex.Message} -");
                Console.WriteLine("");
                return;
            }
        }
    }
}
