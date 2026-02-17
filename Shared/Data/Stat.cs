public sealed class Stats : IEquatable<Stats>
{
    public SortedDictionary<Stat, int> Values { get; set; } = new SortedDictionary<Stat, int>();
    public int Count => Values.Sum(pair => Math.Abs(pair.Value));

    public int this[Stat stat]
    {
        get
        {
            return !Values.TryGetValue(stat, out int result) ? 0 : result;
        }
        set
        {
            if (value == 0)
            {
                if (Values.ContainsKey(stat))
                {
                    Values.Remove(stat);
                }

                return;
            }

            Values[stat] = value;
        }
    }

    public Stats() { }

    public Stats(Stats stats)
    {
        foreach (KeyValuePair<Stat, int> pair in stats.Values)
            this[pair.Key] += pair.Value;
    }

    public Stats(BinaryReader reader, int version = int.MaxValue, int customVersion = int.MaxValue)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Values[(Stat)reader.ReadByte()] = reader.ReadInt32();
    }

    public void Add(Stats stats)
    {
        foreach (KeyValuePair<Stat, int> pair in stats.Values)
            this[pair.Key] += pair.Value;
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Values.Count);

        foreach (KeyValuePair<Stat, int> pair in Values)
        {
            writer.Write((byte)pair.Key);
            writer.Write(pair.Value);
        }
    }

    public void Clear()
    {
        Values.Clear();
    }

    public bool Equals(Stats other)
    {
        if (Values.Count != other.Values.Count) return false;

        foreach (KeyValuePair<Stat, int> value in Values)
            if (other[value.Key] != value.Value) return false;

        return true;
    }
}

public enum StatFormula : byte
{
    Health,
    Mana,
    Weight,
    Stat
}

public enum Stat : byte
{
    MinAC = 0,
    MaxAC = 1,
    MinMAC = 2,
    MaxMAC = 3,
    MinDC = 4,
    MaxDC = 5,
    MinMC = 6,
    MaxMC = 7,
    MinSC = 8,
    MaxSC = 9,

    Accuracy = 10,
    Agility = 11,
    HP = 12,
    MP = 13,
    AttackSpeed = 14,
    Luck = 15,
    BagWeight = 16,
    HandWeight = 17,
    WearWeight = 18,
    Reflect = 19,
    Strong = 20,
    Holy = 21,
    Freezing = 22,
    PoisonAttack = 23,

    MagicResist = 30,
    PoisonResist = 31,
    HealthRecovery = 32,
    SpellRecovery = 33,
    PoisonRecovery = 34, //TODO - Should this be in seconds or milliseconds??
    CriticalRate = 35,
    CriticalDamage = 36,

    MaxACRatePercent = 40,
    MaxMACRatePercent = 41,
    MaxDCRatePercent = 42,
    MaxMCRatePercent = 43,
    MaxSCRatePercent = 44,
    AttackSpeedRatePercent = 45,
    HPRatePercent = 46,
    MPRatePercent = 47,
    HPDrainRatePercent = 48,

    ExpRatePercent = 100,
    ItemDropRatePercent = 101,
    GoldDropRatePercent = 102,
    MineRatePercent = 103,
    GemRatePercent = 104,
    FishRatePercent = 105,
    CraftRatePercent = 106,
    SkillGainMultiplier = 107,
    AttackBonus = 108,

    LoverExpRatePercent = 120,
    MentorDamageRatePercent = 121,
    MentorExpRatePercent = 123,
    DamageReductionPercent = 124,
    EnergyShieldPercent = 125,
    EnergyShieldHPGain = 126,
    ManaPenaltyPercent = 127,
    TeleportManaPenaltyPercent = 128,
    Hero = 129,

    Unknown = 255
}

public static class StatExtensions
{
    public static string GetDescription(this Stat e)
    {
        switch (e)
        {
            case Stat.MinAC: return "防御下限";
            case Stat.MaxAC: return "防御上限";
            case Stat.MinMAC: return "魔法防御下限";
            case Stat.MaxMAC: return "魔法防御上限";
            case Stat.MinDC: return "攻击下限";
            case Stat.MaxDC: return "攻击上限";
            case Stat.MinMC: return "魔法下限";
            case Stat.MaxMC: return "魔法上限";
            case Stat.MinSC: return "道术下限";
            case Stat.MaxSC: return "道术上限";

            case Stat.Accuracy: return "准确";
            case Stat.Agility: return "敏捷";
            case Stat.HP: return "生命值";
            case Stat.MP: return "魔法值";
            case Stat.AttackSpeed: return "攻击速度";
            case Stat.Luck: return "幸运";
            case Stat.BagWeight: return "背包负重";
            case Stat.HandWeight: return "腕力";
            case Stat.WearWeight: return "装备负重";
            case Stat.Reflect: return "反弹";
            case Stat.Strong: return "Strong";
            case Stat.Holy: return "神圣";
            case Stat.Freezing: return "冰冻";
            case Stat.PoisonAttack: return "毒素攻击";

            case Stat.MagicResist: return "魔法抗性";
            case Stat.PoisonResist: return "毒素抗性";
            case Stat.HealthRecovery: return "生命恢复";
            case Stat.SpellRecovery: return "魔法恢复";
            case Stat.PoisonRecovery: return "中毒恢复";
            case Stat.CriticalRate: return "暴击率";
            case Stat.CriticalDamage: return "暴击伤害";

            case Stat.MaxACRatePercent: return "防御上限";
            case Stat.MaxMACRatePercent: return "魔御上限";
            case Stat.MaxDCRatePercent: return "攻击上限";
            case Stat.MaxMCRatePercent: return "魔法上限";
            case Stat.MaxSCRatePercent: return "道术上限";
            case Stat.AttackSpeedRatePercent: return "攻击速度";
            case Stat.HPRatePercent: return "生命值";
            case Stat.MPRatePercent: return "魔法值";
            case Stat.HPDrainRatePercent: return "生命恢复";

            case Stat.ExpRatePercent: return "经验";
            case Stat.ItemDropRatePercent: return "爆率";
            case Stat.GoldDropRatePercent: return "金币";
            case Stat.MineRatePercent: return "挖矿";
            case Stat.GemRatePercent: return "宝石";
            case Stat.FishRatePercent: return "钓鱼";
            case Stat.CraftRatePercent: return "制作";
            case Stat.SkillGainMultiplier: return "技能熟练度";
            case Stat.AttackBonus: return "攻击";

            case Stat.LoverExpRatePercent: return "夫妻经验";
            case Stat.MentorDamageRatePercent: return "导师伤害";
            case Stat.MentorExpRatePercent: return "导师经验";
            case Stat.DamageReductionPercent: return "伤害减免";
            case Stat.EnergyShieldPercent: return "能量护盾";
            case Stat.EnergyShieldHPGain: return "能量护盾恢复";
            case Stat.ManaPenaltyPercent: return "魔法消耗";
            case Stat.TeleportManaPenaltyPercent: return "传送魔法消耗";
            case Stat.Hero: return "英雄";
            default:
                return "";
        }
    }
}
