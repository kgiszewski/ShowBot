using System;
using System.Configuration;

namespace ShowBot.Core.Config
{
    public static class AppConfigs
    {
        public static class SpeechComponent
        {
            public static bool SendOutputToFile = Convert.ToBoolean(ConfigurationManager.AppSettings["SpeechComponent:SendToFile"] ?? "false");
            public static bool UseMaleVoice = Convert.ToBoolean(ConfigurationManager.AppSettings["SpeechComponent:UseMaleVoice"] ?? "false");

            public static class ErrorResponses
            {
                public const string SorryCannotDoThat = "Sorry, I cannot do that.";
            }
        }
    }
}
