using System;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Wikipedia.Models;

namespace ShowBot.Core.Components.Robot
{
    public interface IRobot
    {
        Lazy<IVoiceBoxComponent> VoiceBox { get; }
        Lazy<ISkill<WikipediaSearchQuery, WikipediaSearchResult>> WikipediaSkill { get; }
    }
}
