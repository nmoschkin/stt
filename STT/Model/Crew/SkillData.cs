using Newtonsoft.Json;

namespace STT.Model.Crew
{
    public class SkillData
    {
        /// <summary>
        /// rarity
        /// </summary>
        [JsonProperty("rarity")]
        public CrewRarity Rarity { get; set; }

        /// <summary>
        /// base_skills
        /// </summary>
        [JsonProperty("base_skills")]
        public BaseSkillSet BaseSkills { get; set; }

        public override string ToString()
        {
            return $"({Rarity}) {BaseSkills}";
        }

    }

    public class IntermediateSkillData : SkillData
    {
        /// <summary>
        /// level
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        /// action
        /// </summary>
        [JsonProperty("action")]
        public BattleAction ShipAction { get; set; }

        /// <summary>
        /// ship_battle
        /// </summary>
        [JsonProperty("ship_battle")]
        public ShipSkill ShipSkills { get; set; }

        public override string ToString()
        {
            return $"({Rarity} Level {Level}) {BaseSkills}";
        }
    }


}
