using System;

namespace STT.Model.Crew
{
    /// <summary>
    /// Skill Types
    /// </summary>
    [Flags]
    public enum SkillType
    {
        Undefined = 0,
        Security = 0x1,
        Command = 0x2,
        Diplomacy = 0x4,
        Medicine = 0x8,
        Science = 0x10,
        Engineering = 0x20,
    }

}
