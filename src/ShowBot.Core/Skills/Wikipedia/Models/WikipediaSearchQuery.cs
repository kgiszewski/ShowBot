namespace ShowBot.Core.Skills.Wikipedia.Models
{
    public class WikipediaSearchQuery : ISkillInput
    {
        public string Keyword { get; set; }
    }
}
