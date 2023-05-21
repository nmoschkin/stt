using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace STT.Model.Crew
{

    /// <summary>
    /// Crew Rarity
    /// </summary>
    public enum CrewRarity
    {
        /// <summary>
        /// Common Crew
        /// </summary>
        Common = 1,

        /// <summary>
        /// Uncommon Crew
        /// </summary>
        Uncommon = 2,

        /// <summary>
        /// Rare Crew
        /// </summary>
        Rare = 3,

        /// <summary>
        /// Super Rare Crew
        /// </summary>
        SuperRare = 4,

        /// <summary>
        /// Legendary Crew
        /// </summary>
        Legendary = 5
    }

    /// <summary>
    /// Crew Card for Star Trek Timelines
    /// </summary>
    public class CrewMember
    {
        /// <summary>
        /// symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// short_name
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// flavor
        /// </summary>
        [JsonProperty("flavor")]
        public string Flavor { get; set; }

        /// <summary>
        /// archetype_id
        /// </summary>
        [JsonProperty("archetype_id")]
        public int ArchetypeId { get; set; }

        /// <summary>
        /// max_rarity
        /// </summary>
        [JsonProperty("max_rarity")]
        public CrewRarity MaxRarity { get; set; }

        /// <summary>
        /// equipment_slots
        /// </summary>
        [JsonProperty("equipment_slots")]
        public EquipmentSlot[] EquipmentSlots { get; set; }
        /// <summary>
        /// voice_over
        /// </summary>
        [JsonProperty("voice_over")]
        public string VoiceOver { get; set; }

        /// <summary>
        /// traits
        /// </summary>
        [JsonProperty("traits")]
        public string[] Traits { get; set; }
        /// <summary>
        /// traits_hidden
        /// </summary>
        [JsonProperty("traits_hidden")]
        public string[] HiddenTraits { get; set; } 

        /// <summary>
        /// base_skills
        /// </summary>
        [JsonProperty("base_skills")]
        public BaseSkillSet BaseSkills { get; set; }

        /// <summary>
        /// ship_battle
        /// </summary>
        [JsonProperty("ship_battle")]
        public ShipSkill ShipSkills { get; set; } 

        /// <summary>
        /// action
        /// </summary>
        [JsonProperty("action")]
        public BattleAction ShipAction { get; set; }

        /// <summary>
        /// cross_fuse_targets
        /// </summary>
        [JsonProperty("cross_fuse_targets")]
        public object CrossFuseTargets { get; set; }

        /// <summary>
        /// skill_data
        /// </summary>
        [JsonProperty("skill_data")]
        public SkillData[] SkillData { get; set; }

        /// <summary>
        /// intermediate_skill_data
        /// </summary>
        [JsonProperty("intermediate_skill_data")]
        public IntermediateSkillData[] IntermediateSkillData { get; set; }
        /// <summary>
        /// is_craftable
        /// </summary>
        [JsonProperty("is_craftable")]
        public bool IsCraftable { get; set; }

        /// <summary>
        /// imageUrlPortrait
        /// </summary>
        [JsonProperty("imageUrlPortrait")]
        public string ImageUrlPortrait { get; set; }

        /// <summary>
        /// imageUrlFullBody
        /// </summary>
        [JsonProperty("imageUrlFullBody")]
        public string ImageUrlFullBody { get; set; }

        /// <summary>
        /// series
        /// </summary>
        [JsonProperty("series")]
        public string Series { get; set; }

        /// <summary>
        /// traits_named
        /// </summary>
        [JsonProperty("traits_named")]
        public string[] NamedTraits { get; set; }
        /// <summary>
        /// collections
        /// </summary>
        [JsonProperty("collections")]
        public string[] Collections { get; set; }
        /// <summary>
        /// nicknames
        /// </summary>
        [JsonProperty("nicknames")]
        public NicknameDetails[] Nicknames { get; set; }
        /// <summary>
        /// cab_ov
        /// </summary>
        [JsonProperty("cab_ov")]
        public float CABOverallPowerRating { get; set; }

        /// <summary>
        /// cab_ov_rank
        /// </summary>
        [JsonProperty("cab_ov_rank")]
        public int CABOverallRank { get; set; }

        /// <summary>
        /// cab_ov_grade
        /// </summary>
        [JsonProperty("cab_ov_grade")]
        public string CABOverallGrade { get; set; }

        /// <summary>
        /// Total Chronoton Cost
        /// </summary>
        [JsonProperty("totalChronCost")]
        public int TotalChronotonCost { get; set; }

        /// <summary>
        /// factionOnlyTotal
        /// </summary>
        [JsonProperty("factionOnlyTotal")]
        public int FactionOnlyTotal { get; set; }

        /// <summary>
        /// craftCost
        /// </summary>
        [JsonProperty("craftCost")]
        public int CraftCost { get; set; }

        /// <summary>
        /// ranks
        /// </summary>
        [JsonProperty("ranks")]
        public Ranks Ranks { get; set; }

        /// <summary>
        /// bigbook_tier
        /// </summary>
        [JsonProperty("bigbook_tier")]
        public int BigBookTier { get; set; }

        /// <summary>
        /// events
        /// </summary>
        [JsonProperty("events")]
        public int Events { get; set; }

        /// <summary>
        /// in_portal
        /// </summary>
        [JsonProperty("in_portal")]
        public bool InPortal { get; set; }

        /// <summary>
        /// date_added
        /// </summary>
        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// obtained
        /// </summary>
        [JsonProperty("obtained")]
        public string Obtained { get; set; }

        /// <summary>
        /// markdownContent
        /// </summary>
        [JsonProperty("markdownContent")]
        public string MarkdownContent { get; set; }

        /// <summary>
        /// unique_polestar_combos
        /// </summary>
        [JsonProperty("unique_polestar_combos")]
        public string[][] UniquePolestarCombos { get; set; }

        /// <summary>
        /// constellation
        /// </summary>
        [JsonProperty("constellation")]
        public Constellation Constellation { get; set; }

        /// <summary>
        /// kwipment
        /// </summary>
        [JsonProperty("kwipment")]
        public object[] Kwipment { get; set; }

        /// <summary>
        /// q_bits
        /// </summary>
        [JsonProperty("q_bits")]
        public int QBits { get; set; }

        public override string ToString()
        {
            return $"{Name} / {MaxRarity} / {BaseSkills}";
        }

    }

}
