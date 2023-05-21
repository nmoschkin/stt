using Newtonsoft.Json;
using System.Collections.Generic;

namespace STT.Model.Crew
{
    /// <summary>
    /// Ship Battle Action
    /// </summary>
    public class BattleAction
    {
        public static readonly Dictionary<int, string> TypeMap = new Dictionary<int, string>
        {
            { 0, "Attack" },
            { 1, "Evasion" },
            { 2, "Accuracy" },
		    // These are only for penalty
		    { 3, "Shield Regeneration" }
        };

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
            return $"{Name} (Boosts {TypeMap[BonusType]} By {BonusAmount})" + (((ChargePhases?.Length ?? 0) > 0) ? $" ({ChargePhases.Length} Charge Phases)" : "");
        }

    }



    public class Penalty
    {
        public static readonly Dictionary<int, string> TypeMap = new Dictionary<int, string>
        {
            { 0, "Attack" },
            { 1, "Evasion" },
            { 2, "Accuracy" },
		    // These are only for penalty
		    { 3, "Shield Regeneration" }
        };

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

        public override string ToString()
        {
            if (TypeMap.ContainsKey(Type))
            {
                return $"Decrease {TypeMap[Type]} by {Amount}";
            }

            return base.ToString();
        }

        /* 
         * 
         
         
        
	static readonly REWARDS_ITEM_TYPE: { [index: number]: string } = {
		0: 'None',
		1: 'Crew',
		2: 'Equipment',
		3: 'Component',
		4: 'Shuttle consumable',
		5: 'Ship part',
		6: 'Shuttle token',
		7: 'Crew experience training',
		8: 'Ship schematic',
		9: 'Replicator ration',
		10: 'Honorable citation',
		11: 'Buff',
		12: 'Starbase component',
		13: 'Voyage consumable'
	};

	static readonly CREW_SHIP_BATTLE_BONUS_TYPE: { [index: number]: string } = {
		0: 'Attack',
		1: 'Evasion',
		2: 'Accuracy',
		// These are only for penalty
		3: 'Shield Regeneration'
	};

	static readonly CREW_SHIP_BATTLE_TRIGGER: { [index: number]: string } = {
		0: 'None',
		1: 'Position',
		2: 'Cloak',
		4: 'Boarding'
	};

	static readonly CREW_SHIP_BATTLE_ABILITY_TYPE: { [index: number]: string } = {
		0: 'Increases bonus boost by +%VAL%',
		1: 'Immediately deals %VAL%% damage',
		2: 'Immediately repairs Hull by %VAL%%',
		3: 'Immediately repairs Shields by %VAL%%',
		4: '+%VAL% to Crit Rating',
		5: '+%VAL% to Crit Bonus',
		6: '+%VAL% to Shield Regeneration',
		7: '+%VAL%% to Attack Speed',
		8: 'Increases boarding damage by %VAL%%'
	};


         */

        public static implicit operator int(Penalty penalty)
        {
            return penalty.Type;
        }
    }

    public class Ability : Penalty
    {
        public static readonly Dictionary<int, string> TriggerMap = new Dictionary<int, string>
        {
            { 0, "None" },
            { 1, "Position" },
            { 2, "Cloak" },
		    { 4, "Boarding" }
        };

        new public static readonly Dictionary<int, string> TypeMap = new Dictionary<int, string>
        {
            { 0, "Increases bonus boost by +%VAL%" }, // IncreaseBoost
            { 1, "Immediately deals %VAL%% damage" }, // DealDamage
            { 2, "Immediately repairs Hull by %VAL%%" }, // RepairHull
            { 3, "Immediately repairs Shields by %VAL%%" }, // RepairShields
            { 4, "+%VAL% to Crit Rating" }, // CritRating
            { 5, "+%VAL% to Crit Bonus" }, // CritBonus
            { 6, "+%VAL% to Shield Regeneration" }, // ShieldRegeneration
            { 7, "+%VAL%% to Attack Speed" }, // AttackSpeed
            { 8, "Increases boarding damage by %VAL%%" } // BoardingDamage
        };

        /// <summary>
        /// condition
        /// </summary>
        [JsonProperty("condition")]
        public int Condition { get; set; }

        public override string ToString()
        {
            if (TypeMap.ContainsKey(Type) && TriggerMap.ContainsKey(Condition))
            {
                if (Condition != 0)
                {
                    return $"{TypeMap[Type].Replace("%VAL%", Amount.ToString())} (Trigger: {TriggerMap[Condition]})";
                }
                else
                {
                    return $"{TypeMap[Type].Replace("%VAL%", Amount.ToString())}";
                }
            }

            return base.ToString();
        }
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
