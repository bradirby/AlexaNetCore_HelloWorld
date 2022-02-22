using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCoreSampleSkill.Tests
{
    public class InvalidIntentRequestTests 
    {


        [Test]
        public void InvalidIntentName_ReturnsHelpText()
        {
            var s = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.InvalidIntentName()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.AreEqual("I can help you with that", s.ResponseEnv.GetOutputSpeechText(AlexaLocale.English_US));
        }

        [Test]
        public void InvalidIntentName_DoesNotEndSession()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.InvalidIntentType()).ProcessRequest();

            Assert.AreEqual(false, skill.ResponseEnv.ShouldEndSession);
        }

       

    }
}

