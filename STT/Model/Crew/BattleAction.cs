using Newtonsoft.Json;

namespace STT.Model.Crew
{
    /// <summary>
    /// Ship Battle Action
    /// </summary>
    public class BattleAction
    {
        /// <summary>
        /// bonus_amount
        /// </summary>
        [JsonProperty("bonus_amount")]
        public int BonusAmount { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// cooldown
        /// </summary>
        [JsonProperty("cooldown")]
        public int Cooldown { get; set; }

        /// <summary>
        /// initial_cooldown
        /// </summary>
        [JsonProperty("initial_cooldown")]
        public int InitialCooldown { get; set; }

        /// <summary>
        /// duration
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// bonus_type
        /// </summary>
        [JsonProperty("bonus_type")]
        public int BonusType { get; set; }

        /// <summary>
        /// crew
        /// </summary>
        [JsonProperty("crew")]
        public int Crew { get; set; }

        /// <summary>
        /// crew_archetype_id
        /// </summary>
        [JsonProperty("crew_archetype_id")]
        public int CrewArchetypeId { get; set; }

        /// <summary>
        /// icon
        /// </summary>
        [JsonProperty("icon")]
        public ImageAsset Icon { get; set; }

        /// <summary>
        /// special
        /// </summary>
        [JsonProperty("special")]
        public bool IsSpecial { get; set; }

        /// <summary>
        /// penalty
        /// </summary>
        [JsonProperty("penalty")]
        public Penalty Penalty { get; set; }

        /// <summary>
        /// limit
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// ability
        /// </summary>
        [JsonProperty("ability")]
        public Ability Ability { get; set; }

        /// <summary>
        /// charge_phases
        /// </summary>
        [JsonProperty("charge_phases")]
        public ChargePhase[] ChargePhases { get; set; }

        public override string ToString()
        {
            return Symbol;
        }

    }

    public class Penalty
    {
        /// <summary>
        /// type
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

    }

    public class Ability
    {
        /// <summary>
        /// condition
        /// </summary>
        [JsonProperty("condition")]
        public int Condition { get; set; }

        /// <summary>
        /// type
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

    }

    public class ChargePhase
    {
        /// <summary>
        /// charge_time
        /// </summary>
        [JsonProperty("charge_time")]
        public int ChargeTime { get; set; }

        /// <summary>
        /// ability_amount
        /// </summary>
        [JsonProperty("ability_amount")]
        public int AbilityAmount { get; set; }

        /// <summary>
        /// bonus_amount
        /// </summary>
        [JsonProperty("bonus_amount")]
        public int BonusAmount { get; set; }

        /// <summary>
        /// cooldown
        /// </summary>
        [JsonProperty("cooldown")]
        public int Cooldown { get; set; }

        /// <summary>
        /// duration
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

    }

}
