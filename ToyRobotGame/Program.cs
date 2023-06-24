using ToyRobotGame.src.Action;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main()
        {
            bool restartGame = false;

            Robot robot = new();
            CommandProcessor commandProcessor = new(robot);

            Console.WriteLine("WELCOME TO TOYROBOT! |O.O|");
            // Robot ASCII
            Console.WriteLine("        _____\n     __/__|__\\__\n    |            |\n    |  0      0  |\n    |     >      |\n    |  \\_____/   |\n    |____________| \n");
            Console.WriteLine("Insert command here:");
            
            while (true)
            {
                if (restartGame)
                {
                    robot = new();
                    commandProcessor = new(robot);
                    restartGame = false;

                    Console.WriteLine("Game restarted. Insert command here:");
                }

                string? userInput = Console.ReadLine();
                if (userInput == "END GAME")
                    break;

                if (userInput == "RESTART")
                {
                    Console.Clear();
                    restartGame = true;
                    continue;
                }
                
                try 
                {
                    // Warning of userInput - NULL is handled inside CommandProcessor
                    commandProcessor.ProcessCommand(userInput);
                }
                catch (CustomException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }
    }
}