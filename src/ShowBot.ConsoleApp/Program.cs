using System;
using System.Collections.Generic;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Dependencies;
using ShowBot.Core.Skills;
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
            var skills = container.Resolve<IEnumerable<ISkill<ISkillInput>>>();

            LogoHelper.RenderLogo();

            Console.WriteLine();
            Console.WriteLine("Skills installed:");

            //register some console stuffs to see what is going on internally
            foreach (var skill in skills)
            {
                Console.WriteLine($"{skill.GetType().Name} {skill.InvocationPhrase}");

                skill.OnSkillExecuting += (sender, e) =>
                {
                    Console.WriteLine($"Executing skill: {e.Name}");
                    Console.WriteLine($"Keyword: {e.Keyword}");
                };

                skill.OnSkillExecuted += (sender, e) =>
                {
                    Console.WriteLine($"{e.TextToRead}");
                };
            }

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
                        robot.LookupInformation(_getInput("Enter search term:"));
                        break;
                    case 't':
                        robot.Say(_getInput("What shall I say?"));
                        break;
                    case 'l':
                        Console.WriteLine("Listening...");
                        robot.ListenForCommand();
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
            Console.WriteLine("l - Listen for a command");
            Console.WriteLine("q - Quit");
            Console.WriteLine("====================");
            Console.WriteLine();
        }
    }
}
