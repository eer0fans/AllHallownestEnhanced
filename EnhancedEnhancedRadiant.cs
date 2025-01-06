using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vasi;

namespace AllHallownestEnhanced
{
    internal class EnhancedEnhancedRadiant : SingletonBase<EnhancedEnhancedRadiant>
    {
        public bool repeat1 = false;
        public bool repeat2 = false;

        public void PlayMakerFSM_Radiance(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.EnhanceBOSS)
                return;
            if (!AllHallownestEnhanced.settings_.enhanced_2Radiant)
                return;

            //减少1阶段剑速度
            if (self.gameObject.name.Contains("Radiant Nail Comb") && self.FsmName == "Control")
            {
                self.GetState("L").GetAction<SetFloatValue>(4).floatValue.Value = 15;
                self.GetState("R").GetAction<SetFloatValue>(4).floatValue.Value = 15;
            }
            if (!self.gameObject.scene.name.Contains("GG"))
                return;
            //QOL
            if (self.gameObject.name == "Boss Control" && self.FsmName == "Control")
            {
                self.GetState("Setup").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Challenge Pause").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Sun Antic").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Antic Rumble").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Appear Boom").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Title Up").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Refight Pause").GetAction<Wait>().time.Value = 0.25f;
            }
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Attack Choices")
            {
                //SendEventByName topSweep = self.GetState("Nail Top Sweep").GetAction<SendEventByName>();
                //SendEventByName LSweep = self.GetState("Nail L Sweep").GetAction<SendEventByName>();
                //SendEventByName RSweep = self.GetState("Nail R Sweep").GetAction<SendEventByName>();

                //一阶段上刺
                self.GetState("Nail Top Sweep").GetAction<SendEventByName>(1).delay.Value = 0.4f;
                self.GetState("Nail Top Sweep").GetAction<SendEventByName>(2).delay.Value = 0.8f;
                self.GetState("Nail Top Sweep").GetAction<SendEventByName>(3).delay.Value = 1.2f;
                self.GetState("Nail Top Sweep").GetAction<Wait>().time.Value = 1.6f;

                //一阶段左右刺
                self.GetState("Nail L Sweep").GetAction<SendEventByName>(0).delay.Value = 0;
                self.GetState("Nail L Sweep").GetAction<SendEventByName>(1).delay.Value = 1.5f;
                self.GetState("Nail L Sweep").GetAction<SendEventByName>(2).delay.Value = 3f;
                self.GetState("Nail L Sweep").GetAction<Wait>().time.Value = 4.5f;
                self.GetState("Nail R Sweep").GetAction<SendEventByName>(0).delay.Value = 0;
                self.GetState("Nail R Sweep").GetAction<SendEventByName>(1).delay.Value = 1.5f;
                self.GetState("Nail R Sweep").GetAction<SendEventByName>(2).delay.Value = 3;
                self.GetState("Nail R Sweep").GetAction<Wait>().time.Value = 4.5f;

                //二阶段左右刺
                self.GetState("Nail L Sweep 2").GetAction<SendEventByName>(1).delay.Value = 1.5f;
                self.GetState("Nail L Sweep 2").GetAction<Wait>().time.Value = 3;
                self.GetState("Nail R Sweep 2").GetAction<SendEventByName>(1).delay.Value = 1.5f;
                self.GetState("Nail R Sweep 2").GetAction<Wait>().time.Value = 3;


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
                self.GetState("Eye Beam Recover").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Beam Sweep L").GetAction<Wait>().time.Value = 1.5f;
                self.GetState("Beam Sweep R").GetAction<Wait>().time.Value = 1.5f;
                self.GetState("Nail Fan Recover").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Orb Recover").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Beam Sweep L 2").GetAction<Wait>().time.Value = 1.5f;
                self.GetState("Beam Sweep R 2").GetAction<Wait>().time.Value = 1.5f;

                //一二阶段权重
                self.GetState("A1 Choice").GetAction<SendRandomEventV3>().weights = new FsmFloat[] { 1, 0.5f, 0.5f, 1, 0.75f, 0.75f, 1, 1 };
                self.GetState("A1 Choice").GetAction<SendRandomEventV3>().eventMax = new FsmInt[] { 1, 1, 1, 1, 1, 1, 1, 1 };
                self.GetState("A1 Choice").GetAction<SendRandomEventV3>().missedMax = new FsmInt[] { 10, 10, 10, 10, 10, 10, 10, 10 };
                self.GetState("A2 Choice").GetAction<SendRandomEventV3>().weights = new FsmFloat[] { 1, 1, 0.75f, 0.75f, 1, 1 };
                self.GetState("A2 Choice").GetAction<SendRandomEventV3>().eventMax = new FsmInt[] { 1, 1, 1, 1, 1, 1 };
                self.GetState("A2 Choice").GetAction<SendRandomEventV3>().missedMax = new FsmInt[] { 8, 8, 8, 8, 8, 8 };

            }
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Attack Commands")
            {

                //光球
                self.GetState("Orb Antic").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Orb Antic").GetAction<RandomInt>().min.Value = 7;
                self.GetState("Orb Antic").GetAction<RandomInt>().max.Value = 8;
                self.GetState("Orb Summon").GetAction<Wait>().time.Value = 0.4f;
                self.GetState("Orb Pause").GetAction<Wait>().time.Value = 0;
                self.GetState("FinalOrb Pause").GetAction<Wait>().time.Value = 0.6f;

                //眼光
                self.ChangeTransition("EB 1", "A2", "EB 2");

                self.GetState("NF Glow").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("EB Glow End").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("EB 1").GetAction<AudioPlayerOneShotSingle>().delay.Value = 0.35f;
                self.GetState("EB 1").GetAction<SendEventByName>(3).delay.Value = 0.35f;
                self.GetState("EB 1").GetAction<SendEventByName>(8).delay.Value = 0.35f;
                self.GetState("EB 1").GetAction<SendEventByName>(9).delay.Value = 0.45f;
                self.GetState("EB 1").GetAction<Wait>().time.Value = 0.5f;

                self.GetState("EB 2").GetAction<AudioPlayerOneShotSingle>(3).delay.Value = 0.30f;
                self.GetState("EB 2").GetAction<SendEventByName>(4).delay.Value = 0.30f;
                self.GetState("EB 2").GetAction<SendEventByName>(8).delay.Value = 0.30f;
                self.GetState("EB 2").GetAction<SendEventByName>(9).delay.Value = 0.40f;
                self.GetState("EB 2").GetAction<Wait>().time.Value = 0.45f;

                self.GetState("EB 3").GetAction<AudioPlayerOneShotSingle>(3).delay.Value = 0.30f;
                self.GetState("EB 3").GetAction<SendEventByName>(4).delay.Value = 0.30f;
                self.GetState("EB 3").GetAction<SendEventByName>(8).delay.Value = 0.30f;
                self.GetState("EB 3").GetAction<SendEventByName>(9).delay.Value = 0.40f;
                self.GetState("EB 3").GetAction<Wait>().time.Value = 0.45f;

                self.CopyState("EB 3", "EB 31");
                self.CopyState("EB 3", "EB 32");
                self.CopyState("EB 3", "EB 33");
                self.ChangeTransition("EB 3", "FINISHED", "EB 31");
                self.ChangeTransition("EB 31", "FINISHED", "EB 32");
                self.ChangeTransition("EB 32", "FINISHED", "EB Glow End");
                //self.ChangeTransition("EB 33", "FINISHED", "EB Glow End");
                self.GetState("EB 1").RemoveAction(4);

                //眼剑
                self.GetState("Nail Fan").GetAction<Wait>().time.Value = 0.2f;
                self.GetState("Eb Extra Wait 2").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("CW Restart").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("CCW Restart").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Nail Fan").GetAction<SetIntValue>(4).intValue.Value = 18;
                self.GetState("CW Spawn").GetAction<FloatAdd>().add.Value = -20;
                self.GetState("CCW Spawn").GetAction<FloatAdd>().add.Value = 20;
                self.GetState("CW Restart").GetAction<SetIntValue>().intValue.Value = 18;
                self.GetState("CCW Restart").GetAction<SetIntValue>().intValue.Value = 18;
                self.GetState("CW Restart").GetAction<FloatAdd>().add.Value = -10;
                self.GetState("CCW Restart").GetAction<FloatAdd>().add.Value = 10;
                self.GetState("CW Repeat").GetAction<Wait>().time.Value = 0;
                self.GetState("CCW Repeat").GetAction<Wait>().time.Value = 0;
                self.GetState("Nail Fan").AddMethod(() =>
                {
                    repeat1 = false;
                    repeat2 = false;
                });
                self.CreateState("Repeat1");
                self.CreateState("Repeat2");
                self.ChangeTransition("CW Double", "END", "Repeat1");
                self.ChangeTransition("CCW Double", "END", "Repeat2");
                self.GetState("Repeat1").AddMethod(() =>
                {
                    if (repeat1)
                    {
                        self.SetState("End");
                    }
                    else
                    {
                        self.SetState("CW Restart");
                        repeat1 = true;
                    }
                });
                self.GetState("Repeat2").AddMethod(() =>
                {
                    if (repeat2)
                    {
                        self.SetState("End");
                    }
                    else
                    {
                        self.SetState("CCW Restart");
                        repeat2 = true;
                    }
                });

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
                self.GetState("AB Start").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Aim").GetAction<SendEventByName>(2).delay.Value = 0.4f;
                self.GetState("Aim").GetAction<AudioPlayerOneShotSingle>(3).delay.Value = 0.4f;
                self.GetState("Aim").GetAction<SendEventByName>(8).delay.Value = 0.4f;
                self.GetState("Aim").GetAction<SendEventByName>(9).delay.Value = 0.4f;
                self.GetState("Aim").GetAction<SendEventByName>(10).delay.Value = 0.5f;
                self.GetState("Aim").GetAction<Wait>().time.Value = 0.6f;


            }
            //血量
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Control")
            {
                Modding.Logger.Log("神居——二次加强福光");
                //二次加强
                self.GetState("Set Arena 1").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Arena 2 Start").GetAction<Wait>().time.Value = 0.01f;



                //1-3落刺
                self.GetState("Rage1 Start").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Rage Comb").GetAction<Wait>().time.Value = 0.35f;
                if (!AllHallownestEnhanced.settings_.originalHp)
                {
                    self.GetComponent<HealthManager>().hp = 4500;
                    self.GetState("Scream").GetAction<SetHP>().hp.Value = 1000;
                    self.FsmVariables.FindFsmInt("Death HP").Value = 0;
                }

                //QOL
                self.GetState("Knight Break Antic").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Ball Down").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Abyss Tween").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Tendrils 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Statue Death 1").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Statue Death 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Abyss Final Burst").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Lord Appear").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Hand Grab").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Break").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Shade Slash").GetAction<Wait>().time.Value = 0.25f;
                self.GetState("Kill Hit").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Final Stream").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Final Explode").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Tendrils 3").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Yank Down").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Final Black").GetAction<Wait>().time.Value = 0.5f;


            }
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Phase Control")
            {
                //原版：
                //1 - 1：3000~2600（400血）
                //1 - 2：2600~2150（450血）
                //1 - 3：2150~1850（300血）
                //2：1850~1100（750血）
                //3：1000~720（280血）

                //加强后：（2000+1500+1000=4500）
                //1 - 1：4500~3800（700血）
                //1 - 2：3800~3000（800血）
                //1 - 3：3000~2500（500血）
                //2：2500~1000（1500血）
                //3：1000~0（1000血）
                if (!AllHallownestEnhanced.settings_.originalHp)
                {
                    self.FsmVariables.FindFsmInt("P2 Spike Waves").Value = 3800;
                    self.FsmVariables.FindFsmInt("P3 A1 Rage").Value = 3000;
                    self.FsmVariables.FindFsmInt("P4 Stun1").Value = 2500;
                    self.FsmVariables.FindFsmInt("P5 Acend").Value = 1000;
                }
            }
            if (self.gameObject.name == "Beam Sweeper" && self.FsmName == "Control")
            {
                self.GetState("Beam Sweep L").GetAction<iTweenMoveBy>().vector = new Vector3(-80, 0, 0);
                self.GetState("Beam Sweep R").GetAction<iTweenMoveBy>().vector = new Vector3(80, 0, 0);
                self.GetState("Beam Sweep L 2").GetAction<iTweenMoveBy>().vector = new Vector3(-100, 0, 0);
                self.GetState("Beam Sweep R 2").GetAction<iTweenMoveBy>().vector = new Vector3(100, 0, 0);

                self.GetState("Beam Sweep L").GetAction<SetPosition>().x.Value = 89;
                self.GetState("Beam Sweep R").GetAction<SetPosition>().x.Value = 32.6f;

            }

        }

    }
}
