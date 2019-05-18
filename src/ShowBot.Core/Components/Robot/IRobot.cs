using System;
using ShowBot.Core.Components.Speech;

namespace ShowBot.Core.Components.Robot
{
    public interface IRobot
    {
        Lazy<IVoiceBoxComponent> VoiceBox { get; }
    }
}
