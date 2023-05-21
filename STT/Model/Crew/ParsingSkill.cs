using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace STT.Model.Crew
{
    /// <summary>
    /// Skill Map and Parsing Class
    /// </summary>
    public sealed class ParsingSkill // : IParsable<SkillSet>
    {
        private static string dcs = "/";

        /// <summary>
        /// Gets or sets the default compound separator in cases where it is not explicitly provided
        /// </summary>
        public static string DefaultSeparator
        {
            get => dcs;
            set => dcs = value;
        }

        /// <summary>
        /// Security
        /// </summary>
        public static readonly ParsingSkill Security = new ParsingSkill("Security", SkillType.Security, "SEC");

        /// <summary>
        /// Command
        /// </summary>
        public static readonly ParsingSkill Command = new ParsingSkill("Command", SkillType.Command, "CMD");

        /// <summary>
        /// Diplomacy
        /// </summary>
        public static readonly ParsingSkill Diplomacy = new ParsingSkill("Command", SkillType.Diplomacy, "DIP");

        /// <summary>
        /// Medicine
        /// </summary>
        public static readonly ParsingSkill Medicine = new ParsingSkill("Command", SkillType.Medicine, "MED");

        /// <summary>
        /// Science
        /// </summary>
        public static readonly ParsingSkill Science = new ParsingSkill("Command", SkillType.Science, "SCI");

        /// <summary>
        /// Engineering
        /// </summary>
        public static readonly ParsingSkill Engineering = new ParsingSkill("Command", SkillType.Engineering, "ENG");

        /// <summary>
        /// Skill map keyed off of 3-letter code
        /// </summary>
        public static readonly ReadOnlyDictionary<SkillType, ParsingSkill> SkillMap =
            new ReadOnlyDictionary<SkillType, ParsingSkill>(
                new Dictionary<SkillType, ParsingSkill>()
                {
                    { SkillType.Security, Security },
                    { SkillType.Command, Command },
                    { SkillType.Diplomacy, Diplomacy },
                    { SkillType.Medicine, Medicine },
                    { SkillType.Science, Science },
                    { SkillType.Engineering, Engineering },
                    { SkillType.Undefined, null }
                });


        /// <summary>
        /// Create a new compound skill set from the specified <see cref="SkillType"/> flag.
        /// </summary>
        /// <param name="skillType">The skill type flag to use to create the new skill set.</param>
        /// <returns>A new compound skill set object.</returns>
        /// <remarks>
        /// If <paramref name="skillType"/> does not refer to a compound skill type, then the singleton is returned.
        /// </remarks>
        public static ParsingSkill Create(SkillType skillType) => Create(skillType, null);

        /// <summary>
        /// Create a new compound skill set from the specified <see cref="SkillType"/> flag.
        /// </summary>
        /// <param name="skillType">The skill type flag to use to create the new skill set.</param>
        /// <param name="separator">The string that separates the entries</param>
        /// <returns>A new compound skill set object.</returns>
        /// <remarks>
        /// If <paramref name="skillType"/> does not refer to a compound skill type, then the singleton is returned.
        /// </remarks>
        public static ParsingSkill Create(SkillType skillType, string separator)
        {
            if (SkillMap.ContainsKey(skillType)) return SkillMap[skillType];
            return new ParsingSkill(PrintSkillType(skillType, false, separator), skillType, PrintSkillType(skillType, true, separator));
        }

        /// <summary>
        /// Merge skill sets into a new single compound skill set.
        /// </summary>
        /// <param name="skillSets">The skill sets to use to create the new skill set.</param>
        /// <param name="separator">The string that separates the entries</param>
        /// <returns></returns>
        public static ParsingSkill Merge(IEnumerable<ParsingSkill> skillSets, string separator)
        {
            SkillType skillType = SkillType.Undefined;

            foreach (var sk in skillSets)
            {
                skillType |= sk.Type;
            }

            return Create(skillType, separator);
        }

        /// <summary>
        /// Merge skill sets into a new single compound skill set.
        /// </summary>
        /// <param name="skillSets">The skill sets to use to create the new skill set.</param>
        /// <returns></returns>
        public static ParsingSkill Merge(params ParsingSkill[] skillSets)
        {
            return Merge(skillSets, null);
        }

        private ParsingSkill(string name, SkillType type, string code)
        {
            Name = name;
            Type = type;
            Code = code;
        }

        /// <summary>
        /// Print the skill type, or combination, as text
        /// </summary>
        /// <param name="st">The skill type value</param>
        /// <param name="printCodes">True to print 3-letter codes, otherwise, prints long names</param>
        /// <param name="separator">The string that separates the entries</param>
        /// <returns>A string formatted as requested</returns>
        public static string PrintSkillType(SkillType st, bool printCodes, string separator = null)
        {
            separator ??= dcs;

            var sb = new StringBuilder();
            int i = 0;

            foreach (var kv in SkillMap)
            {
                if ((st & kv.Key) != 0)
                {
                    if (i++ > 0) sb.Append(separator);
                    if (printCodes) sb.Append(kv.Value.Code);
                    else sb.Append(kv.Value.Name);
                }
            }

            return sb.Length > 0 ? sb.ToString() : SkillType.Undefined.ToString();
        }

        /// <summary>
        /// Parse a single value to a <see cref="SkillType"/> enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The recognized skill type or <see cref="SkillType.Undefined"/></returns>
        /// <remarks>
        /// Does not support compound values, only pure names or 3-letter codes (case-insensitive)
        /// <br /><br />
        /// To parse compound values, use <see cref="TryParse(string, out ParsingSkill)"/>.
        /// </remarks>
        public static SkillType StringToSkillType(string value)
        {
            switch (value.ToLower().Trim())
            {
                case "sec":
                case "security":
                    return SkillType.Security;

                case "cmd":
                case "command":
                    return SkillType.Command;

                case "dip":
                case "diplomacy":
                    return SkillType.Diplomacy;

                case "med":
                case "medicine":
                    return SkillType.Medicine;

                case "sci":
                case "science":
                    return SkillType.Science;

                case "eng":
                case "engineering":
                    return SkillType.Engineering;

            }

            return SkillType.Undefined;
        }

        /// <summary>
        /// Parse a string into a single or compound skill set into a new <see cref="ParsingSkill"/> object.
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ParsingSkill Parse(string value)
        {
            if (!TryParse(value, out var skillSet, false, dcs))
            {
                throw new ArgumentException("Could not parse value into skill set");
            }

            return skillSet;
        }

        /// <summary>
        /// Parse a string into a single or compound skill set into a new <see cref="ParsingSkill"/> object.
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <param name="preserveForm">True to preserve the input string in the <see cref="Name"/> property of the newly created <see cref="ParsingSkill"/> object.</param>
        /// <param name="separator">The string to use to separate elements in the printed versions of compound skill sets.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ParsingSkill Parse(string value, bool preserveForm, string separator)
        {
            if (!TryParse(value, out var skillSet, preserveForm, separator))
            {
                throw new ArgumentException("Could not parse value into skill set");
            }

            return skillSet;
        }


        /// <summary>
        /// Try to parse a string into a single or compound skill set into a new <see cref="ParsingSkill"/> object.
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <param name="skillSet">The <see cref="ParsingSkill"/> object result</param>
        /// <returns></returns>
        public static bool TryParse(string value, out ParsingSkill skillSet)
        {
            return TryParse(value, out skillSet, false, dcs);
        }


        /// <summary>
        /// Try to parse a string into a single or compound skill set into a new <see cref="ParsingSkill"/> object.
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <param name="skillSet">The <see cref="ParsingSkill"/> object result</param>
        /// <param name="preserveForm">True to preserve the input string in the <see cref="Name"/> property of the newly created <see cref="ParsingSkill"/> object.</param>
        /// <param name="separator">The string to use to separate elements in the printed versions of compound skill sets.</param>
        /// <returns></returns>
        public static bool TryParse(string value, out ParsingSkill skillSet, bool preserveForm, string separator)
        {
            SkillType skillType = StringToSkillType(value);

            if (skillType != SkillType.Undefined)
            {
                skillSet = SkillMap[skillType];
                return true;
            }

            var sb = new StringBuilder();
            var l = new List<string>();

            foreach (var ch in value)
            {
                if (char.IsLetter(ch))
                {
                    sb.Append(ch);
                }
                else if (sb.Length > 0)
                {
                    l.Add(sb.ToString());
                    sb.Clear();
                }
            }

            foreach (var sk in l)
            {
                skillType |= StringToSkillType(sk);
            }

            if (skillType != SkillType.Undefined)
            {
                skillSet = new ParsingSkill(preserveForm ? value : PrintSkillType(skillType, false, separator), skillType, PrintSkillType(skillType, true, separator));
                return true;
            }

            skillSet = null;
            return false;
        }

        /// <summary>
        /// The skill name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The skill enum code
        /// </summary>
        public SkillType Type { get; }

        /// <summary>
        /// The skill 3-letter code
        /// </summary>
        public string Code { get; }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator SkillType(ParsingSkill obj) => obj.Type;
    }

}
