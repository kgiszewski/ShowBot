using System;
using ShowBot.Core.Components.Speech;

namespace ShowBot.Core.Components.Robot
{
    public class ShowBot : IRobot
    {
        public ShowBot(
            Lazy<IVoiceBoxComponent> voiceBox
        )
        {
            VoiceBox = voiceBox;
        }

        public Lazy<IVoiceBoxComponent> VoiceBox { get; }
    }
}
