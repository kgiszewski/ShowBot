using System;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Dependencies;
using Unity;

namespace ShowBot.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            Registrations.Register(container);

            var robot = container.Resolve<IRobot>();

            LogoHelper.RenderLogo();

            _showMenu();

            do
            {
                Console.WriteLine($"What shall I do?");

                var selection = Console.ReadKey(true);

                switch (selection.KeyChar)
                {
                    case 'c':
                        robot.StopTalking();
                        break;
                    case 's':
                        var result = robot.LookupInformation(_getInput("Enter search term:"));
                        Console.WriteLine(result);
                        break;
                    case 't':
                        robot.Say(_getInput("What shall I say?"));
                        break;
                    case 'g':
                        robot.Greet(_getInput("Who are we meeting?"));
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                    default:
                        _showMenu();
                        break;
                }
            } while (true);
        }

        private static string _getInput(string prompt)
        {
            Console.WriteLine($"{prompt} ");

            return Console.ReadLine();
        }

        private static void _showMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("====================");
            Console.WriteLine("g - Greet someone");
            Console.WriteLine("s - Search Wikipedia");
            Console.WriteLine("t - Say something");
            Console.WriteLine("c - Cancel Speech");
            Console.WriteLine("q - Quit");
            Console.WriteLine("====================");
            Console.WriteLine();
        }
    }
}
