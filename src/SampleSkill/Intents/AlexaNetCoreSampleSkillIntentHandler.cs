using AlexaNetCore;
using DistanceLibrary;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AlexaNetCoreSampleSkill.Intents
{
    public class AlexaNetCoreSampleSkillIntentHandler : AlexaIntentHandlerBase
    {

        /// <summary>
        /// There is a default console logger built in which ties in with AWS logging.
        /// This logger can be replaced with any logger that implements IAlexaNetCoreMessageLogger if you would like to build your own.
        /// </summary>
        public AlexaNetCoreSampleSkillIntentHandler(IAlexaNetCoreMessageLogger log) : base(IntentNames.SampleIntent, log)
        {
        }

        public override void Process()
        {
            try
            {
                //no matter what the user said, we respond with Hello World
                ResponseEnv.SetOutputSpeechText("Hello World");
            }
            catch (Exception exc)
            {
                //if something goes wrong we log it
                MsgLogger.Error(exc, $"Exception: {exc.Message}");

                //...now tell the user what is going on
                ResponseEnv.SetOutputSpeechText($"I'm sorry, something went wrong.  Can you try again?");
            }

        }


    }
}
