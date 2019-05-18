using System;
using System.Speech.Synthesis;

namespace ShowBot.Core.Components.Speech
{
    public class SpeechSynthesizerVoiceBoxComponent : IVoiceBoxComponent
    {
        private readonly Lazy<SpeechSynthesizer> _speechSynthesizer;

        public SpeechSynthesizerVoiceBoxComponent(
            Lazy<SpeechSynthesizer> speechSynthesizer    
        )
        {
            _speechSynthesizer = speechSynthesizer;
        }

        public void Say(string input)
        {
            _speechSynthesizer.Value.Speak(input);
        }
    }
}
