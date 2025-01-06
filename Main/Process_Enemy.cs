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
using IL.HutongGames.PlayMaker;
using System.IO;

namespace AllHallownestEnhanced
{
    public class Process_Enemy : SingletonBase<Process_Enemy>
    {
        //精英怪
        public void Process_PlayMakerFSM_EliteMonster(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceEnemy)
                return;
            //安息之地蛆虫
            if (self.gameObject.name.Contains("Grave Zombie") && self.FsmName == "Attack")
            {
                self.FsmVariables.FindFsmFloat("Idle Time").Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 90;
                //jiou75
                self.GetComponent<HealthManager>().SetGeoLarge(1);
                self.GetComponent<HealthManager>().SetGeoMedium(5);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //苔藓骑士
            if (self.gameObject.name.Contains("Moss Knight") && self.FsmName == "Moss Knight Control")
            {
                self.GetState("Block High").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Block Low").GetAction<Wait>().time.Value = 0.2f;

                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }
                self.GetComponent<HealthManager>().hp = 100;
                //jiou110
                self.GetComponent<HealthManager>().SetGeoLarge(2);
                self.GetComponent<HealthManager>().SetGeoMedium(7);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //大巴德尔
            if (self.gameObject.name.Contains("Blocker") && self.FsmName == "Blocker Control")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.2f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 90;
                //jiou75
                self.GetComponent<HealthManager>().SetGeoLarge(1);
                self.GetComponent<HealthManager>().SetGeoMedium(5);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //龙牙哥
            if (self.gameObject.name.Contains("Zombie Guard") && self.FsmName == "Zombie Guard")
            {
                self.ChangeTransition("Wake", "WAIT", "Idle");
                self.ChangeTransition("Attack End", "WAIT", "Idle");
                self.ChangeTransition("Land", "FINISHED", "Idle");

                self.GetComponent<HealthManager>().hp = 120;
                //jiou100
                self.GetComponent<HealthManager>().SetGeoLarge(2);
                self.GetComponent<HealthManager>().SetGeoMedium(5);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //磕头菇战斗房间
            if(self.gameObject.name.Contains("Battle Scene v2") && self.FsmName == "Battle Control")
            {
                self.GetState("Start").GetAction<Wait>().time.Value = 0f;
            }
            //磕头菇
            if (self.gameObject.name.Contains("Mushroom Brawler") && self.FsmName == "Shroom Brawler")
            {
                self.GetState("Change Movement").GetAction<RandomFloat>(0).min.Value = 0.1f;
                self.GetState("Change Movement").GetAction<RandomFloat>(0).max.Value = 0.5f;
                self.GetState("Set Wait Time").GetAction<RandomFloat>().min.Value = 0.1f;
                self.GetState("Set Wait Time").GetAction<RandomFloat>().max.Value = 0.1f;
                self.GetState("Spit CD").GetAction<Wait>().time.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 160;

                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }
                //jiou120
                self.GetComponent<HealthManager>().SetGeoLarge(2);
                self.GetComponent<HealthManager>().SetGeoMedium(9);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //胖蜜蜂
            if (self.gameObject.name.Contains("Big Bee") && self.FsmName == "Big Bee")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.1f;
                self.GetState("Idle").GetAction<IdleBuzz>().waitMin.Value = 0.1f;
                self.GetState("Charge Pos").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Charge Pos").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("Recover").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Start Chase").GetAction<Wait>().time.Value = 0.1f;


                self.GetComponent<HealthManager>().hp = 200;
                //jiou80
                self.GetComponent<HealthManager>().SetGeoLarge(1);
                self.GetComponent<HealthManager>().SetGeoMedium(6);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //面具哥
            if (self.gameObject.name.Contains("Slash Spider") && self.FsmName == "Slash Spider")
            {
                self.ChangeTransition("Idle", "ATTACK", "Attack Antic Quick");
                self.ChangeTransition("Run", "ATTACK", "Attack Antic Quick");
                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }

                self.GetComponent<HealthManager>().hp = 200;
                //jiou110
                self.GetComponent<HealthManager>().SetGeoLarge(2);
                self.GetComponent<HealthManager>().SetGeoMedium(7);
                self.GetComponent<HealthManager>().SetGeoSmall(25);
            }
            //大跳虫
            if (self.gameObject.name.Contains("Giant Hopper") && self.FsmName == "Hopper")
            {
                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }
                self.GetComponent<HealthManager>().hp = 250;
                if (!self.gameObject.scene.name.Contains("Colosseum"))
                {
                    //jiou70
                    self.GetComponent<HealthManager>().SetGeoLarge(1);
                    self.GetComponent<HealthManager>().SetGeoMedium(4);
                    self.GetComponent<HealthManager>().SetGeoSmall(25);
                }
                else
                {
                    self.GetComponent<HealthManager>().SetGeoLarge(0);
                    self.GetComponent<HealthManager>().SetGeoMedium(0);
                    self.GetComponent<HealthManager>().SetGeoSmall(0);
                }

            }
            //小毛里克
            if (self.gameObject.name.Contains("Mawlek Turret") && self.FsmName == "Mawlek Turret")
            {
                self.GetState("Fire Left").GetAction<WaitRandom>().timeMax.Value = 0.15f;
                self.GetState("Fire Left").GetAction<WaitRandom>().timeMin.Value = 0.10f;
                self.GetState("Fire Right").GetAction<WaitRandom>().timeMax.Value = 0.15f;
                self.GetState("Fire Right").GetAction<WaitRandom>().timeMin.Value = 0.10f;
                self.ChangeTransition("Fire Left", "HERO EXIT", "Active");
                self.ChangeTransition("Fire Right", "HERO EXIT", "Active");
                //self.ChangeTransition("Active", "HERO EXIT", "Active");

                self.GetComponent<HealthManager>().hp = 250;
                //jiou60
                self.GetComponent<HealthManager>().SetGeoLarge(1);
                self.GetComponent<HealthManager>().SetGeoMedium(3);
                self.GetComponent<HealthManager>().SetGeoSmall(20);

                #region 不要移动
                Rigidbody2D rb = self.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                #endregion
            }
            //下水道肥虫
            if (self.gameObject.name.Contains("Fat Fluke") && self.FsmName == "Control")
            {
                self.GetComponent<HealthManager>().hp = 300;
                //jiou250
                self.GetComponent<HealthManager>().SetGeoLarge(5);
                self.GetComponent<HealthManager>().SetGeoMedium(15);
                self.GetComponent<HealthManager>().SetGeoSmall(50);
            }
            //白宫守卫
            if (self.gameObject.name.Contains("Royal Gaurd") && self.FsmName == "Guard")
            {
                self.GetState("Idle").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Chase").GetAction<Wait>().time.Value = 1f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 0f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 0f;


                self.GetComponent<HealthManager>().hp = 450;
            }
            //大盾哥
            if (self.gameObject.name.Contains("Great Shield Zombie") && self.FsmName == "ZombieShieldControl")
            {
                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }


                //贴图
                Texture2D texture2D;
                var stream = typeof(AllHallownestEnhanced).Assembly.GetManifestResourceStream("AllHallownestEnhanced.Res.SuperGreatShieldZombie.png");
                MemoryStream memoryStream = new MemoryStream((int)stream.Length);
                stream.CopyTo(memoryStream);
                stream.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();
                texture2D = new Texture2D(0, 0);
                texture2D.LoadImage(bytes, true);
                self.GetComponent<tk2dSprite>().CurrentSprite.material.mainTexture = texture2D;

