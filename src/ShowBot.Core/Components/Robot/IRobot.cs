namespace ShowBot.Core.Components.Robot
{
    public interface IRobot
    {
        void Greet(string name);
        void Say(string input);
        void StopTalking();
        string LookupInformation(string input);
    }
}
