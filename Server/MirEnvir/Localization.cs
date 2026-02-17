using ClientPackets;
using Server.Library.MirDatabase;
using Server.Library.Utils;
using Server.MirDatabase;
using Server.MirNetwork;
using Server.MirObjects;
using Server.MirObjects.Monsters;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text.RegularExpressions;
using S = ServerPackets;

namespace Server.MirEnvir
{
    public class Localization
    {
        public static void 读取汉化(MessageQueue MessageQueue, List<ItemInfo> ItemInfoList, List<MonsterInfo> MonsterInfoList, List<QuestInfo> QuestInfoList, List<NPCInfo> NPCInfoList, List<MapInfo> MapInfoList)
        {
            string ItemCnCSVPath = Path.Combine(".", "物品汉化.csv");
            // 加载汉化物品列表
            var ItemInfoCNList = new List<ItemInfo>();
            if (File.Exists(ItemCnCSVPath))
            {
                var ItemCnRows = File.ReadAllLines(ItemCnCSVPath);
                var ItemCnColumns = ItemCnRows[0].Split(',');
                for (int i = 1; i < ItemCnRows.Length; i++)
                {
                    var row = ItemCnRows[i];
                    var cells = row.Split(',');
                    if (cells.Length == 0) break;
                    var itemCN = new ItemInfo();
                    itemCN.Name = cells[0];
                    itemCN.NameLocale = cells[1].Trim();
                    itemCN.ToolTip = cells[20].Trim().Replace("\\r\\n", "\r\n");
                    ItemInfoCNList.Add(itemCN);
                }
                // MessageQueue.Enqueue($"从物品汉化CSV文件 {ItemCnCSVPath} 加载 {ItemInfoCNList.Count} 个汉化物品");
            }

            // 处理汉化物品
            if (ItemInfoCNList.Count > 0)
            {
                var c = 0;
                for (var i = 0; i < ItemInfoList.Count; i++)
                {
                    if (i >= ItemInfoCNList.Count) break;
                    if (!ItemInfoList[i].Name.Equals(ItemInfoCNList[i].Name))
                    {
                        MessageQueue.Enqueue($"数据库中物品名与CSV中的名称不符，将使用数据库英文名 (Index = {i}. 数据库名称 = {ItemInfoList[i].Name} CSV中名称 = {ItemInfoCNList[i].Name})");
                        ItemInfoList[i].NameLocale = ItemInfoList[i].Name;
                    }
                    else
                    {
                        c++;
                        ItemInfoList[i].NameLocale = ItemInfoCNList[i].NameLocale.Trim();
                        ItemInfoList[i].ToolTip = ItemInfoCNList[i].ToolTip;
                    }
                }
                MessageQueue.Enqueue($"已汉化物品 {c} / {ItemInfoList.Count}");
            }
            ItemInfoCNList.Clear();

            // 加载汉化怪物列表
            string MonsterCnCSVPath = Path.Combine(".", "怪物汉化.csv");
            var MonsterCNList = new List<MonsterInfo>();
            if (File.Exists(MonsterCnCSVPath))
            {
                var Rows = File.ReadAllLines(MonsterCnCSVPath);
                for (int i = 1; i < Rows.Length; i++)
                {
                    var row = Rows[i];
                    var cells = row.Split(',');
                    if (cells.Length == 0) break;
                    var cn = new MonsterInfo();
                    cn.Name = cells[0];
                    cn.NameLocale = cells[1];
                    MonsterCNList.Add(cn);
                }
                // MessageQueue.Enqueue($"从怪物汉化CSV文件 {MonsterCnCSVPath} 加载 {MonsterCNList.Count} 个汉化怪物");
            }
            if (MonsterCNList.Count > 0)
            {
                var c = 0;
                for (var i = 0; i < MonsterInfoList.Count; i++)
                {
                    if (i >= MonsterCNList.Count) break;
                    if (!MonsterInfoList[i].Name.Equals(MonsterCNList[i].Name))
                    {
                        MessageQueue.Enqueue($"数据库中怪物名与CSV中的名称不符，将使用数据库英文名 (Index = {i}. 数据库名称 = {MonsterInfoList[i].Name} CSV中名称 = {MonsterCNList[i].Name})");
                        MonsterInfoList[i].NameLocale = MonsterInfoList[i].Name;
                    }
                    else
                    {
                        c++;
                        MonsterInfoList[i].NameLocale = MonsterCNList[i].NameLocale.Trim();
                    }
                }
                MessageQueue.Enqueue($"已汉化怪物 {c} / {MonsterInfoList.Count}");
            }
            MonsterCNList.Clear();

            string QuestCnCSVPath = Path.Combine(".", "任务汉化.csv");
            var QuestCNList = new List<QuestInfo>();
            if (File.Exists(QuestCnCSVPath))
            {
                var Rows = File.ReadAllLines(QuestCnCSVPath);
                for (int i = 1; i < Rows.Length; i++)
                {
                    var row = Rows[i];
                    var cells = row.Split(',');
                    if (cells.Length == 0) break;
                    var cn = new QuestInfo();
                    cn.Name = cells[0];
                    cn.NameLocale = cells[1];
                    cn.GotoMessage = cells[5];
                    cn.KillMessage = cells[6];
                    cn.ItemMessage = cells[7];
                    cn.FlagMessage = cells[8];
                    QuestCNList.Add(cn);
                }
                // MessageQueue.Enqueue($"从任务汉化CSV文件 {QuestCnCSVPath} 加载 {QuestCNList.Count} 个汉化任务");
            }
            if (QuestCNList.Count > 0)
            {
                var c = 0;
                for (var i = 0; i < QuestInfoList.Count; i++)
                {
                    if (i >= QuestCNList.Count) break;
                    if (!QuestInfoList[i].Name.Equals(QuestCNList[i].Name))
                    {
                        MessageQueue.Enqueue($"数据库中任务名与CSV中的名称不符，将使用数据库名 (Index = {i}. 数据库名称 = {QuestInfoList[i].Name} CSV中名称 = {QuestCNList[i].Name})");
                    }
                    else
                    {
                        c++;
                        QuestInfoList[i].NameLocale = QuestCNList[i].NameLocale.Trim();
                        QuestInfoList[i].GotoMessage = QuestCNList[i].GotoMessage.Trim();
                        QuestInfoList[i].KillMessage = QuestCNList[i].KillMessage.Trim();
                        QuestInfoList[i].ItemMessage = QuestCNList[i].ItemMessage.Trim();
                        QuestInfoList[i].FlagMessage = QuestCNList[i].FlagMessage.Trim();
                    }
                }
                MessageQueue.Enqueue($"已汉化任务 {c} / {QuestInfoList.Count}");
            }
            QuestCNList.Clear();

            // 加载汉化NPC列表
            string NpcCnCSVPath = Path.Combine(".", "NPC汉化.csv");
            var NpcCNList = new List<NPCInfo>();
            if (File.Exists(NpcCnCSVPath))
            {
                var Rows = File.ReadAllLines(NpcCnCSVPath);
                for (int i = 1; i < Rows.Length; i++)
                {
                    var row = Rows[i];
                    var cells = row.Split(',');
                    if (cells.Length == 0) break;
                    var cn = new NPCInfo();
                    cn.Name = cells[4];
                    // ZZ NPC汉化
                    cn.NameLocale = cells[5];
                    NpcCNList.Add(cn);
                }
                // MessageQueue.Enqueue($"从NPC汉化CSV文件 {NpcCnCSVPath} 加载 {NpcCNList.Count} 个汉化NPC");
            }
            if (NpcCNList.Count > 0)
            {
                var c = 0;
                for (var i = 0; i < NPCInfoList.Count; i++)
                {
                    if (i >= NpcCNList.Count) break;
                    if (!NPCInfoList[i].Name.Equals(NpcCNList[i].Name))
                    {
                        MessageQueue.Enqueue($"数据库中NPC名与CSV中的名称不符，将使用数据库名 (Index = {i}. 数据库名称 = {NPCInfoList[i].Name} CSV中名称 = {NpcCNList[i].Name})");
                    }
                    else
                    {
                        c++;
                        // ZZ NPC汉化
                        NPCInfoList[i].NameLocale = NpcCNList[i].NameLocale.Trim();
                    }
                }
                MessageQueue.Enqueue($"已汉化NPC {c} / {NPCInfoList.Count}");
            }
            NpcCNList.Clear();

            // 地图汉化
            string MapCnCSVPath = Path.Combine(".", "地图汉化.csv");
            var MapCNList = new List<MapInfo>();
            if (File.Exists(MapCnCSVPath))
            {
                var Rows = File.ReadAllLines(MapCnCSVPath);
                for (int i = 1; i < Rows.Length; i++)
                {
                    var row = Rows[i];
                    var cells = row.Split(',');
                    if (cells.Length == 0) break;
                    var cn = new MapInfo();
                    cn.Title = cells[0];
                    cn.TitleLocale = cells[1];
                    MapCNList.Add(cn);
                }
                // MessageQueue.Enqueue($"从地图汉化CSV文件 {MapCnCSVPath} 加载 {MapCNList.Count} 个汉化地图");
            }
            if (MapCNList.Count > 0)
            {
                var c = 0;
                for (var i = 0; i < MapInfoList.Count; i++)
                {
                    if (i >= MapCNList.Count) break;
                    if (!MapInfoList[i].Title.Equals(MapCNList[i].Title))
                    {
                        MessageQueue.Enqueue($"数据库中地图名与CSV中的名称不符，将使用数据库名 (Index = {i}. 数据库名称 = {MapInfoList[i].Title} CSV中名称 = {MapCNList[i].Title})");
                    }
                    else
                    {
                        c++;
                        MapInfoList[i].TitleLocale = MapCNList[i].TitleLocale.Trim();
                    }
                }
                MessageQueue.Enqueue($"已汉化地图 {c} / {MapInfoList.Count}");
            }
            MapCNList.Clear();
        }
    }
}
