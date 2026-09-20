using JokenpoTerminal.Manager;
using JokenpoTerminal.Screens;

namespace JokenpoTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.CursorVisible = false;
            Screen firstScreen = new IntroScreen();
            GameManager gameManager = new GameManager(firstScreen);

            while (gameManager.isRunning)
            {
                gameManager.Run();
            }
        }
    }
}