using System;
using System.Speech.Synthesis;
using ShowBot.Core.Config;

namespace ShowBot.Core.Components.Speech
{
    public class SpeechSynthesizerVoiceBoxComponent : IVoiceBoxComponent, IDisposable
    {
        private readonly Lazy<SpeechSynthesizer> _speechSynthesizer;

        private const string FemaleVoice = "Microsoft Zira Desktop";
        private const string MaleVoice = "Microsoft David Desktop";

        public SpeechSynthesizerVoiceBoxComponent(
            Lazy<SpeechSynthesizer> speechSynthesizer    
        )
        {
            _speechSynthesizer = speechSynthesizer;

            _speechSynthesizer.Value.SelectVoice(AppConfigs.SpeechComponent.UseMaleVoice ? MaleVoice : FemaleVoice);
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
