using System;

namespace ShowBot.Core.Skills.Events
{
    public class SkillInvokeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Keyword { get; set; }
        public string TextToRead { get; set; }
    }
}
