using System;
using System.Collections.Generic;
using System.Linq;
using ShowBot.Core.Components.Speech;
using ShowBot.Core.Components.VoiceRecognition;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Models;

namespace ShowBot.Core.Components.Robot
{
    public class ShowBot : IRobot
    {
        private readonly Lazy<IVoiceBox> _voiceBox;
        private readonly IEnumerable<ISkill<ISkillInput>> _skills;
        private readonly Lazy<IVoiceCommandListener> _voiceCommandListener;

        public ShowBot(
            Lazy<IVoiceBox> voiceBox,
            IEnumerable<ISkill<ISkillInput>> skills,
            Lazy<IVoiceCommandListener> voiceCommandListener
        )
        {
            _voiceBox = voiceBox;
            _skills = skills;
            _voiceCommandListener = voiceCommandListener;

            foreach (var skill in _skills)
            {
                skill.OnSkillExecuted += Skill_OnSkillExecuted;
            }
        }

        private void Skill_OnSkillExecuted(object sender, Skills.Events.SkillInvokeEventArgs e)
        {
            _voiceBox.Value.Say(e.TextToRead);
        }

        public void Greet(string name)
        {
            _voiceBox.Value.Say($"Hello {name}! I'm the official Bob & Kevin show intern. It's nice to meet you.");
        }

        public void Say(string input)
        {
            _voiceBox.Value.Say(input);
        }

        public void StopTalking()
        {
            _voiceBox.Value.Stop();
        }

        public void ListenForCommand()
        {
            _voiceCommandListener.Value.Listen();
        }

        public void LookupInformation(string input)
        {
            var wikipediaSkill = _skills.FirstOrDefault(x => x.InvocationPhrase.ToLower().Contains("wikipedia"));

            if (wikipediaSkill != null)
            {
                wikipediaSkill.Execute(new GenericSkillInput
                {
                    Keyword = input
                });
            }
            else
            {
                _voiceBox.Value.Say($"I can't find my wikipedia skill.");
            }
        }
    }
}
