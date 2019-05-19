using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using ShowBot.Core.Components.Robot;
using ShowBot.Core.Skills;
using ShowBot.Core.Skills.Models;

namespace ShowBot.Core.Components.VoiceRecognition
{
    public class VoiceCommandListener : IVoiceCommandListener, IDisposable
    {
        private readonly Lazy<IRobot> _robot;
        private readonly IEnumerable<ISkill<ISkillInput>> _skills;
        private readonly SpeechRecognitionEngine _engine;

        public VoiceCommandListener(
            SpeechRecognitionEngine engine,
            Lazy<IRobot> robot,
            IEnumerable<ISkill<ISkillInput>> skills
        )
        {
            _engine = engine;
            _robot = robot;
            _skills = skills;

            _engine.SpeechRecognized += _speechRecognized;
            _engine.SpeechRecognitionRejected += _speechRecognitionRejected;
        }

        private void _speechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            _robot.Value.Say("Sorry, I don't understand.");
        }

        public void Listen()
        {
            _engine.RecognizeAsyncCancel();

            try
            {
                _engine.RecognizeAsync(RecognizeMode.Single);
            }
            catch (Exception ex)
            {

            }
        }

        private void _speechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var skill = _skills.FirstOrDefault(x => e.Result.Text.ToLower().StartsWith(x.InvocationPhrase.ToLower()));

            if (skill != null)
            {
                var keyword = e.Result.Text.ToLower().Replace(skill.InvocationPhrase, "");

                skill.Execute(new GenericSkillInput
                {
                    Keyword = keyword.Trim()
                });
            }
            else
            {
                _robot.Value.Say("Sorry, I don't understand.");
            }
        }

        public void Dispose()
        {
            _engine?.Dispose();
        }
    }
}
