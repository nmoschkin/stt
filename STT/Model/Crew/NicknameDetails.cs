using Newtonsoft.Json;

namespace STT.Model.Crew
{
    public class NicknameDetails
    {
        /// <summary>
        /// actualName
        /// </summary>
        [JsonProperty("actualName")]
        public string ActualName { get; set; }

        /// <summary>
        /// cleverThing
        /// </summary>
        [JsonProperty("cleverThing")]
        public string CleverThing { get; set; }

        /// <summary>
        /// creator
        /// </summary>
        [JsonProperty("creator")]
        public string Creator { get; set; }


        public override string ToString()
        {
            return CleverThing ?? ActualName ?? Creator ?? base.ToString();
        }

    }

}
