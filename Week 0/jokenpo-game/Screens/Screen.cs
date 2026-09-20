using JokenpoTerminal.Game;
using JokenpoTerminal.Render;

namespace JokenpoTerminal.Screens
{
    public abstract class Screen
    {
        public bool AllowInput { get; protected set; } = true; 

        public virtual void Enter(Renderer renderer, Assets assets) { }

        public virtual void Update(Renderer renderer, Assets assets, double deltaTime) { }

        public virtual void Draw(Renderer renderer, Assets assets) { }

        public virtual void Exit(Renderer renderer, Assets assets) { }

        public virtual void HandleInput(ConsoleKeyInfo key) { }

        public Screen() { }
    }
}
