using System;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Wikipedia.Models;

namespace ShowBot.Core.Components.Robot
{
    public class ShowBot : IRobot
    {
        private readonly Lazy<IVoiceBoxComponent> _voiceBox;
        private readonly Lazy<ISkill<WikipediaSearchQuery, WikipediaSearchResult>> _wikipediaSkill;

        public ShowBot(
            Lazy<IVoiceBoxComponent> voiceBox,
            Lazy<ISkill<WikipediaSearchQuery, WikipediaSearchResult>> wikipediaSkill
        )
        {
            _voiceBox = voiceBox;
            _wikipediaSkill = wikipediaSkill;
        }

        public void Greet(string name)
        {
            _voiceBox.Value.Say($"Hello {name}! I'm the official Bob & Kevin show intern. It's nice to meet you.");
        }

        public void Say(string input)
        {
            _voiceBox.Value.Say(input);
        }

        public void StopTalking()
        {
            _voiceBox.Value.Stop();
        }

        public string LookupInformation(string input)
        {
            return _wikipediaSkill.Value.Execute(new WikipediaSearchQuery
            {
                Keyword = input
            })?.TextToRead;
        }
    }
}
