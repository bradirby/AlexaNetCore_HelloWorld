﻿using System;
using AlexaNetCore;
using AlexaNetCoreSampleSkill.Intents;

namespace AlexaNetCoreSampleSkill
{
    public class AlexaNetCoreHelloWorldSkill : AlexaSkillBase
    {

        public AlexaNetCoreHelloWorldSkill()
        {
            //There is a default console logger built in, which ties in with AWS logging.  It can be replaced with any logger that
            //implements IAlexaNetCoreMessageLogger.  
            MsgLogger.Debug("Sample skill is initializing");

            SetSkillVersion("0.1");

            //There are default intent handlers you can use for simple interactions, or implement your own
            RegisterIntentHandler(new DefaultLaunchIntentHandler("Hello, what can this AlexaNetCoreHelloWorldSkill do for you today?"));
            RegisterIntentHandler(new DefaultHelpIntentHandler("I can help you with that"));
            RegisterIntentHandler(new DefaultCancelIntentHandler("Goodbye"));

            //This will register default handlers for the remaining actions.  Previously defined handlers will not be overwritten
            RegisterDefaultIntentHandlers();

            //Then register your custom intent handlers
            RegisterIntentHandler(new AlexaNetCoreSampleSkillIntentHandler(MsgLogger));
        }

        
    }
}
