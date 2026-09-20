using JokenpoTerminal.Render;
using JokenpoTerminal.Screens;
using JokenpoTerminal.Game;
using System.Diagnostics;

namespace JokenpoTerminal.Manager
{
    public class GameManager
    {
        public bool isRunning { get; private set; } = true;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Assets assets = new Assets();
        private Renderer renderer = new Renderer();
        private Screen currentScreen = null!;
        private double frameDelay = 1.0 / 20.0; // 20 FPS

        public void ChangeScreen(Screen newScreen)
        {
            currentScreen?.Exit(renderer, assets);
            currentScreen = newScreen;
            currentScreen.Enter(renderer, assets);
        }

        public void Run()
        {
            double deltaTime = stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();

            // Either keep the while or change to if -> while to consume all extra keys
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                currentScreen.HandleInput(key);
            }

            currentScreen.Update(renderer, assets, deltaTime);
            renderer.ClearLayers();
            renderer.Clear();
            currentScreen.Draw(renderer, assets);
            renderer.Composite('X');
            renderer.Present();

            Thread.Sleep(Math.Max((int)(frameDelay - deltaTime) * 1000, 0));
        }

        public GameManager()
        {
            ChangeScreen(new DebugScreen());
        }

        public GameManager(Screen setCurrentScreen)
        {
            ChangeScreen(setCurrentScreen);
        }
    }
}