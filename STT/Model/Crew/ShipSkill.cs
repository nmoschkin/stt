using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace STT.Model.Crew
{
    /// <summary>
    /// Crew Ship Skill Structure
    /// </summary>
    public sealed class ShipSkill : IEquatable<ShipSkill>, IComparable<ShipSkill>
    {
        /// <summary>
        /// Empty ShipSkill
        /// </summary>
        public static readonly ShipSkill Empty = new ShipSkill(0, 0, 0, 0);

        private int accuracy;
        private int evasion;
        private int critChance;
        private int critBonus;

        /// <summary>
        /// Returns true if this ship skill set is empty
        /// </summary>
        public bool IsEmpty => Equals(Empty);

        /// <summary>
        /// Accuracy
        /// </summary>
        [JsonProperty("accuracy")]
        public int Accuracy
        {
            get => accuracy;
            set => accuracy = value;
        }

        /// <summary>
        /// Evasion
        /// </summary>
        [JsonProperty("evasion")]
        public int Evasion
        {
            get => evasion;
            set => evasion = value;
        }

        /// <summary>
        /// Crit Chance
        /// </summary>
        [JsonProperty("crit_chance")]
        public int CritChance
        {
            get => critChance;
            set => critChance = value;
        }

        /// <summary>
        /// Crit Bonus
        /// </summary>
        [JsonProperty("crit_bonus")]
        public int CritBonus
        {
            get => critBonus;
            set => critBonus = value;
        }

        /// <summary>
        /// Create a new ship skill with all the skills populated
        /// </summary>
        /// <param name="accuracy">Accuracy</param>
        /// <param name="evasion">Evasion</param>
        /// <param name="critChance">Crit Bonus</param>
        /// <param name="critBonus">Crit Bonus</param>
        public ShipSkill(int accuracy, int evasion, int critChance, int critBonus)
        {
            Accuracy = accuracy;
            Evasion = evasion;
            CritChance = critChance;
            CritBonus = critBonus;
        }

        public ShipSkill() { }

        /// <inheritdoc/>
        public bool Equals(ShipSkill other)
        {
            return Accuracy == other.Accuracy && Evasion == other.Evasion && CritChance == other.CritChance && CritBonus == other.CritBonus;
        }

        /// <inheritdoc/>
        public int CompareTo(ShipSkill other)
        {
            int r = Accuracy.CompareTo(other.Accuracy);

            if (r != 0) return r;
            r = Evasion.CompareTo(other.Evasion);

            if (r != 0) return r;
            r = CritChance.CompareTo(other.CritChance);

            if (r != 0) return r;
            r = CritBonus.CompareTo(other.CritBonus);

            return r;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"A: {Accuracy}; E: {Evasion}; CC: {CritChance}; CB: {CritBonus}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (Accuracy, Evasion, CritChance, CritBonus).GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is ShipSkill sk) return Equals(sk);
            return false;
        }

        /// <summary>
        /// Test if a == b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(ShipSkill a, ShipSkill b) { return a.Accuracy == b.Accuracy && a.Evasion == b.Evasion && a.CritChance == b.CritChance && a.CritBonus == b.CritBonus; }

        /// <summary>
        /// Test if a != b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(ShipSkill a, ShipSkill b) { return a.Accuracy != b.Accuracy || a.Evasion != b.Evasion || a.CritChance != b.CritChance || a.CritBonus != b.CritBonus; }

        /// <summary>
        /// Test if a > b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(ShipSkill a, ShipSkill b) { return a.CompareTo(b) > 0; }

        /// <summary>
        /// Test if a < b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(ShipSkill a, ShipSkill b) { return a.CompareTo(b) < 0; }

        /// <summary>
        /// Test if a >= b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(ShipSkill a, ShipSkill b) { return a.CompareTo(b) >= 0; }

        /// <summary>
        /// Test if a <= b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(ShipSkill a, ShipSkill b) { return a.CompareTo(b) <= 0; }

    }

}
