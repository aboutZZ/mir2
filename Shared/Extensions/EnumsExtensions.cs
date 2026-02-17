public static class EnumsExtensions
{
    public static string GetDescription(this MirClass e)
    {
        switch (e)
        {
            case MirClass.Warrior: return "战士";
            case MirClass.Wizard: return "法师";
            case MirClass.Taoist: return "道士";
            case MirClass.Assassin: return "刺客";
            case MirClass.Archer: return "弓箭手";
            default:
                return "";
        }
    }

    public static string GetDescription(this Spell e)
    {
        switch (e)
        {
            case Spell.None: return "无";

            // Warrior
            case Spell.Fencing: return "基本剑术";
            case Spell.Slaying: return "攻杀剑术";
            case Spell.Thrusting: return "刺杀剑术";
            case Spell.HalfMoon: return "半月弯刀";
            case Spell.ShoulderDash: return "野蛮冲撞";
            case Spell.TwinDrakeBlade: return "双龙斩";
            case Spell.Entrapment: return "捕蝇剑";
            case Spell.FlamingSword: return "烈火剑法";
            case Spell.LionRoar: return "狮子吼";
            case Spell.CrossHalfMoon: return "十字狂风斩";
            case Spell.BladeAvalanche: return "剑刃风暴";
            case Spell.ProtectionField: return "护体真气";
            case Spell.Rage: return "剑气爆";
            case Spell.CounterAttack: return "血龙剑法";
            case Spell.SlashingBurst: return "日闪";
            // 翻译 Fury狂暴
            case Spell.Fury: return "狂暴";
            case Spell.ImmortalSkin: return "金刚不坏";

            // Wizard
            case Spell.FireBall: return "火球术";
            case Spell.Repulsion: return "抗拒火环";
            case Spell.ElectricShock: return "诱惑之光";
            case Spell.GreatFireBall: return "大火球";
            case Spell.HellFire: return "地狱火";
            case Spell.ThunderBolt: return "雷电术"; // 用闪电攻击敌人，造成高额伤害
            case Spell.Teleport: return "瞬息移动";
            case Spell.FireBang: return "爆裂火焰";
            case Spell.FireWall: return "火墙";
            case Spell.Lightning: return "疾光电影"; // 射出一道闪电攻击前方的怪物
            case Spell.FrostCrunch: return "寒冰掌";
            // TODO ZZ 待翻译 ThunderStorm 该技能会在指定区域产生雷暴攻击怪物。
            case Spell.ThunderStorm: return "地狱雷光";
            case Spell.MagicShield: return "魔法盾";
            case Spell.TurnUndead: return "圣言术";
            case Spell.Vampirism: return "嗜血术";
            case Spell.IceStorm: return "冰咆哮";
            case Spell.FlameDisruptor: return "灭天火";
            case Spell.Mirroring: return "分身术";
            case Spell.FlameField: return "火龙气焰";
            case Spell.Blizzard: return "暴风雪"; // 或者叫 天霜冰环
            case Spell.MagicBooster: return "深延术";
            case Spell.MeteorStrike: return "流星火雨";
            case Spell.IceThrust: return "冰刺";
            case Spell.FastMove: return "FastMove";
            case Spell.StormEscape: return "雷仙风";

            // Taoist
            case Spell.Healing: return "治愈术";
            case Spell.SpiritSword: return "精神力战法";
            case Spell.Poisoning: return "施毒术";
            case Spell.SoulFireBall: return "灵魂火符";
            case Spell.SummonSkeleton: return "召唤骷髅";
            case Spell.Hiding: return "隐身术";
            case Spell.MassHiding: return "群体隐身术";
            case Spell.SoulShield: return "幽灵盾";
            case Spell.Revelation: return "心灵启示";
            case Spell.BlessedArmour: return "神圣战甲术";
            case Spell.EnergyRepulsor: return "气功波";
            case Spell.TrapHexagon: return "困魔咒";
            case Spell.Purification: return "净化术";
            case Spell.MassHealing: return "群体治疗术";
            case Spell.Hallucination: return "迷魂术";
            case Spell.UltimateEnhancer: return "无极真气";
            case Spell.SummonShinsu: return "召唤神兽";
            case Spell.Reincarnation: return "转生术";
            case Spell.SummonHolyDeva: return "召唤月灵";
            case Spell.Curse: return "诅咒术";
            case Spell.Plague: return "瘟疫";
            case Spell.PoisonCloud: return "毒雾";
            case Spell.EnergyShield: return "先天气功";
            case Spell.PetEnhancer: return "血龙水";
            case Spell.HealingCircle: return "阴阳五行阵";

            // Assassin
            case Spell.FatalSword: return "绝命剑法";
            case Spell.DoubleSlash: return "风剑术";
            case Spell.Haste: return "体迅风";
            case Spell.FlashDash: return "拔刀术";
            case Spell.LightBody: return "风身术";
            case Spell.HeavenlySword: return "迁移剑";
            case Spell.FireBurst: return "烈风击";
            case Spell.Trap: return "捕缚术";
            case Spell.PoisonSword: return "猛毒剑气";
            case Spell.MoonLight: return "月影术";
            case Spell.MPEater: return "魔法汲取";
            case Spell.SwiftFeet: return "神行术";
            case Spell.DarkBody: return "暗影之身";
            case Spell.Hemorrhage: return "血风击";
            case Spell.CrescentSlash: return "月华乱舞";
            case Spell.MoonMist: return "月影雾";
            case Spell.CatTongue: return "猫舌兰";

            // Archer
            case Spell.Focus: return "必中闪";
            case Spell.StraightShot: return "天日闪";
            case Spell.DoubleShot: return "无我闪";
            case Spell.ExplosiveTrap: return "爆裂陷阱";
            case Spell.DelayedExplosion: return "延时爆裂陷阱";
            case Spell.Meditation: return "冥想";
            case Spell.BackStep: return "风弹步";
            // TODO ZZ 待翻译 ElementalShot元素射击
            case Spell.ElementalShot: return "元素射击";
            case Spell.Concentration: return "专注";
            case Spell.Stonetrap: return "石化陷阱";
            case Spell.ElementalBarrier: return "元素护盾";
            case Spell.SummonVampire: return "吸血地精";
            case Spell.VampireShot: return "吸血箭";
            case Spell.SummonToad: return "召唤毒蛙";
            case Spell.PoisonShot: return "毒箭";
            case Spell.CrippleShot: return "致残箭";
            case Spell.SummonSnakes: return "召唤毒蛇";
            case Spell.NapalmShot: return "火焰箭";
            case Spell.OneWithNature: return "自然之友";
            case Spell.BindingShot: return "束缚箭";
            case Spell.MentalState: return "精神集中";

            // Custom
            case Spell.Blink: return "闪烁";
            case Spell.Portal: return "传送";
            case Spell.BattleCry: return "战斗吼叫";
            case Spell.FireBounce: return "火焰弹跳";
            case Spell.MeteorShower: return "陨石流星";

            // Map Events
            // case Spell.DigOutZombie: return "挖出僵尸";
            // case Spell.Rubble: return "碎石";
            // case Spell.MapLightning: return "地图闪电";
            // case Spell.MapLava: return "地图岩浆";
            // case Spell.MapQuake1: return "地图震动1";
            // case Spell.MapQuake2: return "地图震动2";
            // case Spell.DigOutArmadillo: return "挖出犰狳";
            // case Spell.GeneralMeowMeowThunder: return "喵喵雷电";
            // case Spell.StoneGolemQuake: return "石像鬼震动";
            // case Spell.EarthGolemPile: return "土像鬼堆积";
            // case Spell.TreeQueenRoot: return "树女王根";
            // case Spell.TreeQueenMassRoots: return "树女王大量根";
            // case Spell.TreeQueenGroundRoots: return "树女王地面根";
            // case Spell.TucsonGeneralRock: return "土城将军岩石";
            // case Spell.FlyingStatueIceTornado: return "飞行雕像冰龙卷";
            // case Spell.DarkOmaKingNuke: return "黑暗王子核弹";
            // case Spell.HornedSorcererDustTornado: return "角魔法师沙尘暴";
            // case Spell.HornedCommanderRockFall: return "角指挥官岩石陨落";
            // case Spell.HornedCommanderRockSpike: return "角指挥官岩石尖刺";
            default:
                return e.ToString();
        }
    }
}
