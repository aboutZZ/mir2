using System;
using System.Collections.Generic;

namespace Client
{
    public class MirMarco
    {
        public static void LoadMarcoConfig(HashSet<string> ItemFilterNames)
        {
            var ItemFilterFilePath = Path.Combine(".", "物品显示过滤.ini");
            if (!File.Exists(ItemFilterFilePath)) return;
            {
                var Rows = File.ReadAllLines(ItemFilterFilePath);
                for (int i = 1; i < Rows.Length; i++)
                {
                    var row = Rows[i];
                    if (string.IsNullOrWhiteSpace(row)) continue;
                    if (row.StartsWith(";")) continue; // 跳过注释行
                    ItemFilterNames.Add(row);
                }
            }
        }
    }
}
