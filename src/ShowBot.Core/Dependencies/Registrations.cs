using System;
using System.Speech.Synthesis;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Config;
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
            });

            container.RegisterType<SpeechSynthesizer>(new HierarchicalLifetimeManager());

            container.RegisterType<IVoiceBoxComponent, SpeechSynthesizerVoiceBoxComponent>(new HierarchicalLifetimeManager());
        }
    }
}
