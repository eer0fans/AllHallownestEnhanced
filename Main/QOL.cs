using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Vasi;

namespace AllHallownestEnhanced
{
    public class QOL : SingletonBase<QOL>
    {

        //跳过空房间
        public bool SkipEmptyRoom(On.BossSequence.orig_CanLoad orig, BossSequence self, int index)
        {
            orig(self, index);
            if (!AllHallownestEnhanced.settings_.on)
                return orig(self, index);
            switch (self.name)
            {
                case "Boss Sequence Tier 1":
                case "Boss Sequence Tier 2":
                case "Boss Sequence Tier 3":
                case "Boss Sequence Tier 4":
                    return index != 10 && orig(self, index);
                case "Boss Sequence Tier 5":
                    return index != 5 && index != 30 && index != 43 && index != 50 && orig(self, index);
            }
            return orig(self, index);
        }

        //温泉恢复速度
        public void PlayMakerFSM_Spa(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (self.gameObject.name.Contains("Spa Region") && self.FsmName == "Spa Region")
            {
                self.GetState("Stay").GetAction<Wait>().time.Value = 0.1f;
                self.GetState("Heal Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Spa Region") && self.FsmName == "Heal HP")
            {
                self.GetState("Heal Pause").GetAction<Wait>().time.Value = 0.1f;
            }
            if (self.gameObject.name.Contains("Spa Region") && self.FsmName == "Heal Soul")
            {
                self.GetState("Heal Pause").GetAction<Wait>().time.Value = 0.005f;
            }
        }

        //椅子、灵魂雕像
        public void BenchQOL(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (to.name == "GG_Spa")
            {
                //椅子
                GameObject obj = GameObject.Instantiate(AddEnemy.Instance.enemyDic["RestBench (1)"], new Vector3(87.5f, 14.77f, 0.08f), Quaternion.identity);
                obj.SetActive(true);
                //先辈雕像
                obj = GameObject.Instantiate(AddEnemy.Instance.enemyDic["Soul Totem white_Infinte"], new Vector3(78f, 16.9f, 0.1f), Quaternion.identity);
                obj.SetActive(true);
            }
        }

        //雕像回蓝速度
        public void PlayMakerFSM_SoulTotem(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            orig(self);
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (self.gameObject.name.Contains("Soul Totem white_Infinte") && self.FsmName == "soul_totem")
            {
                self.GetState("Hit").GetAction<Wait>().time.Value = 0.05f;
                self.GetState("Hit").GetAction<FlingObjectsFromGlobalPool>().spawnMax.Value = 100;
                self.GetState("Hit").GetAction<FlingObjectsFromGlobalPool>().spawnMin.Value = 100;
            }
        }

    }
}
