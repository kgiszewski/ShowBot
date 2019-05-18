namespace ShowBot.Core.Skills
{
    public interface ISkill<in TInput, out TResult> where TInput : ISkillInput where TResult : ISkillResult

    {
        TResult Execute(TInput input);
    }
}
