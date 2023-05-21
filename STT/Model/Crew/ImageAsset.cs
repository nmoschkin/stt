using Newtonsoft.Json;

namespace STT.Model.Crew
{
    /// <summary>
    /// Icon Image Asset
    /// </summary>
    public class ImageAsset
    {
        /// <summary>
        /// file
        /// </summary>
        [JsonProperty("file")]
        public string Filename { get; set; }

    }

}
