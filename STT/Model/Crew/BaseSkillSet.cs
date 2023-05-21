using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace STT.Model.Crew
{

    public class BaseSkillSetJsonConverter : JsonConverter<BaseSkillSet>
    {
        public override BaseSkillSet ReadJson(JsonReader reader, Type objectType, BaseSkillSet existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var result = new BaseSkillSet();
                reader.Read();

                while (true)
                {
                    if (reader.Value is string str)
                    {
                        reader.Read();

                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var skill = serializer.Deserialize<Skill>(reader);

                            var prop = typeof(BaseSkillSet).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .Where(p => p.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName == str)
                                .FirstOrDefault();

                            if (prop != null)
                            {
                                skill.SkillInfo = ParsingSkill.Parse(prop.Name);
                                prop.SetValue(result, skill);
                            }
                        }
                    }

                    reader.Read();

                    if (reader.TokenType == JsonToken.EndObject) break;
                }

                return result;
            }

            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, BaseSkillSet value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Base Skill Set Collection
    /// </summary>
    [JsonConverter(typeof(BaseSkillSetJsonConverter))]
    public class BaseSkillSet : IReadOnlyList<Skill>
    {
        public int Count => this.Count();

        /// <summary>
        /// security_skill
        /// </summary>
        [JsonProperty("security_skill")]
        public Skill Security { get; set; }

        /// <summary>
        /// command_skill
        /// </summary>
        [JsonProperty("command_skill")]
        public Skill Command { get; set; }

        /// <summary>
        /// diplomacy_skill
        /// </summary>
        [JsonProperty("diplomacy_skill")]
        public Skill Diplomacy { get; set; }

        /// <summary>
        /// medicine_skill
        /// </summary>
        [JsonProperty("medicine_skill")]
        public Skill Medicine { get; set; } 

        /// <summary>
        /// science_skill
        /// </summary>
        [JsonProperty("science_skill")]
        public Skill Science { get; set; } 

        /// <summary>
        /// engineering_skill
        /// </summary>
        [JsonProperty("engineering_skill")]
        public Skill Engineering { get; set; }

        public Skill this[int index]
        {
            get
            {
                int i = 0;
                foreach (Skill skill in this)
                {
                    if (i == index) return skill;
                    i++;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public SkillType SkillFlag
        {
            get
            {
                SkillType skillType = SkillType.Undefined;

                if (Security != null && !Security.IsEmpty) skillType |= SkillType.Security;
                if (Command != null && !Command.IsEmpty) skillType |= SkillType.Command;
                if (Diplomacy != null && !Diplomacy.IsEmpty) skillType |= SkillType.Diplomacy;
                if (Medicine != null && !Medicine.IsEmpty) skillType |= SkillType.Medicine;
                if (Science != null && !Science.IsEmpty) skillType |= SkillType.Science;
                if (Engineering != null && !Engineering.IsEmpty) skillType |= SkillType.Engineering;

                return skillType;
            }
        }

        public IEnumerator<Skill> GetEnumerator()
        {
            if (Security != null && !Security.IsEmpty) yield return Security;
            if (Command != null && !Command.IsEmpty) yield return Command;
            if (Diplomacy != null && !Diplomacy.IsEmpty) yield return Diplomacy;
            if (Medicine != null && !Medicine.IsEmpty) yield return Medicine;
            if (Science != null && !Science.IsEmpty) yield return Science;
            if (Engineering != null && !Engineering.IsEmpty) yield return Engineering;

            yield break;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this)
            {
                if (sb.Length > 0) sb.Append(", ");

                sb.Append(item.ToString());
            }

            return sb.ToString();   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
