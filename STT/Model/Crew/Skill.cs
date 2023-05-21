using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace STT.Model.Crew
{
    /// <summary>
    /// Crew Core and Proficiency Skill Set Structure
    /// </summary>
    public sealed class Skill : IEquatable<Skill>, IComparable<Skill>
    {
        /// <summary>
        /// Empty Skill
        /// </summary>
        public static readonly Skill Empty = new Skill(0, 0, 0);

        private int core;
        private int rangeMin;
        private int rangeMax;
        private ParsingSkill skill;

        [JsonIgnore]
        public ParsingSkill SkillInfo
        {
            get => skill; 
            set => skill = value;
        }

        /// <summary>
        /// Returns true if this skill set is empty
        /// </summary>
        public bool IsEmpty => Equals(Empty);

        /// <summary>
        /// core
        /// </summary>
        [JsonProperty("core")]
        public int Core
        {
            get => core;
            set => core = value;
        }

        /// <summary>
        /// range_min
        /// </summary>
        [JsonProperty("range_min")]
        public int RangeMin
        {
            get => rangeMin;
            set => rangeMin = value;
        }

        /// <summary>
        /// range_max
        /// </summary>
        [JsonProperty("range_max")]
        public int RangeMax
        {
            get => rangeMax;
            set => rangeMax = value;
        }

        /// <summary>
        /// Create a new skill with all the skills populated
        /// </summary>
        /// <param name="core">Core Skill</param>
        /// <param name="rangeMin">Proficiency Min</param>
        /// <param name="rangeMax">Proficiency Max</param>
        public Skill(int core, int rangeMin, int rangeMax)
        {
            Core = core;
            RangeMin = rangeMin;
            RangeMax = rangeMax;
        }

        public Skill() { }

        /// <inheritdoc/>
        public bool Equals(Skill other)
        {
            if (other is null) return false;
            return Core == other.Core && RangeMin == other.RangeMin && RangeMax == other.RangeMax;
        }

        /// <inheritdoc/>
        public int CompareTo(Skill other)
        {
            if (other is null) return -1;

            int r = Core.CompareTo(other.Core);

            if (r != 0) return r;
            r = RangeMax.CompareTo(other.RangeMax);

            if (r != 0) return r;
            r = RangeMin.CompareTo(other.RangeMin);

            return r;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (SkillInfo != null)
            {
                return $"{SkillInfo.Code}: {Core} ({RangeMin}-{RangeMax})";
            }
            else
            {
                return $"{Core} ({RangeMin}-{RangeMax})";
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (Core, RangeMin, RangeMax).GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is Skill sk) return Equals(sk);
            return false;
        }

        /// <summary>
        /// Test if a == b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Skill a, Skill b) { return a?.Core == b?.Core && a?.RangeMin == b?.RangeMin && a?.RangeMax == b?.RangeMax; }

        /// <summary>
        /// Test if a != b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Skill a, Skill b) { return a?.Core != b?.Core || a?.RangeMin != b?.RangeMin || a?.RangeMax != b?.RangeMax; }

        /// <summary>
        /// Test if a > b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Skill a, Skill b) { return a?.CompareTo(b) > 0; }

        /// <summary>
        /// Test if a < b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Skill a, Skill b) { return a?.CompareTo(b) < 0; }

        /// <summary>
        /// Test if a >= b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(Skill a, Skill b) { return a?.CompareTo(b) >= 0; }

        /// <summary>
        /// Test if a <= b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(Skill a, Skill b) { return a?.CompareTo(b) <= 0; }

    }

}
