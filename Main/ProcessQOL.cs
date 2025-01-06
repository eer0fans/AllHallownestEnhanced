using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vasi;

namespace AllHallownestEnhanced.Main
{
    public class ProcessQOL : SingletonMono<ProcessQOL>
    {

        //无FSM
        public void Process_QOL(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            if (!AllHallownestEnhanced.settings_.on)
                return;
            StartCoroutine(Dealy_QOL(to.name, 0.02f));
        }

        IEnumerator Dealy_QOL(string nowSceneName, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            //德特矛斯走路区
            if (nowSceneName == "Town")
            {
                GameObject.Destroy(GameObject.Find("Walk Area"));
                GameObject.Destroy(GameObject.Find("Walk Area 2"));
            }
        }


        //有FSM
        public void PlayMakerFSM_Process_QOL(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            PlayMakerFSM_Process_Knight(orig, self);
            PlayMakerFSM_Process_NPC(orig, self);
            PlayMakerFSM_Process_GetItem(orig, self);
            PlayMakerFSM_Process_Bench(orig, self);
            PlayMakerFSM_Process_Switch(orig, self);
            PlayMakerFSM_Process_DreamPoint(orig, self);
            PlayMakerFSM_Process_BattleRoomQOL(orig, self);

        }


        #region 详细
        //小骑士
        public void PlayMakerFSM_Process_Knight(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            if (AllHallownestEnhanced.settings_.fastSuperdash)
            {
                //超冲
                if (self.gameObject.name == "Knight" && self.FsmName == "Superdash")
                {
                    self.FsmVariables.FindFsmFloat("Cancelable Time").Value = 0.01f;
                    self.FsmVariables.FindFsmFloat("Charge Time").Value = 0.01f;
                    self.FsmVariables.FindFsmFloat("Superdash Speed").Value = 45;
                    self.FsmVariables.FindFsmFloat("Superdash Speed neg").Value = -45;

                }
            }
            if (AllHallownestEnhanced.settings_.fastDreamDoor)
            {
                //梦门
                if (self.gameObject.name == "Knight" && self.FsmName == "Dream Nail")
                {
                    self.GetState("Set Charge Start").GetAction<Wait>().time.Value = 0.1f;
                    self.GetState("Set Charge").GetAction<Wait>().time.Value = 0.1f;
                    self.GetState("Set Antic").GetAction<Wait>().time.Value = 0.1f;

                    self.GetState("Warp Charge Start").GetAction<Wait>().time.Value = 0.1f;
                    self.GetState("Warp Charge").GetAction<Wait>().time.Value = 0.1f;
                    self.GetState("Warp End").GetAction<Wait>().time.Value = 0.1f;
                }
            }
        }
        //NPC
        public void PlayMakerFSM_Process_NPC(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //科尼法买地图
            if (self.gameObject.name == "Cornifer" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("YN Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Geo Pause and GetMap").GetAction<Wait>().time.Value = 0.1f;

                self.GetState("Get F Map").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Prompt Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Map End").GetAction<Wait>().time.Value = 0.1f;
            }
            //虫爷爷
            if (self.gameObject.name == "Grub King" && self.FsmName == "King Control")
            {
                self.GetState("Cheer Pause").GetAction<Wait>().time.Value = 0.1f;
                //self.ChangeTransition("Final Reward?", "FINISHED", "Recheck");
                self.GetState("Recover Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            //商店购买物品
            if (self.gameObject.name == "Shop Menu" && self.FsmName == "shop_control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 5").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Activate Item List").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Down").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Item List" && self.FsmName == "ui_list_getinput")
            {
                self.GetState("Confirm").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cancel").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "UI List" && self.FsmName == "Confirm Control")
            {
                self.GetState("Bob").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Particles").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Blessing").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get F Map").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Prompt Down").GetAction<Wait>().time.Value = 0.1f;
            }
            //先知
            if (self.gameObject.name == "Dream Dialogue" && self.FsmName == "npc_dream_dialogue")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Dream Moth" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 5").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 6").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 7").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 8").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 9").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 10").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 11").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Relic2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Door Open").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Open").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Ore").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Charm").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Relic4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get DN Upgrade").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Nail Flash").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Casting").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Boom").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Depart").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Depart Charge").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Disappear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get DN Upgrade 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Nail Flash 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Casting 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Boom 2").GetAction<Wait>().time.Value = 0.1f;
            }
            //灰色哀悼者
            if (self.gameObject.name == "Xun NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down2 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Decline Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Yes Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Give Flower").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Crumble Antic").GetAction<Wait>().time.Value = 0.1f;
            }
            //3000块钱
            if (self.gameObject.name == "Fountain Donation" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Dial Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Full Donation").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Decline Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Wishing_Well_anims" && self.FsmName == "Fountain Control")
            {
                self.GetState("Appear Anim").GetAction<Wait>().time.Value = 0.1f;
            }
            //升骨钉
            if (self.gameObject.name == "Nailsmith" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Dial Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Decline Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Yes").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cinematic End").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade In").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Leave Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade In 2").GetAction<Wait>().time.Value = 0.1f;
            }
            //剑技
            if ((self.gameObject.name == "NM Sheo NPC" || self.gameObject.name == "NM Mato NPC" || self.gameObject.name == "NM Oro NPC")
                && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Decline Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Yes").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cinematic End").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Back").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Bow").GetAction<Wait>().time.Value = 0.1f;
            }
            //乌恩
            if (self.gameObject.name == "Giant Slug NPC" && self.FsmName == "Control")
            {
                self.GetState("Enter Pause").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Emerge").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Leave Pause").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Submerge").GetAction<Wait>().time.Value = 0.5f;
            }
            //银行家
            if (self.gameObject.name == "Banker Spa NPC" && self.FsmName == "Hit Around")
            {
                self.GetState("Give Geo").GetAction<IntCompare>(1).integer2.Value = 10000;
                self.GetState("Give Geo").GetAction<RandomInt>(4).min.Value = 100;
                self.GetState("Give Geo").GetAction<RandomInt>(4).max.Value = 100;
                self.GetState("Give Geo").GetAction<RandomInt>(7).min.Value = 100;
                self.GetState("Give Geo").GetAction<RandomInt>(7).max.Value = 100;
                self.GetState("Give Geo").GetAction<RandomInt>(11).min.Value = 100;
                self.GetState("Give Geo").GetAction<RandomInt>(11).max.Value = 100;
            }
            //格林房间
            if (self.gameObject.name == "Dream Enter Grimm" && self.FsmName == "Control")
            {
                self.GetState("Dream Box Down").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Defeated NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Bow Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Bow").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Applause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 5").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 6").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Hand Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Click").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flame Ring").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Level Up To 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Final Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Gates Open").GetAction<Wait>().time.Value = 0.1f;
            }
            //集火
            if (self.gameObject.name == "Brumm Torch NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Give Antic").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Give").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flame Ring").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Flamebearer Spawn" && self.FsmName == "Spawn Control")
            {
                self.GetState("Get Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flame Ring").GetAction<Wait>().time.Value = 0.1f;
            }
            //竞技场小傻子
            if (self.gameObject.name == "Little Fool NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Dial Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Decline Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Yes").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pan").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Open Event").GetAction<Wait>().time.Value = 0.1f;
            }
            //泪城中心电影
            if (self.gameObject.name == "Hornet Fountain Encounter" && self.FsmName == "Control")
            {
                self.GetState("Fade Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Position").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade In").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Jump").GetAction<Wait>().time.Value = 0.1f;
            }
            //苦痛末尾
            if (self.gameObject.name == "End Scene" && self.FsmName == "Conversation Control")
            {
                self.GetState("Hero Anim").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Disappear Scne").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Orb Away").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Journal").GetAction<Wait>().time.Value = 0.1f;
            }
            //奎若
            if (self.gameObject.name == "Quirrel" && self.FsmName == "Control")
            {
                self.GetState("Leap Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Leap In Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Quirrel" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Hold Anim").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Going").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Tendrils Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Monomon Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Finish").GetAction<Wait>().time.Value = 0.1f;
            }

        }
        //获取道具能力
        public void PlayMakerFSM_Process_GetItem(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //geoRock
            if (self.gameObject.name.Contains("Geo Rock") && self.FsmName == "Geo Rock")
            {
                int finalPayout = self.FsmVariables.FindFsmInt("Final Payout").Value;
                int geoPerHit = self.FsmVariables.FindFsmInt("Geo Per Hit").Value;
                int hits = self.FsmVariables.FindFsmInt("Hits").Value;

                self.GetState("Hit").GetAction<FlingObjectsFromGlobalPool>().spawnMax = new FsmInt(geoPerHit * hits);
                self.GetState("Hit").GetAction<FlingObjectsFromGlobalPool>().spawnMin = new FsmInt(geoPerHit * hits);
                self.GetState("Hit").GetAction<IntOperator>().integer2.Value = hits;
            }
            //获取面具碎片动画
            if (self.gameObject.name.Contains("Heart Piece") && self.FsmName == "Heart Container Control")
            {
                self.GetState("Get").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Heart Container UI") && self.FsmName == "Heart Container UI")
            {
                self.GetState("Piece Fade").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Piece Get Particles").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fuse").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Max Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade").GetAction<Wait>().time.Value = 0.1f;
            }
            //获取容器碎片
            if (self.gameObject.name.Contains("Vessel Fragment") && self.FsmName == "Vessel Fragment Control")
            {
                self.GetState("Get").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Vessel Fragment UI") && self.FsmName == "Vessel Fragment UI")
            {
                self.GetState("Piece Ready").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Piece Fade").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Piece Fade 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Piece Get Particles").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fuse").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Max Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade").GetAction<Wait>().time.Value = 0.1f;
            }
            //捡item
            if (self.gameObject.name.Contains("Shiny Item") && self.FsmName == "Shiny Control")
            {
                self.GetState("Hero Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Tute").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flash").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Big Get Flash").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Trink Pause").GetAction<Wait>().time.Value = 0.1f;
                //self.GetState("Fade Pause").GetAction<Wait>().time.Value = 0.1f;
                //self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;

            }
            //白波
            if (self.gameObject.name == "Knight Get Fireball" && self.FsmName == "Get Fireball")
            {
                self.GetState("Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.1f;
            }
            //所有技能获取UI
            if (self.gameObject.name.Contains("UI Msg Get Item") && self.FsmName == "Msg Control")
            {
                self.GetState("Top Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Bot Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Stop Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Down").GetAction<Wait>().time.Value = 0.1f;
            }
            //下砸
            if (self.gameObject.name == "Knight Get Quake" && self.FsmName == "Get Quake")
            {
                self.GetState("Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fall").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Quake Pickup" && self.FsmName == "Pickup")
            {
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cascade Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Arrival Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Cascade End").GetAction<Wait>().time.Value = 0.1f;
            }
            //黑波
            if (self.gameObject.name == "Knight Get Fireball Lv2" && self.FsmName == "Get Fireball")
            {
                self.GetState("Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Up Anim").GetAction<Wait>().time.Value = 0.1f;
            }
            //黑砸
            if (self.gameObject.name == "Crystal Shaman" && self.FsmName == "Control")
            {
                //self.GetState("Hit").GetAction<IntCompare>().integer2.Value = 1;
                self.GetState("Orbs").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get Up").GetAction<Wait>().time.Value = 0.1f;
            }
            //获取梦钉
            if (self.gameObject.name == "Dreamer Plaque Inspect" && self.FsmName == "Conversation Control")
            {
                self.GetState("Hero Anim").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Msg Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pan Back").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Map Msg?").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Dreamer Scene 2" && self.FsmName == "Control")
            {
                self.GetState("Hero Fall").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flyby 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flyby 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flyby 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Lurien Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Monomon Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Hegemol Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Casting").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Dial Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Witch Control" && self.FsmName == "Control")
            {
                self.GetState("First Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Repeat Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Witch Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Move 1").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Moth NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Moth Leave").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Nail Appear").GetAction<Wait>().time.Value = 0.1f;
            }
            //白吼
            if (self.gameObject.name == "Knight Get Scream" && self.FsmName == "Get Scream")
            {
                self.GetState("Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fall").GetAction<Wait>().time.Value = 0.1f;
            }
            //黑吼
            if (self.gameObject.name == "Scream 2 Get" && self.FsmName == "Scream Get")
            {
                self.GetState("Get Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Moved Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Spill").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Spill").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Orb Spawn").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Getting").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
            }
            //黑冲
            if (self.gameObject.name == "Dish Plat" && self.FsmName == "Get Shadow Dash")
            {
                self.GetState("Fall").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shaking").GetAction<Wait>().time.Value = 0.1f;
            }
            //二段跳
            if (self.gameObject.name == "Shiny Item DJ" && self.FsmName == "DJ Control")
            {
                self.GetState("Getting").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Get2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
            }
            //酸泪
            if (self.gameObject.name == "Shiny Item Acid" && self.FsmName == "Control")
            {
                self.GetState("Grab").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Push").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Stop Push").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Finish").GetAction<Wait>().time.Value = 0.1f;
            }
            //黑蛋
            if (self.gameObject.name == "door_dreamReturn" && self.FsmName == "Door Control")
            {
                self.GetState("Unvisited").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Visited").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Normal Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Enter").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pan Up").GetAction<Wait>().time.Value = 0.1f;
            }
            //黑心动画
            if (self.gameObject.name == "Entry Cutscene" && self.FsmName == "Control")
            {
                self.GetState("Start Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Corpse 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Corpse 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Corpse 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("First Shake").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Climb 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Climb 2").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "End Cutscene" && self.FsmName == "Control")
            {
                self.GetState("Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("King Look").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("King Leave").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("HK Step").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Clamber1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Clamber Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Look").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Leave Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("HK Leave").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Falter").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Shake").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fall").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Black").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Charm Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Return Pause").GetAction<Wait>().time.Value = 0.1f;
            }
        }
        //坐椅子开车站
        public void PlayMakerFSM_Process_Bench(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //坐椅子
            if (self.gameObject.name.Contains("Bench") && self.FsmName == "Bench Control")
            {
                self.GetState("Start Rest").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Pause").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Resting Init").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Resting").GetAction<Wait>().time.Value = 9999;
                //self.GetState("Open Map").GetAction<Wait>().time.Value = 0.05f;
                //self.GetState("Inv Map Open").GetAction<Wait>().time.Value = 0.05f;

                self.GetState("Get Off").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Idle Pause").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Regain Control").GetAction<Wait>().time.Value = 0.05f;

            }
            //开车站
            if (self.gameObject.name.Contains("Station Bell") && self.FsmName == "Stag Bell")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause Before Box Drop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Disappear Anim").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Bell Up Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Regain Control").GetAction<Wait>().time.Value = 0.1f;

            }
            //收费椅子
            if (self.gameObject.name.Contains("Toll Machine Bench") && self.FsmName == "Toll Machine Bench")
            {
                self.GetState("Pause Before Box Drop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Bench Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Regain Control").GetAction<Wait>().time.Value = 0.1f;
            }
            //假椅子
            if (self.gameObject.name == "RestBench Spider" && self.FsmName == "Bench Control Spider")
            {
                self.GetState("Start Rest").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Sit Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Start Left").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Start Right").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "RestBench Spider" && self.FsmName == "Fade")
            {
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Start Fade").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Finish Fade").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Finish Fade").GetAction<TransitionToAudioSnapshot>().transitionTime.Value = 0.1f;
                self.GetState("Sound 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Capture End").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Up").GetAction<SetFsmFloat>().setValue.Value = 0.1f;
                self.GetState("Fade Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
            }
            //蜂巢椅子
            if (self.gameObject.name == "Hive Bench" && self.FsmName == "Control")
            {
                self.GetState("Hit").GetAction<IntCompare>(7).integer2.Value = 1;
                self.GetState("Hit").GetAction<IntCompare>(8).integer2.Value = 2;
            }

        }
        //各种开关
        public void PlayMakerFSM_Process_Switch(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //教程大门
            if (self.gameObject.scene.name == "Tutorial_01" && self.gameObject.name == "Door" && self.FsmName == "Great Door")
            {
                self.GetState("Check Hits").GetAction<IntSwitch>().compareTo = new FsmInt[3] { 1, 2, 3 };
            }
            //单向门
            if (self.gameObject.name.Contains("Break Floor") && self.FsmName == "break_floor")
            {
                self.ChangeTransition("Hit", "HIT 1", "Break");
                self.ChangeTransition("Hit", "HIT 2", "Break");
            }
            if (self.gameObject.name.Contains("One Way Wall") && self.FsmName == "break_floor")
            {
                self.ChangeTransition("Hit", "HIT 1", "PlayerData");
                self.ChangeTransition("Hit", "HIT 2", "PlayerData");
            }
            //隐藏墙
            if (self.gameObject.name.Contains("Break Wall") && self.FsmName == "FSM")
            {
                self.ChangeTransition("Hit", "FINISHED", "Pause Frame");
            }
            if (self.gameObject.name.Contains("Breakable Wall") && self.FsmName == "breakable_wall_v2")
            {
                self.ChangeTransition("Hit", "FINISHED", "Pause Frame");
            }
            if (self.gameObject.name.Contains("Hive Breakable Pillar") && self.FsmName == "Pillar")
            {
                self.FsmVariables.FindFsmInt("Hits").Value = 1;
            }

            //大门开关
            if ((self.gameObject.name.Contains("Gate Switch") || self.gameObject.name.Contains("Lever"))
                && self.FsmName == "Switch Control")
            {
                self.GetState("Hit").GetAction<Wait>().time.Value = 0.1f;
            }
            //吉吉大门
            if (self.gameObject.name == "door_jiji" && self.FsmName == "Door Control")
            {
                self.GetState("Pan Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Enter").GetAction<Wait>().time.Value = 0.1f;
            }
            //泪城大门
            if (self.gameObject.name == "Ruins_gate_main" && self.FsmName == "Open")
            {
                self.GetState("Open 1").GetAction<Wait>().time.Value = 0.1f;
            }
            //泪城电梯
            if (self.gameObject.name.Contains("Control Lever") && self.FsmName == "Control Lever")
            {
                self.GetState("Idle Anim").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Down").GetAction<Wait>().time.Value = 0.01f;
                self.GetState("Up").GetAction<Wait>().time.Value = 0.01f;
            }
            //大电梯开关
            if (self.gameObject.name == "Toll Machine Lift" && self.FsmName == "Toll Machine")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Regain Control").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause Before Box Drop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Disappear Anim").GetAction<Wait>().time.Value = 0.1f;
            }
            //大电梯
            if (self.gameObject.name == "elev_main" && self.FsmName == "Lift lower")
            {
                self.GetState("Come Down").GetAction<iTweenMoveTo>().time.Value = 0.1f;
                self.GetState("Come Down").GetAction<iTweenMoveTo>().delay.Value = 0.1f;
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "elev_main" && self.FsmName == "Lift Move")
            {
                self.GetState("Close").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Move Out").GetAction<iTweenMoveBy>().time.Value = 0.1f;
                self.GetState("Move Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade").GetAction<Wait>().time.Value = 0.1f;
            }
            //深渊大门
            if (self.gameObject.name == "abyss_door" && self.FsmName == "Control")
            {
                self.GetState("Open Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Open Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Opening").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Orbing").GetAction<Wait>().time.Value = 0.1f;
            }
            //蓝心门
            if (self.gameObject.name == "Blue Plinth" && self.FsmName == "Control")
            {
                self.GetState("Start Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Glow Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Send Event").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Complete Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Final Glow").GetAction<Wait>().time.Value = 0.1f;
            }
            //格林大脑
            if (self.gameObject.name == "grimm_brazier" && self.FsmName == "grimm_brazier")
            {
                self.GetState("Spark").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Rumble").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Light").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Arrival Rumble").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Arrive Event").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Final Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Final Shake").GetAction<Wait>().time.Value = 0.1f;

                self.GetState("Spark 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flare Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Explode").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Destroyed").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Back").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Back").GetAction<SetFsmFloat>().setValue.Value = 0.05f;
                self.GetState("Fade Back").GetAction<SendEventByName>().delay.Value = 0.05f;
            }
            //电车
            if (self.gameObject.name == "Tram Call Box" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Yes").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Flash").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Start Shake").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Call Tram").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Door Inspect" && self.FsmName == "Tram Door")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Y Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Door Shake").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Open").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("No").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Regain Control").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Tram Control" && self.FsmName == "Control")
            {
                self.GetState("Shake").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Tween Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade In").GetAction<Wait>().time.Value = 0.1f;
                //self.GetState("Sound Fade").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name == "Inspect Region" && self.FsmName == "Control")
            {
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Y Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("N Box Down").GetAction<Wait>().time.Value = 0.1f;
            }
        }
        //梦境精华
        public void PlayMakerFSM_Process_DreamPoint(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            //梦境战士
            if (self.gameObject.name == "Ghost Warrior NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up YN").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down Yes").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down No").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Ready").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Glow").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Burst").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanisher Stop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Collected").GetAction<Wait>().time.Value = 0.1f;
            }
            //假骑士
            if (self.gameObject.name == "Ghost False Knight NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 4").GetAction<Wait>().time.Value = 0.1f;

                self.GetState("Vanish Glow").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Burst").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanisher Stop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Collected").GetAction<Wait>().time.Value = 0.1f;
            }
            //灵魂暴君
            if (self.gameObject.name == "Ghost Mage Lord NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 4").GetAction<Wait>().time.Value = 0.1f;

                self.GetState("Vanish Glow").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Burst").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanisher Stop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Collected").GetAction<Wait>().time.Value = 0.1f;
            }
            //梦表
            if (self.gameObject.name == "Ghost Infected Knight NPC" && self.FsmName == "Conversation Control")
            {
                self.GetState("Start Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Bow Anim").GetAction<Wait>().time.Value = 0.1f;

                self.GetState("Vanish Glow").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Burst").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get Start").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanish Get").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Vanisher Stop").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Collected").GetAction<Wait>().time.Value = 0.1f;
            }
        }
        //战斗房
        public void PlayMakerFSM_Process_BattleRoomQOL(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            #region 十字路
            //十字路战斗房
            if (self.gameObject.scene.name == "Crossroads_08" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Wave Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //假骑士
            if (self.gameObject.scene.name == "Crossroads_10_boss" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //格鲁兹
            if (self.gameObject.scene.name == "Crossroads_04" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //电饭煲
            if (self.gameObject.scene.name == "Crossroads_09" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Blow Wait").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //发光子宫
            if (self.gameObject.scene.name == "Crossroads_22" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Pause W 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause W 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause W 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Blob Open").GetAction<Wait>().time.Value = 0.1f;
            }
            //先辈
            if (self.gameObject.scene.name == "Room_Final_Boss_Core" && self.gameObject.name == "Hollow Knight Boss" && self.FsmName == "Control")
            {
                self.GetState("H Stab Antic").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("H Scene 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("H Scene 2").GetAction<Wait>().time.Value = 0.1f;
            }
            //福光
            if (self.gameObject.scene.name == "Dream_Final_Boss" && self.gameObject.name == "Boss Control" && self.FsmName == "Control")
            {
                self.GetState("Challenge Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Sun Antic").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Antic Rumble").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Appear Boom").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Title Up").GetAction<Wait>().time.Value = 0.5f;
                //self.GetState("Refight Pause").GetAction<Wait>().time.Value = 0.5f;
            }
            if (self.gameObject.name == "Radiance" && self.FsmName == "Control")
            {
                self.GetState("Knight Pull").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Ball Tween").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Tendrils 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Shade Antic").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Shade Pull").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Pulling").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Break").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Kill Hit").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Tendrils 3").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Yank Down").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Final Black").GetAction<Wait>().time.Value = 0.5f;
            }
            #endregion


            #region 苍绿
            //苔藓骑士
            if (self.gameObject.scene.name == "Fungus1_32" && self.gameObject.name == "Battle Scene v2" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //一见
            if (self.gameObject.scene.name == "Fungus1_04" && self.gameObject.name == "Dreamer Scene 1" && self.FsmName == "Control")
            {
                self.GetState("Land").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Lurien Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Monomon Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Hegemol Appear").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Casting").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade Out").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Fade In").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 真菌
            //磕头菇
            if (self.gameObject.scene.name == "Fungus2_05" && self.gameObject.name == "Battle Scene v2" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Drop Item").GetAction<Wait>().time.Value = 0.1f;
            }
            //三螳螂
            if (self.gameObject.scene.name == "Fungus2_15_boss" && self.gameObject.name == "Mantis Battle" && self.FsmName == "Battle Control")
            {
                self.GetState("Return 2").GetAction<Wait>().time.Value = 0.5f;
                self.GetState("Bow").GetAction<Wait>().time.Value = 0.5f;
            }
            #endregion


            #region 泪城
            //泪城椅子前
            if (self.gameObject.scene.name == "Ruins1_05" && self.gameObject.name == "Battle Scene v2" && self.FsmName == "Battle Control")
            {
                self.GetState("W2 Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //灵魂小师
            if (self.gameObject.scene.name == "Ruins1_09" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Enemy Killed").GetAction<Wait>().time.Value = 0.1f;
            }
            //灵魂战士
            if (self.gameObject.scene.name == "Ruins1_23" && self.gameObject.name == "Battle Scene v2" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //灵魂战士2
            if (self.gameObject.scene.name == "Ruins1_31b" && self.gameObject.name == "Battle Scene v2" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //国王驿站碎片
            if (self.gameObject.scene.name == "Ruins2_09" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("W2 Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause W 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause W 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            //幼虫房
            if (self.gameObject.scene.name == "Ruins_House_01" && self.gameObject.name == "Battle Scene" && self.FsmName == "Control")
            {
                self.GetState("Killed Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 山峰
            //苟哥
            if (self.gameObject.scene.name == "Mines_18" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Scene")
            {
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            //暴怒苟哥
            if (self.gameObject.scene.name == "Mines_32" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Scene")
            {
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 下水道
            if (self.gameObject.scene.name == "Waterways_09" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.scene.name == "Waterways_13" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 雾谷
            if (self.gameObject.scene.name == "Fungus3_archive_02_boss" && self.gameObject.name == "Battle Scene" && self.FsmName == "Control")
            {
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 盆地
            if (self.gameObject.scene.name == "Abyss_17" && self.gameObject.name == "Battle Scene Ore" && self.FsmName == "Battle Control")
            {
                self.GetState("Completed").GetAction<SendEventByName>().delay.Value = 0.1f;
            }
            if (self.gameObject.scene.name == "Abyss_19" && self.gameObject.name == "infected_door" && self.FsmName == "Control")
            {
                self.GetState("Open Rumble").GetAction<Wait>().time.Value = 0.1f;
            }

            #endregion


            #region 边缘
            if (self.gameObject.scene.name == "Deepnest_East_Hornet_boss" && self.gameObject.name == "Hornet Outskirts Battle Encounter" && self.FsmName == "Encounter")
            {
                self.GetState("Box Up").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Up 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Box Down 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Idle Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Blizzard Start").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 深巢
            if (self.gameObject.scene.name == "Deepnest_33" && self.gameObject.name == "Battle Scene v2" && self.FsmName == "Battle Control")
            {
                self.GetState("End Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.scene.name == "Deepnest_32" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Scene")
            {
                self.GetState("Wait").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion


            #region 花园
            if (self.gameObject.scene.name == "Fungus3_05" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Pause 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.scene.name == "Fungus3_39" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Open Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.scene.name == "Fungus3_10" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Pause 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Lil Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 4").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.scene.name == "Fungus3_23_boss" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("Pause 3").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 1").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Pause 2").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }

            #endregion


            #region 白宫
            if (self.gameObject.scene.name == "White_Palace_02" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            //苦痛末尾
            if (self.gameObject.scene.name == "White_Palace_20" && self.gameObject.name == "Battle Scene" && self.FsmName == "Battle Control")
            {
                self.GetState("End Pause").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Sting").GetAction<Wait>().time.Value = 0.1f;
            }
            #endregion




        }
        #endregion
    }
}
