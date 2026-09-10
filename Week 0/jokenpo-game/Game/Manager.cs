using JokenpoTerminal.Render;
using JokenpoTerminal.Interfaces;
using JokenpoTerminal.Screens;
using JokenpoTerminal.Game;

namespace JokenpoTerminal.Manager
{
    public class GameManager
    {
        public bool isRunning = true;
        private static Assets assets = new Assets();
        private static Renderer renderer = new Renderer();
        public IScreen currentScreen = null!;
        public int fps = 1000 / 20; // 20 FPS

        public void ChangeScreen(IScreen newScreen)
        {
            currentScreen = newScreen;
            currentScreen.Enter();
        }

        public void Run()
        {            
            currentScreen.Update();
            renderer.ClearLayers();
            currentScreen.Draw(renderer);
            renderer.Composite();
            renderer.Present();
        }

        public GameManager()
        {
            ChangeScreen(new DebugScreen(renderer, assets));
        }

        public GameManager(IScreen setCurrentScreen)
        {
            ChangeScreen(setCurrentScreen);
        }
    }
}