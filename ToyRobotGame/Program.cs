using System;
using ToyRobotGame.src.Action;
using ToyRobotGame.src.Robot;

namespace ToyRobotGame // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            CommandProcessor commandProcessor = new CommandProcessor(robot);

            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "END GAME")
                    break;
                
                try 
                {
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