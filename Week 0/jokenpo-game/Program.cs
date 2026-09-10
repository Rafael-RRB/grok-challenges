using JokenpoTerminal.Manager;

namespace JokenpoTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.CursorVisible = false;
            GameManager gameManager = new GameManager();

            while (gameManager.isRunning)
            {
                gameManager.Run();
            }
        }
    }
}