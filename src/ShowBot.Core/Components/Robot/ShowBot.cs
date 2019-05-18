using System;
using System.Collections.Generic;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Wikipedia.Models;

namespace ShowBot.Core.Components.Robot
{
    public class ShowBot : IRobot
    {
        public ShowBot(
            Lazy<IVoiceBoxComponent> voiceBox,
            Lazy<ISkill<WikipediaSearchQuery, WikipediaSearchResult>> wikipediaSkill
        )
        {
            VoiceBox = voiceBox;
            WikipediaSkill = wikipediaSkill;
        }

        public Lazy<IVoiceBoxComponent> VoiceBox { get; }
        public Lazy<ISkill<WikipediaSearchQuery, WikipediaSearchResult>> WikipediaSkill { get; }
    }
}
