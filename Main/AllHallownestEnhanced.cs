using System;
using Modding;
using Vasi;
using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker.Actions;
using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;
using System.Runtime;
using static Modding.IMenuMod;
using Random = UnityEngine.Random;
using HutongGames.PlayMaker;
using System.Threading;
using UnityEngine.SceneManagement;
using AllHallownestEnhanced.Main;
using UnityEngine.UI;

namespace AllHallownestEnhanced
{
    public class Settings
    {
        public bool on = true;//总开关
        public bool EnhanceBOSS = true;//是否加强BOSS
        public bool EnhanceEnemy = true;//是否加强小怪
        public bool moreEnemy = true;//是否增加小怪
        public bool fastSuperdash = true;//0帧超冲
        public bool fastDreamDoor = true;//快速梦门

        public bool changeCharm = true;//改护符
        public bool originalHp = false;//是否恢复原版血量
        public bool enhanced_2Radiant = false;//二次加强福光

    }

    public class AllHallownestEnhanced : Mod, IGlobalSettings<Settings>, IMenuMod
    {
        #region 选项设置相关
        public static Settings settings_ = new Settings();
        public bool ToggleButtonInsideMenu => true;
        public void OnLoadGlobal(Settings settings) => settings_ = settings;
        public Settings OnSaveGlobal() => settings_;
        public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? menu)
        {
            List<IMenuMod.MenuEntry> menus = new List<IMenuMod.MenuEntry>();

            if (Language.Language.CurrentLanguage()==Language.LanguageCode.ZH)
            {
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "总开关",
                    Description = "切换场景生效",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.on = i == 0,
                    Loader = () => settings_.on ? 0 : 1,
                });

                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "加强所有BOSS",
                    Description = "切换场景生效",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.EnhanceBOSS = i == 0,
                    Loader = () => settings_.EnhanceBOSS ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "加强所有小怪",
                    Description = "切换场景生效",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.EnhanceEnemy = i == 0,
                    Loader = () => settings_.EnhanceEnemy ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "更多敌人",
                    Description = "切换场景生效",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.moreEnemy = i == 0,
                    Loader = () => settings_.moreEnemy ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "快速超冲",
                    Description = "切回菜单SL生效",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.fastSuperdash = i == 0,
                    Loader = () => settings_.fastSuperdash ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "快速梦门",
                    Description = "切回菜单SL生效",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.fastDreamDoor = i == 0,
                    Loader = () => settings_.fastDreamDoor ? 0 : 1,
                });

                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "神居BOSS恢复原版血量",
                    Description = "切换场景生效",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.originalHp = i == 0,
                    Loader = () => settings_.originalHp ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "!!二次加强无上福光!!",
                    Description = "切换场景生效",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.enhanced_2Radiant = i == 0,
                    Loader = () => settings_.enhanced_2Radiant ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "护符平衡",
                    Description = "切换场景生效",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.changeCharm = i == 0,
                    Loader = () => settings_.changeCharm ? 0 : 1,
                });
            }
            else
            {
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Main Switch",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.on = i == 0,
                    Loader = () => settings_.on ? 0 : 1,
                });

                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Strengthen All Boss",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.EnhanceBOSS = i == 0,
                    Loader = () => settings_.EnhanceBOSS ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Strengthen All Monsters",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.EnhanceEnemy = i == 0,
                    Loader = () => settings_.EnhanceEnemy ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Adding More Enemies",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.moreEnemy = i == 0,
                    Loader = () => settings_.moreEnemy ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Fast Superdash",
                    Description = "Switch to menu to take effect",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.fastSuperdash = i == 0,
                    Loader = () => settings_.fastSuperdash ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Fast Dreamdoor",
                    Description = "Switch to menu to take effect",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.fastDreamDoor = i == 0,
                    Loader = () => settings_.fastDreamDoor ? 0 : 1,
                });

                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "GG Boss Original HP",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                        {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                        },
                    Saver = i => settings_.originalHp = i == 0,
                    Loader = () => settings_.originalHp ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "!!More Difficult Radiance!!",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.enhanced_2Radiant = i == 0,
                    Loader = () => settings_.enhanced_2Radiant ? 0 : 1,
                });
                menus.Add(new IMenuMod.MenuEntry()
                {
                    Name = "Reduce the charmCost",
                    Description = "Switching scenes takes effect",
                    Values = new string[]
                    {
                    Language.Language.Get("MOH_ON", "MainMenu"),
                    Language.Language.Get("MOH_OFF", "MainMenu"),
                    },
                    Saver = i => settings_.changeCharm = i == 0,
                    Loader = () => settings_.changeCharm ? 0 : 1,
                });
            }


            return menus;
        }
        #endregion

        public override string GetVersion() => "2.5";

        public AllHallownestEnhanced() : base("AllHallownestEnhanced") { }

        public override List<(string, string)> GetPreloadNames()
        {
            return new List<(string, string)>
            {
                #region MyRegion
                ("Tutorial_01","_Enemies/Buzzer"),//反击蝇
                ("Crossroads_19","_Enemies/Spitter"),//十字路橙汁
                ("Crossroads_15","_Enemies/Zombie Shield"),//武器躯壳
                ("Crossroads_ShamanTemple","_Enemies/Roller"),//小滚滚
                ("Fungus1_02","Mosquito"),//苍绿蚊子
                ("Fungus1_09","Acid Flyer"),//苍绿飞刺虫
                ("Fungus1_12","Acid Walker"),//苍绿游刺虫
                ("Fungus2_03","Fungoon Baby"),//小真菌飘飘
                ("Fungus2_11","Fungus Flyer"),//大真菌飘飘
                ("Fungus2_12","Mantis Flyer Child"),//飞螳螂
                ("Fungus2_12","Mantis"),//螳螂
                ("Abyss_19","Parasite Balloon (1)"),//气球
                ("Mines_05","Cave Spikes (3)"),//水晶下劈刺
                ("Ruins1_17","Ruins Flying Sentry"),//泪城飞哥
                ("Ruins1_17","Ruins Flying Sentry Javelin"),//泪城箭哥
                ("Fungus3_44","Moss Flyer (1)"),//飞绿虫
                ("Fungus3_39","Moss Knight Fat"),//感染苔藓胖胖
                ("Fungus2_28","Mushroom Roller"),//中蘑菇哇哇
                ("Ruins2_01_b","Royal Zombie 1"),//富人
                ("Ruins2_01_b","Royal Zombie Coward"),//富老人
                ("Ruins2_01_b","Royal Zombie Fat"),//富胖人
                ("Mines_20","Crystallised Lazer Bug (3)"),//水晶激光虫
                ("Mines_20","Crystallised Lazer Bug (7)"),//水晶激光虫
                ("Waterways_04b","Inflater"),//下水道波波
                ("Fungus3_27","Jellyfish Baby"),//小水母
                ("Fungus3_27","Jellyfish"),//水母
                ("Abyss_17","Lesser Mawlek"),//小毛里克
                ("Deepnest_East_06","Hopper"),//小跳虫
                ("Deepnest_36","Grub Mimic Bottle"),//假虫子瓶
                ("Deepnest_36","Grub Mimic Top"),//假虫子
                ("Fungus3_39","Battle Scene/Mantis Heavy"),//走螳螂
                ("Hive_04","Big Bee (3)"),//胖蜜蜂
                ("Deepnest_39","Spider Flyer"),//飞蜘蛛
                #endregion
                #region MyRegion
                ("Ruins2_04","Great Shield Zombie"),//大盾哥
                ("Ruins_House_02","Gorgeous Husk/Shine"),//Shine
                ("Crossroads_01","Infected Parent/Angry Buzzer"),//感染反击蝇
                ("White_Palace_18","saw_collection/wp_saw"),//电锯
                ("White_Palace_07","wp_trap_spikes"),//缩刺
                ("White_Palace_06","White Palace Fly"),//翅膀傀儡
                ("GG_Hollow_Knight","Battle Scene/Focus Blasts/HK Prime Blast"),//星爆
                ("Crossroads_31","_Props/Cave Spikes"),//刺
                ("Fungus1_14","Zap Cloud"),//闪电
                ("Fungus2_23","Mushroom Turret"),//吐炸弹
                ("Fungus2_04","Mushroom Turret (3)"),//吐炸弹（小范围）
                ("Mines_07","Crystal Flyer"),//狙神
                ("Mines_29","Mines Platform"),//翻转平台
                ("Hive_01","Bee Hatchling Ambient"),//小蜜蜂
                ("Hive_01","Bee Stinger"),//电钻蜜蜂
                ("Hive_03_c","Big Bee"),//大蜜蜂
                ("Tutorial_01","_Props/Health Cocoon"),//生命茧
                ("Fungus3_34","Garden Zombie"),//花园刺虫
                ("RestingGrounds_10","Ceiling Dropper (1)"),//爆肚蝙
                ("Waterways_02","Fluke Fly"),//吸虫
                ("Ruins1_05c","Ruins Sentry Fat"),//泪城胖哥
                ("Deepnest_East_07","Super Spitter"),//古神
                ("Fungus3_22","Mantis Heavy Flyer"),//花园飞螳螂
	            #endregion
                ("Crossroads_37","Zombie Hornhead"),//冲刺躯壳
                ("Crossroads_37","Zombie Leaper"),//跳跃躯壳
                ("Crossroads_04","Infected Parent/Spitting Zombie"),//感染跳跳
                ("Crossroads_04","Infected Parent/Bursting Zombie"),//感染躯壳
                ("Fungus1_01","Mossman_Shaker"),//苔藓爆炸
                ("Fungus1_01","Mossman_Runner"),//苔藓冲刺
                ("Fungus1_01","Plant Trap"),//食人花
                ("Fungus1_19","_Enemies/Fat Fly"),//苍绿小波波
                ("Fungus2_10","Zombie Fungus A"),//真菌爆炸
                ("Fungus2_10","Zombie Fungus B"),//真菌爆炸
                ("Ruins1_01","Ruins Sentry 1"),//泪城小哥
                ("Ruins1_23","Mage Blob 2"),//错误
                ("Ruins1_32","Mage Balloon"),//愚蠢
                ("Mines_02","Zombie Miner 1"),//矿工
                ("Mines_02","Crystal Crawler"),//水晶胖虫
                ("Mines_23","Zombie Beam Miner"),//水晶激光虫
                ("Deepnest_East_03","Blow Fly"),//边缘大胖虫
                ("Deepnest_39","Slash Spider"),//面具哥
                ("Deepnest_Spider_Town","Slash Spider (2)"),//面具哥（左）
                ("Cliffs_02","Zombie Barger"),//躯壳
                ("Fungus1_11","Plant Turret (2)"),//吐绿球（右）
                ("White_Palace_18","Soul Totem white_Infinte"),//先辈雕像
                ("GG_Spa","RestBench (1)"),//神居椅子
                ("Fungus1_04_boss","Hornet Infected Knight Encounter"),//小姐姐NPC
                ("Mines_11","Mines Crawler"),//水晶尖刺虫
                ("Fungus3_25b","Jelly Egg Bomb"),//炸弹
                ("Tutorial_01","_Enemies/Crawler 1"),//小爬虫

            };
        }
        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            InitPreloadedObject(preloadedObjects);
            Add_GG_BOSS();//加强神居BOSS
            Add_Process_BOSS();//加强流程BOSS
            Add_Process_Enemy();//加强小怪
            Add_Enemy();//流程加怪
            GodSeeker_QOL();//神居QOL
            Process_QOL();//流程QOL
            Charm();//护符
        }

        //初始化游戏中要加载的GameObject
        public void InitPreloadedObject(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            #region MyRegion
            AddEnemyDic(preloadedObjects, "Tutorial_01", "_Enemies/Buzzer");//反击蝇
            AddEnemyDic(preloadedObjects, "Crossroads_19", "_Enemies/Spitter");//十字路橙汁
            AddEnemyDic(preloadedObjects, "Crossroads_15", "_Enemies/Zombie Shield");//武器躯壳
            AddEnemyDic(preloadedObjects, "Crossroads_ShamanTemple", "_Enemies/Roller");//小滚滚
            AddEnemyDic(preloadedObjects, "Fungus1_02", "Mosquito");//苍绿蚊子
            AddEnemyDic(preloadedObjects, "Fungus1_09", "Acid Flyer");//苍绿飞刺虫
            AddEnemyDic(preloadedObjects, "Fungus1_12", "Acid Walker");//苍绿游刺虫
            AddEnemyDic(preloadedObjects, "Fungus2_03", "Fungoon Baby");//小真菌飘飘
            AddEnemyDic(preloadedObjects, "Fungus2_11", "Fungus Flyer");//大真菌飘飘
            AddEnemyDic(preloadedObjects, "Fungus2_12", "Mantis Flyer Child");//飞螳螂
            AddEnemyDic(preloadedObjects, "Fungus2_12", "Mantis");//螳螂
            AddEnemyDic(preloadedObjects, "Abyss_19", "Parasite Balloon (1)");//气球
            AddEnemyDic(preloadedObjects, "Mines_05", "Cave Spikes (3)");//水晶下劈刺
            AddEnemyDic(preloadedObjects, "Ruins1_17", "Ruins Flying Sentry");//泪城飞哥
            AddEnemyDic(preloadedObjects, "Ruins1_17", "Ruins Flying Sentry Javelin");//泪城箭哥
            AddEnemyDic(preloadedObjects, "Fungus3_44", "Moss Flyer (1)");//飞绿虫
            AddEnemyDic(preloadedObjects, "Fungus3_39", "Moss Knight Fat");//感染苔藓胖胖
            AddEnemyDic(preloadedObjects, "Fungus2_28", "Mushroom Roller");//中蘑菇哇哇
            AddEnemyDic(preloadedObjects, "Ruins2_01_b", "Royal Zombie 1");//富人
            AddEnemyDic(preloadedObjects, "Ruins2_01_b", "Royal Zombie Coward");//富老人
            AddEnemyDic(preloadedObjects, "Ruins2_01_b", "Royal Zombie Fat");//富胖人
            AddEnemyDic(preloadedObjects, "Mines_20", "Crystallised Lazer Bug (3)");//水晶激光虫
            AddEnemyDic(preloadedObjects, "Mines_20", "Crystallised Lazer Bug (7)");//水晶激光虫
            AddEnemyDic(preloadedObjects, "Waterways_04b", "Inflater");//下水道波波
            AddEnemyDic(preloadedObjects, "Fungus3_27", "Jellyfish Baby");//小水母
            AddEnemyDic(preloadedObjects, "Fungus3_27", "Jellyfish");//水母
            AddEnemyDic(preloadedObjects, "Abyss_17", "Lesser Mawlek");//小毛里克
            AddEnemyDic(preloadedObjects, "Deepnest_East_06", "Hopper");//小跳虫
            AddEnemyDic(preloadedObjects, "Deepnest_36", "Grub Mimic Bottle");//假虫子瓶
            AddEnemyDic(preloadedObjects, "Deepnest_36", "Grub Mimic Top");//假虫子
            AddEnemyDic(preloadedObjects, "Fungus3_39", "Battle Scene/Mantis Heavy");//走螳螂
            AddEnemyDic(preloadedObjects, "Hive_04", "Big Bee (3)");//胖蜜蜂
            AddEnemyDic(preloadedObjects, "Deepnest_39", "Spider Flyer");//飞蜘蛛
            #endregion
            #region MyRegion
            AddEnemyDic(preloadedObjects, "Ruins2_04", "Great Shield Zombie");//大盾哥
            AddEnemyDic(preloadedObjects, "Ruins_House_02", "Gorgeous Husk/Shine");//Shine
            AddEnemyDic(preloadedObjects, "Crossroads_01", "Infected Parent/Angry Buzzer");//感染反击蝇
            AddEnemyDic(preloadedObjects, "White_Palace_18", "saw_collection/wp_saw");//电锯
            AddEnemyDic(preloadedObjects, "White_Palace_07", "wp_trap_spikes");//缩刺
            AddEnemyDic(preloadedObjects, "White_Palace_06", "White Palace Fly");//翅膀傀儡
            AddEnemyDic(preloadedObjects, "GG_Hollow_Knight", "Battle Scene/Focus Blasts/HK Prime Blast");//星爆
            AddEnemyDic(preloadedObjects, "Crossroads_31", "_Props/Cave Spikes");//刺
            AddEnemyDic(preloadedObjects, "Fungus1_14", "Zap Cloud");//闪电
            AddEnemyDic(preloadedObjects, "Fungus2_23", "Mushroom Turret");//吐炸弹
            AddEnemyDic(preloadedObjects, "Fungus2_04", "Mushroom Turret (3)");//吐炸弹
            AddEnemyDic(preloadedObjects, "Mines_07", "Crystal Flyer");//狙神
            AddEnemyDic(preloadedObjects, "Mines_29", "Mines Platform");//翻转平台
            AddEnemyDic(preloadedObjects, "Hive_01", "Bee Hatchling Ambient");//小蜜蜂
            AddEnemyDic(preloadedObjects, "Hive_01", "Bee Stinger");//电钻蜜蜂
            AddEnemyDic(preloadedObjects, "Hive_03_c", "Big Bee");//大蜜蜂
            AddEnemyDic(preloadedObjects, "Tutorial_01", "_Props/Health Cocoon");//生命茧
            AddEnemyDic(preloadedObjects, "Fungus3_34", "Garden Zombie");//花园刺虫
            AddEnemyDic(preloadedObjects, "RestingGrounds_10", "Ceiling Dropper (1)");//爆肚蝙
            AddEnemyDic(preloadedObjects, "Waterways_02", "Fluke Fly");//吸虫
            AddEnemyDic(preloadedObjects, "Ruins1_05c", "Ruins Sentry Fat");//胖哥
            AddEnemyDic(preloadedObjects, "Deepnest_East_07", "Super Spitter");//古神
            AddEnemyDic(preloadedObjects, "Fungus3_22", "Mantis Heavy Flyer");//花园飞螳螂
            #endregion
            AddEnemyDic(preloadedObjects, "Crossroads_37", "Zombie Hornhead");//冲刺躯壳
            AddEnemyDic(preloadedObjects, "Crossroads_37", "Zombie Leaper");//跳跃躯壳
            AddEnemyDic(preloadedObjects, "Crossroads_04", "Infected Parent/Spitting Zombie");//感染跳跳
            AddEnemyDic(preloadedObjects, "Crossroads_04", "Infected Parent/Bursting Zombie");//感染躯壳
            AddEnemyDic(preloadedObjects, "Fungus1_01", "Mossman_Shaker");//苔藓爆炸
            AddEnemyDic(preloadedObjects, "Fungus1_01", "Mossman_Runner");//苔藓冲刺
            AddEnemyDic(preloadedObjects, "Fungus1_01", "Plant Trap");//食人花(y+1.1)
            AddEnemyDic(preloadedObjects, "Fungus1_19", "_Enemies/Fat Fly");//苍绿小波波
            AddEnemyDic(preloadedObjects, "Fungus2_10", "Zombie Fungus A");//真菌爆炸
            AddEnemyDic(preloadedObjects, "Fungus2_10", "Zombie Fungus B");//真菌爆炸
            AddEnemyDic(preloadedObjects, "Ruins1_01", "Ruins Sentry 1");//泪城小哥
            AddEnemyDic(preloadedObjects, "Ruins1_23", "Mage Blob 2");//错误
            AddEnemyDic(preloadedObjects, "Ruins1_32", "Mage Balloon");//愚蠢
            AddEnemyDic(preloadedObjects, "Mines_02", "Zombie Miner 1");//矿工
            AddEnemyDic(preloadedObjects, "Mines_02", "Crystal Crawler");//水晶胖虫
            AddEnemyDic(preloadedObjects, "Mines_23", "Zombie Beam Miner");//水晶激光虫
            AddEnemyDic(preloadedObjects, "Deepnest_East_03", "Blow Fly");//边缘大胖虫
            AddEnemyDic(preloadedObjects, "Deepnest_39", "Slash Spider");//面具哥
            AddEnemyDic(preloadedObjects, "Deepnest_Spider_Town", "Slash Spider (2)");//面具哥（左）
            AddEnemyDic(preloadedObjects, "Cliffs_02", "Zombie Barger");//躯壳
            AddEnemyDic(preloadedObjects, "Fungus1_11", "Plant Turret (2)");//吐绿球（右）
            AddEnemyDic(preloadedObjects, "White_Palace_18", "Soul Totem white_Infinte");//先辈雕像
            AddEnemyDic(preloadedObjects, "GG_Spa", "RestBench (1)");//神居椅子
            AddEnemyDic(preloadedObjects, "Fungus1_04_boss", "Hornet Infected Knight Encounter");//小姐姐NPC
            AddEnemyDic(preloadedObjects, "Mines_11", "Mines Crawler");//水晶尖刺虫
            AddEnemyDic(preloadedObjects, "Fungus3_25b", "Jelly Egg Bomb");//炸弹
            AddEnemyDic(preloadedObjects, "Tutorial_01", "_Enemies/Crawler 1");//小爬虫

        }

        //拿到某个场景中的某个敌人，并将其放到enemyDic中
        public void AddEnemyDic(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects, string sceneName, string objName)
        {
            AddEnemy.Instance.enemyDic.Add(objName, preloadedObjects[sceneName][objName].gameObject);
        }

        #region 加强＆加怪
        //加强神居BOSS
        public void Add_GG_BOSS()
        {
            //一门
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Gruz_Mother;//格鲁滋之母
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Big_Buzzer;//反击鹰
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_FalseKnight;//假骑士
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Moss_Charger;//苔藓
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Hornet;//小姐姐

            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Gorb;//戈布
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_DungDefender;//芬达
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_SoulWarrior;//灵魂战士
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Brooding_Mawlek;//毛里克
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_nailmaster;//双师傅

            //二门
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Xero;//泽若
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_CrystalDefender;//水晶守卫
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_MageLord;//灵魂大师
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Oblobbles;//奥波路波
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_MantisLord;//三螳螂

            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Marmu;//马尔姆
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_FlukeMarm;//吸虫
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_BrokenVessel;//残破容器
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Galien;//加利安
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Sheo;//西奥

            //三门
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_HiveKnight;//蜜蜂骑士
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_ElderHu;//胡长老
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Collector;//收藏家
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_GodTamer;//神训
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Grim;//格林

            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_WatcherKnight;//滚滚
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_UUmuu;//乌姆
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Nosk;//诺斯克
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_HornetNosk;//有翼诺斯克
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Hornet2;//小姐姐2
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Sly;//莱斯

            //四门
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_FuriousGuard;//暴怒守卫
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_LostKin;//失落近亲
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_NoEyes;//无眼
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_TraitorLord;//叛徒领主
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_WhiteDefender;//白芬达

            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_MageTyrant;//灵魂暴君
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Markoth;//马科斯
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Zote;//左特
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_FailedChampion;//失败冠军
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_HollowKnight;//空洞骑士

            //五门
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Nightmare_Grim;//王格林
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_Radiance;//福光
            On.PlayMakerFSM.Start += EnhancedEnhancedRadiant.Instance.PlayMakerFSM_Radiance;//福光
            On.PlayMakerFSM.Start += GG_BOSS.Instance.PlayMakerFSM_EndlessZote;//无尽左特
            On.PlayMakerFSM.Start += GG_BOSS.Instance.Hornet;//小姐姐皮肤
        }

        //加强流程BOSS
        public void Add_Process_BOSS()
        {
            //一门
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Gruz_Mother;//格鲁滋之母
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Big_Buzzer;//反击鹰
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_FalseKnight;//假骑士
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Moss_Charger;//苔藓
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Hornet;//小姐姐

            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Gorb;//戈布
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_DungDefender;//芬达
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_SoulWarrior;//灵魂战士
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Brooding_Mawlek;//毛里克

            //二门                   
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Xero;//泽若
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_CrystalDefender;//水晶守卫
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_MageLord;//灵魂大师
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Oblobbles;//奥波路波
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_MantisLord;//三螳螂

            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Marmu;//马尔姆
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_FlukeMarm;//吸虫
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_BrokenVessel;//残破容器
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Galien;//加利安

            //三门                  
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_HiveKnight;//蜜蜂骑士
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_ElderHu;//胡长老
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Collector;//收藏家
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_GodTamer;//神训
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Grim;//格林

            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_WatcherKnight;//滚滚
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_UUmuu;//乌姆
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Nosk;//诺斯克
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Hornet2;//小姐姐2

            //四门                  
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_FuriousGuard;//暴怒守卫
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_LostKin;//失落近亲
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_NoEyes;//无眼
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_TraitorLord;//叛徒领主
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_WhiteDefender;//白芬达

            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_MageTyrant;//灵魂暴君
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Markoth;//马科斯
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Zote;//左特
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_FailedChampion;//失败冠军
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_HollowKnight;//空洞骑士

            //五门                 
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Nightmare_Grim;//王格林
            On.PlayMakerFSM.Start += Process_BOSS.Instance.Process_PlayMakerFSM_Radiance;//福光
        }

        //加强流程小怪
        public void Add_Process_Enemy()
        {
            On.PlayMakerFSM.Start += Process_Enemy.Instance.Process_PlayMakerFSM_EliteMonster;//精英怪
            On.PlayMakerFSM.Start += Process_Enemy.Instance.Process_PlayMakerFSM_Monster;//小怪
            Process_Enemy.Instance.Enemy_NoFSM();
        }

        //流程加怪
        public void Add_Enemy()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += AddEnemy.Instance.ActiveSceneChanged;
        }

        //神居QOL
        public void GodSeeker_QOL()
        {
            //跳空房间
            On.BossSequence.CanLoad += QOL.Instance.SkipEmptyRoom;
            //温泉恢复速度
            On.PlayMakerFSM.Start += QOL.Instance.PlayMakerFSM_Spa;
            //椅子位置、灵魂雕像
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += QOL.Instance.BenchQOL;
            //雕像回蓝速度
            On.PlayMakerFSM.Start += QOL.Instance.PlayMakerFSM_SoulTotem;
        }
        //流程QOL
        public void Process_QOL()
        {
            On.PlayMakerFSM.Start += ProcessQOL.Instance.PlayMakerFSM_Process_QOL;
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += ProcessQOL.Instance.Process_QOL;
            
        }
        //护符
        public void Charm()
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += CharmsChange.Instance.Change;
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += CharmsChange.Instance.Change2;
        }
        #endregion


    }
}
