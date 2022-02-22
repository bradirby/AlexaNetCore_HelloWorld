using AlexaNetCore;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AlexaNetCoreSampleSkill
{
    public class SampleSkillLambdaFunction
    {
        /// <summary>
        /// This is all that is necessary for a fully functional skill.
        /// We let the AWS processing turn the JSON string into the proper AlexaSkillRequestEnvelop object we want, then process it.
        /// We can inject the ILambdaContext just by including it in the method signature, but for this skill we do not need it
        /// </summary>
        public string ProductionFunctionHandler(AlexaSkillRequestEnvelope input)
        {
            return  new AlexaNetCoreHelloWorldSkill().LoadRequest(input).ProcessRequest().CreateAlexaResponse();
        }

        /// <summary>
        /// You can add error logging and other data checks throughout the pipeline for easy debugging.
        /// By processing the input as an object we can adjust the incoming string if we want, such as changing it to appear to come
        /// from a user in a different locale.
        /// </summary>
        public string TestFunctionHandler(object input, ILambdaContext context)
        {
            //Create the skill and process the incoming string
            var skill = new AlexaNetCoreHelloWorldSkill().LoadRequest(input.ToString()).ProcessRequest();

            //since we are in test, we validate the response that comes back to check for errors
            skill.ValidateResponse();

            //return the speach string to Alexa
            return skill.CreateAlexaResponse();
        }
     
    }
}
