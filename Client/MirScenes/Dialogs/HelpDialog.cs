using Client.MirControls;
using Client.MirGraphics;
using Client.MirSounds;

namespace Client.MirScenes.Dialogs
{
    public sealed class HelpDialog : MirImageControl
    {
        public List<HelpPage> Pages = new List<HelpPage>();

        public MirButton CloseButton, NextButton, PreviousButton;
        public MirLabel PageLabel;
        public HelpPage CurrentPage;

        public int CurrentPageNumber = 0;

        public HelpDialog()
        {
            Index = 920;
            Library = Libraries.Prguse;
            Movable = true;
            Sort = true;

            Location = Center;

            MirImageControl TitleLabel = new MirImageControl
            {
                Index = 57,
                Library = Libraries.Title,
                Location = new Point(18, 9),
                Parent = this
            };

            PreviousButton = new MirButton
            {
                Index = 240,
                HoverIndex = 241,
                PressedIndex = 242,
                Library = Libraries.Prguse2,
                Parent = this,
                Size = new Size(16, 16),
                Location = new Point(210, 485),
                Sound = SoundList.ButtonA,
            };
            PreviousButton.Click += (o, e) =>
            {
                CurrentPageNumber--;

                if (CurrentPageNumber < 0) CurrentPageNumber = Pages.Count - 1;

                DisplayPage(CurrentPageNumber);
            };

            NextButton = new MirButton
            {
                Index = 243,
                HoverIndex = 244,
                PressedIndex = 245,
                Library = Libraries.Prguse2,
                Parent = this,
                Size = new Size(16, 16),
                Location = new Point(310, 485),
                Sound = SoundList.ButtonA,
            };
            NextButton.Click += (o, e) =>
            {
                CurrentPageNumber++;

                if (CurrentPageNumber > Pages.Count - 1) CurrentPageNumber = 0;

                DisplayPage(CurrentPageNumber);
            };

            PageLabel = new MirLabel
            {
                Text = "",
                Font = new Font(Settings.FontName, 9F),
                DrawFormat = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
                Parent = this,
                NotControl = true,
                Location = new Point(230, 480),
                Size = new Size(80, 20)
            };

            CloseButton = new MirButton
            {
                HoverIndex = 361,
                Index = 360,
                Location = new Point(509, 3),
                Library = Libraries.Prguse2,
                Parent = this,
                PressedIndex = 362,
                Sound = SoundList.ButtonA,
            };
            CloseButton.Click += (o, e) => Hide();

            LoadImagePages();

            DisplayPage();
        }

