using System;
using System.Net.Http;
using System.Speech.Synthesis;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Config;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Wikipedia;
using ShowBot.Core.Skills.Wikipedia.Models;
using Unity;
using Unity.Lifetime;

namespace ShowBot.Core.Dependencies
{
    public static class Registrations
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterFactory(typeof(SpeechSynthesizer), x =>
            {
                var synth = new SpeechSynthesizer();

                synth.SetOutputToDefaultAudioDevice();
                
                if (AppConfigs.SpeechComponent.SendOutputToFile)
                {
                    var path = $"{AppDomain.CurrentDomain.BaseDirectory}\\test.wav";

                    synth.SetOutputToWaveFile(path);
                }

                return synth;
            }, new HierarchicalLifetimeManager());

            container.RegisterFactory(typeof(HttpClient), x =>
            {
                return new HttpClient();
            }, new HierarchicalLifetimeManager());

            container.RegisterType<SpeechSynthesizer>(new HierarchicalLifetimeManager());
            container.RegisterType<IVoiceBoxComponent, SpeechSynthesizerVoiceBoxComponent>(new HierarchicalLifetimeManager());

            container.RegisterType<IRobot, Components.Robot.ShowBot>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkill<WikipediaSearchQuery, WikipediaSearchResult>, WikipediaSkill>(new HierarchicalLifetimeManager());
        }
    }
}
