using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Components.VoiceRecognition;
using ShowBot.Core.Config;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Wikipedia;
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

                if (AppConfigs.SpeechComponent.SendOutputToFile)
                {
                    synth.SetOutputToWaveFile(AppConfigs.SpeechComponent.OutputFilePath);
                }
                else
                {
                    synth.SetOutputToDefaultAudioDevice();
                }

                return synth;
            }, new HierarchicalLifetimeManager());

            container.RegisterFactory(typeof(HttpClient), x =>
            {
                return new HttpClient();
            }, new HierarchicalLifetimeManager());

            container.RegisterType<IVoiceBox, SpeechSynthesizerVoiceBox>(new HierarchicalLifetimeManager());

            container.RegisterType<IRobot, Components.Robot.ShowBot>(new HierarchicalLifetimeManager());
            container.RegisterType<ISkill<ISkillInput>, WikipediaSkill>(nameof(WikipediaSkill), new HierarchicalLifetimeManager());

            container.RegisterFactory(typeof(SpeechRecognitionEngine), x => 
            {
                var engine = new SpeechRecognitionEngine();

                foreach (var config in SpeechRecognitionEngine.InstalledRecognizers())
                {
                    if (config.Culture.ToString() == "en-US")
                    {
                        engine = new SpeechRecognitionEngine(config);
                    }
                }


                engine.SetInputToDefaultAudioDevice();

                engine.EndSilenceTimeout = TimeSpan.FromSeconds(2);

                var invocationPhrases = new List<string>();

                var skills = x.Resolve<IEnumerable<ISkill<ISkillInput>>>();

                invocationPhrases.AddRange(skills.Select(y => y.InvocationPhrase));

                var grammarBuilder = new GrammarBuilder(new Choices(invocationPhrases.ToArray()));

                grammarBuilder.AppendDictation("grammar:dictation");

                var grammar = new Grammar(grammarBuilder);

                engine.LoadGrammar(grammar);

                return engine;
            });

            container.RegisterType<IVoiceCommandListener, VoiceCommandListener>(new HierarchicalLifetimeManager());
        }
    }
}
