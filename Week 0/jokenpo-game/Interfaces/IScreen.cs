using JokenpoTerminal.Render;

namespace JokenpoTerminal.Interfaces
{
    public interface IScreen
    {
        void Enter();
        void Update();
        void Draw(Renderer renderer);
        void Exit();
    }
}