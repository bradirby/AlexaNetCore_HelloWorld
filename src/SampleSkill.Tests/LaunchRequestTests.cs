using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCoreSampleSkill.Tests
{
    public class LaunchRequestTests 
    {

        [Test]
        public void LaunchRequest_InvokeWithNoIntent_SaysHello()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();

            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.AreEqual("Hello, what can this AlexaNetCoreHelloWorldSkill do for you today?", skill.ResponseEnv.GetOutputSpeechText(AlexaLocale.English_US));
        }

        [Test]
        public void OpenRequest_InvokeWithNoIntent_SaysHello()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.OpenRequest()).ProcessRequest();

            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.AreEqual("Hello, what can this AlexaNetCoreHelloWorldSkill do for you today?", skill.ResponseEnv.GetOutputSpeechText(AlexaLocale.English_US));
        }

        [Test]
        public void StartSession_InvokeWithNoIntent_SaysHello()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.StartSession()).ProcessRequest();

            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.AreEqual("Hello, what can this AlexaNetCoreHelloWorldSkill do for you today?", skill.ResponseEnv.GetOutputSpeechText(AlexaLocale.English_US));
        }

        [Test]
        public void LaunchRequest_InvokeWithNoIntent_DoesNotEndSession()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();
            Assert.AreEqual(false, skill.ResponseEnv.ShouldEndSession);
        }

        
        [Test]
        public void LaunchRequest_ShouldNotReturnCard()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();
            Assert.IsNull(skill.ResponseEnv.GetCard());
        }
      

    }
}

