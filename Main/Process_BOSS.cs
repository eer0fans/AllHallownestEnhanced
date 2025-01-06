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
using System.IO;

namespace AllHallownestEnhanced
{
    public class Process_BOSS : SingletonBase<Process_BOSS>
    {
        #region 流程BOSS

        #region 一门
        //格鲁滋之母
        public void Process_PlayMakerFSM_Gruz_Mother(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if ((self.gameObject.name == "Giant Fly" || self.gameObject.name == "Giant Fly Col(Clone)") && self.FsmName == "Big Fly Control")
            {
                Modding.Logger.Log("流程——格鲁兹");
                if (self.gameObject.name == "Giant Fly")//流程特有 竞技场中没有的
                {
                    //jiou300
                    self.GetComponent<HealthManager>().SetGeoLarge(5);
                    self.GetComponent<HealthManager>().SetGeoMedium(25);
                    self.GetComponent<HealthManager>().SetGeoSmall(50);

                }
                self.GetState("Fly").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Buzz").GetAction<RandomFloat>().max.Value = 1.4f;
                self.GetState("Buzz").GetAction<RandomFloat>().min.Value = 1;
                self.GetState("Super Choose").GetAction<SendRandomEventV2>().weights = new FsmFloat[2] { 2, 1 };
                self.GetState("Super Choose").GetAction<SendRandomEventV2>().eventMax = new FsmInt[2] { 3, 1 };

                self.GetState("Go Left").GetAction<SetFloatValue>(0).floatValue.Value = 110;
                self.GetState("Go Left").GetAction<SetFloatValue>(1).floatValue.Value = 250;
                self.GetState("Go Right").GetAction<SetFloatValue>(0).floatValue.Value = 70;
                self.GetState("Go Right").GetAction<SetFloatValue>(1).floatValue.Value = 290;

                self.GetState("Turn Left").GetAction<SetFloatValue>(1).floatValue.Value = 110;
                self.GetState("Turn Left").GetAction<SetFloatValue>(2).floatValue.Value = 250;
                self.GetState("Turn Right").GetAction<SetFloatValue>(1).floatValue.Value = 70;
                self.GetState("Turn Right").GetAction<SetFloatValue>(2).floatValue.Value = 290;

                self.GetComponent<HealthManager>().hp = 400;
            }

        }

        //反击鹰
        public void Process_PlayMakerFSM_Big_Buzzer(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if ((self.gameObject.name == "Giant Buzzer" || self.gameObject.name == "Giant Buzzer Col") && self.FsmName == "Big Buzzer")
            {
                Modding.Logger.Log("流程——反击蝇");
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 1.5f;

                self.GetComponent<HealthManager>().hp = 250;
                if (self.gameObject.name == "Giant Buzzer" && !self.gameObject.scene.name.Contains("Colosseum")) 
                {
                    //jiou250
                    self.GetComponent<HealthManager>().SetGeoLarge(5);
                    self.GetComponent<HealthManager>().SetGeoMedium(15);
                    self.GetComponent<HealthManager>().SetGeoSmall(50);
                }
                else
                {
                    self.GetComponent<HealthManager>().SetGeoLarge(0);
                    self.GetComponent<HealthManager>().SetGeoMedium(0);
                    self.GetComponent<HealthManager>().SetGeoSmall(0);
                }

            }

        }

        //假骑士
        public void Process_PlayMakerFSM_FalseKnight(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "False Knight New" && self.FsmName == "FalseyControl")
            {
                Modding.Logger.Log("流程——假骑士");
                self.ChangeTransition("Music", "FINISHED", "Idle");
                self.ChangeTransition("Move Choice", "JUMP", "S Check Hero Pos");
                self.CreateState("Check Jump?");
                self.ChangeTransition("S Antic", "FINISHED", "Check Jump?");
                self.GetState("Check Jump?").AddMethod(() =>
                {
                    Transform player = GameObject.Find("Knight").transform;
                    if ((self.transform.position.x < 20 && player.transform.position.x < self.transform.position.x)
                    || (self.transform.position.x > 35 && player.transform.position.x > self.transform.position.x))
                    {
                        //太靠左或右就后跳
                        self.SetState("Check Jump Dir");
                    }
                    else
                    {
                        self.SetState("Voice? 2");
                    }
                });

                self.GetState("First Idle").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("S Attack Antic").GetAction<Wait>().time.Value = 0.75f;
                self.GetState("Idle Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rage End").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("To Phase 2").GetAction<SetFloatValue>(0).floatValue.Value = 0.1f;
                self.GetState("To Phase 2").GetAction<SetFloatValue>(1).floatValue.Value = 0.1f;
                self.GetState("To Phase 3").GetAction<SetFloatValue>(0).floatValue.Value = 0.1f;
                self.GetState("To Phase 3").GetAction<SetFloatValue>(1).floatValue.Value = 0.1f;

                self.FsmVariables.FindFsmInt("Jump Barrel Min").Value = 2;
                self.FsmVariables.FindFsmInt("Jump Barrel Max").Value = 3;
                self.FsmVariables.FindFsmInt("Slam Barrel Min").Value = 3;
                self.FsmVariables.FindFsmInt("Slam Barrel Max").Value = 4;
                self.GetState("To Phase 2").GetAction<SetIntValue>(2).intValue.Value = 2;
                self.GetState("To Phase 2").GetAction<SetIntValue>(3).intValue.Value = 3;
                self.GetState("To Phase 2").GetAction<SetIntValue>(4).intValue.Value = 3;
                self.GetState("To Phase 2").GetAction<SetIntValue>(5).intValue.Value = 4;
                self.GetState("To Phase 3").GetAction<SetIntValue>(2).intValue.Value = 2;
                self.GetState("To Phase 3").GetAction<SetIntValue>(3).intValue.Value = 3;
                self.GetState("To Phase 3").GetAction<SetIntValue>(4).intValue.Value = 3;
                self.GetState("To Phase 3").GetAction<SetIntValue>(5).intValue.Value = 4;

                self.GetComponent<HealthManager>().hp = 140;
            }

        }

        //苔藓冲锋者
        public void Process_PlayMakerFSM_Moss_Charger(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mega Moss Charger" && self.FsmName == "Mossy Control")
            {
                Modding.Logger.Log("流程——草团子");
                self.GetState("Shake").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Roar").GetAction<Wait>().time.Value = 0.5f;

                self.GetState("Submerge CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Emerge Pause").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Emerge Pause").GetAction<WaitRandom>().timeMin.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 480;
            }

        }

        //小姐姐
        public void Process_PlayMakerFSM_Hornet(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Hornet Boss 1" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——一见");
                //贴图
                Texture2D texture2D;
                var stream = typeof(AllHallownestEnhanced).Assembly.GetManifestResourceStream("AllHallownestEnhanced.Res.hornet.png");
                MemoryStream memoryStream = new MemoryStream((int)stream.Length);
                stream.CopyTo(memoryStream);
                stream.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();
                texture2D = new Texture2D(0, 0);
                texture2D.LoadImage(bytes, true);
                self.GetComponent<tk2dSprite>().CurrentSprite.material.mainTexture = texture2D;


                self.ChangeTransition("GG Music", "FINISHED", "Sphere Antic G");
                self.ChangeTransition("Dmg Response", "IDLE", "G Sphere?");
                self.ChangeTransition("After Evade", "IDLE", "G Sphere?");
                self.ChangeTransition("Throw Recover", "FINISHED", "G Sphere?");
                self.ChangeTransition("Sphere Recover", "FINISHED", "G Sphere?");
                self.ChangeTransition("GDash Recover2", "FINISHED", "G Sphere?");
                self.ChangeTransition("Hard Land", "FINISHED", "G Sphere?");
                self.ChangeTransition("Land", "FINISHED", "G Sphere?");
                self.ChangeTransition("Hit Roof", "FINISHED", "G Sphere?");
                self.ChangeTransition("Can Throw?", "CAN THROW", "Move Choice B");

                self.ChangeTransition("Hard Land", "FINISHED", "Run");
                self.ChangeTransition("Dmg Response", "IDLE", "G Sphere?");

                self.FsmVariables.FindFsmFloat("A Dash Speed").Value = 35;
                self.FsmVariables.FindFsmFloat("G Dash Speed").Value = -30;
                self.GetState("Jump").GetAction<RandomFloat>().min.Value = 50f;
                self.GetState("Jump").GetAction<RandomFloat>().max.Value = 50f;
                self.FsmVariables.FindFsmFloat("Gravity").Value = 2.5f;
                self.GetState("Sphere").GetAction<Wait>().time.Value = 0.7f;
                self.GetState("Sphere A").GetAction<Wait>().time.Value = 0.7f;
                
