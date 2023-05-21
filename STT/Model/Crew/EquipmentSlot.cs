using Newtonsoft.Json;

namespace STT.Model.Crew
{
    public class EquipmentSlot
    {
        /// <summary>
        /// level
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        public override string ToString()
        {
            return Symbol;
        }
    }

}
