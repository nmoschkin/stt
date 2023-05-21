using Newtonsoft.Json;

namespace STT.Model.Crew
{
    public class TripletData
    {
        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// rank
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"{Name} / Rank {Rank}";
        }

    }

}
