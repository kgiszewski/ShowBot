using System;
using System.Configuration;

namespace ShowBot.Core.Config
{
    public static class AppConfigs
    {
        public static class SpeechComponent
        {
            public static bool SendOutputToFile = Convert.ToBoolean(ConfigurationManager.AppSettings["SpeechComponent:SendToFile"] ?? "false");
        }
    }
}
