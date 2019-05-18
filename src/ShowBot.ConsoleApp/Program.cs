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

            // Speak a string.  
            robot.VoiceBox.Value.Say("Hello! I'm the official Bob & Kevin show intern. It's nice to meet you.");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
