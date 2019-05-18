using System;
using ShowBot.Core.Components.Speech;
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

            var voiceBox = container.Resolve<IVoiceBoxComponent>();

            // Speak a string.  
            voiceBox.Say("Hi Jackson. Your dad built me, it's nice to meet you.");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
