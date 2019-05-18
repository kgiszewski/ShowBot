using System;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Dependencies;
using ShowBot.Core.Skills.Wikipedia.Models;
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
                var selection = Console.ReadKey(true);

                switch (selection.KeyChar)
                {
                    case 'i':
                        robot.VoiceBox.Value.Say("Hello! I'm the official Bob & Kevin show intern. It's nice to meet you.");
                        break;
                    case 'c':
                        robot.VoiceBox.Value.Stop();
                        break;
                    case 's':
                        var result = robot.WikipediaSkill.Value.Execute(new WikipediaSearchQuery
                        {
                            Keyword = _getInput()
                        });

                        Console.WriteLine(result.TextToRead);

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

        private static string _getInput()
        {
            Console.WriteLine("Please enter your input: ");

            return Console.ReadLine();
        }

        private static void _showMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("====================");
            Console.WriteLine("i - Introduce yourself");
            Console.WriteLine("s - Search Wikipedia");
            Console.WriteLine("c - Cancel Speech");
            Console.WriteLine("q - Quit");
            Console.WriteLine("====================");
            Console.WriteLine();
        }
    }
}