        private void LoadImagePages()
        {
            Point location = new Point(12, 35);

            Dictionary<string, string> keybinds = new Dictionary<string, string>();

            List<HelpPage> imagePages = new List<HelpPage> {
                new HelpPage("快捷键", -1, new ShortcutPage1 { Parent = this } ) { Parent = this, Location = location, Visible = false },
                new HelpPage("快捷键", -1, new ShortcutPage2 { Parent = this } ) { Parent = this, Location = location, Visible = false },
                new HelpPage("聊天快捷键", -1, new ShortcutPage3 { Parent = this } ) { Parent = this, Location = location, Visible = false },
                new HelpPage("移动", 0, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("攻击", 1, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("Collecting Items", 2, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("生命", 3, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("技能", 4, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("技能", 5, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("魔法", 6, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("聊天", 7, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("组队", 8, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("持久", 9, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("购买", 10, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("出售", 11, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("修理", 12, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("交易", 13, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("鉴定", 14, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("统计", 15, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("统计", 16, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("统计", 17, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("统计", 18, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("统计", 19, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("统计", 20, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("任务", 21, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("任务", 22, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("任务", 23, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("任务", 24, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("坐骑", 25, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("坐骑", 26, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("钓鱼", 27, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("宝石和宝珠", 28, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("英雄", 29, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("英雄", 30, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("英雄", 31, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("英雄", 32, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("英雄", 33, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("工会BUFF", 34, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("工会BUFF", 35, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("工会BUFF", 36, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("觉醒", 37, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("觉醒", 38, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("觉醒", 39, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("觉醒", 40, null) { Parent = this, Location = location, Visible = false },
                new HelpPage("觉醒", 41, null) { Parent = this, Location = location, Visible = false },
            };

            Pages.AddRange(imagePages);
        }


        public void DisplayPage(string pageName)
        {
            if (Pages.Count < 1) return;

            for (int i = 0; i < Pages.Count; i++)
            {
                if (Pages[i].Title.ToLower() != pageName.ToLower()) continue;

                DisplayPage(i);
                break;
            }
        }

        public void DisplayPage(int id = 0)
        {
            if (Pages.Count < 1) return;

            if (id > Pages.Count - 1) id = Pages.Count - 1;
            if (id < 0) id = 0;

            if (CurrentPage != null)
            {
                CurrentPage.Visible = false;
                if (CurrentPage.Page != null) CurrentPage.Page.Visible = false;
            }

            CurrentPage = Pages[id];

            if (CurrentPage == null) return;

            CurrentPage.Visible = true;
            if (CurrentPage.Page != null) CurrentPage.Page.Visible = true;
            CurrentPageNumber = id;

            CurrentPage.PageTitleLabel.Text = id + 1 + ". " + CurrentPage.Title;

            PageLabel.Text = string.Format("{0} / {1}", id + 1, Pages.Count);

            Show();
        }


        public void Toggle()
        {
            if (!Visible)
                Show();
            else
                Hide();
        }
    }

    public class ShortcutPage1 : ShortcutInfoPage
    {
        public ShortcutPage1()
        {
            Shortcuts = new List<ShortcutInfo>
            {
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Exit), "退出游戏"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Logout), "Log out"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Bar1Skill1) + "-" + CMain.InputKeys.GetKey(KeybindOptions.Bar1Skill8), "技能按键"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Inventory), "背包 (打开 / 关闭)"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Equipment), "状态面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Skills), "技能面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Group), "组队面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Trade), "交易面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Friends), "好友面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Minimap), "小地图面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Guilds), "行会面板"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.GameShop), "商城面板"),
                //Shortcuts.Add(new ShortcutInfo("K", "Rental window (open / close)"));
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Relationship), "婚恋"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Belt), "Belt window (open / close)"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Options), "选项"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Help), "帮助"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Mount), "坐骑"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.TargetSpellLockOn), "法术锁定")
            };

            LoadKeyBinds();
        }
    }
    public class ShortcutPage2 : ShortcutInfoPage
    {
        public ShortcutPage2()
        {
            Shortcuts = new List<ShortcutInfo>
            {
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.ChangePetmode), "切换宠物攻击模式"),
                //Shortcuts.Add(new ShortcutInfo("Ctrl + F", "Change the font in the chat box"));
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.ChangeAttackmode), "切换攻击模式"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.AttackmodePeace), "和平模式 - 仅攻击怪物"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.AttackmodeGroup), "组队模式 - 攻击除队友以外的对象"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.AttackmodeGuild), "行会模式 - 攻击除行会成员以外的对象"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.AttackmodeRedbrown), "善恶模式 - 攻击PK玩家及怪物"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.AttackmodeAll), "全体攻击模式 - 攻击所有对象"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Bigmap), "显示地图"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Skillbar), "显示技能栏"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Autorun), "自动奔跑"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Cameramode), "显示 / 隐藏 界面UI"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Pickup), "高亮 / 拾取 物品"),
                new ShortcutInfo("Ctrl + 右击", "显示其他玩家装备"),
                //Shortcuts.Add(new ShortcutInfo("F12", "Chat macros"));
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Screenshot), "截屏"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Fishing), "钓鱼"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.Mentor), "师徒"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.CreaturePickup), "灵物自动拾取 (Multi Mouse Target)"),
                new ShortcutInfo(CMain.InputKeys.GetKey(KeybindOptions.CreatureAutoPickup), "灵物自动拾取 (Single Mouse Target)")
            };

            LoadKeyBinds();
        }
    }
    public class ShortcutPage3 : ShortcutInfoPage
    {
        public ShortcutPage3()
        {
            Shortcuts = new List<ShortcutInfo>
            {
                //Shortcuts.Add(new ShortcutInfo("` / Ctrl", "Change the skill bar"));
                new ShortcutInfo("/(username)", "发送私聊"),
                new ShortcutInfo("!(text)", "发送给附近的玩家"),
                new ShortcutInfo("!~(text)", "行会聊天")
            };

            LoadKeyBinds();
        }
    }

    public class ShortcutInfo
    {
        public string Shortcut { get; set; }
        public string Information { get; set; }

        public ShortcutInfo(string shortcut, string info)
        {
            Shortcut = shortcut.Replace("\n", " + ");
            Information = info;
        }
    }

    public class ShortcutInfoPage : MirControl
    {
        protected List<ShortcutInfo> Shortcuts = new List<ShortcutInfo>();

        public ShortcutInfoPage()
        {
            Visible = false;

            MirLabel shortcutTitleLabel = new MirLabel
            {
                Text = "快捷键",
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                ForeColour = Color.White,
                Font = new Font(Settings.FontName, 10F),
                Parent = this,
                AutoSize = true,
                Location = new Point(13, 75),
                Size = new Size(100, 30)
            };

            MirLabel infoTitleLabel = new MirLabel
            {
                Text = "功能",
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                ForeColour = Color.White,
                Font = new Font(Settings.FontName, 10F),
                Parent = this,
                AutoSize = true,
                Location = new Point(114, 75),
                Size = new Size(405, 30)
            };
        }

        public void LoadKeyBinds()
        {
            if (Shortcuts == null) return;

            for (int i = 0; i < Shortcuts.Count; i++)
            {
                MirLabel shortcutLabel = new MirLabel
                {
                    Text = Shortcuts[i].Shortcut,
                    ForeColour = Color.Yellow,
                    DrawFormat = TextFormatFlags.VerticalCenter,
                    Font = new Font(Settings.FontName, 9F),
                    Parent = this,
                    AutoSize = true,
                    Location = new Point(18, 107 + (20 * i)),
                    Size = new Size(95, 23),
                };

                MirLabel informationLabel = new MirLabel
                {
                    Text = Shortcuts[i].Information,
                    DrawFormat = TextFormatFlags.VerticalCenter,
                    ForeColour = Color.White,
                    Font = new Font(Settings.FontName, 9F),
                    Parent = this,
                    AutoSize = true,
                    Location = new Point(119, 107 + (20 * i)),
                    Size = new Size(400, 23),
                };
            }
        }
    }

    public class HelpPage : MirControl
    {
        public string Title;
        public int ImageID;
        public MirControl Page;

        public MirLabel PageTitleLabel;

        public HelpPage(string title, int imageID, MirControl page)
        {
            Title = title;
            ImageID = imageID;
            Page = page;

            NotControl = true;
            Size = new System.Drawing.Size(508, 396 + 40);

            BeforeDraw += HelpPage_BeforeDraw;

            PageTitleLabel = new MirLabel
            {
                Text = Title,
                Font = new Font(Settings.FontName, 10F, FontStyle.Bold),
                DrawFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter,
                Parent = this,
                Size = new System.Drawing.Size(242, 30),
                Location = new Point(135, 4)
            };
        }

        void HelpPage_BeforeDraw(object sender, EventArgs e)
        {
            if (ImageID < 0) return;

            Libraries.Help.Draw(ImageID, new Point(DisplayLocation.X, DisplayLocation.Y + 40), Color.White, false);
        }
    }
}
