using JokenpoTerminal.Manager;
using JokenpoTerminal.Screens;

namespace JokenpoTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.CursorVisible = false;
            GameManager gameManager = new GameManager(new IntroScreen());

            while (gameManager.isRunning)
            {
                gameManager.Run();
            }
        }
    }
}