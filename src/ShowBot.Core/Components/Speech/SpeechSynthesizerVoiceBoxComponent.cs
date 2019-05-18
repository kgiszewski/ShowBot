using System;
using System.Speech.Synthesis;

namespace ShowBot.Core.Components.Speech
{
    public class SpeechSynthesizerVoiceBoxComponent : IVoiceBoxComponent, IDisposable
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
            Stop();

            _speechSynthesizer.Value.SpeakAsync(new Prompt(input));
        }

        public void Stop()
        {
            _speechSynthesizer.Value.SpeakAsyncCancelAll();
        }

        public void Dispose()
        {
            _speechSynthesizer.Value.Dispose();
        }
    }
}
