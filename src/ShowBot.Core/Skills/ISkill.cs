using ShowBot.Core.Skills.Events;

namespace ShowBot.Core.Skills
{
    public delegate void SkillExecutingHandler(object sender, SkillInvokeEventArgs e);
    public delegate void SkillExecutedHandler(object sender, SkillInvokeEventArgs e);

    public interface ISkill<in TInput> where TInput : ISkillInput

    {
        string InvocationPhrase { get; }
        void Execute(TInput input);
        event SkillExecutingHandler OnSkillExecuting;
        event SkillExecutedHandler OnSkillExecuted;
    }
}