                self.GetComponent<HealthManager>().hp = 600;
            }
            if (self.gameObject.name == "Hornet Boss 1" && self.FsmName == "Stun Control")
            {
                self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
            }
        }


        //戈布
        public void Process_PlayMakerFSM_Gorb(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Ghost Warrior Slug" && self.FsmName == "Attacking")
            {
                Modding.Logger.Log("流程——戈布");
                self.CopyState("Attack", "CopyAttack");
                self.CopyState("Double", "CopyDouble");
                self.CopyState("Triple", "CopyTriple");
                self.ChangeTransition("CopyAttack", "FINISHED", "CopyDouble");
                self.ChangeTransition("CopyDouble", "FINISHED", "CopyTriple");
                self.ChangeTransition("CopyTriple", "FINISHED", "Recover");

                self.ChangeTransition("Wait", "FINISHED", "Antic");
                self.ChangeTransition("Double?", "DOUBLE", "Double");
                self.ChangeTransition("Double?", "FINISHED", "Anim");
                self.ChangeTransition("Triple?", "TRIPLE", "CopyAttack");
                self.ChangeTransition("Triple?", "FINISHED", "Anim");

                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 1f;

            }
            if (self.gameObject.name == "Ghost Warrior Slug" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 800;
                self.FsmVariables.FindFsmInt("Level 2").Value = 800;
                self.FsmVariables.FindFsmInt("Level 3").Value = 800;
                self.FsmVariables.FindFsmInt("Level 4").Value = 800;
                self.FsmVariables.FindFsmInt("Level 5").Value = 800;
            }
        }

        //芬达
        public void Process_PlayMakerFSM_DungDefender(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Dung Defender" && self.FsmName == "Dung Defender")
            {
                Modding.Logger.Log("流程——芬达");
                self.GetState("GG Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wake").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wake").GetAction<SetFloatValue>().floatValue.Value = 0.1f;

                self.ChangeTransition("Tunneling L", "QUAKE FALL END", "Erupt Antic R");
                self.ChangeTransition("Tunneling R", "QUAKE FALL END", "Erupt Antic R");
                self.ChangeTransition("RJ In Air", "HIT UP", "RJ In Air");
                self.ChangeTransition("RJ In Air", "HIT LEFT", "RJ In Air");
                self.ChangeTransition("RJ In Air", "HIT RIGHT", "RJ In Air");

                self.GetState("Timer").GetAction<SetFloatValue>(1).floatValue.Value = 25;
                self.GetState("Set Rage").GetAction<SetFloatValue>(3).floatValue.Value = 30;
                self.GetState("Rage In").GetAction<SetFloatValue>(7).floatValue.Value = 0.2f;
                self.GetState("Rage In").GetAction<SetFloatValue>(8).floatValue.Value = 40;
                self.FsmVariables.FindFsmFloat("Dolphin Speed").Value = 15;
                self.ChangeTransition("After Throw?", "DIVE IN", "Timer");
                self.GetState("Dolph Dives").GetAction<RandomInt>().min.Value = 1;
                self.GetState("Dolph Dives").GetAction<RandomInt>().max.Value = 2;
                self.GetState("Roll Speed").GetAction<FloatAdd>().add.Value = 12;
                self.GetState("Roll Speed").GetAction<FloatCompare>().float2.Value = 24;
                self.GetState("Roll Speed").GetAction<SetFloatValue>().floatValue.Value = 12;


                self.GetState("Idle").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("To Dolph Pause").GetAction<Wait>().time.Value = 0;
                self.GetState("Set Throws").GetAction<RandomInt>().max.Value = 5;
                self.GetState("DT Set").GetAction<SetIntValue>().intValue.Value = 3;
                self.GetState("TD Set").GetAction<SetIntValue>().intValue.Value = 3;
                self.GetState("RJ Set").GetAction<SetIntValue>().intValue.Value = 4;
                self.ChangeTransition("Throw Antic 2", "FINISHED", "Throw 1");
            }
            if (self.gameObject.name == "Dung Defender" && self.FsmName == "Stun")
            {
                self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
            }
            if (self.gameObject.name.Contains("Dung Ball Small") && self.FsmName == "Ball Control")
            {
                self.transform.localScale = Vector3.one * 1.2f;
            }
            if (self.gameObject.name == "Dung Defender" && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 2").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 3").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 4").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 5").Value = 1000;
            }

        }


        //灵魂战士
        public void Process_PlayMakerFSM_SoulWarrior(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mage Knight" && self.FsmName == "Mage Knight")
            {
                Modding.Logger.Log("流程——灵魂战士");
                self.ChangeTransition("Stomp Recover", "FINISHED", "Shoot Aim");
                self.ChangeTransition("Slash Recover", "FINISHED", "Move Decision");
                
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0;
                //self.GetState("Shoot CD").GetAction<Wait>().time.Value = 0;
                self.GetState("Evade Recover").GetAction<Wait>().time.Value = 0;

                self.GetComponent<HealthManager>().hp = 600;
                if (!self.gameObject.scene.name.Contains("Colosseum"))//竞技场中不刷钱
                {
                    //jiou350
                    self.GetComponent<HealthManager>().SetGeoLarge(7);
                    self.GetComponent<HealthManager>().SetGeoMedium(25);
                    self.GetComponent<HealthManager>().SetGeoSmall(50);
                }
                else
                {
                    self.GetComponent<HealthManager>().SetGeoLarge(0);
                    self.GetComponent<HealthManager>().SetGeoMedium(0);
                    self.GetComponent<HealthManager>().SetGeoSmall(0);
                }
            }
        }


        //电饭煲
        public void Process_PlayMakerFSM_Brooding_Mawlek(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if ((self.gameObject.name == "Mawlek Body" || self.gameObject.name == "Mawlek Col(Clone)") && self.FsmName == "Mawlek Control")
            {
                Modding.Logger.Log("流程——毛里克");
                if (self.gameObject.name == "Mawlek Body")
                {
                    self.ChangeTransition("Title", "FINISHED", "Music");
                }

                self.GetState("Shoot").GetAction<SetFloatValue>().floatValue.Value = 0.5f;
                self.GetState("Land 2").GetAction<SetFloatValue>().floatValue.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Land 2").GetAction<Wait>().time.Value = 0.1f;

                self.GetComponent<HealthManager>().hp = 750;
            }

            if (self.gameObject.name == "Mawlek Head" && self.FsmName == "Mawlek Head")
            {
                self.GetState("Idle").GetAction<RandomFloat>().min.Value = 0.15f;
                self.GetState("Idle").GetAction<RandomFloat>().max.Value = 0.2f;
                self.GetState("Shoot").GetAction<Wait>().time.Value = 0.1f;
            }
        }
        #endregion


        #region 二门
        //泽若
        public void Process_PlayMakerFSM_Xero(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Ghost Warrior Xero" && self.FsmName == "Attacking")
            {
                Modding.Logger.Log("神居——泽若");
                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 0.75f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 0.75f;
                self.GetState("Wait Rage").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Wait Rage").GetAction<WaitRandom>().timeMax.Value = 0.5f;
                self.GetState("Recover").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Summon Antic").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Summon").GetAction<Wait>().time.Value = 0.25f;
            }

            if (self.gameObject.name == "Ghost Warrior Xero" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 800;
                self.FsmVariables.FindFsmInt("Level 2").Value = 800;
                self.FsmVariables.FindFsmInt("Level 3").Value = 800;
                self.FsmVariables.FindFsmInt("Level 4").Value = 800;
                self.FsmVariables.FindFsmInt("Level 5").Value = 800;
            }
        }

        //水晶守卫
        public void Process_PlayMakerFSM_CrystalDefender(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mega Zombie Beam Miner (1)" && self.FsmName == "Beam Miner")
            {
                Modding.Logger.Log("流程——水晶守卫");
                self.CopyState("Lasers", "CopyLasers");
                self.CopyState("Lasers", "CopyLasers 2");
                self.ChangeTransition("Roar End", "FINISHED", "Choice");
                self.ChangeTransition("Choice", "ROAR", "Aim Jump");
                self.ChangeTransition("Land", "FINISHED", "CopyLasers");
                self.ChangeTransition("CopyLasers", "FINISHED", "Choice");
                self.ChangeTransition("Beam Recover", "FINISHED", "CopyLasers 2");
                self.ChangeTransition("CopyLasers 2", "FINISHED", "Choice");

                self.GetState("Beam Antic").GetAction<Wait>().time.Value = 0.6f;

                self.GetComponent<HealthManager>().hp = 650;
            }
        }

        //灵魂大师
        public void Process_PlayMakerFSM_MageLord(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mage Lord" && self.FsmName == "Mage Lord")
            {
                Modding.Logger.Log("流程——灵魂大师");
                self.GetState("Roar").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Roar End").GetAction<Wait>().time.Value = 0f;

                self.CopyState("HS Summon", "Copy HS Summon");
                self.CopyState("HS Orb", "Copy HS Orb");
                //无idle
                self.ChangeTransition("Roar End", "FINISHED", "Tele Spinner X");
                self.ChangeTransition("After Tele", "IDLE", "Shot Antic");
                self.ChangeTransition("Next?", "FINISHED", "Attack Choice");

                //合二为一
                self.ChangeTransition("After Tele", "CHARGE", "Copy HS Summon");
                self.ChangeTransition("Copy HS Summon", "FINISHED", "Copy HS Orb");
                self.ChangeTransition("Copy HS Orb", "FINISHED", "Charge Dir");
                self.ChangeTransition("Charge Stop", "FINISHED", "HS Tele Out");
                self.ChangeTransition("HS Orb", "FINISHED", "Charge Dir");
               
                self.GetState("HS Ret Left").GetAction<AccelerateVelocity>().xAccel.Value = -0.6f;
                self.GetState("HS Ret Left").GetAction<AccelerateVelocity>().xMaxSpeed.Value = 30f;
                self.GetState("HS Ret Left").GetAction<Wait>().time.Value = 1.65f;
                self.GetState("Hs Ret Right").GetAction<AccelerateVelocity>().xAccel.Value = 0.6f;
                self.GetState("Hs Ret Right").GetAction<AccelerateVelocity>().xMaxSpeed.Value = 30f;
                self.GetState("Hs Ret Right").GetAction<Wait>().time.Value = 1.65f;

                //攻击
                self.GetState("Shot Antic").GetAction<Wait>().time.Value = 0.35f;
                self.GetState("Quake Waves").GetAction<Wait>().time.Value = 1f;

                self.GetComponent<HealthManager>().hp = 800;
            }
            if (self.gameObject.name == "Mage Lord Phase2" && self.FsmName == "Mage Lord 2")
            {
                self.GetState("Arrive Pause").GetAction<Wait>().time.Value = 1f;

                self.GetState("Shot Antic").GetAction<Wait>().time.Value = 0.3f;
                self.GetState("Shot Antic").GetAction<SetIntValue>(4).intValue.Value = 7;
                self.GetState("Shot Antic").GetAction<RandomInt>(5).min.Value = 5;
                self.GetState("Shot Antic").GetAction<RandomInt>(5).max.Value = 5;
                self.GetState("Orb Summon").GetAction<Wait>().time.Value = 0.65f;
                self.GetState("Spawn Fireball").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Shot CD").GetAction<Wait>().time.Value = 0f;
                self.FsmVariables.FindFsmFloat("Quake Speed").Value = -75;

                self.GetState("Shift?").GetAction<RandomFloat>().min.Value = -4f;
                self.GetState("Shift?").GetAction<RandomFloat>().max.Value = 4f;
                self.GetState("Quake Land").GetAction<Wait>().time.Value = 0.5f;

                self.GetComponent<HealthManager>().hp = 350;
            }
            if (self.gameObject.name == "Mage Lord" && self.FsmName == "Stun")
            {
                self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
            }
        }

        //奥波路波
        public void Process_PlayMakerFSM_Oblobbles(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if ((self.gameObject.name == "Mega Fat Bee (1)" || self.gameObject.name == "Mega Fat Bee")
                && self.FsmName == "Fatty Fly Attack")
            {
                Modding.Logger.Log("流程——奥波路波");
                self.CopyState("Attack", "Copy Attack");
                self.CopyState("Attack 2", "Copy Attack 2");

                self.ChangeTransition("Copy Attack", "FINISHED", "Attack Check");
                self.ChangeTransition("Copy Attack 2", "FINISHED", "Attack 2");
                self.GetState("Attack").AddMethod(() =>
                {
                    self.SetState("Copy Attack 2");
                });
                self.GetState("Attack 2").AddMethod(() =>
                {
                    self.SetState("Copy Attack");
                });

                self.GetComponent<HealthManager>().hp = 500;
            }
        }

        //三螳螂
        public void Process_PlayMakerFSM_MantisLord(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mantis Lord" && self.FsmName == "Mantis Lord")
            {
                Modding.Logger.Log("流程——三螳螂1");
                self.ChangeTransition("Start Pause", "FINISHED", "Attack Choice");
                self.ChangeTransition("Throw", "FINISHED", "Leave Pause");
                self.ChangeTransition("Throw 2", "FINISHED", "Leave Pause");
                self.ChangeTransition("After Throw Pause", "FINISHED", "Attack Choice");
                self.ChangeTransition("Away", "FINISHED", "Attack Choice");

                self.GetComponent<HealthManager>().hp = 400;
            }
            if (self.gameObject.name == "Mantis Lord S1" && self.FsmName == "Mantis Lord")
            {
                Modding.Logger.Log("流程——三螳螂2");
                self.ChangeTransition("Start Pause", "FINISHED", "Attack Choice");
                self.ChangeTransition("Throw", "FINISHED", "Leave Pause");
                self.ChangeTransition("Throw 2", "FINISHED", "Leave Pause");
                self.ChangeTransition("After Throw Pause", "FINISHED", "Attack Choice");
                self.ChangeTransition("Away", "FINISHED", "Attack Choice");

                self.GetComponent<HealthManager>().hp = 400;
            }
            if (self.gameObject.name == "Mantis Lord S2" && self.FsmName == "Mantis Lord")
            {
                Modding.Logger.Log("流程——三螳螂3");
                self.ChangeTransition("Start Pause", "FINISHED", "Sub Idle");
                self.ChangeTransition("Throw", "FINISHED", "Leave Pause");
                self.ChangeTransition("Throw 2", "FINISHED", "Leave Pause");
                self.ChangeTransition("After Throw Pause", "FINISHED", "Sub Idle");
                self.ChangeTransition("Away", "FINISHED", "Sub Idle");

                self.GetComponent<HealthManager>().hp = 400;
            }
        }

        //马尔姆
        public void Process_PlayMakerFSM_Marmu(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Ghost Warrior Marmu" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——马尔姆");
                self.ChangeTransition("Roll Warp?", "FINISHED", "Set Pos 2");
                self.ChangeTransition("Redo 2", "CANCEL", "Set Pos 2");

                self.GetState("Antic").GetAction<Wait>().time.Value = 0.35f;
            }
            if (self.gameObject.name == "Ghost Warrior Marmu" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 650;
                self.FsmVariables.FindFsmInt("Level 2").Value = 650;
                self.FsmVariables.FindFsmInt("Level 3").Value = 650;
                self.FsmVariables.FindFsmInt("Level 4").Value = 650;
                self.FsmVariables.FindFsmInt("Level 5").Value = 650;
            }
        }

        //白给之母
        public void Process_PlayMakerFSM_FlukeMarm(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Fluke Mother" && self.FsmName == "Fluke Mother")
            {
                Modding.Logger.Log("流程——吸虫");
                self.GetState("Delay Roar").GetAction<Wait>().time.Value = 0;
                self.GetState("Rage").GetAction<WaitRandom>().timeMax.Value = 1;
                self.GetState("Rage").GetAction<WaitRandom>().timeMin.Value = 1;

                self.GetComponent<HealthManager>().hp = 800;
            }

        }

        //残破容器
        public void Process_PlayMakerFSM_BrokenVessel(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Infected Knight" && self.FsmName == "Stun Control")
            {
                //self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
                self.FsmVariables.FindFsmInt("Stun Combo").Value = 12;
            }
            if (self.gameObject.name == "Infected Knight" && self.FsmName == "IK Control")
            {
                Modding.Logger.Log("流程——表哥");
                self.GetState("Roar").GetAction<Wait>().time.Value = 0.5f;
                
                self.ChangeTransition("First Counter", "FINISHED", "Set Dstab");
                self.ChangeTransition("Set Counter", "FINISHED", "Attack Choice");
                self.ChangeTransition("Dash Recover", "FINISHED", "Jump Antic");
                self.ChangeTransition("Ohead Recover", "FINISHED", "Attack Choice");
                self.ChangeTransition("Land", "FINISHED", "Attack Choice");
                self.ChangeTransition("Damage Response", "FINISHED", "Attack Choice");
                self.CreateState("After Dstab");
                self.ChangeTransition("Dstab Land", "FINISHED", "After Dstab");
                self.GetState("After Dstab").AddMethod(() =>
                {
                    float dis = CheckDistance(self.transform);
                    if (dis < 5f)
                    {
                        self.SetState("Ohead Slashing");
                    }
                    else
                    {
                        self.SetState("Attack Choice");
                    }
                });

                self.GetState("Ohead Antic").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Dash Antic 2").GetAction<Wait>().time.Value = 0.4f;
                self.GetState("Jump").GetAction<RandomFloat>().min.Value = 60f;
                self.GetState("Jump").GetAction<RandomFloat>().max.Value = 60f;
                self.FsmVariables.FindFsmFloat("Gravity").Value = 3.25f;
                self.GetComponent<HealthManager>().hp = 900;
            }
            if (self.gameObject.name == "Infected Knight" && self.FsmName == "Spawn Balloon")
            {
                self.FsmVariables.FindFsmFloat("Wait Max").Value = 2.5f;
                self.FsmVariables.FindFsmFloat("Wait Min").Value = 2.5f;
                self.GetState("Spawn").GetAction<IntCompare>(3).integer2 = 9999;
            }
        }

        //加利安
        public void Process_PlayMakerFSM_Galien(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            //小锤
            if (self.gameObject.name == "Ghost Warrior Galien" && self.FsmName == "Summon Minis")
            {
                self.CopyState("Summon", "Copy Summon");
                self.ChangeTransition("Init", "FINISHED", "Summon Antic");
                self.ChangeTransition("Summon", "FINISHED", "Copy Summon");
                self.ChangeTransition("Copy Summon", "FINISHED", "Summon 2");
            }
            //大锤
            if (self.gameObject.name == "Galien Hammer" && self.FsmName == "Attack")
            {
                self.GetState("Chase").GetAction<ChaseObjectGround>().acceleration.Value = 0.75f;
                self.GetState("Chase").GetAction<FloatTestToBool>().float2.Value = 9999f;
            }
            if (self.gameObject.name == "Galien Hammer" && self.FsmName == "Control")
            {
                self.GetState("Start Spin").GetAction<Wait>().time.Value = 0;
            }
            if (self.gameObject.name == "Ghost Warrior Galien" && self.FsmName == "Movement")
            {
                Modding.Logger.Log("流程——加利安");
                self.GetState("Warp In").GetAction<Wait>().time.Value = 0;
            }
            if (self.gameObject.name == "Ghost Warrior Galien" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 900;
                self.FsmVariables.FindFsmInt("Level 2").Value = 900;
                self.FsmVariables.FindFsmInt("Level 3").Value = 900;
                self.FsmVariables.FindFsmInt("Level 4").Value = 900;
                self.FsmVariables.FindFsmInt("Level 5").Value = 900;
            }
        }
        #endregion


        #region 三门
        //蜜蜂骑士
        public void Process_PlayMakerFSM_HiveKnight(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Hive Knight" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——蜂巢骑士");


                self.ChangeTransition("Activate", "FINISHED", "Phase 3");
                self.ChangeTransition("Dash End", "FINISHED", "Phase 3");
                self.ChangeTransition("Land", "FINISHED", "Phase 3");
                self.ChangeTransition("Glob Recover", "FINISHED", "Dash Antic");
                self.ChangeTransition("Roar Recover", "FINISHED", "Glob Antic 1");

                self.GetState("Glob Recover").GetAction<Wait>().time.Value = 0.35f;
            }
            if (self.gameObject.name == "Hive Knight" && self.FsmName == "Stun Control")
            {
                self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
            }
            if (self.gameObject.name == "Hive Knight" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 2").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 3").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 4").Value = 1000;
                self.FsmVariables.FindFsmInt("Level 5").Value = 1000;
            }
        }


        //胡长老
        public void Process_PlayMakerFSM_ElderHu(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Ghost Warrior Hu" && self.FsmName == "Attacking")
            {
                self.ChangeTransition("Set HP", "FINISHED", "Antic");

                self.ChangeTransition("M 9", "FINISHED", "M 2");
                self.ChangeTransition("M 8", "FINISHED", "Choose Pos");
                self.GetState("M 1").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 3").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 5").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 7").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 9").GetAction<Wait>().time.Value = 0.3f;
                self.GetState("M 2").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 4").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 6").GetAction<Wait>().time.Value = 0f;
                self.GetState("M 8").GetAction<Wait>().time.Value = 0.5f;

                self.GetState("M 1").AddMethod(() =>
                {
                    self.SetState("M 3");
                    self.SetState("M 5");
                    self.SetState("M 7");
                    self.SetState("M 9");
                });
                self.GetState("M 2").AddMethod(() =>
                {
                    self.SetState("M 4");
                    self.SetState("M 6");
                    self.SetState("M 8");
                });


                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 0.75f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 0.75f;
                self.GetState("Warp In").GetAction<Wait>().time.Value = 0.4f;
            }
            if (self.gameObject.name == "Ghost Warrior Hu" && self.FsmName == "Movement")
            {
                Modding.Logger.Log("流程——胡长老");
            }
            if (self.gameObject.name == "Ghost Warrior Hu" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 800;
                self.FsmVariables.FindFsmInt("Level 2").Value = 800;
                self.FsmVariables.FindFsmInt("Level 3").Value = 800;
                self.FsmVariables.FindFsmInt("Level 4").Value = 800;
                self.FsmVariables.FindFsmInt("Level 5").Value = 800;
            }
        }

        //收藏家
        public void Process_PlayMakerFSM_Collector(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            //加硬直次数
            if (self.gameObject.name == "Jar Collector" && self.FsmName == "Stun Control")
            {
                self.FsmVariables.FindFsmFloat("Combo Time").Value = 1;
                self.FsmVariables.FindFsmInt("Stun Combo").Value = 16;
                self.FsmVariables.FindFsmInt("Stun Hit Max").Value = 18;
            }
            //阶段
            if (self.gameObject.name == "Jar Collector" && self.FsmName == "Phase Control")
            {
                self.ChangeTransition("Set", "FINISHED", "Phase 2");
                self.ChangeTransition("Idle", "TOOK DAMAGE", "Phase 2");
            }
            //行为
            if (self.gameObject.name == "Jar Collector" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——收藏家");
                self.GetState("Roar Recover").GetAction<Wait>().time.Value = 0;
                //self.GetState("Roar").GetAction<Wait>().time.Value = 3f;

                self.ChangeTransition("Enemy Count", "MAX", "Move Choice None");
                self.ChangeTransition("Enemy Count", "FINISHED", "Move Choice None");
                self.ChangeTransition("Summon?", "CANCEL", "Spawn");

                self.GetState("Resummon Pause").GetAction<Wait>().time.Value = 0;
                self.GetState("Spawn Recover").GetAction<Wait>().time.Value = 0;

                self.GetState("Resummon?").RemoveAction(1);
                self.GetState("Resummon?").RemoveAction(0);
                self.GetState("Resummon?").InsertMethod(0, () =>
                {
                    self.GetState("Resummon?").GetAction<IntCompare>(2).integer2.Value = 6;
                    self.GetState("Resummon?").GetAction<IntCompare>(3).integer2.Value = 4;
                });
            }
            if (self.gameObject.name == "Jar Collector" && self.FsmName == "hp_scaler")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 1100;
                self.FsmVariables.FindFsmInt("Level 2").Value = 1100;
                self.FsmVariables.FindFsmInt("Level 3").Value = 1100;
                self.FsmVariables.FindFsmInt("Level 4").Value = 1100;
                self.FsmVariables.FindFsmInt("Level 5").Value = 1100;
            }
        }

        //神训
        public void Process_PlayMakerFSM_GodTamer(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            //坐骑
            if (self.gameObject.name == "Lobster" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——神训大虫");
                self.ChangeTransition("Wake", "FINISHED", "Attack Choice");
                self.ChangeTransition("RC Land", "FINISHED", "Spit Turn?");
                self.ChangeTransition("Spit Recover", "FINISHED", "Attack Choice");
                self.ChangeTransition("Attack Choice", "FINISHED", "Move Choice");
                //self.ChangeTransition("Move Choice", "BACK", "Attack Choice");

                self.FsmVariables.FindFsmFloat("Charge Speed").Value = -35;
                self.FsmVariables.FindFsmFloat("Scuttle Speed").Value = -8;
                self.GetComponent<HealthManager>().hp = 1000;
            }
            //骑士
            if (self.gameObject.name == "Lancer" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——小虫");
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.5f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 1;
                self.GetComponent<HealthManager>().hp = 500;
            }
        }

        //格林
        public void Process_PlayMakerFSM_Grim(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Grimm Boss" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——格林");
                self.GetState("Set 1").GetAction<SetHP>().hp.Value = 1000;
                self.GetState("Set 2").GetAction<SetHP>().hp.Value = 1000;
                self.GetState("Set 3").GetAction<SetHP>().hp.Value = 1000;
                self.GetState("Set 4").GetAction<SetHP>().hp.Value = 1000;
                self.GetState("Set 5").GetAction<SetHP>().hp.Value = 1000;

                //后撤步后正常
                self.ChangeTransition("Auto Evade?", "EVADE", "Slash Antic");
                self.ChangeTransition("After Evade", "FIREBATS", "Slash Antic");

                //2发火球后必闪
                self.ChangeTransition("Firebat 1", "FINISHED", "FB Behind");
                //闪后正常
                self.ChangeTransition("FB Re Tele", "FINISHED", "Balloon?");
                //升龙后地火
                self.ChangeTransition("Explode Pause", "FINISHED", "Balloon?");
                self.GetState("Explode Pause").GetAction<Wait>().time.Value = 0.5f;
                //刺后地火
                self.ChangeTransition("Move Choice", "SPIKES", "Spike Attack");
                self.GetState("Spike Attack").GetAction<Wait>().time.Value = 1.35f;
                self.ChangeTransition("Spike Attack", "FINISHED", "Balloon?");
                //快速气球
                self.CopyState("Fire Pause", "Copy Pause");
                self.ChangeTransition("Balloon Tele In", "FINISHED", "Inflate");
                self.ChangeTransition("Down", "FINISHED", "Copy Pause");
                self.ChangeTransition("Copy Pause", "FINISHED", "Fire Repeat");
                self.GetState("Fire Pause").GetAction<Wait>().time.Value = 0.45f;
                self.GetState("Copy Pause").GetAction<Wait>().time.Value = 0.03f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.25f;

                self.GetComponent<HealthManager>().hp = 1000;
            }

        }


        //滚滚
        public void Process_PlayMakerFSM_WatcherKnight(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if ((self.gameObject.name == "Black Knight 1" || self.gameObject.name == "Black Knight 3" || self.gameObject.name == "Black Knight 5"
                || self.gameObject.name == "Black Knight 2" || self.gameObject.name == "Black Knight 4" || self.gameObject.name == "Black Knight 6")
                && self.FsmName == "Black Knight")
            {
                Modding.Logger.Log("流程——滚滚");
                self.GetState("Set Time").GetAction<SetFloatValue>(1).floatValue.Value = 0f;
                self.GetState("Set Time").GetAction<SetFloatValue>(2).floatValue.Value = 0f;
                self.GetState("Set Time").GetAction<SetFloatValue>(5).floatValue.Value = 0f;
                self.GetState("Set Time").GetAction<SetFloatValue>(6).floatValue.Value = 0f;

                self.CopyState("Turn", "Copy Turn");
                self.CreateState("After Slash1");
                self.ChangeTransition("Slash1 Recover", "FINISHED", "After Slash1");
                self.GetState("After Slash1").AddMethod(() =>
                {
                    Transform player = GameObject.Find("Knight").transform;
                    //1左 -1右
                    if ((self.transform.lossyScale.x == 1 && player.transform.position.x > self.transform.position.x)
                    || (self.transform.lossyScale.x == -1 && player.transform.position.x < self.transform.position.x))
                    {
                        self.SetState("Copy Turn");
                    }
                    else
                    {
                        self.SetState("Slash2");
                    }
                });
                self.ChangeTransition("Copy Turn", "FINISHED", "Slash2");
                self.GetState("Recover").GetAction<Wait>().time.Value = 0f;
                self.GetState("Charge Recover").GetAction<Wait>().time.Value = 0f;
            }
            if (self.gameObject.scene.name == "Ruins2_03_boss" && self.gameObject.name == "Battle Control" && self.FsmName == "Battle Control")
            {
                self.GetState("Knight 1").GetAction<Wait>().time.Value = 0f;
                
                self.ChangeTransition("Knight 1", "NEXT", "Knight 2");
                self.ChangeTransition("Knight 2", "NEXT", "Knight 3");
                self.ChangeTransition("Knight 3", "NEXT", "Knight 4");
                self.ChangeTransition("Knight 4", "NEXT", "Knight 5");
                self.ChangeTransition("Knight 5", "NEXT", "Knight 6");
               
                self.GetState("Pause 5").GetAction<Wait>().time.Value = 0f;
                self.GetState("Music End").GetAction<Wait>().time.Value = 0.1f;
            }
            if ((self.gameObject.name == "Black Knight 1" || self.gameObject.name == "Black Knight 3" || self.gameObject.name == "Black Knight 5"
                || self.gameObject.name == "Black Knight 2" || self.gameObject.name == "Black Knight 4" || self.gameObject.name == "Black Knight 6")
                && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 500;
                self.FsmVariables.FindFsmInt("Level 2").Value = 500;
                self.FsmVariables.FindFsmInt("Level 3").Value = 500;
                self.FsmVariables.FindFsmInt("Level 4").Value = 500;
                self.FsmVariables.FindFsmInt("Level 5").Value = 500;
            }
        }


        //乌姆
        public void Process_PlayMakerFSM_UUmuu(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mega Jellyfish" && self.FsmName == "Mega Jellyfish")
            {
                Modding.Logger.Log("流程——乌姆");
                self.GetState("Wake Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Wake Rumble").GetAction<Wait>().time.Value = 1f;
                self.GetState("Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle").GetAction<ChaseObjectV2>().speedMax.Value = 8f;
                self.GetState("Idle").GetAction<ChaseObjectV2>().accelerationForce.Value = 6f;
                self.GetState("Attack Antic").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Attack Recover").GetAction<Wait>().time.Value = 0.1f;
                //self.GetState("Multizap").GetAction<Wait>().time.Value = 1f;
                self.GetState("Wounded").GetAction<Wait>().time.Value = 2.5f;

                self.ChangeTransition("Start", "FINISHED", "Pattern Choice");
                self.ChangeTransition("Quirrel Roam", "FINISHED", "Attack Antic");
                self.GetComponent<HealthManager>().hp = 400;
                self.GetState("Start").AddMethod(() =>
                {
                    self.GetComponent<HealthManager>().hp = 400;
                });
            }
        }

        //诺斯克
        public void Process_PlayMakerFSM_Nosk(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mimic Spider" && self.FsmName == "Mimic Spider")
            {
                Modding.Logger.Log("流程——诺斯克");
                self.GetState("Charge R").AddAction(self.GetState("Roof Drop").GetAction<FlingObjectsFromGlobalPoolTime>());
                self.GetState("Charge R").GetAction<FlingObjectsFromGlobalPoolTime>().frequency = 0.5f;
                self.GetState("Charge L").AddAction(self.GetState("Roof Drop").GetAction<FlingObjectsFromGlobalPoolTime>());
                self.GetState("Charge L").GetAction<FlingObjectsFromGlobalPoolTime>().frequency = 0.5f;
                self.GetState("Roof Drop").GetAction<FlingObjectsFromGlobalPoolTime>().frequency.Value = 0.25f;
                self.GetState("Fall Antic").GetAction<Wait>().time.Value = 0.5f;
                self.GetComponent<HealthManager>().hp = 800;
            }
        }


        //小姐姐2
        public void Process_PlayMakerFSM_Hornet2(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Hornet Boss 2" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——二见");
                //贴图
                Texture2D texture2D;
                var stream = typeof(AllHallownestEnhanced).Assembly.GetManifestResourceStream("AllHallownestEnhanced.Res.hornet.png");
                MemoryStream memoryStream = new MemoryStream((int)stream.Length);
                stream.CopyTo(memoryStream);
                stream.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();
                texture2D = new Texture2D(0, 0);
                texture2D.LoadImage(bytes, true);
                self.GetComponent<tk2dSprite>().CurrentSprite.material.mainTexture = texture2D;


                self.ChangeTransition("Dmg Response", "IDLE", "G Sphere?");
                self.ChangeTransition("After Evade", "IDLE", "G Sphere?");
                self.ChangeTransition("Throw Recover", "FINISHED", "G Sphere?");
                self.ChangeTransition("Sphere Recover", "FINISHED", "G Sphere?");
                self.ChangeTransition("GDash Recover2", "FINISHED", "G Sphere?");
                self.ChangeTransition("Hard Land", "FINISHED", "G Sphere?");
                self.ChangeTransition("Idle", "RUN", "Barb Antic");
                self.ChangeTransition("Idle", "EVADE", "Counter Antic");
                self.ChangeTransition("Barb?", "FINISHED", "Move Choice B");
                self.ChangeTransition("CA Recover", "FINISHED", "G Sphere?");
                self.ChangeTransition("Barb Recover", "FINISHED", "GDash Antic");

                //格挡反击
                self.ChangeTransition("Hard Land", "FINISHED", "Run");
                self.ChangeTransition("Dmg Response", "IDLE", "G Sphere?");
                self.ChangeTransition("Counter End", "FINISHED", "G Sphere?");

                self.FsmVariables.FindFsmFloat("A Dash Speed").Value = 45;
                self.FsmVariables.FindFsmFloat("G Dash Speed").Value = -40;
                self.FsmVariables.FindFsmFloat("Evade Speed").Value = 30;
                self.FsmVariables.FindFsmFloat("Gravity").Value = 3;
                self.FsmVariables.FindFsmFloat("Run Speed").Value = -10;
                self.GetState("Jump").GetAction<RandomFloat>().min.Value = 54f;
                self.GetState("Jump").GetAction<RandomFloat>().max.Value = 54f;
                self.GetState("Barb Throw").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Sphere").GetAction<Wait>().time.Value = 0.4f;
                self.GetState("Sphere A").GetAction<Wait>().time.Value = 0.4f;

                self.FsmVariables.FindFsmFloat("Wall X Left").Value = 16.06f;
                self.FsmVariables.FindFsmFloat("Wall X Right").Value = 36.53f;

                self.GetComponent<HealthManager>().hp = 1200;
            }
            if (self.gameObject.name == "Hornet Boss 2" && self.FsmName == "Stun Control")
            {
                self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
            }
        }
        #endregion


        #region 四门
        //暴怒守卫
        public void Process_PlayMakerFSM_FuriousGuard(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Zombie Beam Miner Rematch" && self.FsmName == "Beam Miner")
            {
                Modding.Logger.Log("流程——暴怒守卫");
                self.CopyState("Laser Shoot", "CopyLaser Shoot");
                self.CopyState("Laser Shoot", "CopyLaser Shoot 2");
                self.ChangeTransition("Roar End", "FINISHED", "Choice");
                self.ChangeTransition("Choice", "ROAR", "Aim Jump");
                self.ChangeTransition("Land", "FINISHED", "CopyLaser Shoot");
                self.ChangeTransition("CopyLaser Shoot", "FINISHED", "Choice");
                self.ChangeTransition("Beam Recover", "FINISHED", "CopyLaser Shoot 2");
                self.ChangeTransition("CopyLaser Shoot 2", "FINISHED", "Choice");

                self.GetState("Beam Antic 2").GetAction<Wait>().time.Value = 0.5f;
            }
            if (self.gameObject.name == "Zombie Beam Miner Rematch" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 900;
                self.FsmVariables.FindFsmInt("Level 2").Value = 900;
                self.FsmVariables.FindFsmInt("Level 3").Value = 900;
                self.FsmVariables.FindFsmInt("Level 4").Value = 900;
                self.FsmVariables.FindFsmInt("Level 5").Value = 900;
            }

        }

        //失落近亲
        public void Process_PlayMakerFSM_LostKin(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Lost Kin" && self.FsmName == "Stun Control")
            {
                //self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
                self.FsmVariables.FindFsmInt("Stun Combo").Value = 12;
            }
            if (self.gameObject.name == "Lost Kin" && self.FsmName == "IK Control")
            {
                Modding.Logger.Log("流程——梦表");
                self.GetState("Roar").GetAction<Wait>().time.Value = 0.5f;

                self.ChangeTransition("First Counter", "FINISHED", "Set Dstab");
                self.ChangeTransition("Set Counter", "FINISHED", "Attack Choice");
                self.ChangeTransition("Dash Recover", "FINISHED", "Jump Antic");
                self.ChangeTransition("Ohead Recover", "FINISHED", "Attack Choice");
                self.ChangeTransition("Land", "FINISHED", "Attack Choice");
                self.ChangeTransition("Damage Response", "FINISHED", "Attack Choice");
                self.CreateState("After Dstab");
                self.ChangeTransition("Dstab Land", "FINISHED", "After Dstab");
                self.GetState("After Dstab").AddMethod(() =>
                {
                    float dis = CheckDistance(self.transform);
                    if (dis < 5f)
                    {
                        self.SetState("Ohead Slashing");
                    }
                    else
                    {
                        self.SetState("Attack Choice");
                    }
                });

                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0;
                self.GetState("Ohead Antic").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Dash Antic 2").GetAction<Wait>().time.Value = 0.325f;
                self.GetState("Jump").GetAction<RandomFloat>().min.Value = 62.5f;
                self.GetState("Jump").GetAction<RandomFloat>().max.Value = 62.5f;
                self.FsmVariables.FindFsmFloat("Gravity").Value = 3.65f;
                self.GetComponent<HealthManager>().hp = 1400;


                //self.GetState("Stunned").GetAction<Wait>().time.Value = 30;
            }
            if (self.gameObject.name == "Lost Kin" && self.FsmName == "Spawn Balloon")
            {
                self.FsmVariables.FindFsmFloat("Wait Max").Value = 1.5f;
                self.FsmVariables.FindFsmFloat("Wait Min").Value = 1.5f;
                self.GetState("Spawn").GetAction<IntCompare>(3).integer2 = 9999;
            }
        }


        //无眼
        public void Process_PlayMakerFSM_NoEyes(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "Movement")
            {
                Modding.Logger.Log("流程——无眼");
            }
            if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "Shot Spawn")
            {
                self.FsmVariables.FindFsmFloat("Spawn Pause").Value = 1.5f;
                self.GetState("Spawn L").GetAction<SetFsmFloat>(3).setValue.Value = 5f;
                self.GetState("Spawn L").GetAction<SetFsmFloat>(7).setValue.Value = -5f;
                self.GetState("Spawn L").GetAction<RandomFloat>(1).min.Value = 13.5f;
                self.GetState("Spawn L").GetAction<RandomFloat>(5).min.Value = 0f;
                self.GetState("Spawn R").GetAction<SetFsmFloat>(3).setValue.Value = -5f;
                self.GetState("Spawn R").GetAction<SetFsmFloat>(7).setValue.Value = 5f;
                self.GetState("Spawn R").GetAction<RandomFloat>(1).min.Value = 13.5f;
                self.GetState("Spawn R").GetAction<RandomFloat>(5).min.Value = 0f;
            }
            if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "Escalation")
            {
                self.GetState("Escalate").GetAction<SetFsmFloat>().setValue.Value = 1.35f;
                self.FsmVariables.FindFsmInt("Esc 1").Value = 480;
                self.GetState("Escalate 2").GetAction<SetFsmFloat>().setValue.Value = 1.2f;
                self.FsmVariables.FindFsmInt("Esc 2").Value = 240;
            }
            if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 720;
                self.FsmVariables.FindFsmInt("Level 2").Value = 720;
                self.FsmVariables.FindFsmInt("Level 3").Value = 720;
                self.FsmVariables.FindFsmInt("Level 4").Value = 720;
                self.FsmVariables.FindFsmInt("Level 5").Value = 720;
            }
        }

        //叛徒领主
        public void Process_PlayMakerFSM_TraitorLord(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Mantis Traitor Lord" && self.FsmName == "Mantis")
            {
                Modding.Logger.Log("流程——叛徒领主");
                self.GetState("Emerge Dust").GetAction<Wait>().time.Value = 1f;

                self.ChangeTransition("Intro Land", "FINISHED", "Active");
                self.ChangeTransition("Active", "FINISHED", "Idle");
                self.CreateState("After Cooldown");
                self.ChangeTransition("Cooldown", "FINISHED", "After Cooldown");
                self.GetState("After Cooldown").AddMethod(() =>
                {
                    float i = Random.Range(0, 1f);
                    if (i < 0.33f)
                    {
                        self.SetState("Slam Antic");
                    }
                    else if (i < 0.66f)
                    {
                        self.SetState("Sickle Antic");
                    }
                    else
                    {
                        self.SetState("Idle");
                    }
                });
                self.ChangeTransition("Sick Throw CD", "FINISHED", "Idle");

                self.GetState("Idle").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Sick Throw CD").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cooldown").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Slam End").GetAction<Wait>().time.Value = 0.2f;
                self.GetComponent<HealthManager>().hp = 1200;
            }
        }

        //白芬达
        public void Process_PlayMakerFSM_WhiteDefender(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "White Defender" && self.FsmName == "Dung Defender")
            {
                Modding.Logger.Log("流程——白芬达");
                self.GetState("Wake").GetAction<Wait>().time.Value = 0f;

                //self.ChangeTransition("Ground Slam?", "FINISHED", "G Slam Antic");
                self.GetState("Ground Slam?").GetAction<SendRandomEvent>().weights = new FsmFloat[2] { 0, 1 };
                self.ChangeTransition("RJ In Air", "HIT UP", "RJ In Air");
                self.ChangeTransition("RJ In Air", "HIT LEFT", "RJ In Air");
                self.ChangeTransition("RJ In Air", "HIT RIGHT", "RJ In Air");

                self.GetState("Timer").GetAction<SetFloatValue>(2).floatValue.Value = 35;
                self.GetState("Set Rage").GetAction<SetFloatValue>(3).floatValue.Value = 60;
                self.GetState("Dive In 1").GetAction<SetFloatValue>().floatValue.Value = 35;
                self.GetState("Rage In").GetAction<SetFloatValue>(8).floatValue.Value = 0.13f;
                self.GetState("Rage In").GetAction<SetFloatValue>(9).floatValue.Value = 60;
                self.FsmVariables.FindFsmFloat("Dolphin Speed").Value = 15;
                self.ChangeTransition("After Throw?", "IDLE", "G Slam Antic");
                self.ChangeTransition("After Throw?", "DIVE IN", "Timer");
                self.GetState("Dolph Dives").GetAction<RandomInt>().min.Value = 1;
                self.GetState("Dolph Dives").GetAction<RandomInt>().max.Value = 2;
                self.GetState("Roll Speed").GetAction<FloatAdd>().add.Value = 12;
                self.GetState("Roll Speed").GetAction<FloatCompare>().float2.Value = 24;
                self.GetState("Roll Speed").GetAction<SetFloatValue>().floatValue.Value = 12;


                self.GetState("Idle").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("To Dolph Pause").GetAction<Wait>().time.Value = 0;
                self.GetState("Set Throws").GetAction<RandomInt>().max.Value = 5;
                self.GetState("DT Set").GetAction<SetIntValue>().intValue.Value = 4;
                self.GetState("TD Set").GetAction<SetIntValue>().intValue.Value = 4;
                self.GetState("RJ Set").GetAction<SetIntValue>().intValue.Value = 5;
                self.ChangeTransition("Throw Antic 2", "FINISHED", "Throw 1");
                self.GetState("G Slam Antic").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("G Slam").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pillar").GetAction<Wait>().time.Value = 0.0625f;

                self.GetComponent<HealthManager>().hp = 2000;
            }

        }

        //灵魂暴君
        public void Process_PlayMakerFSM_MageTyrant(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Dream Mage Lord" && self.FsmName == "Mage Lord")
            {
                Modding.Logger.Log("流程——暴君");
                self.GetState("Roar").GetAction<Wait>().time.Value = 0.5f;

                self.CopyState("HS Summon", "Copy HS Summon");
                self.CopyState("HS Orb", "Copy HS Orb");
                //无idle
                self.ChangeTransition("Roar End", "FINISHED", "Tele Spinner X");
                self.ChangeTransition("After Tele", "IDLE", "Shot Antic");
                self.ChangeTransition("Next?", "FINISHED", "Attack Choice");

                //合二为一
                self.ChangeTransition("After Tele", "CHARGE", "Copy HS Summon");
                self.ChangeTransition("Copy HS Summon", "FINISHED", "Copy HS Orb");
                self.ChangeTransition("Copy HS Orb", "FINISHED", "Charge Dir");
                self.ChangeTransition("Charge Stop", "FINISHED", "HS Tele Out");
                self.ChangeTransition("HS Orb", "FINISHED", "Charge Dir");

                //攻击
                self.GetState("Shot Antic").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Quake Waves").GetAction<Wait>().time.Value = 0.65f;

                self.GetComponent<HealthManager>().hp = 1100;
            }
            if (self.gameObject.name == "Dream Mage Lord Phase2" && self.FsmName == "Mage Lord 2")
            {
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.5f;

                self.GetState("Shot Antic").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shot Antic").GetAction<SetIntValue>(4).intValue.Value = 10;
                self.GetState("Shot Antic").GetAction<RandomInt>(5).min.Value = 7;
                self.GetState("Shot Antic").GetAction<RandomInt>(5).max.Value = 7;
                self.GetState("Orb Summon").GetAction<Wait>().time.Value = 0.45f;
                self.GetState("Spawn Fireball").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Shot CD").GetAction<Wait>().time.Value = 0f;

                self.GetState("Shift?").GetAction<RandomFloat>().min.Value = -6f;
                self.GetState("Shift?").GetAction<RandomFloat>().max.Value = 6f;
                self.GetState("Quake Land").GetAction<Wait>().time.Value = 0.5f;

                self.GetComponent<HealthManager>().hp = 500;
            }
            if (self.gameObject.name == "Dream Mage Lord" && self.FsmName == "Stun")
            {
                self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
            }
        }


        //马科斯
        public void Process_PlayMakerFSM_Markoth(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Ghost Warrior Markoth" && self.FsmName == "Attacking")
            {
                Modding.Logger.Log("流程——马爹");
                self.CopyState("Nail", "Copy Nail");
                self.ChangeTransition("Nail", "FINISHED", "Copy Nail");
                self.ChangeTransition("Copy Nail", "FINISHED", "Wait");
            }
            if (self.gameObject.name == "Ghost Warrior Markoth" && self.FsmName == "Shield Attack")
            {
                self.GetState("Ready").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Rage Pause").GetAction<Wait>().time.Value = 0f;
                self.GetState("Rage Anim").GetAction<Wait>().time.Value = 0f;
                self.GetState("Send Summon").GetAction<Wait>().time.Value = 0.2f;
            }
            if (self.gameObject.name.Contains("Markoth Shield") && self.FsmName == "Control")
            {
                self.GetState("At Start CW").GetAction<FloatAdd>().add.Value = -480;
                self.GetState("At Start CW").GetAction<FloatClamp>().minValue.Value = -540;
                self.GetState("At Start CW").GetAction<FloatCompare>().float2.Value = -540;
                self.GetState("At Start CCW").GetAction<FloatAdd>().add.Value = 480;
                self.GetState("At Start CCW").GetAction<FloatClamp>().maxValue.Value = 540;
                self.GetState("At Start CCW").GetAction<FloatCompare>().float2.Value = 540;

                self.GetState("Spinning CW").GetAction<FloatAdd>().add.Value = 360;
                self.GetState("Spinning CW").GetAction<FloatClamp>().maxValue.Value = 360;
                self.GetState("Spinning CCW").GetAction<FloatAdd>().add.Value = -360;
                self.GetState("Spinning CCW").GetAction<FloatClamp>().minValue.Value = -360;
                self.GetState("Decelerate CW").GetAction<FloatAdd>().add.Value = -360;
                self.GetState("Decelerate CW").GetAction<FloatClamp>().maxValue.Value = 360;
                self.GetState("Decelerate CCW").GetAction<FloatAdd>().add.Value = 360;
                self.GetState("Decelerate CCW").GetAction<FloatClamp>().minValue.Value = -360;
            }
            if (self.gameObject.name == "Ghost Warrior Markoth" && self.FsmName == "FSM")
            {
                self.FsmVariables.FindFsmInt("Level 1").Value = 800;
                self.FsmVariables.FindFsmInt("Level 2").Value = 800;
                self.FsmVariables.FindFsmInt("Level 3").Value = 800;
                self.FsmVariables.FindFsmInt("Level 4").Value = 800;
                self.FsmVariables.FindFsmInt("Level 5").Value = 800;
            }

        }

        //左特
        public void Process_PlayMakerFSM_Zote(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Grey Prince Title" && self.FsmName == "Control")
            {
                self.GetState("Get Level").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Main Title Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Main Title").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Extra 1").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 2").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 3").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 4").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 5").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 6").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 7").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 8").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 9").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 10").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 11").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 12").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Extra 13").GetAction<Wait>().time.Value = 0.01f;
            }
            if (self.gameObject.name == "Grey Prince" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——左特");
                self.GetState("Enter 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Enter Short").GetAction<Wait>().time.Value = 0.5f;

                self.ChangeTransition("Set Damage", "FINISHED", "Idle Start");
                self.ChangeTransition("BR Recover", "FINISHED", "Idle Start");
                self.ChangeTransition("Respit?", "FINISHED", "Idle Start");
                self.ChangeTransition("After Jump", "FINISHED", "Idle Start");
                self.ChangeTransition("FT Recover", "FINISHED", "Idle Start");
                self.ChangeTransition("Slash Recover", "FINISHED", "Idle Start");
                self.ChangeTransition("Idle Start", "STAND", "Run Flip");
                self.ChangeTransition("Run End", "FINISHED", "Move Choice 3");

                //二连假动作
                self.CopyState("Shift?", "CopyShift");
                self.ChangeTransition("Stomp Shift L", "FINISHED", "CopyShift");
                self.ChangeTransition("Stomp Shift R", "FINISHED", "CopyShift");
                self.GetState("Shift?").GetAction<SendRandomEvent>().weights = new FsmFloat[2] { 0.8f, 0.2f };
                self.GetState("CopyShift").GetAction<SendRandomEvent>().weights = new FsmFloat[2] { 0.4f, 0.6f };


                //二连砸
                self.CreateState("After Ft Waves");
                self.CopyState("FT Through", "Copy FT Through");
                self.CopyState("FT Fall", "Copy FT Fall");
                self.CopyState("Ft Waves", "Copy Ft Waves");

                self.ChangeTransition("Ft Waves", "FINISHED", "After Ft Waves");
                self.GetState("After Ft Waves").AddMethod(() =>
                {
                    if (Random.Range(0, 1f) < 0.7f)
                    {
                        self.SetState("Copy FT Through");
                    }
                    else
                    {
                        self.SetState("FT Slam");
                    }
                });
                self.ChangeTransition("Copy FT Through", "FINISHED", "Copy FT Fall");
                self.ChangeTransition("Copy FT Fall", "LAND", "Copy Ft Waves");
                self.ChangeTransition("Copy Ft Waves", "FINISHED", "FT Slam");

                self.GetState("FT Slam").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Charge Slam").GetAction<Wait>().time.Value = 0.25f;

                //双倍小怪
                self.CopyState("Spit L", "Copy Spit L");
                self.CopyState("Spit R", "Copy Spit R");
                self.ChangeTransition("Spit L", "FINISHED", "Copy Spit R");
                self.ChangeTransition("Spit R", "FINISHED", "Copy Spit L");

                //charge速度
                self.GetState("Charge R").GetAction<AccelerateVelocity>().xMaxSpeed.Value = 35;
                self.GetState("Charge L").GetAction<AccelerateVelocity>().xMaxSpeed.Value = 35;

                self.GetState("Level 1").GetAction<SetHP>().hp.Value = 1800;
                self.GetState("Level 2").GetAction<SetHP>().hp.Value = 1800;
                self.GetState("Level 3").GetAction<SetHP>().hp.Value = 1800;
                self.GetState("4+").GetAction<SetHP>().hp.Value = 1800;
            }
            //爆炸左特不会自动爆炸
            if (self.gameObject.name.Contains("Zote Balloon") && self.FsmName == "Control")
            {
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 9999;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 9999;
                self.GetState("Idle").GetAction<IdleBuzzV3>().speedMax.Value = 0;
                self.GetState("Idle").GetAction<IdleBuzzV3>().accelerationMax.Value = 0;
                self.GetState("Idle").GetAction<IdleBuzzV3>().accelerationMin.Value = 0;
                self.GetState("Idle").GetAction<IdleBuzzV3>().roamingRangeX.Value = 0;
                self.GetState("Idle").GetAction<IdleBuzzV3>().roamingRangeY.Value = 0;
            }
        }

        //失败冠军
        public void Process_PlayMakerFSM_FailedChampion(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "False Knight Dream" && self.FsmName == "FalseyControl")
            {
                Modding.Logger.Log("流程——失败冠军");
                self.ChangeTransition("Move Choice", "JUMP", "S Check Hero Pos");
                self.CreateState("Check Jump?");
                self.ChangeTransition("S Antic", "FINISHED", "Check Jump?");
                self.GetState("Check Jump?").AddMethod(() =>
                {
                    Transform player = GameObject.Find("Knight").transform;
                    if ((self.transform.position.x < 55 && player.transform.position.x < self.transform.position.x)
                    || (self.transform.position.x > 63 && player.transform.position.x > self.transform.position.x))
                    {
                        //太靠左或右就后跳
                        self.SetState("Check Jump Dir");
                    }
                    else
                    {
                        self.SetState("Voice? 2");
                    }
                });

                self.GetState("First Idle").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMax.Value = 0.1f;
                self.GetState("Idle").GetAction<WaitRandom>().timeMin.Value = 0.1f;
                self.GetState("S Attack Antic").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Idle Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rage End").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("To Phase 2").GetAction<SetFloatValue>(0).floatValue.Value = 0.1f;
                self.GetState("To Phase 2").GetAction<SetFloatValue>(1).floatValue.Value = 0.1f;
                self.GetState("To Phase 3").GetAction<SetFloatValue>(0).floatValue.Value = 0.1f;
                self.GetState("To Phase 3").GetAction<SetFloatValue>(1).floatValue.Value = 0.1f;

                self.FsmVariables.FindFsmInt("Jump Barrel Min").Value = 3;
                self.FsmVariables.FindFsmInt("Jump Barrel Max").Value = 4;
                self.FsmVariables.FindFsmInt("Slam Barrel Min").Value = 4;
                self.FsmVariables.FindFsmInt("Slam Barrel Max").Value = 5;
                self.GetState("To Phase 2").GetAction<SetIntValue>(2).intValue.Value = 3;
                self.GetState("To Phase 2").GetAction<SetIntValue>(3).intValue.Value = 4;
                self.GetState("To Phase 2").GetAction<SetIntValue>(4).intValue.Value = 4;
                self.GetState("To Phase 2").GetAction<SetIntValue>(5).intValue.Value = 5;
                self.GetState("To Phase 3").GetAction<SetIntValue>(2).intValue.Value = 3;
                self.GetState("To Phase 3").GetAction<SetIntValue>(3).intValue.Value = 4;
                self.GetState("To Phase 3").GetAction<SetIntValue>(4).intValue.Value = 4;
                self.GetState("To Phase 3").GetAction<SetIntValue>(5).intValue.Value = 5;


                self.GetComponent<HealthManager>().hp = 550;
            }

        }

        //纯粹容器
        public void Process_PlayMakerFSM_HollowKnight(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            //QOL
            if (self.gameObject.name == "Boss Control" && self.FsmName == "Battle Start")
            {
                self.FsmVariables.FindFsmFloat("Title Time").Value = 1;
            }
            if (self.gameObject.name == "Hollow Knight Boss" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——先辈");
                //基础加强
                self.FsmVariables.FindFsmFloat("Idle Time").Value = 0;
                self.FsmVariables.FindFsmFloat("Idle Time Max").Value = 0;
                self.FsmVariables.FindFsmFloat("Idle Time Min").Value = 0;
                self.ChangeTransition("Phase?", "PHASE1", "Choice P2");
                //self.GetState("Stun").GetAction<Wait>().time = 0.5f;

                //地刺
                self.ChangeTransition("Try DStab", "DSTAB", "Stomp Antic");
                self.ChangeTransition("Stomp Antic", "FINISHED", "Stomp Land");

                //三连斩
                self.CreateState("After Slash2");
                self.ChangeTransition("Slash2 Recover", "FINISHED", "After Slash2");
                self.GetState("After Slash2").AddMethod(() =>
                {
                    if (Random.Range(0, 1f) < 0.5f)
                    {
                        self.SetState("Stomp Antic");
                    }
                    else
                    {
                        self.SetState("Slash 3");
                    }
                });

                //橙汁
                self.GetState("SmallShot HighLow").GetAction<FlingObjectsFromGlobalPoolTime>().frequency.Value = 0.10f;
                self.GetState("SmallShot LowHigh").GetAction<FlingObjectsFromGlobalPoolTime>().frequency.Value = 0.10f;

                //大量橙汁
                self.GetState("Chest Shot Antic").GetAction<RandomFloat>().min.Value = 8f;
                self.GetState("Chest Shot Antic").GetAction<RandomFloat>().max.Value = 10f;
                self.GetState("Chest Shot").GetAction<Wait>().time.Value = 0.10f;
                self.GetState("ChestShot Pause").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Fall Down").GetAction<Wait>().time.Value = 0.25f;

                //砸地
                //self.GetState("Puppet Down").GetAction<Wait>().time.Value = 1f;

                //删掉2阶段吼
                self.GetState("Choice P2").RemoveAction(0);

                self.GetComponent<HealthManager>().hp = 1500;

                DamageHero[] damages = self.GetComponentsInChildren<DamageHero>(true);
                foreach (DamageHero damage in damages)
                {
                    damage.damageDealt = 2;
                }
            }
            if (self.gameObject.name == "Hollow Knight Boss" && self.FsmName == "Stun Control")
            {
                //self.ChangeTransition("Idle", "STUN DAMAGE", "Reset Counter");
                self.FsmVariables.FindFsmInt("Stun Combo").Value = 15;
                self.FsmVariables.FindFsmInt("Stun Hit Max").Value = 18;
            }
            if (self.gameObject.name == "Hollow Knight Boss" && self.FsmName == "Phase Control")
            {
                self.FsmVariables.FindFsmInt("Phase3 HP").Value = 400;
                self.GetState("Set Phase 4").GetAction<SetHP>().hp = 350;

            }
        }
        #endregion


        #region 五门
        //王格林
        public void Process_PlayMakerFSM_Nightmare_Grim(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Grimm Control" && self.FsmName == "Control")
            {
                self.GetState("Pan Over").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Eye 1").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Eye 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Pan Over 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Eye 3").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Eye 4").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Silhouette").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Silhouette 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Title Up").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Title Up 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Defeated Pause").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Defeated Start").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Explode Start").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Silhouette Up").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Ash Away").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Fade").GetAction<Wait>().time.Value = 0.5f;

            }
            if (self.gameObject.name == "Nightmare Grimm Boss" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——王格林");
                //后撤步后正常
                self.ChangeTransition("Auto Evade?", "EVADE", "Slash Antic");
                self.ChangeTransition("After Evade", "FIREBATS", "Slash Antic");

                //斜冲后50%升龙50%冲刺
                self.GetState("AD Antic").AddMethod(() =>
                {
                    if (Random.Range(0, 1f) < 0.5f)
                    {
                        //50%概率冲刺
                        self.ChangeTransition("GD Antic", "NEXT", "G Dash");
                        self.GetState("AD Fire").GetAction<SpawnObjectFromGlobalPoolOverTime>().frequency = 0.025f;
                    }
                    else
                    {
                        //50%概率升龙
                        self.ChangeTransition("GD Antic", "NEXT", "Uppercut Antic");
                        //升龙的话 则不产生尾气
                        self.GetState("AD Fire").GetAction<SpawnObjectFromGlobalPoolOverTime>().frequency = 999f;
                    }
                });

                //2发火球后必闪
                self.ChangeTransition("Firebat 2", "FINISHED", "FB Behind");
                //闪后正常
                self.ChangeTransition("FB Re Tele", "FINISHED", "Pillar");
                //升龙后地火
                self.ChangeTransition("Explode Pause", "FINISHED", "Pillar");
                self.GetState("Explode Pause").GetAction<Wait>().time.Value = 0;
                //刺后地火
                self.GetState("Spike Attack").GetAction<Wait>().time.Value = 1.35f;
                self.ChangeTransition("Spike Attack", "FINISHED", "Pillar");
                //地火后恢复
                self.ChangeTransition("Pillar", "FINISHED", "Balloon?");
                //无地火状态
                self.ChangeTransition("Pillar Pos", "FINISHED", "Balloon?");
                //快速气球
                self.CopyState("Fire Pause", "Copy Pause");
                self.ChangeTransition("Balloon Tele In", "FINISHED", "Inflate");
                self.ChangeTransition("Down", "FINISHED", "Copy Pause");
                self.ChangeTransition("Copy Pause", "FINISHED", "Fire Repeat");
                self.GetState("Fire Pause").GetAction<Wait>().time.Value = 0.45f;
                self.GetState("Copy Pause").GetAction<Wait>().time.Value = 0.03f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.25f;
            }

        }

        //福光
        public void Process_PlayMakerFSM_Radiance(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (self.gameObject.scene.name.Contains("GG"))
                return;
            if (self.gameObject.name == "Radiance" && self.FsmName == "Attack Choices")
            {
                //一阶段上刺
                self.GetState("Nail Top Sweep").GetAction<SendEventByName>(1).delay.Value = 0.75f;
                self.GetState("Nail Top Sweep").GetAction<SendEventByName>(2).delay.Value = 1.5f;
                self.GetState("Nail Top Sweep").GetAction<SendEventByName>(3).delay.Value = 2.25f;
                self.GetState("Nail Top Sweep").GetAction<Wait>().time.Value = 3.75f;

                //一阶段左右刺
                self.GetState("Nail L Sweep").GetAction<SendEventByName>(1).delay.Value = 2.25f;
                self.GetState("Nail L Sweep").GetAction<SendEventByName>(2).delay.Value = 4f;
                self.GetState("Nail L Sweep").GetAction<SendEventByName>(3).delay.Value = 7f;
                self.GetState("Nail L Sweep").GetAction<Wait>().time.Value = 5.5f;
                self.GetState("Nail R Sweep").GetAction<SendEventByName>(1).delay.Value = 2.25f;
                self.GetState("Nail R Sweep").GetAction<SendEventByName>(2).delay.Value = 4f;
                self.GetState("Nail R Sweep").GetAction<SendEventByName>(3).delay.Value = 7f;
                self.GetState("Nail R Sweep").GetAction<Wait>().time.Value = 5.5f;

                //二阶段左右刺
                self.GetState("Nail L Sweep 2").GetAction<SendEventByName>(2).delay.Value = 4f;
                self.GetState("Nail R Sweep 2").GetAction<SendEventByName>(2).delay.Value = 4f;


                //横刺后不再接左右上刺
                self.CreateState("After LR Nail");
                self.ChangeTransition("Nail L Sweep", "FINISHED", "After LR Nail");
                self.ChangeTransition("Nail R Sweep", "FINISHED", "After LR Nail");
                self.GetState("After LR Nail").AddMethod(() =>
                {
                    float random = Random.Range(0, 1f);
                    if (random < 0.22f)
                    {
                        self.SetState("Eye Beam Wait");
                    }
                    else if (random < 0.39f)
                    {
                        self.SetState("Beam Sweep L");
                    }
                    else if (random < 0.56f)
                    {
                        self.SetState("Beam Sweep R");
                    }
                    else if (random < 0.78f)
                    {
                        self.SetState("Nail Fan Wait");
                    }
                    else
                    {
                        self.SetState("Orb Wait");
                    }
                });

                //二次加强
                self.GetState("A1 Pause").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("A2 Pause").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Eye Beam Recover").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Nail Fan Recover").GetAction<Wait>().time.Value = 0.25f;

                //一二阶段权重
                self.GetState("A1 Choice").GetAction<SendRandomEventV3>().weights = new FsmFloat[] { 1, 0.5f, 0.5f, 1, 0.75f, 0.75f, 1, 1 };
                self.GetState("A1 Choice").GetAction<SendRandomEventV3>().eventMax = new FsmInt[] { 1, 1, 1, 1, 1, 1, 1, 1 };
                self.GetState("A1 Choice").GetAction<SendRandomEventV3>().missedMax = new FsmInt[] { 10, 10, 10, 10, 10, 10, 10, 10 };
                self.GetState("A2 Choice").GetAction<SendRandomEventV3>().weights = new FsmFloat[] { 1, 1, 0.75f, 0.75f, 1, 1 };
                self.GetState("A2 Choice").GetAction<SendRandomEventV3>().eventMax = new FsmInt[] { 1, 1, 1, 1, 1, 1 };
                self.GetState("A2 Choice").GetAction<SendRandomEventV3>().missedMax = new FsmInt[] { 8, 8, 8, 8, 8, 8 };
            }
            if (self.gameObject.name == "Radiance" && self.FsmName == "Attack Commands")
            {
                //光球
                self.GetState("Orb Antic").GetAction<SetIntValue>().intValue.Value = 4;
                self.GetState("Orb Antic").GetAction<RandomInt>().min.Value = 4;
                self.GetState("Orb Antic").GetAction<RandomInt>().max.Value = 4;
                self.GetState("Spawn Fireball").GetAction<Wait>().time.Value = 0.01f;

                //眼光
                self.GetState("NF Glow").GetAction<Wait>().time.Value = 0.3f;
                self.GetState("EB 1").GetAction<Wait>().time.Value = 0.65f;
                self.GetState("EB 2").GetAction<Wait>().time.Value = 0.65f;
                self.GetState("EB 3").GetAction<Wait>().time.Value = 0.65f;
                self.GetState("Eb Extra Wait").GetAction<Wait>().time.Value = 0.3f;
                self.GetState("EB 7").GetAction<Wait>().time.Value = 0.8f;
                self.GetState("EB 7").GetAction<SendEventByName>(8).delay.Value = 0.65f;
                self.GetState("EB 8").GetAction<Wait>().time.Value = 0.8f;
                self.GetState("EB 8").GetAction<SendEventByName>(8).delay.Value = 0.65f;
                self.GetState("EB 9").GetAction<Wait>().time.Value = 0.8f;
                self.GetState("EB 9").GetAction<SendEventByName>(8).delay.Value = 0.65f;
                //声音
                self.GetState("EB 1").GetAction<AudioPlayerOneShotSingle>(3).delay.Value = 0.5f;
                self.GetState("EB 7").GetAction<AudioPlayerOneShotSingle>(3).delay.Value = 0.65f;
                //结束
                self.GetState("EB 1").GetAction<SendEventByName>(10).delay.Value = 0.60f;
                self.GetState("EB 2").GetAction<SendEventByName>(9).delay.Value = 0.60f;
                self.GetState("EB 3").GetAction<SendEventByName>(9).delay.Value = 0.60f;
                self.GetState("EB 7").GetAction<SendEventByName>(9).delay.Value = 0.75f;
                self.GetState("EB 8").GetAction<SendEventByName>(9).delay.Value = 0.75f;
                self.GetState("EB 9").GetAction<SendEventByName>(9).delay.Value = 0.75f;


                //眼剑
                self.GetState("Eb Extra Wait 2").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Nail Fan").GetAction<SetIntValue>(4).intValue.Value = 18;
                self.GetState("CW Spawn").GetAction<FloatAdd>().add.Value = -20;
                self.GetState("CCW Spawn").GetAction<FloatAdd>().add.Value = 20;

                //刺双倍
                self.CopyState("Comb L", "Copy Comb L");
                self.CopyState("Comb R", "Copy Comb R");
                self.CopyState("Comb L 2", "Copy Comb L 2");
                self.CopyState("Comb R 2", "Copy Comb R 2");
                self.GetState("Comb R").AddMethod(() =>
                {
                    self.SetState("Copy Comb L");
                });
                self.GetState("Comb L").AddMethod(() =>
                {
                    self.SetState("Copy Comb R");
                });
                self.GetState("Comb R 2").AddMethod(() =>
                {
                    self.SetState("Copy Comb L 2");
                });
                self.GetState("Comb L 2").AddMethod(() =>
                {
                    self.SetState("Copy Comb R 2");
                });

                //上升激光
                self.GetState("AB Start").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Aim").GetAction<SendEventByName>(2).delay.Value = 0.6f;
                self.GetState("Aim").GetAction<AudioPlayerOneShotSingle>(3).delay.Value = 0.6f;
                self.GetState("Aim").GetAction<SendEventByName>(8).delay.Value = 0.6f;
                self.GetState("Aim").GetAction<SendEventByName>(9).delay.Value = 0.6f;
                self.GetState("Aim").GetAction<SendEventByName>(10).delay.Value = 0.85f;
                self.GetState("Aim").GetAction<Wait>().time.Value = 0.9f;
            }
            if (self.gameObject.name == "Radiance" && self.FsmName == "Control")
            {
                Modding.Logger.Log("流程——福光");
                //1-3落刺
                self.GetState("Rage Comb").GetAction<Wait>().time.Value = 0.65f;
                //二阶段开具位置随机
                self.ChangeTransition("Tele SFX", "FINISHED", "A2 Tele Choice");
                //二次加强
                self.GetState("Arena 1 Idle").GetAction<WaitRandom>().timeMax.Value = 1.5f;
                self.GetState("Arena 1 Idle").GetAction<WaitRandom>().timeMin.Value = 0.9f;
                self.GetState("Arena 2 Idle").GetAction<WaitRandom>().timeMax.Value = 2f;


                self.GetComponent<HealthManager>().hp = 2500;
            }
            if (self.gameObject.name == "Radiance" && self.FsmName == "Phase Control")
            {
                //加强后：
                //1 - 1：3000~2650（350血）
                //1 - 2：2650~2250（400血）
                //1 - 3：2250~2000（250血）
                //2：2000~1300（700血）
                //3：1300~0（1300血）

                //加强后：（1500+1000=2500）
                //1 - 1：2500~2000（500血）
                //1 - 2：2000~1400（600血）
                //1 - 3：1400~1000（400血）
                //2：1000~0（1000血）
                //3：0（0血）
                self.FsmVariables.FindFsmInt("P2 Spike Waves").Value = 2000;
                self.FsmVariables.FindFsmInt("P3 A1 Rage").Value = 1400;
                self.FsmVariables.FindFsmInt("P4 Stun1").Value = 1000;
                self.FsmVariables.FindFsmInt("P5 Acend").Value = 0;
            }

        }
        #endregion


        #endregion

        //检测BOSS到玩家的距离
        public float CheckDistance(Transform transform)
        {
            Transform player = GameObject.Find("Knight").transform;
            if (player != null)
                return Vector3.Distance(transform.position, player.position);
            return 0f;
        }

    }
}