                //Shine
                GameObject shine = GameObject.Instantiate(AddEnemy.Instance.enemyDic["Gorgeous Husk/Shine"], self.transform, false);
                shine.transform.localPosition = new Vector3(0, -0.9f, 0);
                shine.transform.localScale = Vector3.one * 5f;
                shine.gameObject.SetActive(true);

                //self.transform.localScale = Vector3.one * 1f;
                //self.GetState("Shield Left High").GetAction<SetScale>().x = -1f;
                //self.GetState("Shield Left Low").GetAction<SetScale>().x = -1f;
                //self.GetState("Shield Right High").GetAction<SetScale>().x = 1f;
                //self.GetState("Shield Right Low").GetAction<SetScale>().x = 1f;
                //self.GetComponent<Walker>().Reflect().rightScale = 1f;
                //self.GetComponent<Walker>().Reflect().walkSpeedL = -4f;
                //self.GetComponent<Walker>().Reflect().walkSpeedR = 4f;

                self.GetState("Block High").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Block Low").GetAction<Wait>().time.Value = 0.05f;

                self.GetComponent<HealthManager>().hp = 400;
                //jiou150
                self.GetComponent<HealthManager>().SetGeoLarge(3);
                self.GetComponent<HealthManager>().SetGeoMedium(15);
                self.GetComponent<HealthManager>().SetGeoSmall(0);

            }
            //金色传说?????
            if (self.gameObject.name.Contains("Gorgeous Husk") && self.FsmName == "Attack")
            {
                self.GetState("Return to idle").GetAction<Wait>().time.Value = 0.1f;

                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }
                self.GetComponent<HealthManager>().hp = 600;
                //jiou1145
                self.GetComponent<HealthManager>().SetGeoLarge(25);
                self.GetComponent<HealthManager>().SetGeoMedium(75);
                self.GetComponent<HealthManager>().SetGeoSmall(145);
            }

        }

        //小怪
        public void Process_PlayMakerFSM_Monster(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceEnemy)
                return;
            Process_PlayMakerFSM_Crossing(orig, self);//十字路
            Process_PlayerMakerFSM_GreenPath(orig, self);//苍绿之径
            Process_PlayerMakerFSM_Fungalwasteland(orig, self);//真菌荒地
            Process_PlayerMakerFSM_TearsCity(orig, self);//泪城
            Process_PlayerMakerFSM_RoyalWaterway(orig, self);//皇家水道
            Process_PlayerMakerFSM_CrystalPeak(orig, self);//水晶山峰
            Process_PlayerMakerFSM_DeepNest(orig, self);//深巢
            Process_PlayerMakerFSM_AncientBasin(orig, self);//古老盆地
            Process_PlayerMakerFSM_KingdomEdge(orig, self);//王国边缘
            Process_PlayerMakerFSM_BeeNest(orig, self);//蜂巢
            Process_PlayerMakerFSM_QueensGarden(orig, self);//王后花园
            Process_PlayerMakerFSM_Arena(orig, self);//竞技场
            Process_PlayerMakerFSM_Grimm(orig, self);//格林亲族
            Process_PlayerMakerFSM_OtherEnemy(orig, self);//补充敌人
            Process_PlayerMakerFSM_OtherEnemy2(orig, self);//补充敌人2
            Colosseum_Battle(orig, self);//竞技场战斗
        }

        #region 所有区域的小怪
        //十字路
        public void Process_PlayMakerFSM_Crossing(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //小爬虫
            if (self.gameObject.name.Contains("Crawler") && self.FsmName == "Crawler")
            {
                self.GetComponent<HealthManager>().hp = 12;
            }
            //小反击鹰
            if (self.gameObject.name.Contains("Buzzer") && self.FsmName == "chaser")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.1f;
                self.GetState("Idle").GetAction<IdleBuzz>().waitMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 12;
            }
            //小格鲁兹
            if (self.gameObject.name.Contains("Fly") 
                && !self.gameObject.name.Contains("Giant")
                && self.FsmName == "Bouncer Control")
            {
                self.GetComponent<HealthManager>().hp = 12;
            }
            //小橙汁
            if (self.gameObject.name.Contains("Spitter") 
                && !self.gameObject.name.Contains("Super")
                && self.FsmName == "spitter")
            {
                self.GetState("Distance Fly").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Distance Fly").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Fly Back").GetAction<Wait>().time.Value = 0.25f;

                self.GetComponent<HealthManager>().hp = 21;
            }
            //橙汁妈妈
            if (self.gameObject.name.Contains("Hatcher") && self.FsmName == "Hatcher")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.2f;
                self.GetState("Idle").GetAction<IdleBuzz>().waitMin.Value = 0.1f;
                self.GetState("Distance Fly").GetAction<RandomFloat>().min.Value = 0.5f;
                self.GetState("Distance Fly").GetAction<RandomFloat>().max.Value = 0.5f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //游荡者
            if (self.gameObject.name.Contains("Zombie Barger") && self.FsmName == "Zombie Swipe")
            {
                self.FsmVariables.GetFsmFloat("Idle Time").Value = 0.05f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //游荡者2
            if (self.gameObject.name.Contains("Zombie Hornhead") && self.FsmName == "Zombie Swipe")
            {
                self.FsmVariables.GetFsmFloat("Idle Time").Value = 0.05f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //冲刺游荡者
            if (self.gameObject.name.Contains("Zombie Runner") && self.FsmName == "Zombie Swipe")
            {
                self.FsmVariables.GetFsmFloat("Idle Time").Value = 0.05f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //小跳游荡者
            if (self.gameObject.name.Contains("Zombie Leaper") && self.FsmName == "Zombie Leap")
            {
                self.FsmVariables.GetFsmFloat("Idle Time").Value = 0.2f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //武器游荡者
            if (self.gameObject.name.Contains("Zombie Shield") && self.FsmName == "ZombieShieldControl")
            {
                self.GetState("Block High").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Block Low").GetAction<Wait>().time.Value = 0.2f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //小巴德尔
            if (self.gameObject.name.Contains("Roller") && self.FsmName == "Roller")
            {
                self.FsmVariables.FindFsmFloat("Stop Time").Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 15;
            }
            //爆炸反击鹰
            if (self.gameObject.name.Contains("Angry Buzzer") && self.FsmName == "Control")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.GetState("Idle").GetAction<IdleBuzz>().waitMin.Value = 0.25f;
                self.GetComponent<HealthManager>().hp = 60;
            }
            //爆炸格鲁兹
            if (self.gameObject.name.Contains("Bursting Bouncer") && self.FsmName == "Bouncer Control")
            {
                self.GetComponent<HealthManager>().hp = 60;
            }
            if (self.gameObject.name.Contains("Bursting Bouncer") && self.FsmName == "Drip")
            {
                self.GetState("Pause").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Pause").GetAction<WaitRandom>().timeMin.Value = 0.25f;
            }
            //瘟疫跳跳
            if (self.gameObject.name.Contains("Spitting Zombie") && self.FsmName == "Spit")
            {
                self.GetState("Attack Wait").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 45;
            }

        }
        //苍绿之径
        public void Process_PlayerMakerFSM_GreenPath(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //小绿爬虫
            if (self.gameObject.name.Contains("Moss Walker") && self.FsmName == "Moss Walker")
            {
                self.GetState("Wake Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Shake").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Wake").GetAction<RandomFloat>().max.Value = 2f;
                self.GetState("Wake").GetAction<RandomFloat>().min.Value = 1f;
                self.GetComponent<HealthManager>().hp = 15;
            }
            //小飞爬虫
            if (self.gameObject.name.Contains("Moss Flyer") && self.FsmName == "Moss Flyer")
            {
                self.GetState("Wake Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Shake").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Wake").GetAction<RandomFloat>().max.Value = 2f;
                self.GetState("Wake").GetAction<RandomFloat>().min.Value = 1f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //苔藓冲刺
            if (self.gameObject.name.Contains("Mossman_Runner") && self.FsmName == "Zombie Swipe")
            {
                self.FsmVariables.GetFsmFloat("Idle Time").Value = 0.05f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //苔藓爆炸
            if (self.gameObject.name.Contains("Mossman_Shaker") && self.FsmName == "Fungus Zombie Attack")
            {
                self.GetState("Attack Delay").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 25;
            }
            //小蚊子
            if (self.gameObject.name.Contains("Mosquito") && self.FsmName == "Mozzie")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.GetState("Idle").GetAction<IdleBuzz>().waitMin.Value = 0.25f;
                self.GetState("Stop").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0.25f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMin.Value = 0.05f;
                self.GetState("Recover").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 15;
            }
            //小波波
            if (self.gameObject.name.Contains("Fat Fly") && self.FsmName == "Fatty Fly Attack")
            {
                self.GetState("CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 1f;
                self.GetComponent<HealthManager>().hp = 15;
            }
            //食人花
            if (self.gameObject.name.Contains("Plant Trap") && self.FsmName == "Plant Trap Control")
            {
                self.GetState("Ready").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Snap").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0f;
                self.GetComponent<HealthManager>().hp = 24;
            }
            //橙汁宝宝
            if (self.gameObject.name.Contains("Hatcher Baby Spawner") && self.FsmName == "Control")
            {
                self.GetComponent<HealthManager>().hp = 8;
            }


        }
        //真菌荒地
        public void Process_PlayerMakerFSM_Fungalwasteland(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //小真菌飘飘
            if (self.gameObject.name.Contains("Fungoon Baby") && self.FsmName == "Fungoon baby")
            {
                self.GetComponent<HealthManager>().hp = 15;
            }
            //大真菌飘飘
            if (self.gameObject.name.Contains("Fungus Flyer") && self.FsmName == "Fungus Flyer")
            {
                self.GetState("Idle").GetAction<IdleBuzzV2>().waitMax.Value = 0.5f;
                self.GetState("Idle").GetAction<IdleBuzzV2>().waitMin.Value = 0.25f;
                self.GetState("Spit CD").GetAction<Wait>().time.Value = 0.5f;
                self.GetComponent<HealthManager>().hp = 25;
            }
            //更大范围爆炸
            if (self.gameObject.name.Contains("Zombie Fungus") && self.FsmName == "Fungus Zombie Attack")
            {
                self.GetState("CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 25;
            }
            //中蘑菇娃娃
            if (self.gameObject.name.Contains("Mushroom Roller") && self.FsmName == "Mush Roller")
            {
                self.GetState("Emerge Cooldown").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //飞螳螂
            if (self.gameObject.name.Contains("Mantis Flyer Child") && self.FsmName == "Mantis Flyer")
            {
                self.GetState("Idle Buzz").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.GetState("Idle Buzz").GetAction<IdleBuzz>().waitMin.Value = 0.25f;
                self.GetState("CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Pause").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 21;
            }
            //走螳螂
            if (self.gameObject.name.Contains("Mantis") && !self.gameObject.name.Contains("Traitor") && self.FsmName == "Mantis")
            {
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 30;
            }
        }
        //泪水之城
        public void Process_PlayerMakerFSM_TearsCity(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //泪城小哥
            if (self.gameObject.name.Contains("Ruins Sentry") && self.FsmName == "Ruins Sentry")
            {
                self.GetState("Attack CD").GetAction<WaitRandom>().timeMax.Value = 0.2f;
                self.GetState("Attack CD").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("Evade Cooldown").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Ruins Sentry") && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 40;
                self.FsmVariables.FindFsmInt("Level 2").Value = 40;
                self.FsmVariables.FindFsmInt("Level 3").Value = 40;
                self.FsmVariables.FindFsmInt("Level 4").Value = 40;
                self.FsmVariables.FindFsmInt("Level 5").Value = 40;
            }
            //泪城胖哥
            if (self.gameObject.name.Contains("Ruins Sentry Fat") && self.FsmName == "Ruins Sentry Fat")
            {
                self.GetState("Attack CD").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Attack CD").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 50;
            }
            //泪城飞哥
            if (self.gameObject.name.Contains("Ruins Flying Sentry") && self.FsmName == "Flying Sentry Nail")
            {
                self.GetState("Idle Buzz").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.GetState("Idle Buzz").GetAction<IdleBuzz>().waitMin.Value = 0.25f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetComponent<HealthManager>().hp = 35;
            }
            //泪城箭哥
            if (self.gameObject.name.Contains("Ruins Flying Sentry Javelin") && self.FsmName == "Flying Sentry Javelin")
            {
                self.GetState("Idle Buzz").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.GetState("Idle Buzz").GetAction<IdleBuzz>().waitMin.Value = 0.25f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetComponent<HealthManager>().hp = 35;
            }
            //愚蠢飞飞
            if (self.gameObject.name.Contains("Mage Balloon") && self.FsmName == "Control")
            {
                //BOSS场景不加血
                if (!self.gameObject.scene.name.Contains("GG") 
                    && self.gameObject.scene.name != "Ruins1_31b"
                    && self.gameObject.scene.name != "DontDestroyOnLoad") 
                {
                    self.GetComponent<HealthManager>().hp = 20;
                }
            }
            //错误爬爬
            if (self.gameObject.name.Contains("Mage Blob") && self.FsmName == "Blob")
            {
                self.GetComponent<HealthManager>().hp = 20;
            }
            //灵魂小师
            if (self.gameObject.name.Contains("Mage") && self.FsmName == "Mage")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 1.5f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 1f;
                self.GetState("Idle After Tele").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetComponent<HealthManager>().hp = 50;
            }
            //泪城富人
            if (self.gameObject.name.Contains("Royal Zombie") 
                && !self.gameObject.name.Contains("Fat") 
                && self.FsmName == "Attack")
            {
                self.GetState("Return to idle").GetAction<WaitRandom>().timeMax.Value = 0.2f;
                self.GetState("Return to idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //泪城富老人
            if (self.gameObject.name.Contains("Royal Zombie Coward") && self.FsmName == "Coward Swipe")
            {
                self.FsmVariables.FindFsmFloat("Idle Time").Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //泪城富胖人
            if (self.gameObject.name.Contains("Royal Zombie Fat") && self.FsmName == "Attack")
            {
                self.GetState("Return to idle").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 45;
            }
        }
        //下水道
        public void Process_PlayerMakerFSM_RoyalWaterway(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //下水道翻身虫
            if (self.gameObject.name.Contains("Flip Hopper") && self.FsmName == "Attack")
            {
                self.GetComponent<HealthManager>().hp = 40;
            }
            //下水道波波
            if (self.gameObject.name.Contains("Inflater") && self.FsmName == "Inflater")
            {
                self.GetComponent<HealthManager>().hp = 40;
            }
            //下水道吸虫
            if (self.gameObject.name.Contains("Fluke Fly") && self.FsmName == "Fluke Fly")
            {
                //BOSS场景不加血
                if (!self.gameObject.scene.name.Contains("GG")
                    && !self.gameObject.scene.name.Contains("Waterways_12")
                    && self.gameObject.scene.name != "DontDestroyOnLoad")
                {
                    self.GetComponent<HealthManager>().hp = 20;
                }
            }
            //下水道分身虫
            if (self.gameObject.name.Contains("Flukeman") && self.FsmName == "Flukeman")
            {
                self.GetComponent<HealthManager>().hp = 40;
            }
            if (self.gameObject.name.Contains("Flukeman Bot") && self.FsmName == "Flukeman Bot")
            {
                self.GetState("Land").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Land").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            if (self.gameObject.name.Contains("Flukeman Top") && self.FsmName == "Flukeman Top")
            {
                self.GetComponent<HealthManager>().hp = 20;
            }
        }
        //水晶山峰
        public void Process_PlayerMakerFSM_CrystalPeak(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //水晶尖刺虫
            if (self.gameObject.name.Contains("Mines Crawler") && self.FsmName == "Mines Crawler")
            {
                self.GetComponent<HealthManager>().hp = 25;
            }
            //水晶胖虫
            if (self.gameObject.name.Contains("Crystal Crawler") && self.FsmName == "Crawler")
            {
                self.GetComponent<HealthManager>().hp = 50;
            }
            //水晶猎人
            if (self.gameObject.name.Contains("Crystal Flyer") && self.FsmName == "Crystal Flyer")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.GetState("Idle").GetAction<IdleBuzz>().waitMin.Value = 0.25f;
                self.GetState("Idle").GetAction<IdleBuzz>().speedMax.Value = 3.5f;
                self.GetState("Alert").GetAction<DistanceFly>().speedMax.Value = 7;
                self.GetState("Antic").GetAction<DistanceFly>().speedMax.Value = 7;
                self.FsmVariables.FindFsmFloat("Wait Max").Value = 1f;
                self.FsmVariables.FindFsmFloat("Wait Min").Value = 1f;
                self.GetComponent<HealthManager>().hp = 40;
            }
            //水晶矿工
            if (self.gameObject.name.Contains("Zombie Miner") && self.FsmName == "Zombie Miner")
            {
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cooldown").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 40;
            }
            //水晶激光虫
            if (self.gameObject.name.Contains("Zombie Beam Miner")
                && !self.gameObject.name.Contains("Mega")
                && !self.gameObject.name.Contains("Rematch")
                && self.FsmName == "Beam Miner")
            {
                self.GetState("Beam Antic").GetAction<Wait>().time.Value = 0.6f;
                self.GetState("Cancel").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("CD").GetAction<Wait>().time.Value = 0.05f;
                self.GetComponent<HealthManager>().hp = 50;
            }
            //假虫子
            if (self.gameObject.name.Contains("Grub Mimic") && self.FsmName == "Grub Control")
            {
                self.GetState("Free").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Grub Mimic") && self.FsmName == "Grub Mimic")
            {
                //self.GetState("Scream").GetAction<Wait>().time.Value = 0.25f;
                self.GetComponent<HealthManager>().hp = 90;
            }
        }
        //深邃巢穴
        public void Process_PlayerMakerFSM_DeepNest(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //电车站爬虫
            if (self.gameObject.name.Contains("Baby Centipede") && self.FsmName == "Centipede")
            {
                self.GetComponent<HealthManager>().hp = 30;
            }
            //电车站爬虫妈妈
            if (self.gameObject.name.Contains("Centipede Hatcher") && self.FsmName == "Centipede Hatcher")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().waitMax.Value = 0.5f;
                self.FsmVariables.FindFsmFloat("Wait Max").Value = 1;
                self.FsmVariables.FindFsmFloat("Wait Min").Value = 0.5f;
                self.FsmVariables.FindFsmInt("Hatched Max").Value = 10;
                self.GetState("Exhausted").GetAction<SetFloatValue>(0).floatValue.Value = 1f;
                self.GetState("Exhausted").GetAction<SetFloatValue>(1).floatValue.Value = 1.5f;
                self.GetState("Check Births").GetAction<SetFloatValue>(1).floatValue.Value = 1f;
                self.GetState("Check Births").GetAction<SetFloatValue>(2).floatValue.Value = 2f;

                self.GetComponent<HealthManager>().hp = 50;
            }
            //深巢变异虫
            if (self.gameObject.name.Contains("Zombie Spider") && self.FsmName == "Chase")
            {
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Wait 2").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Wait 2").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Burst Antic").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Burst Antic").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Pause").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //深巢小爬虫
            if (self.gameObject.name.Contains("Tiny Spider") && self.FsmName == "Spawn")
            {
                self.GetComponent<HealthManager>().hp = 20;
            }
            //深巢子弹虫
            if (self.gameObject.name.Contains("Spider Mini") && self.FsmName == "Spider")
            {
                self.GetComponent<HealthManager>().hp = 25;
            }
            if (self.gameObject.name.Contains("Spider Mini") && self.FsmName == "Shoot")
            {
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 0.25f;
                self.GetState("Recover").GetAction<Wait>().time.Value = 0.25f;
            }
            //深巢飞蜘蛛
            if (self.gameObject.name.Contains("Spider Flyer") && self.FsmName == "Control")
            {
                self.GetState("Spawn Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 40;
            }
        }
        //古老盆地
        public void Process_PlayerMakerFSM_AncientBasin(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //小毛里克
            if (self.gameObject.name.Contains("Lesser Mawlek") && self.FsmName == "Lesser Mawlek")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Recovery").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Slash Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 90;
            }
            //气球
            if (self.gameObject.name.Contains("Parasite Balloon") && self.FsmName == "Control")
            {
                self.GetState("Spawn Pause").GetAction<WaitRandom>().timeMax.Value = 0f;


                //BOSS场景不加血
                if (!self.gameObject.scene.name.Contains("GG") 
                    && self.gameObject.scene.name != "Abyss_19"
                    && !self.gameObject.scene.name.Contains("Dream")
                    && self.gameObject.scene.name != "DontDestroyOnLoad")
                {
                    self.GetComponent<HealthManager>().hp = 25;
                }
            }
        }
        //王国边缘
        public void Process_PlayerMakerFSM_KingdomEdge(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //边缘大胖虫
            if (self.gameObject.name.Contains("Blow Fly") && self.FsmName == "Blow Fly")
            {
                self.GetComponent<HealthManager>().hp = 60;
            }
            //古神
            if (self.gameObject.name.Contains("Super Spitter") 
                && self.FsmName == "spitter")
            {

                #region 改为超级古神
                //贴图
                Texture2D texture2D;
                var stream = typeof(AllHallownestEnhanced).Assembly.GetManifestResourceStream("AllHallownestEnhanced.Res.SuperSpitter.png");
                MemoryStream memoryStream = new MemoryStream((int)stream.Length);
                stream.CopyTo(memoryStream);
                stream.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();
                texture2D = new Texture2D(0, 0);
                texture2D.LoadImage(bytes, true);
                self.GetComponent<tk2dSprite>().CurrentSprite.material.mainTexture = texture2D;

                self.GetState("Distance Fly").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Distance Fly").GetAction<WaitRandom>().timeMin.Value = 0.75f;
                self.GetState("Fly Back").GetAction<Wait>().time.Value = 0.25f;

                if (!self.gameObject.scene.name.Contains("GG")
                    && self.gameObject.scene.name != "DontDestroyOnLoad")
                {
                    if (!self.gameObject.scene.name.Contains("Colosseum"))
                    {
                        self.GetState("Fire").GetAction<FloatAdd>(7).add.Value = -45;
                        self.GetState("Fire").GetAction<FloatAdd>(10).add.Value = 90;
                        //self.GetState("Fire").GetAction<FireAtTarget>().speed.Value = 15;
                        //self.GetState("Fire").GetAction<SetVelocityAsAngle>(9).speed.Value = 15;
                        //self.GetState("Fire").GetAction<SetVelocityAsAngle>(12).speed.Value = 15;

                        self.CopyState("Fire", "Copy Fire");
                        self.ChangeTransition("Fire", "WAIT", "Copy Fire");
                        self.ChangeTransition("Copy Fire", "WAIT", "Fire Dribble");

                        self.GetState("Copy Fire").GetAction<FireAtTarget>().speed.Value = 15f;
                        self.GetState("Copy Fire").GetAction<FloatAdd>(7).add.Value = -15;
                        self.GetState("Copy Fire").GetAction<SetVelocityAsAngle>(9).speed.Value = 12;
                        self.GetState("Copy Fire").GetAction<FloatAdd>(10).add.Value = 30;
                        self.GetState("Copy Fire").GetAction<SetVelocityAsAngle>(12).speed.Value = 12;

                        //self.GetState("Sleep").GetAction<FloatCompare>(3).float2.Value = 45f;
                        //self.GetState("Sleep").GetAction<FloatCompare>(5).float2.Value = 36f;
                        //self.GetState("Idle").GetAction<FloatCompare>(12).float2.Value = 64f;
                        //self.GetState("Idle").GetAction<FloatCompare>(14).float2.Value = 50f;
                        self.GetState("Distance Fly").GetAction<FloatCompare>().float2.Value = 16f;
                        self.GetState("Distance Fly").GetAction<DistanceFly>().speedMax.Value = 20f;
                        self.GetState("Fly Back").GetAction<DistanceFly>().speedMax.Value = 25f;
                        self.GetState("Fire Anticipate").GetAction<DistanceFly>().speedMax.Value = 6f;
                    }
                    self.GetComponent<HealthManager>().hp = 50;
                }
                #endregion

            }
            //小跳虫
            if (self.gameObject.name.Contains("Hopper") && !self.gameObject.name.Contains("Giant") && self.FsmName == "Hopper")
            {
                self.GetComponent<HealthManager>().hp = 75;
            }
        }
        //蜂巢
        public void Process_PlayerMakerFSM_BeeNest(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //小蜜蜂
            if (self.gameObject.name.Contains("Bee Hatchling Ambient") && self.FsmName == "Bee")
            {
                self.GetComponent<HealthManager>().hp = 30;
            }
            if (self.gameObject.name.Contains("Hiveling Spawner") && self.FsmName == "Control")
            {
                self.GetState("Death").GetAction<SetHP>().hp.Value = 40;

                self.GetComponent<HealthManager>().hp = 30;
            }
            //电钻蜜蜂
            if (self.gameObject.name.Contains("Bee Stinger") && self.FsmName == "Bee Stinger")
            {
                self.GetState("Chase").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetComponent<HealthManager>().hp = 100;
            }
            //蜜蜂妈妈
            if (self.gameObject.name.Contains("Zombie Hive") && self.FsmName == "Hive Zombie")
            {
                self.GetState("Run").GetAction<WaitRandom>().timeMax.Value = 0.7f;
                self.GetState("Run").GetAction<WaitRandom>().timeMin.Value = 0.35f;
                self.GetComponent<HealthManager>().hp = 90;
            }
        }
        //王后花园
        public void Process_PlayerMakerFSM_QueensGarden(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //花园尖刺虫
            if (self.gameObject.name.Contains("Garden Zombie") && self.FsmName == "Attack")
            {
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0;
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 60;
            }
            //花园鲁多
            if (self.gameObject.name.Contains("Grass Hopper") && self.FsmName == "Crazy Hopper")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.05f;

                self.GetComponent<HealthManager>().hp = 45;
            }
            //花园飞螳螂
            if (self.gameObject.name.Contains("Mantis Heavy Flyer") && self.FsmName == "Heavy Flyer")
            {
                self.GetState("Alert").GetAction<WaitRandom>().timeMax.Value = 1.5f;
                self.GetState("Alert").GetAction<WaitRandom>().timeMin.Value = 1f;
                self.GetState("Recover").GetAction<WaitRandom>().timeMax.Value = 0.25f;
                self.GetState("Recover").GetAction<WaitRandom>().timeMin.Value = 0.25f;
                self.GetComponent<HealthManager>().hp = 65;
            }
            //花园螳螂
            if (self.gameObject.name.Contains("Mantis Heavy") && self.FsmName == "Mantis")
            {
                self.GetState("Spawn Recover").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.05f;

                self.GetComponent<HealthManager>().hp = 110;
            }
        }
        //竞技场
        public void Process_PlayerMakerFSM_Arena(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //竞技场滚滚(Colosseum_Armoured_Roller)
            if (self.gameObject.name.Contains("Colosseum_Armoured_Roller") && self.FsmName == "Roller") 
            {
                self.FsmVariables.FindFsmFloat("Stop Time").Value = 0.1f;

                //BOSS场景不加血
                if (!self.gameObject.scene.name.Contains("GG")
                    && self.gameObject.scene.name != "DontDestroyOnLoad")
                {
                    self.GetComponent<HealthManager>().hp = 100;
                }
            }
            //竞技场蚊子(Colosseum_Armoured_Mosquito)
            if (self.gameObject.name.Contains("Colosseum_Armoured_Mosquito") && self.FsmName == "Mozzie2")
            {
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0.25f;
                self.GetState("Stick").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Recover").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Stop").GetAction<Wait>().time.Value = 0.25f;

                //BOSS场景不加血
                if (!self.gameObject.scene.name.Contains("GG")
                    && self.gameObject.scene.name != "DontDestroyOnLoad")
                {
                    self.GetComponent<HealthManager>().hp = 60;
                }
            }
            //竞技场小波波(Blobble)
            if (self.gameObject.name.Contains("Blobble") && self.FsmName == "Fatty Fly Attack")
            {
                self.GetState("CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 0.5f;

                self.GetComponent<HealthManager>().hp = 110;
            }
            //竞技场骑士(Colosseum_Shield_Zombie)
            if (self.gameObject.name.Contains("Colosseum_Shield_Zombie") && self.FsmName == "ZombieShieldControl")
            {
                self.GetState("Recover Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Block High").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Block Low").GetAction<Wait>().time.Value = 0.2f;

                self.GetComponent<HealthManager>().hp = 100;
            }
            //竞技场矿工(Colosseum_Miner)
            if (self.gameObject.name.Contains("Colosseum_Miner") && self.FsmName == "Zombie Miner")
            {
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cooldown").GetAction<WaitRandom>().timeMax.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 120;
            }
            //竞技场飞哥(Colosseum_Flying_Sentry)
            if (self.gameObject.name.Contains("Colosseum_Flying_Sentry") && self.FsmName == "Flying Sentry Nail") 
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.5f;

                self.GetComponent<HealthManager>().hp = 110;
            }
            //竞技场大胖虫(Colosseum_Worm)
            if (self.gameObject.name.Contains("Colosseum_Worm") && self.FsmName == "Ruins Sentry Fat") 
            {
                self.GetState("Alert Cooldown").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Alert Cooldown").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Attack CD").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Attack CD").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 150;
            }
            //竞技场鲁多(Colosseum Grass Hopper)
            if (self.gameObject.name.Contains("Colosseum Grass Hopper") && self.FsmName == "Crazy Hopper")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.05f;

                self.GetComponent<HealthManager>().hp = 65;
            }
            //竞技场电哥(Electric Mage New)
            if (self.gameObject.name.Contains("Electric Mage New") && self.FsmName == "Electric Mage")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 1f;

                self.GetComponent<HealthManager>().hp = 130;
            }
        }
        //格林亲族
        public void Process_PlayerMakerFSM_Grimm(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            if (self.gameObject.name.Contains("Flamebearer Spawn") && self.FsmName == "Spawn Control") 
            {
                self.GetState("Get Pause").GetAction<Wait>().time.Value = 0;
            }
            //大脑QOL
            //if (self.gameObject.name.Contains("grimm_brazier") && self.FsmName == "grimm_brazier")
            //{
            //    self.GetState("Spark").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Rumble").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Light").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Arrival Rumble").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Arrive Event").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Final Shake").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Final Pause").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Spark 2").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Flare Up").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Destroyed").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Fade Back").GetAction<Wait>().time.Value = 0.5f;
            //    self.GetState("Fade Back").GetAction<SetFsmFloat>().setValue.Value = 0.25f;
            //    self.GetState("Fade Back").GetAction<SendEventByName>().delay.Value = 0.25f;
            //}
            //格林亲族1
            if (self.gameObject.name.Contains("Flamebearer Small") && self.FsmName == "Control") 
            {
                self.GetState("Alert Pause").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Follow").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Follow").GetAction<WaitRandom>().timeMin.Value = 0.05f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMin.Value = 0.05f;
            }
            if (self.gameObject.name.Contains("Flamebearer Small") && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 220;
                self.FsmVariables.FindFsmInt("Level 2").Value = 220;
                self.FsmVariables.FindFsmInt("Level 3").Value = 220;
                self.FsmVariables.FindFsmInt("Level 4").Value = 220;
                self.FsmVariables.FindFsmInt("Level 5").Value = 220;
            }
            //格林亲族2
            if (self.gameObject.name.Contains("Flamebearer Med") && self.FsmName == "Control")
            {
                self.GetState("Alert Pause").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Follow").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Follow").GetAction<WaitRandom>().timeMin.Value = 0.05f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMin.Value = 0.05f;
            }
            if (self.gameObject.name.Contains("Flamebearer Med") && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 360;
                self.FsmVariables.FindFsmInt("Level 2").Value = 360;
                self.FsmVariables.FindFsmInt("Level 3").Value = 360;
                self.FsmVariables.FindFsmInt("Level 4").Value = 360;
                self.FsmVariables.FindFsmInt("Level 5").Value = 360;
            }
            //格林亲族3
            if (self.gameObject.name.Contains("Flamebearer Large") && self.FsmName == "Control")
            {
                self.GetState("Alert Pause").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Follow").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Follow").GetAction<WaitRandom>().timeMin.Value = 0.05f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0.05f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMin.Value = 0.05f;
            }
            if (self.gameObject.name.Contains("Flamebearer Large") && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 500;
                self.FsmVariables.FindFsmInt("Level 2").Value = 500;
                self.FsmVariables.FindFsmInt("Level 3").Value = 500;
                self.FsmVariables.FindFsmInt("Level 4").Value = 500;
                self.FsmVariables.FindFsmInt("Level 5").Value = 500;
            }
        }
        //补充敌人
        public void Process_PlayerMakerFSM_OtherEnemy(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //闪电
            if (self.gameObject.name.Contains("Zap Cloud") && self.FsmName == "zap control")
            {
                self.transform.localScale = Vector3.one * 1.5f;
                //self.ChangeTransition("Attack CD", "FINISHED", "Attack Antic");
                Wait wait = new Wait()
                {
                    time = 0.25f,
                    finishEvent = HutongGames.PlayMaker.FsmEvent.Finished,
                };
                self.GetState("Ready").InsertAction(0, wait);
            }
            if (self.gameObject.name.Contains("Zap Cloud") && self.FsmName == "damages_enemy")
            {
                self.FsmVariables.GetFsmInt("damageDealt").Value = 0;
            }

            //魂
            if (self.gameObject.name.Contains("Hollow Shade") && self.FsmName == "Shade Control")
            {
                self.GetState("Fly").GetAction<WaitRandom>().timeMax.Value = 0.25f;
                self.GetState("Fly").GetAction<WaitRandom>().timeMin.Value = 0.25f;
                self.GetState("Quake Antic").GetAction<Wait>().time.Value = 0.4f;
                self.GetState("Return Pause").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Scream Antic").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Fireball Pos").GetAction<Wait>().time.Value = 0.5f;
            }
            //苔藓冲锋者
            if (self.gameObject.name.Contains("Moss Charger") 
                && !self.gameObject.name.Contains("Mega")
                && self.FsmName == "Mossy Control")
            {
                self.GetState("Emerge Pause").GetAction<WaitRandom>().timeMax.Value = 0.2f;
                self.GetState("Emerge Pause").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("Submerge CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //爆肚蝙
            if (self.gameObject.name.Contains("Ceiling Dropper")
                && !self.gameObject.name.Contains("Col")
                && self.FsmName == "Ceiling Dropper")
            {

                //贴图
                Texture2D texture2D;
                var stream = typeof(AllHallownestEnhanced).Assembly.GetManifestResourceStream("AllHallownestEnhanced.Res.SuperCeilingDropper.png");
                MemoryStream memoryStream = new MemoryStream((int)stream.Length);
                stream.CopyTo(memoryStream);
                stream.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();
                texture2D = new Texture2D(0, 0);
                texture2D.LoadImage(bytes, true);
                self.GetComponent<tk2dSprite>().CurrentSprite.material.mainTexture = texture2D;

                self.GetState("Startle").InsertAction(2, self.GetState("Idle").GetAction<WaitRandom>());
                self.GetState("Startle").GetAction<WaitRandom>().timeMax.Value = 0.35f;
                self.GetState("Startle").GetAction<WaitRandom>().timeMin.Value = 0.35f;
                self.GetState("Startle").GetAction<WaitRandom>().finishEvent = self.GetState("Startle").GetAction<Tk2dPlayAnimationWithEvents>().animationCompleteEvent; 
                
                //self.GetState("Startle").InsertMethod(0, () =>
                //{
                //    self.SetState("Dive");
                //});

            }
            //苍白潜伏者
            if (self.gameObject.name.Contains("Pale Lurker") && self.FsmName == "Lurker Control")
            {
                self.FsmVariables.FindFsmFloat("Gravity").Value = 3f;
                self.FsmVariables.FindFsmFloat("Hop X Force").Value = -20f;
                self.FsmVariables.FindFsmFloat("Hop Y Force").Value = 60;
                self.FsmVariables.FindFsmFloat("Jump X Force").Value = -18;
                self.FsmVariables.FindFsmFloat("Jump Y Force").Value = 70;

                self.GetState("Back").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Forward").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wall Cling").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Slash End").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Pale Lurker") && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 500;
                self.FsmVariables.FindFsmInt("Level 2").Value = 500;
                self.FsmVariables.FindFsmInt("Level 3").Value = 500;
                self.FsmVariables.FindFsmInt("Level 4").Value = 500;
                self.FsmVariables.FindFsmInt("Level 5").Value = 500;
            }
            //十字路陷阱
            if (self.gameObject.name.Contains("Worm") && self.FsmName == "Worm Control")
            {
                self.GetState("Up").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Down").GetAction<Wait>().time.Value = 0.5f;
            }
            if (self.gameObject.name.Contains("Worm") && self.FsmName == "damages_enemy")
            {
                self.FsmVariables.GetFsmInt("damageDealt").Value = 9999;
            }
            //飞刺虫
            if (self.gameObject.name.Contains("Acid Flyer") && self.FsmName == "Acid Flyer")
            {
                self.GetComponent<HealthManager>().hp = 45;
            }
            //游刺虫
            if (self.gameObject.name.Contains("Acid Walker") && self.FsmName == "Acid Walker")
            {
                self.GetComponent<HealthManager>().hp = 45;
            }
            //吐绿球
            if (self.gameObject.name.Contains("Plant Turret") && self.FsmName == "Plant Turret")
            {
                self.GetState("Idle Anim").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shot Pause").GetAction<WaitRandom>().timeMax.Value = 0.3f;
                self.GetState("Shot Pause").GetAction<WaitRandom>().timeMin.Value = 0.2f;
                self.GetState("Return Pause").GetAction<Wait>().time.Value = 0.2f;
                self.GetComponent<HealthManager>().hp = 15;
            }
            //吐炸弹
            if (self.gameObject.name.Contains("Mushroom Turret") && self.FsmName == "Shroom Turret")
            {
                self.GetState("First Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("First Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 2f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 1f;
                self.GetComponent<HealthManager>().hp = 30;
            }
            //感染苔藓胖胖
            if (self.gameObject.name.Contains("Moss Knight Fat") && self.FsmName == "Attack")
            {
                self.GetComponent<HealthManager>().hp = 50;
            }
            //水晶激光虫
            if (self.gameObject.name.Contains("Crystallised Lazer Bug") && self.FsmName == "Laser Bug")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Beam").GetAction<Wait>().time.Value = 3f;
                self.GetComponent<HealthManager>().hp = 20;
            }
            //兄弟
            if (self.gameObject.name.Contains("Shade Sibling") && self.FsmName == "Control")
            {
                self.GetState("Idle").GetAction<IdleBuzzV3>().waitMax.Value = 0.5f;
                self.GetState("Idle").GetAction<IdleBuzzV3>().waitMin.Value = 0.25f;
                self.GetState("Idle").GetAction<IdleBuzzV3>().roamingRangeX.Value = 10;
                self.GetState("Idle").GetAction<IdleBuzzV3>().roamingRangeY.Value = 10;
                self.GetState("Chase").GetAction<RandomFloat>().max.Value = 10;
                self.GetState("Chase").GetAction<RandomFloat>().min.Value = 7;

                self.GetComponent<HealthManager>().hp = 40;
            }
            //召唤兄弟
            if (self.gameObject.name.Contains("Shade Sibling Spawner") && self.FsmName == "Spawn")
            {
                self.FsmVariables.FindFsmFloat("Spawn Time").Value = 0.1f;
                self.GetState("Check").GetAction<IntCompare>().integer2.Value = 10;
                self.GetState("Spawn").GetAction<RandomFloat>().max.Value = 1;
                self.GetState("Spawn").GetAction<RandomFloat>().min.Value = 0.5f;
            }
        }
        //补充2
        public void Process_PlayerMakerFSM_OtherEnemy2(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //安息之地鬼魂
            if (self.gameObject.name.Contains("Ghost Battle Revek") && self.FsmName == "Control")
            {
                self.GetState("Appear Pause").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Attack Pause").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Slash Idle").GetAction<WaitRandom>().timeMax.Value = 0.25f;
                self.GetState("Slash Idle").GetAction<WaitRandom>().timeMin.Value = 0.25f;
                self.GetState("Damaged Pause").GetAction<WaitRandom>().timeMin.Value = 1.5f;
                self.GetState("Damaged Pause").GetAction<WaitRandom>().timeMax.Value = 1.5f;
            }
            //水晶山峰激光
            if (self.gameObject.name.Contains("Laser Turret") && self.FsmName == "Laser Bug")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.FsmVariables.FindFsmFloat("Idle Time").Value = 0.1f;
            }
            //水晶山峰压路机
            if (self.gameObject.name.Contains("mines_stomper") && self.FsmName == "Spike Hit Effect")
            {
                self.GetState("Pause").GetAction<Wait>().time.Value = 0f;
            }
            //翅膀傀儡
            if (self.gameObject.name.Contains("White Palace Fly") && self.FsmName == "Control")
            {
                self.GetState("Idle").GetAction<IdleBuzz>().speedMax.Value = 0;
                self.GetState("Idle").GetAction<IdleBuzz>().accelerationMax.Value = 0;
                self.GetState("Idle").GetAction<IdleBuzz>().roamingRange.Value = 0;

                self.GetState("Wound").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wait").GetAction<iTweenMoveTo>().time.Value = 0.1f;
            }
            //竞技场左特
            if (self.gameObject.scene.name == "Room_Colosseum_Bronze" && self.gameObject.name.Contains("Zote Boss") && self.FsmName == "Control") 
            {
                self.GetState("Fall Over").GetAction<WaitRandom>().timeMin.Value = 0.25f;
                self.GetState("Fall Over").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Roar?").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Roar Recover").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;               
            }
            //竞技场左特笼子
            if (self.gameObject.name == "Colosseum Cage Zote" && self.FsmName == "Control")
            {
                self.GetState("Shake 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Open").GetAction<Wait>().time.Value = 0.1f;
            }
        }
        #endregion
        //竞技场战斗
        public void Colosseum_Battle(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            if (self.gameObject.name.Contains("Colosseum Manager") && self.FsmName == "Manager")
            {
                self.GetState("Init Cheer").GetAction<SendEventByName>(0).delay.Value = 0.5f;
                self.GetState("Init Cheer").GetAction<SendEventByName>(1).delay.Value = 0.5f;
                self.GetState("Init Cheer").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Extra Title Pause").GetAction<Wait>().time.Value = 1f;
                self.GetState("Extra Title Pause").GetAction<SendEventByName>(1).delay.Value = 0f;
                self.GetState("Extra Title Pause").GetAction<SendEventByName>(2).delay.Value = 0f;
                self.GetState("Start Pause").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Reward Cheer").GetAction<Wait>().time.Value = 0.5f;
            }
            if (self.gameObject.name.Contains("Colosseum Manager") && self.FsmName == "Geo Pool")
            {
                //竞技场1
                if (self.gameObject.scene.name == "Room_Colosseum_Bronze")
                {
                    self.GetState("Spawn").GetAction<WaitRandom>().timeMax.Value = 0.005f;
                    self.GetState("Spawn").GetAction<WaitRandom>().timeMin.Value = 0.005f;
                    self.GetState("Geo Given Pause").GetAction<Wait>().time.Value = 0f;
                }
                //竞技场2
                if (self.gameObject.scene.name == "Room_Colosseum_Silver")
                {
                    self.GetState("Spawn").GetAction<WaitRandom>().timeMax.Value = 0.005f;
                    self.GetState("Spawn").GetAction<WaitRandom>().timeMin.Value = 0.005f;
                    self.GetState("Geo Given Pause").GetAction<Wait>().time.Value = 0f;
                }
                //竞技场3
                if (self.gameObject.scene.name == "Room_Colosseum_Gold")
                {
                    self.GetState("Spawn").GetAction<WaitRandom>().timeMax.Value = 0.005f;
                    self.GetState("Spawn").GetAction<WaitRandom>().timeMin.Value = 0.005f;
                    self.GetState("Geo Given Pause").GetAction<Wait>().time.Value = 0f;
                    self.FsmVariables.FindFsmInt("Pool Min").Value = 4500;
                    self.FsmVariables.FindFsmInt("Starting Pool").Value = 5000;
                }
            }
            if (self.gameObject.name.Contains("Colosseum Manager") && self.FsmName == "Battle Control")
            {
                //竞技场1
                if (self.gameObject.scene.name == "Room_Colosseum_Bronze")
                {
                    self.GetState("Wave 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 3").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Reset").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 5").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 6").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 7").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 3").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 3").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 3").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 4").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 4").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 4").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Arena 4").GetAction<SendEventByName>(7).delay.Value = 0f;
                    self.GetState("Arena 4").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Reset 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 6").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 6").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Arena 6").GetAction<SendEventByName>(7).delay.Value = 0f;
                    self.GetState("Arena 6").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 7").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("State 1").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 14").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Pause 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Pause 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 3").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 17").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 17").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 18").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 18").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 19").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 19").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 20").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 20").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 21").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 21").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 22").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 8").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 8").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 23").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 24").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Gruz Arena").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Gruz Arena").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Gruz Arena").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Gruz Arena").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 27").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 28").GetAction<SendEventByName>(2).delay.Value = 3f;
                    self.GetState("Wave 28").GetAction<SendEventByName>(4).delay.Value = 3.5f;
                    self.GetState("Final Reset").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Final Reset").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Zote Pause").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 29 Zote").GetAction<SendEventByName>(1).delay.Value = 0f;

                }
                //竞技场2
                if (self.gameObject.scene.name == "Room_Colosseum_Silver")
                {
                    self.GetState("Wave 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 3").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Spikes").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Spikes").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 3").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 3").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 4").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 4").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 4").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 12").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Wave 13").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Reset 1").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Reset 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Hopper Arena").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Hopper Arena").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Hopper Arena").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Hopper Arena").GetAction<SendEventByName>(7).delay.Value = 0f;
                    self.GetState("Hopper Arena").GetAction<SendEventByName>(8).delay.Value = 0f;
                    self.GetState("Hopper Arena").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 30").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 31").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Hoppering").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 32").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 8").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 8").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 8").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Cheer 1").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Cheer 1").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Cheer 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 5").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 5").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 5").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Arena 5").GetAction<Wait>().time.Value = 0.5f;

                    self.GetState("Wave 20").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Wave 20").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 20").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Cheer").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Cheer").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 6").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 6").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 6").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 22").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Wave 23").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Wave 24").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 7").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 7").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 7").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 26").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Spikes 2").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Spikes 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 27").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Wave 28").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Wave 29").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Reset 3").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Reset 3").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Reset 3").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Reset 3").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 9").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Arena 9").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 9").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 9").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Arena 9").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 35").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Reset 4").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Reset 4").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena 9 Obble").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena 9 Obble").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena 9 Obble").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Spikes Up Obble").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Spikes Up Obble").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 4 Obble").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Reset 4 Obble").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Reset 4 Obble").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Reset 4 Obble").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena Final Obble").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena Final Obble").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Final Reset").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Final Reset").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("End Pause").GetAction<Wait>().time.Value = 0.5f;

                    self.GetState("Wave 17").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 18").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Wave 19").GetAction<SendEventByName>().delay.Value = 0f;

                }
                //竞技场3
                if (self.gameObject.scene.name == "Room_Colosseum_Gold")
                {
                    self.GetState("Wave 2").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 5").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Wave 5").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Ceiling 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 6").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Reset 1").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Reset 1").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Reset 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC 6").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 2").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Reset 2").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Reset 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena ColHopper").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena ColHopper").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Arena ColHopper").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 3").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena Totem").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena Totem").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena Totem").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Garpedes 1").GetAction<Wait>().time.Value = 5f;
                    self.GetState("Reset 4").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Reset 4").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Reset 4").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC 1").GetAction<Wait>().time.Value = 0.5f;
                    
                    self.GetState("Mage Suite Pause").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("w23 Pause").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 24").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 24").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Wave 24").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC 5").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Arena Mage").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena Mage").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena Mage").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Arena Mage").GetAction<SendEventByName>(14).delay.Value = 0f;
                    self.GetState("Arena Mage").GetAction<SendEventByName>(15).delay.Value = 0f;
                    self.GetState("Arena Mage").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("w26 Pause").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 26").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("w27 Pause").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("w28 Pause").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 5").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Reset 5").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Reset 5").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Reset 5").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 29").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Wave 29").GetAction<SendEventByName>(6).delay.Value = 0f;
                    self.GetState("Wave 30").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Wave 30").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Wave 30").GetAction<SendEventByName>(6).delay.Value = 0f;
                    self.GetState("Wave 30").GetAction<SendEventByName>(9).delay.Value = 0f;
                    self.GetState("Wave 31").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 32").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 33").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 33").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Walls In").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Walls In").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Walls In").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC Pause 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC 7").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Spike Pit").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Spike Pit").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Spike Pit").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Spikes 2").GetAction<SendEventByName>(0).delay.Value = 0f;
                    self.GetState("Spikes 2").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Spikes 2").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("GC 3").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 35").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 38").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 39").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Wave 39").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Wave 39").GetAction<SendEventByName>(6).delay.Value = 0f;
                    self.GetState("Wave 40").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("Arena Barrage").GetAction<SendEventByName>(1).delay.Value = 0f;
                    self.GetState("Arena Barrage").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Arena Barrage").GetAction<SendEventByName>(3).delay.Value = 0f;
                    self.GetState("Arena Barrage").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Arena Barrage").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Arena Barrage").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Reset 6").GetAction<SendEventByName>(4).delay.Value = 0f;
                    self.GetState("Reset 6").GetAction<SendEventByName>(5).delay.Value = 0f;
                    self.GetState("Reset 6").GetAction<Wait>().time.Value = 0.5f;

                    self.GetState("GC 4").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Wave 46").GetAction<SendEventByName>(6).delay.Value = 0f;
                    self.GetState("Wave 46").GetAction<SendEventByName>(7).delay.Value = 0f;
                    self.GetState("Wave 48").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 49").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Wave 50").GetAction<SendEventByName>(2).delay.Value = 0f;
                    self.GetState("Lancer Pause").GetAction<Wait>().time.Value = 1f;
                    self.GetState("Lancer Shake 1").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Final Reset").GetAction<Wait>().time.Value = 0.5f;
                    self.GetState("Final Reset").GetAction<SendEventByName>().delay.Value = 0f;
                    self.GetState("End Pause").GetAction<Wait>().time.Value = 0.5f;

                }
            }
        }

        //无fsm的小怪
        public void Enemy_NoFSM()
        {
            //小白爬虫
            On.Climber.Start += (orig, self) =>
            {
                orig(self);
                if (!AllHallownestEnhanced.settings_.on)
                    return;
                if (!AllHallownestEnhanced.settings_.EnhanceEnemy)
                    return;
                self.GetComponent<HealthManager>().hp = 12;
            };
            //小蘑菇爬爬
            //if (self.gameObject.name.Contains("Fung Crawler"))
            //{
            //    self.GetComponent<HealthManager>().hp = 18;
            //}
            //深渊小爬虫
            //if (self.gameObject.name.Contains(""))
            //{
            //    self.GetComponent<HealthManager>().hp = 30;
            //}

        }
    }
}
