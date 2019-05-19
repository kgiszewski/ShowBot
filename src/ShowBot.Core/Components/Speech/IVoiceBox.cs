namespace ShowBot.Core.Components.Speech
{
    public interface IVoiceBox
    {
        void Say(string input);
        void Stop();
    }
}
