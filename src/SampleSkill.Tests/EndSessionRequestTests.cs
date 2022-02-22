using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCoreSampleSkill.Tests
{
    public class EndSessionRequestTests 
    {

     
        
        [Test]
        public void EndSession_ShouldNotReturnCard()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.EndSession()).ProcessRequest();
            Assert.IsNull(skill.ResponseEnv.GetCard());
        }

      

        [Test]
        public void StopRequest_EndsSession()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.StopRequest()).ProcessRequest();
            Assert.IsTrue( skill.ResponseEnv.ShouldEndSession);

        }
        
        [Test]
        public void StopRequest_SaysGoodbye()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.StopRequest()).ProcessRequest();
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.GetOutputSpeech().SpeechType);

            //Note the period in the string, this is coming from the default Stop handler, not the Cancel handler defined in the AlexaNetCoreHelloWorldSkill
            Assert.AreEqual("Goodbye.", skill.ResponseEnv.GetOutputSpeechText(AlexaLocale.English_US));
        }

        
        
        [Test]
        public void CancelRequest_SaysGoodbye()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.AreEqual("Goodbye", skill.ResponseEnv.GetOutputSpeechText(AlexaLocale.English_US));
        }

        [Test]
        public void CancelRequest_EndsSession()
        {
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();
            Assert.AreEqual(true, skill.ResponseEnv.ShouldEndSession);
        }


    }
}

