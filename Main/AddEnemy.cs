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
using UnityEngine.Events;
using System.IO;
using System.Linq;


namespace AllHallownestEnhanced
{
    public class AddEnemy : SingletonMono<AddEnemy>
    {
        //预加载的敌人种类的字典
        public Dictionary<string, GameObject> enemyDic = new Dictionary<string, GameObject>();

        //每当场景切换时会自动调用
        public void ActiveSceneChanged(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            if (!AllHallownestEnhanced.settings_.on)
                return;
            if (!AllHallownestEnhanced.settings_.moreEnemy)
                return;
            Modding.Logger.Log(from.name + " to " + to.name);

            StartCoroutine(Delay_AddEnemy(to.name, 0.02f));
        }

        //延迟添加敌人
        IEnumerator Delay_AddEnemy(string nowSceneName, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            Skip_Enemy(nowSceneName);
            HardJump_Enemy(nowSceneName);
            Refreshing_Enemy(nowSceneName);
            KeyRegion_Enemy(nowSceneName);
            AllRemainingRegion(nowSceneName);
        }

        #region 加怪
        //skip怪
        public void Skip_Enemy(string nowSceneName)
        {
            //萨鲁巴*2
            AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["_Enemies/Buzzer"], 135, 10);
            AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["_Enemies/Buzzer"], 130, 15);
            //十字路→真菌荒地
            AddEnemyInScene(nowSceneName, "Crossroads_18", enemyDic["_Enemies/Buzzer"], 16, 28);
            AddEnemyInScene(nowSceneName, "Crossroads_18", enemyDic["_Enemies/Buzzer"], 30, 24);
            //十字路幼虫
            AddEnemyInScene(nowSceneName, "Crossroads_05", enemyDic["_Enemies/Buzzer"], 50, 15);
            //十字路碎片
            AddEnemyInScene(nowSceneName, "Crossroads_13", enemyDic["_Enemies/Buzzer"], 26, 14);
            //悬崖上鹿角站
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["_Enemies/Buzzer"], 37, 40);
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["_Enemies/Buzzer"], 30, 45);

            //苍绿速通路线 * 2
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mosquito"], 8, 58);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["Mosquito"], 50, 20);
            //苍绿草团子
            AddEnemyInScene(nowSceneName, "Fungus1_11", enemyDic["Mosquito"], 7, 30);
            //苍绿容器碎片
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Acid Flyer"], 72, 10);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Acid Flyer"], 66, 24);


            //螳螂村批核弹
            AddEnemyInScene(nowSceneName, "Fungus2_11", enemyDic["Fungus Flyer"], 6.5f, 10);
            //真菌二段跳
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Fungoon Baby"], 81, 35.5f);

            //蓝湖腐臭蛋
            AddEnemyInScene(nowSceneName, "Crossroads_50", enemyDic["_Enemies/Buzzer"], 30, 42);
            AddEnemyInScene(nowSceneName, "Crossroads_50", enemyDic["_Enemies/Buzzer"], 40, 40);
            AddEnemyInScene(nowSceneName, "Crossroads_50", enemyDic["_Enemies/Buzzer"], 50, 38);
            AddEnemyInScene(nowSceneName, "Crossroads_50", enemyDic["_Enemies/Buzzer"], 60, 36);

            //盆地批波 * 2
            AddEnemyInScene(nowSceneName, "Abyss_04", enemyDic["Parasite Balloon (1)"], 86, 11);
            AddEnemyInScene(nowSceneName, "Abyss_18", enemyDic["Parasite Balloon (1)"], 30, 9);
            AddEnemyInScene(nowSceneName, "Abyss_18", enemyDic["Parasite Balloon (1)"], 32.5f, 6.5f);
            AddEnemyInScene(nowSceneName, "Abyss_18", enemyDic["Parasite Balloon (1)"], 42, 8);

            //祖先山丘梦树
            AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 14, 56);
            //城市仓库电梯左→右
            AddEnemyInScene(nowSceneName, "Ruins1_28", enemyDic["Ruins Flying Sentry"], 44, 14);

            //城市仓库简单钥匙
            AddEnemyInScene(nowSceneName, "Ruins1_17", enemyDic["Ruins Flying Sentry Javelin"], 52, 49);
            //暴怒守卫
            AddEnemyInScene(nowSceneName, "Mines_18", enemyDic["Cave Spikes (3)"], 50.5f, 16.3f, 230);
            AddEnemyInScene(nowSceneName, "Mines_18", enemyDic["Cave Spikes (3)"], 54.4f, 16.5f, 129);
            AddEnemyInScene(nowSceneName, "Mines_18", enemyDic["Cave Spikes (3)"], 49.4f, 15f, 231);
            AddEnemyInScene(nowSceneName, "Mines_18", enemyDic["Cave Spikes (3)"], 55.5f, 15.2f, 131);

            //王后驿站
            AddEnemyInScene(nowSceneName, "Fungus2_01", enemyDic["Moss Flyer (1)"], 36, 38);
            AddEnemyInScene(nowSceneName, "Fungus2_01", enemyDic["Moss Flyer (1)"], 17.5f, 24);

            //蜂巢
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Big Bee (3)"], 150, 99);

            //双巴尔德
            AddEnemyInScene(nowSceneName, "Fungus1_28", enemyDic["_Enemies/Buzzer"], 60, 27.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_28", enemyDic["_Enemies/Buzzer"], 79.5f, 36);

            //德特矛斯→水晶
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 12);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 17);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 22);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 27);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 32);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 37);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 42);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 47);
            AddEnemyInScene(nowSceneName, "Town", enemyDic["Mines Platform"], 238.5f, 52);

            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 15, 4.5f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 21, 4.5f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 42, 1);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 47, 1);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 52, 2);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 58, 6);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 58, 11);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 86.5f, 6f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 93.5f, 5f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 123, 2.5f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 128, 2.5f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 154, 7f);
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Mines Platform"], 163, 7f);

            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 23, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 33, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 43, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 53, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 63, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 73, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 83, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 93, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 103, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 113, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 123, 6.5f);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Mines Platform"], 133, 6.5f);

            //花园
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Moss Flyer (1)"], 71.5f, 34.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Moss Flyer (1)"], 23.5f, 9.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_43", enemyDic["Moss Flyer (1)"], 21.5f, 88);
            AddEnemyInScene(nowSceneName, "Deepnest_43", enemyDic["Moss Flyer (1)"], 24, 85);

            //升骨钉
            AddEnemyInScene(nowSceneName, "Ruins1_04", enemyDic["_Enemies/Buzzer"], 7, 26);
            AddEnemyInScene(nowSceneName, "Ruins1_04", enemyDic["_Enemies/Buzzer"], 10.5f, 33);

            //开关位置
            if (nowSceneName == "Ruins1_18")
            {
                GameObject obj = GameObject.Find("Ruins Lever");
                obj.transform.localPosition = new Vector3(10.6f, 20.734f, 0.01f);
            }

            //泪城雕像
            AddEnemyInScene(nowSceneName, "Ruins1_27", enemyDic["Ruins Flying Sentry"], 48, 11);

            //苍绿→花园
            if (nowSceneName == "Fungus1_13")
            {
                Destroy(GameObject.Find("Vine Platform (2)"));
            }

            //十字路→苍绿
            AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["Moss Flyer (1)"], 32.5f, 15);
        }

        //加难跑酷怪
        public void HardJump_Enemy(string nowSceneName)
        {
            //十字路幼虫
            AddEnemyInScene2(nowSceneName, "Crossroads_31", enemyDic["_Props/Cave Spikes"], 58.2f, 6.5f, 0, 0, 1.3f);
            AddEnemyInScene2(nowSceneName, "Crossroads_31", enemyDic["_Props/Cave Spikes"], 44.9f, 8.5f, 0, 0, 1.3f);

            //毛里克通道
            AddEnemyInScene2(nowSceneName, "Crossroads_25", enemyDic["_Props/Cave Spikes"], 12.5f, 11.3f, 0, 270, 1.3f);
            AddEnemyInScene2(nowSceneName, "Crossroads_25", enemyDic["_Props/Cave Spikes"], 16.4f, 14.5f, 0, 90, 1.3f);
            AddEnemyInScene2(nowSceneName, "Crossroads_25", enemyDic["_Props/Cave Spikes"], 6, 6.6f, 0, 0, 1);

            //蓄力斩通道
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 216, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 205, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 195, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 180, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 175, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 165, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 160, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 140, 10, 0, 0, 1);
            //AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 122, 10, 0, 0, 1);
            //AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 116, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 100, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 90, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 80, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 52, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 36, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 27, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_09", enemyDic["Acid Flyer"], 14, 10, 0, 0, 1);
            AddEnemyInScene2(nowSceneName, "Fungus1_15", enemyDic["Acid Flyer"], 48, 15, 0, 0, 1);


            //泪城通道
            AddEnemyInScene2(nowSceneName, "Fungus2_21", enemyDic["Zap Cloud"], 49, 26.5f, 0, 0, 1.5f);
            AddEnemyInScene2(nowSceneName, "Fungus2_21", enemyDic["Zap Cloud"], 57, 18.5f, 0, 0, 1.5f);
            AddEnemyInScene2(nowSceneName, "Fungus2_21", enemyDic["Zap Cloud"], 65.5f, 21, 0, 0, 1.5f);
            AddEnemyInScene2(nowSceneName, "Fungus2_21", enemyDic["Zap Cloud"], 84, 26.5f, 0, 0, 1.5f);

            //螳螂村
            AddEnemyInScene(nowSceneName, "Fungus2_14", enemyDic["Mantis Flyer Child"], 41.5f, 38.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_14", enemyDic["Mantis Flyer Child"], 64, 38.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_14", enemyDic["Mantis"], 29, 5.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_14", enemyDic["Mantis"], 83, 5.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_14", enemyDic["Mantis"], 38, 14.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_15", enemyDic["Mantis Flyer Child"], 12, 100.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_15", enemyDic["Mantis Flyer Child"], 8.5f, 69.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_15", enemyDic["Mantis Flyer Child"], 14.5f, 41.5f, 180);

            //小迷妹
            AddEnemyInScene2(nowSceneName, "Fungus2_23", enemyDic["Mushroom Turret"], 15, 29, 0, 180, 1);
            AddEnemyInScene(nowSceneName, "Fungus2_23", enemyDic["Mushroom Roller"], 26.5f, 61.5f);

            //水晶→安息
            AddEnemyInScene(nowSceneName, "Mines_07", enemyDic["Crystal Flyer"], 12, 13);
            AddEnemyInScene(nowSceneName, "Mines_07", enemyDic["Crystal Flyer"], 58, 13.5f);
            AddEnemyInScene(nowSceneName, "Mines_07", enemyDic["Crystal Flyer"], 83, 13.5f);

            //公交车
            if (nowSceneName == "Deepnest_38")
            {
                Destroy(GameObject.Find("Big Centipede"));
                //Destroy(GameObject.Find("Big Centipede (1)"));
                //Destroy(GameObject.Find("Big Centipede (2)"));
                Destroy(GameObject.Find("Big Centipede (3)"));
                Destroy(GameObject.Find("Big Centipede (4)"));
            }

            //水晶→德特矛斯
            AddEnemyInScene(nowSceneName, "Mines_10", enemyDic["Crystal Flyer"], 158, 16);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Crystal Flyer"], 57, 14);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Crystal Flyer"], 79, 16);
            AddEnemyInScene(nowSceneName, "Mines_30", enemyDic["Crystal Flyer"], 107, 16);

            //花园
            AddEnemyInScene(nowSceneName, "Fungus3_21", enemyDic["Mantis Heavy Flyer"], 29.5f, 17.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_23", enemyDic["Mantis Heavy Flyer"], 56.5f, 13);
            AddEnemyInScene(nowSceneName, "Fungus3_23", enemyDic["Mantis Heavy Flyer"], 35, 36.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_23", enemyDic["Mantis Heavy Flyer"], 51, 36.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_08", enemyDic["Mantis Heavy Flyer"], 121.5f, 9);
            AddEnemyInScene(nowSceneName, "Fungus3_08", enemyDic["Mantis Heavy Flyer"], 72, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_08", enemyDic["Mantis Heavy Flyer"], 40.5f, 16);
            AddEnemyInScene(nowSceneName, "Fungus3_08", enemyDic["Mantis Heavy Flyer"], 11, 14);
            AddEnemyInScene(nowSceneName, "Fungus3_04", enemyDic["Mantis Heavy Flyer"], 5, 24);
            AddEnemyInScene(nowSceneName, "Fungus3_04", enemyDic["Mantis Heavy Flyer"], 29, 12.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_49", enemyDic["Battle Scene/Mantis Heavy"], 22, 6.5f);


            #region 苦痛
            if (nowSceneName == "White_Palace_18")
            {
                //第一面
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 265, 22, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 259, 30, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 253, 38, 0, 0, 0.9f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 253, 45, 0, 0, 0.9f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 238, 67, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 233.5f, 83, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 222, 90, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 178, 97, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 184, 89, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 178, 81, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 172, 54, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 166.5f, 36, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 179, 59, 0, 0, 1.2f);

                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 147, 5, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 138, 14, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 128, 12, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 125, 18, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 120, 10, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 91, 35, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 84, 40, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 110, 11, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 113, 15, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 97, 13, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 99, 17, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 88, 23, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_18", enemyDic["saw_collection/wp_saw"], 92, 23, 0, 0, 1f);
            }

            if (nowSceneName == "White_Palace_17")
            {
                //第二面
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 84f, 16, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 85, 20, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 89, 24, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 50.5f, 37, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 20.5f, 37, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 44.5f, 27, 4.538f, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 15.5f, 25, 4.538f, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 8, 38, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 12, 43, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 8, 46, 0, 0, 1f);

                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 32, 66, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 37, 66, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 29, 58.5f, 4.538f, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 45, 58.5f, 4.538f, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 46.5f, 80, 4.538f, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 32.5f, 82, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 25, 83.5f, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 18, 84f, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 10, 102, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 10, 106, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["saw_collection/wp_saw"], 57, 109.5f, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 58, 101, 4.538f, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 56, 107, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_17", enemyDic["wp_trap_spikes"], 36, 104.5f, 4.538f, 0, 1f);
            }

            if (nowSceneName == "White_Palace_19")
            {
                //第三面
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 113.5f, 33.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 121.5f, 37.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 115.5f, 42, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["White Palace Fly"], 120, 42);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["White Palace Fly"], 115, 37.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["White Palace Fly"], 122, 50);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 125.5f, 57.5f, 4.538f, 90, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 125.5f, 68.5f, 4.538f, 90, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["White Palace Fly"], 115, 67);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 116, 74, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 118, 74, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 120, 74, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 122, 74, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 124, 74, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 126, 74, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 121, 80, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 111.5f, 71, 4.538f, 270, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 111.5f, 73, 4.538f, 270, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 120, 91.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 110.5f, 107.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 113.5f, 110.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 117.5f, 112, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 121.5f, 110.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 124.5f, 107.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 132, 102, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 138.8f, 98.5f, 4.538f, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["White Palace Fly"], 151, 103);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["White Palace Fly"], 150, 112.5f);
                Destroy(GameObject.Find("White Palace Fly (13)"));
                Destroy(GameObject.Find("White Palace Fly (16)"));
                Destroy(GameObject.Find("White Palace Fly (17)"));
                Destroy(GameObject.Find("White Palace Fly (18)"));
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 143.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 141.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 139.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 137.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 135.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 133.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 131.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 129.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 127.5f, 120.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 115.5f, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 110, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 104.5f, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 99, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 115.5f, 120, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 91.5f, 133.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 70.5f, 154.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["saw_collection/wp_saw"], 62, 154.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 88.5f, 140, 4.538f, 90, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 78.5f, 146, 4.538f, 90, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 9.6f, 156, 4.538f, 90, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 26.3f, 148, 4.538f, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 37.3f, 148, 4.538f, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 51.5f, 148, 4.538f, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_19", enemyDic["wp_trap_spikes"], 13.5f, 148, 4.538f, 45, 1);

            }

            if (nowSceneName == "White_Palace_20")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 16, 171, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 35, 168, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 37.5f, 169, 4.538f, 315, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 48, 173, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 48, 169, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 48, 165.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 56, 172.5f, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 64, 168.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 74, 171.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 87, 169.5f, 0, 0, 1);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 65, 173.5f);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 74, 168);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 91, 174);
                //AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 96, 169.5f);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 101, 169.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 79, 165);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 117, 171.5f);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 130, 171.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 121, 173);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 121, 171);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 121, 169);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 137, 165);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 156.5f, 162.5f, 0, 0, 2);

                //58 59
                GameObject father = GameObject.Find("wp_saw (58)");
                GameObject obj = AddEnemyInScene3(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 141, 169, 4.538f, 0, 1);
                obj.transform.SetParent(father.transform, true);
                obj.transform.localPosition = new Vector3(-1.25f, -3.2f, 5.93f);
                father = GameObject.Find("wp_saw (59)");
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 141, 169, 4.538f, 0, 1);
                obj.transform.SetParent(father.transform, true);
                obj.transform.localPosition = new Vector3(-1.25f, -3.2f, 5.93f);

                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 156, 172.5f);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 187, 168);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 179, 165.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 203, 170, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 203, 167.5f, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 203, 165, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 209, 173, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 209, 170.5f, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 209, 168, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 215, 164, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 215, 166.5f, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["saw_collection/wp_saw"], 215, 169, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 202, 173, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 209, 165);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 214, 173, 4.538f, 180, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["wp_trap_spikes"], 223, 169, 4.538f, 180, 1);
                AddBlast(nowSceneName, "White_Palace_20", enemyDic["Battle Scene/Focus Blasts/HK Prime Blast"], 229, 165);

                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 215, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 217, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 219, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 221, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 223, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 225, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 227, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 229, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 231, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 233, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 235, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 237, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 239, 122);
                AddEnemyInScene2(nowSceneName, "White_Palace_20", enemyDic["White Palace Fly"], 241, 122);

            }
            #endregion


            #region 白宫
            if (nowSceneName == "White_Palace_01")
            {
                Destroy(GameObject.Find("wp_plat_float_02"));
                Destroy(GameObject.Find("wp_plat_float_03"));
                Destroy(GameObject.Find("wp_plat_float_06 (1)"));
                Destroy(GameObject.Find("wp_plat_float_06"));
                Destroy(GameObject.Find("wp_plat_float_04"));
                Destroy(GameObject.Find("wp_plat_float_05"));
                Destroy(GameObject.Find("wp_plat_float_05 (1)"));

            }
            if (nowSceneName == "White_Palace_02")
            {
                Destroy(GameObject.Find("wp_plat_float_06"));
                Destroy(GameObject.Find("wp_plat_float_04"));
                Destroy(GameObject.Find("wp_plat_float_07 (1)"));
                Destroy(GameObject.Find("wp_plat_float_05"));
                Destroy(GameObject.Find("wp_plat_float_03"));

            }
            if (nowSceneName == "White_Palace_03_hub")
            {
                Destroy(GameObject.Find("wp_plat_float_06 (2)"));
                Destroy(GameObject.Find("wp_plat_float_02 (1)"));
                Destroy(GameObject.Find("wp_plat_float_05 (1)"));
                Destroy(GameObject.Find("wp_plat_float_01_wide"));
                Destroy(GameObject.Find("wp_plat_float_05"));
                Destroy(GameObject.Find("wp_plat_float_06"));
                Destroy(GameObject.Find("wp_plat_float_02"));
                Destroy(GameObject.Find("wp_plat_float_06 (1)"));
                Destroy(GameObject.Find("wp_plat_float_02 (2)"));
            }

            if (nowSceneName == "White_Palace_04")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 152.5f, 22, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 148.5f, 22, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 130, 28, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 123, 35, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 114.5f, 59, 0, 0, 1.2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 86.5f, 34, 0, 0, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 59, 23.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 127, 12.5f, 0, 0, 2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_04", enemyDic["saw_collection/wp_saw"], 43.5f, 51.5f, 0, 0, 1.5f);

                Destroy(GameObject.Find("wp_plat_float_05"));
                Destroy(GameObject.Find("wp_plat_float_03 (3)"));
                Destroy(GameObject.Find("wp_plat_float_03"));
                Destroy(GameObject.Find("wp_plat_float_06"));
                Destroy(GameObject.Find("wp_plat_float_03 (1)"));
                Destroy(GameObject.Find("wp_plat_float_07"));
                Destroy(GameObject.Find("wp_plat_float_04"));
                Destroy(GameObject.Find("wp_plat_float_05 (2)"));
                Destroy(GameObject.Find("wp_plat_float_03 (4)"));
                Destroy(GameObject.Find("wp_plat_float_05 (1)"));
                Destroy(GameObject.Find("wp_plat_float_04 (1)"));

            }
            if (nowSceneName == "White_Palace_14")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 48.1f, 99.5f, 0, 0, 0.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 81, 104, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 85.5f, 104, 0, 0, 1.2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 70, 123, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 118, 119.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 106, 106.2f, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_14", enemyDic["saw_collection/wp_saw"], 123, 96.7f, 0, 0, 0.6f);
                Destroy(GameObject.Find("wp_plat_float_03 (5)"));
                Destroy(GameObject.Find("wp_plat_float_04 (2)"));
                Destroy(GameObject.Find("wp_plat_float_03 (6)"));
                Destroy(GameObject.Find("wp_plat_float_03 (7)"));

            }
            if (nowSceneName == "White_Palace_15")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["wp_trap_spikes"], 17.5f, 40.5f, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["wp_trap_spikes"], 17.5f, 42.5f, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["saw_collection/wp_saw"], 28, 113, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["saw_collection/wp_saw"], 44, 111, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["saw_collection/wp_saw"], 40, 104, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["saw_collection/wp_saw"], 40, 84, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_15", enemyDic["saw_collection/wp_saw"], 42.5f, 72.5f, 0, 0, 1);

            }
            if (nowSceneName == "White_Palace_05")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 87.5f, 17, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 116, 17, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 116, 25, 0, 0, 1.5f);

                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 130, 91, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 122, 82, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 122, 78, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 122, 74, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 102, 47, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 95, 75, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 96.7f, 89.4f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 99, 108, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 95, 107, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 91, 106, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 88, 105, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 105, 108, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 126, 133.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 70.7f, 111.4f, 0, 0, 1.2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 119, 133.5f, 0, 0, 1);
                //AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 109, 140.5f, 0, 0, 3.5f);
                GameObject father = new GameObject();
                father.transform.position = new Vector3(109, 140.5f, 0);
                GameObject obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 109, 140.5f, 0, 0, 0.8f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(0, -4.8f, 0);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 109, 140.5f, 0, 0, 0.8f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(0, -1.5f, 0);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 109, 140.5f, 0, 0, 0.8f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(0, 1.8f, 0);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 109, 140.5f, 0, 0, 0.8f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(0, 5.1f, 0);
                MyRotate rotate = father.AddComponent<MyRotate>();
                rotate.rotateSpeed = 360f;


                //AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 80, 132.5f, 0, 0, 4);
                father = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 94, 138.7f, 0, 0, 0.7f);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 94, 138.7f, 0, 0, 0.7f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(0, -4.5f, 0);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 94, 138.7f, 0, 0, 0.7f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(0, 4.5f, 0);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 94, 138.7f, 0, 0, 0.7f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(-4.5f, 0, 0);
                obj = AddEnemyInScene3(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 94, 138.7f, 0, 0, 0.7f);
                obj.transform.SetParent(father.transform);
                obj.transform.localPosition = new Vector3(4.5f, 0, 0);
                rotate = father.AddComponent<MyRotate>();
                rotate.rotateSpeed = -240f;

                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 80, 127, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 80, 131, 0, 0, 1);

                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 82.4f, 89.5f, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 130.2f, 124, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_05", enemyDic["saw_collection/wp_saw"], 76.5f, 122.9f, 0, 0, 0.5f);
                Destroy(GameObject.Find("wp_plat_float_03 (5)"));
                Destroy(GameObject.Find("wp_plat_float_03 (6)"));
                Destroy(GameObject.Find("wp_plat_float_06"));
                Destroy(GameObject.Find("wp_plat_float_04 (3)"));
                Destroy(GameObject.Find("wp_plat_float_04 (1)"));
                Destroy(GameObject.Find("wp_plat_float_04 (2)"));
                Destroy(GameObject.Find("wp_plat_float_03"));
                Destroy(GameObject.Find("wp_plat_float_03 (1)"));
                Destroy(GameObject.Find("wp_plat_float_03 (2)"));
                Destroy(GameObject.Find("wp_plat_float_03 (4)"));
                Destroy(GameObject.Find("wp_plat_float_03 (3)"));

            }
            if (nowSceneName == "White_Palace_16")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 153.5f, 34, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 153.5f, 56, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 160.5f, 84, 0, 0, 0.6f);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 147, 24.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 154, 86, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 159.5f, 105, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 153.5f, 112, 0, 0, 1);

            }
            if (nowSceneName == "White_Palace_06")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_06", enemyDic["wp_trap_spikes"], 24.5f, 33.5f, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_06", enemyDic["wp_trap_spikes"], 20.5f, 50, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_06", enemyDic["wp_trap_spikes"], 11.5f, 61.1f, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_16", enemyDic["saw_collection/wp_saw"], 14, 54, 0, 0, 1.3f);

            }
            if (nowSceneName == "White_Palace_07")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 38, 29, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 43.5f, 29, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["wp_trap_spikes"], 35.5f, 17, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 26.7f, 41.5f, 0, 0, 0.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 29.5f, 41.5f, 0, 0, 0.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 19, 66, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 15, 48.3f, 0, 0, 0.9f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 36.5f, 42.5f, 0, 0, 0.9f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 32.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 36.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 40.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 44.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 48.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 52.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 56.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 60.5f, 77.5f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 64.5f, 77.5f, 0, 0, 1);
                Destroy(GameObject.Find("wp_plat_float_04 (1)"));
                Destroy(GameObject.Find("wp_plat_float_03"));
                Destroy(GameObject.Find("wp_plat_float_04 (3)"));

                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 49, 50, 0, 0, 0.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 39, 54, 0, 0, 0.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["wp_trap_spikes"], 43.5f, 65, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 51, 60, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 79, 62, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 79, 56.3f, 0, 0, 1.2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 106, 71.5f, 0, 0, 1.2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 111, 68, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 70, 81, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 60, 84, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 55, 84, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 44, 87, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["saw_collection/wp_saw"], 44.5f, 99, 0, 0, 1.2f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["wp_trap_spikes"], 17.5f, 85, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_07", enemyDic["wp_trap_spikes"], 17.5f, 83, 4.538f, 270, 1f);
                Destroy(GameObject.Find("wp_plat_float_05 (4)"));
                Destroy(GameObject.Find("wp_plat_float_03 (1)"));
                Destroy(GameObject.Find("wp_plat_float_05 (1)"));
                Destroy(GameObject.Find("wp_plat_float_01_wide (1)"));
                Destroy(GameObject.Find("Hazard Respawn Trigger v2 (7)"));
                Destroy(GameObject.Find("Hazard Respawn Trigger v2 (8)"));

            }
            if (nowSceneName == "White_Palace_12")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 8.5f, 140, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 8.5f, 142, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 8.5f, 144, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 8.5f, 146, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 8.5f, 148, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 8.5f, 150, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 26.2f, 145.6f, 0, 0, 0.4f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 19.3f, 143.1f, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 8.5f, 162.9f, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 35, 197, 0, 0, 1.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 9.5f, 180, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 9.5f, 184, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 9.5f, 188, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 9.5f, 192, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 9.5f, 196, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 9.5f, 200, 4.538f, 270, 1f);
                Destroy(GameObject.Find("wp_plat_float_03 (4)"));
                Destroy(GameObject.Find("wp_plat_float_04 (2)"));
                Destroy(GameObject.Find("wp_plat_float_04"));
                Destroy(GameObject.Find("wp_plat_float_03 (5)"));
                Destroy(GameObject.Find("wp_plat_float_05"));
                Destroy(GameObject.Find("wp_plat_float_02"));
                Destroy(GameObject.Find("wp_plat_float_02 (1)"));
                Destroy(GameObject.Find("wp_plat_float_03 (6)"));
                Destroy(GameObject.Find("wp_plat_float_06 (1)"));
                Destroy(GameObject.Find("Hazard Respawn Trigger v2 (16)"));

                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 60, 205, 0, 0, 0.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 57.8f, 186.5f, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 57.8f, 184.5f, 4.538f, 270, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 64.1f, 188.5f, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["wp_trap_spikes"], 64.1f, 186.5f, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 57, 161, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 65, 161, 0, 0, 1);

                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 41.5f, 210, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_12", enemyDic["saw_collection/wp_saw"], 53, 204, 0, 0, 1);

            }
            if (nowSceneName == "White_Palace_13")
            {
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 62, 139, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 65, 134, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 65, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 65, 123, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 82, 151.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 76.5f, 151.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 88.4f, 125.1f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 104, 158, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 104, 152.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 93.4f, 164, 0, 0, 1.7f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 73.5f, 171, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 73, 179, 0, 0, 1);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 73, 192, 0, 0, 1);

                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 72, 123, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 72, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 79, 123, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 79, 128.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 68.5f, 128.5f, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 75.5f, 128.5f, 0, 0, 0.5f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["wp_trap_spikes"], 71, 120.5f, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["wp_trap_spikes"], 78, 120.5f, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["wp_trap_spikes"], 92.9f, 111.9f, 4.538f, 180, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 49, 110, 0, 0, 2);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 49, 117, 0, 0, 2);


                Destroy(GameObject.Find("wp_plat_float_01_wide (2)"));
                Destroy(GameObject.Find("wp_plat_float_06 (2)"));
                Destroy(GameObject.Find("Hazard Respawn Trigger v2 (10)"));
                Destroy(GameObject.Find("wp_plat_float_05 (2)"));
                Destroy(GameObject.Find("wp_plat_float_05 (5)"));
                Destroy(GameObject.Find("wp_plat_float_05 (3)"));
                Destroy(GameObject.Find("wp_plat_float_03 (2)"));
                Destroy(GameObject.Find("wp_plat_float_04 (4)"));
                Destroy(GameObject.Find("White Palace Fly (2)"));
                Destroy(GameObject.Find("White Palace Fly"));
                Destroy(GameObject.Find("White Palace Fly (1)"));

                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["wp_trap_spikes"], 101.5f, 196, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["wp_trap_spikes"], 101.5f, 194, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["wp_trap_spikes"], 101.5f, 192, 4.538f, 90, 1f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 105, 130, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 105, 124.5f, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 105, 119, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 120, 122, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 128, 131, 0, 0, 1.3f);
                AddEnemyInScene2(nowSceneName, "White_Palace_13", enemyDic["saw_collection/wp_saw"], 123, 140, 0, 0, 1.3f);

            }

            #endregion
        }

        //彩蛋怪
        public void Refreshing_Enemy(string nowSceneName)
        {
            #region 十字路
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 11, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 13, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 15, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 17, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 19, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 21, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 23, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 25, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 27, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 29, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 31, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 33, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 35, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 37, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 39, 7.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 41, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 43, 5.4f);
            AddEnemyInScene(nowSceneName, "Crossroads_15", enemyDic["_Enemies/Zombie Shield"], 45, 5.4f);
            #endregion


            #region 苍绿
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 27, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 32, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 37, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 42, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 47, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 52, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 57, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 62, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 67, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 72, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_25", enemyDic["Moss Knight Fat"], 77, 10.5f);
            #endregion


            #region 真菌
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 28, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 32, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 36, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 40, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 44, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 48, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 52, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 56, 11.5f);

            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 18, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 22, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 26, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 30, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 34, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 38, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Mushroom Roller"], 42, 33.5f);
            #endregion


            #region 泪城
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 16, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 18, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 20, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 22, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 24, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 26, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 28, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 30, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 32, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 34, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 36, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 38, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 40, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 42, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 44, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 46, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 48, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 50, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 52, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 54, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 56, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 58, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 60, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 62, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 64, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 66, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 68, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 70, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 72, 7.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 74, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 76, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 78, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 80, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 82, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 84, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 86, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie 1"], 88, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Coward"], 90, 7.5f);
            //AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Royal Zombie Fat"], 92, 7.5f);
            #endregion



            #region 水晶
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 53, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 55, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 57, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 59, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 61, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 63, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 65, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 67, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (3)"], 63, 173.9f, 180);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 53, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 55, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 57, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 59, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 61, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 63, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 65, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 67, 177f);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystallised Lazer Bug (7)"], 63, 177f);
            #endregion



            #region 下水道
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 16, 6);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 20, 6);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 24, 6);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 28, 6);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 32, 6);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 36, 6);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 40, 6);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 18, 14);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 22, 10);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 26, 14);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 30, 10);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 34, 14);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 38, 10);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 22, 23);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 26, 23);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 30, 23);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 34, 23);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 38, 23);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 24, 19);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 28, 19);
            AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 32, 19);
            //AddEnemyInScene(nowSceneName, "Waterways_09", enemyDic["Inflater"], 36, 19);
            #endregion



            #region 雾谷
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 63, 21);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 65, 22);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 67, 23);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 69, 24);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 71, 25);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 73, 26);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 75, 27);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 77, 28);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 79, 29);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 81, 30);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 83, 31);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 62, 8);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 64, 9);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 66, 10);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 68, 11);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 70, 12);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 72, 13);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 74, 14);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 76, 15);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 78, 16);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 80, 17);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 82, 18);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 84, 19);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 86, 20);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 88, 21);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 90, 22);

            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 69, 30);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 71, 27);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 73, 24);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 75, 21);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 77, 18);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 79, 15);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 81, 12);
            AddEnemyInScene(nowSceneName, "Fungus3_25", enemyDic["Jellyfish Baby"], 83, 9);

            #endregion



            #region 盆地
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 12, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 16, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 20, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 24, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 28, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 32, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 36, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 40, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 44, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 48, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 52, 38.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 56, 38.5f);
            #endregion



            #region 边缘
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 11, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 12, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 13, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 14, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 15, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 16, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 17, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 18, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 19, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 20, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 21, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 22, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 23, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 24, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 25, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 26, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 27, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 28, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 29, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 30, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 31, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 32, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 33, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 34, 8.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 35, 8.5f);

            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 11, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 12, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 13, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 14, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 15, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 16, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 17, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 18, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 19, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 20, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 21, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 22, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 23, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 24, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 25, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 26, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 27, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 28, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 29, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 30, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 31, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 32, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 33, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 34, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_17", enemyDic["Hopper"], 35, 11f);

            #endregion



            #region 深巢
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 61, 19);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 63, 20);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 65, 21);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 67, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 69, 23);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 71, 24);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 73, 25);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 75, 26);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 77, 27);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 79, 28);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 82, 24);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 84, 24);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 86, 24);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 88, 24);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 84, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 86, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 88, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 86, 20);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 88, 20);
            AddEnemyInScene(nowSceneName, "Deepnest_45_v02", enemyDic["Spider Flyer"], 88, 18);

            #endregion



            #region 花园
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 40, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 42, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 44, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 46, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 48, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 50, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 52, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 54, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 56, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 58, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 60, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 62, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 64, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 66, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 68, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_10", enemyDic["Garden Zombie"], 70, 10.5f);
            #endregion


            #region 感染十字路
            if (PlayerData.instance.crossroadsInfected)
            {
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 25, 11.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 28, 12);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 31, 12.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 34, 13);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 37, 13.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 40, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 43, 14.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 46, 15);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 49, 14.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 52, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 55, 13.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 58, 13);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 61, 12.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 64, 12);
                AddEnemyInScene(nowSceneName, "Crossroads_02", enemyDic["Infected Parent/Angry Buzzer"], 67, 11.5f);
            }
            #endregion


            #region 呼啸悬崖
            //if(nowSceneName== "Cliffs_05")
            //{
            //    GameObject obj = enemyDic["_Props/Health Cocoon"].GetComponent<HealthCocoon>().flingPrefabs.First(x => x.prefab.name.Contains("Scuttler")).prefab;
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 28, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 29, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 30, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 31, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 32, 5.5f);

            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 33, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 34, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 35, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 36, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 37, 5.5f);

            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 38, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 39, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 40, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 41, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 42, 5.5f);

            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 43, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 44, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 45, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 46, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 47, 5.5f);

            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 48, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 49, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 50, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 51, 5.5f);
            //    AddEnemyInScene(nowSceneName, "Cliffs_05", obj, 52, 5.5f);
            //}

            #endregion


            #region 蜂巢
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 25.5f, 133.5f);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 28, 128);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 34, 129);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 36, 139);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 32, 134.5f);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 28, 135);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 30, 131);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 31, 127);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 29, 146.5f);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 24, 144);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 33, 142);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Hatchling Ambient"], 32, 138.5f);

            #endregion
        }

        //关键区域怪
        public void KeyRegion_Enemy(string nowSceneName)
        {
            //十字路小橙汁战斗
            AddEnemyInScene(nowSceneName, "Crossroads_08", enemyDic["_Enemies/Spitter"], 24f, 22);

            //十字路龙牙哥
            if (nowSceneName == "Crossroads_21")
            {
                Destroy(GameObject.Find("plat_float_01"));
                Destroy(GameObject.Find("plat_float_07"));
            }

            //十字路发光子宫
            AddEnemyInScene(nowSceneName, "Crossroads_22", enemyDic["_Enemies/Spitter"], 77, 23.5f);
            AddEnemyInScene(nowSceneName, "Crossroads_22", enemyDic["_Enemies/Spitter"], 66, 10f);
            AddEnemyInScene(nowSceneName, "Crossroads_22", enemyDic["_Enemies/Spitter"], 80, 19f);
            AddEnemyInScene(nowSceneName, "Crossroads_22", enemyDic["_Enemies/Spitter"], 66, 24.5f);
            AddEnemyInScene(nowSceneName, "Crossroads_22", enemyDic["_Enemies/Spitter"], 80, 13);

            //长满蚊子的山丘
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 69, 22);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 34.5f, 16);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 69, 9);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 41, 16.5f);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 80, 9);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 50, 17);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 89, 12);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 55, 14);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 82, 29);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 86, 21);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 92, 33);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 111.5f, 11);
            AddEnemyInScene(nowSceneName, "Room_Fungus_Shaman", enemyDic["Mosquito"], 111f, 17);

            //泪城收费机
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Flying Sentry Javelin"], 15, 160);
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Flying Sentry"], 32, 158.5f);

            //十字路电梯碎片
            AddEnemyInScene(nowSceneName, "Crossroads_37", enemyDic["_Enemies/Zombie Shield"], 47, 7.5f);
            AddEnemyInScene(nowSceneName, "Crossroads_37", enemyDic["_Enemies/Zombie Shield"], 39, 5.5f);
            AddEnemyInScene(nowSceneName, "Crossroads_37", enemyDic["_Enemies/Zombie Shield"], 71, 16.5f);

            //圣巢之冠
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Crystal Flyer"], 79, 15.5f);
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Crystal Flyer"], 151, 30);
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Crystal Flyer"], 166, 12);
            AddEnemyInScene(nowSceneName, "Mines_24", enemyDic["Crystal Flyer"], 19, 11);
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Crystal Flyer"], 11, 39);
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Crystal Flyer"], 33, 82.5f);
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Crystal Flyer"], 5, 123.5f);

            //黑砸
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Crystal Flyer"], 81, 12);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Crystal Flyer"], 72, 37);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Crystal Flyer"], 87, 54.5f);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Crystal Flyer"], 62, 66);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Zombie Beam Miner"], 51, 48.5f);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Zombie Beam Miner"], 65, 48.5f);


            //安息之地
            AddEnemyInScene(nowSceneName, "RestingGrounds_10", enemyDic["Ceiling Dropper (1)"], 121, 12);
            AddEnemyInScene(nowSceneName, "RestingGrounds_10", enemyDic["Ceiling Dropper (1)"], 160, 14);
            AddEnemyInScene(nowSceneName, "RestingGrounds_10", enemyDic["Ceiling Dropper (1)"], 211, 10);
            //AddEnemyInScene(nowSceneName, "RestingGrounds_06", enemyDic["Ceiling Dropper (1)"], 31.5f, 15);
            AddEnemyInScene(nowSceneName, "Ruins2_08", enemyDic["Ceiling Dropper (1)"], 11, 27);
            //AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Ceiling Dropper (1)"], 36, 119);
            //AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Ceiling Dropper (1)"], 31, 98.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_06", enemyDic["Ceiling Dropper (1)"], 81, 26);
            AddEnemyInScene(nowSceneName, "Ruins1_06", enemyDic["Ceiling Dropper (1)"], 66, 26);
            AddEnemyInScene(nowSceneName, "Ruins1_06", enemyDic["Ceiling Dropper (1)"], 41, 25);
            AddEnemyInScene(nowSceneName, "Ruins1_06", enemyDic["Ceiling Dropper (1)"], 23, 25);
            AddEnemyInScene(nowSceneName, "Abyss_01", enemyDic["Ceiling Dropper (1)"], 13, 119);
            AddEnemyInScene(nowSceneName, "Abyss_01", enemyDic["Ceiling Dropper (1)"], 16, 106);
            AddEnemyInScene(nowSceneName, "Abyss_01", enemyDic["Ceiling Dropper (1)"], 9.5f, 24);
            AddEnemyInScene(nowSceneName, "Abyss_01", enemyDic["Ceiling Dropper (1)"], 8.5f, 46);

            //国王驿站碎片
            AddEnemyInScene(nowSceneName, "Ruins2_09", enemyDic["Great Shield Zombie"], 42, 4);

            //守望者塔滚滚入口
            AddEnemyInScene(nowSceneName, "Ruins2_01", enemyDic["Great Shield Zombie"], 62, 69);

            //虫母入口
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 21.5f, 37);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 62.5f, 35);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 73, 38);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 90.5f, 35);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 110, 17.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 115, 23);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 121, 12.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 86, 9.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 71, 8.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 58, 7);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 41, 10);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 112, 11.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 111, 12);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 111, 18);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 115, 8);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 120, 17);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 122, 13);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 128, 10);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 115, 16);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 112, 16.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 112, 12.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 114, 18);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 96, 12);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 100, 9);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 94.5f, 8);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 86, 10.5f);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 83, 8);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 81, 6);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 75, 9);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 75, 9);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 70, 10);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 65, 4);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 61, 8);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 60, 4);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 58, 8);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 53, 7);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 45, 10);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 40.5f, 11);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 42, 7);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Fluke Fly"], 36, 7);

            //芬达入口
            AddEnemyInScene(nowSceneName, "Waterways_02", enemyDic["Ceiling Dropper (1)"], 113.5f, 37);
            AddEnemyInScene(nowSceneName, "Waterways_02", enemyDic["Ceiling Dropper (1)"], 154, 31);
            AddEnemyInScene(nowSceneName, "Waterways_05", enemyDic["Ceiling Dropper (1)"], 13, 25);
            AddEnemyInScene(nowSceneName, "Waterways_05", enemyDic["Ceiling Dropper (1)"], 8.5f, 43);
            AddEnemyInScene(nowSceneName, "Waterways_06", enemyDic["Ceiling Dropper (1)"], 79, 23.5f);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ceiling Dropper (1)"], 9.5f, 52.5f);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ceiling Dropper (1)"], 40.5f, 98);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ceiling Dropper (1)"], 65, 98);

            //酸泪战斗
            //AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ruins Sentry Fat"], 57, 66f);
            //AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ruins Sentry Fat"], 74, 66f);

            //教室档案馆
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Zap Cloud"], 62.5f, 167, 0, 1.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Zap Cloud"], 68.5f, 155, 0, 1.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Zap Cloud"], 53, 146, 0, 1.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Zap Cloud"], 66, 145, 0, 1.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 75.5f, 178);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 75.5f, 145);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 81, 145);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 22, 143.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 29, 144f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 36, 144.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_archive_02", enemyDic["Jellyfish"], 47, 187.5f);

            //表哥通道
            //AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Lesser Mawlek"], 54, 28.5f);
            //AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Lesser Mawlek"], 66.5f, 28.5f);


            //盆地矿石
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 38, 17.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 52, 17.5f);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["_Enemies/Spitter"], 43.5f, 25);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["_Enemies/Spitter"], 38.5f, 22.5f);

            //盆地钥匙
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Lesser Mawlek"], 40f, 8.5f);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Lesser Mawlek"], 50, 8.5f);

            //乔尼诅咒
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 17, 44);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 31, 44.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 39, 38);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 29, 26);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 9, 26);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 17, 10);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 9, 7);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 30.5f, 7);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 37, 10);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 46, 6);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 51, 7);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 54.5f, 12.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 58.5f, 37.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 64, 53);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 74, 50);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 72.5f, 28);
            AddEnemyInScene(nowSceneName, "Cliffs_04", enemyDic["_Enemies/Buzzer"], 69.5f, 19.5f);

            //边缘
            AddEnemyInScene(nowSceneName, "Deepnest_East_06", enemyDic["Super Spitter"], 163.5f, 34);
            AddEnemyInScene(nowSceneName, "Deepnest_East_06", enemyDic["Super Spitter"], 280.5f, 17.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_14b", enemyDic["Super Spitter"], 44, 13);
            AddEnemyInScene(nowSceneName, "Deepnest_East_14b", enemyDic["Super Spitter"], 55, 53);
            AddEnemyInScene(nowSceneName, "Deepnest_East_11", enemyDic["Super Spitter"], 48.5f, 75.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_11", enemyDic["Super Spitter"], 33, 81);
            AddEnemyInScene(nowSceneName, "Deepnest_East_11", enemyDic["Super Spitter"], 61, 94);
            AddEnemyInScene(nowSceneName, "Deepnest_East_11", enemyDic["Super Spitter"], 101, 109);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Super Spitter"], 11, 59.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Super Spitter"], 9, 95);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Super Spitter"], 62, 71);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Super Spitter"], 49, 84);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Super Spitter"], 26, 100);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Super Spitter"], 28, 135);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Super Spitter"], 21, 155.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Super Spitter"], 46.5f, 14.5f);

            //小姐姐妈妈
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 59, 22.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 92.5f, 36.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 98.5f, 34);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 80, 20.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 80, 65);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 82, 86);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 112.5f, 110);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 67, 136.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 7, 137.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 12, 125);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 15, 155);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Spider Flyer"], 21, 156.5f);

            //花园战斗房1
            AddEnemyInScene(nowSceneName, "Fungus3_05", enemyDic["Mantis Heavy Flyer"], 23.5f, 54f);
            AddEnemyInScene(nowSceneName, "Fungus3_05", enemyDic["Mantis Heavy Flyer"], 47.5f, 53);

            //花园救虫
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Mantis Heavy Flyer"], 23, 105);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Mantis Heavy Flyer"], 12, 127);

            //蜂巢
            AddEnemyInScene(nowSceneName, "Hive_02", enemyDic["Bee Stinger"], 162.5f, 33);
            AddEnemyInScene(nowSceneName, "Hive_02", enemyDic["Bee Stinger"], 166, 59);
            AddEnemyInScene(nowSceneName, "Hive_02", enemyDic["Bee Stinger"], 134.5f, 79);
            AddEnemyInScene(nowSceneName, "Hive_03_c", enemyDic["Bee Stinger"], 108, 86);
            AddEnemyInScene(nowSceneName, "Hive_03_c", enemyDic["Big Bee"], 81.5f, 98);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Big Bee"], 74, 131);
            AddEnemyInScene(nowSceneName, "Hive_03", enemyDic["Bee Stinger"], 94, 136.5f);
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Bee Stinger"], 147, 132);
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Bee Stinger"], 142, 99);
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Bee Stinger"], 170, 97);
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Bee Stinger"], 188, 93.5f);
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Big Bee"], 158, 132);
            AddEnemyInScene(nowSceneName, "Hive_04", enemyDic["Big Bee"], 190, 107.5f);


            //金闪闪
            AddEnemyInScene(nowSceneName, "Ruins_House_02", enemyDic["Great Shield Zombie"], 26, 10);

        }


        #region 剩余所有区域
        public void AllRemainingRegion(string nowSceneName)
        {
            Crossroads(nowSceneName);
            GreenPath(nowSceneName);
            Fungus(nowSceneName);
            TearsCity(nowSceneName);
            CrystalPeak(nowSceneName);
            RestingPlace(nowSceneName);
            RoyalWaterway(nowSceneName);
            FogCanyon(nowSceneName);
            AncientBasin(nowSceneName);
            Cliff(nowSceneName);
            KingdomEdge(nowSceneName);
            Deepnest(nowSceneName);
            Beenest(nowSceneName);
            QueensGarden(nowSceneName);
        }

        //十字路（感染）
        public void Crossroads(string nowSceneName)
        {
            //教程
            AddEnemyInScene(nowSceneName, "Tutorial_01", enemyDic["_Enemies/Buzzer"], 144, 16);
            AddEnemyInScene(nowSceneName, "Tutorial_01", enemyDic["_Enemies/Buzzer"], 135, 27);
            AddEnemyInScene(nowSceneName, "Tutorial_01", enemyDic["_Enemies/Buzzer"], 92.5f, 35.5f);
            AddEnemyInScene(nowSceneName, "Tutorial_01", enemyDic["_Enemies/Buzzer"], 141, 46);
            AddEnemyInScene(nowSceneName, "Tutorial_01", enemyDic["_Enemies/Buzzer"], 152, 47);

            //十字路未感染
            if (!PlayerData.instance.crossroadsInfected)
            {
                //01
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["Zombie Hornhead"], 26, 10.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["_Enemies/Spitter"], 14, 15);
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["_Enemies/Spitter"], 70, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["_Enemies/Spitter"], 84, 16.5f);

                //07
                //AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Spitter"], 16.5f, 85.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Spitter"], 28, 85);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 10, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 19, 18);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 31, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 22, 40);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 12, 45);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 31, 72);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Buzzer"], 30, 44);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Zombie Hornhead"], 6, 5);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Zombie Hornhead"], 36, 5);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Zombie Hornhead"], 19, 79);

                //33
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Zombie Leaper"], 21.5f, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Zombie Leaper"], 11, 9.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Zombie Leaper"], 34, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["_Enemies/Buzzer"], 16, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["_Enemies/Buzzer"], 30, 19);


                //08
                AddEnemyInScene(nowSceneName, "Crossroads_08", enemyDic["Zombie Hornhead"], 31, 10.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_08", enemyDic["Zombie Hornhead"], 41, 34.5f);

                //13
                AddEnemyInScene(nowSceneName, "Crossroads_13", enemyDic["Zombie Hornhead"], 17.5f, 12.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_13", enemyDic["Zombie Leaper"], 68, 12.5f);

                //42
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Zombie Leaper"], 28.5f, 7.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Zombie Leaper"], 44, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Zombie Leaper"], 96, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Zombie Hornhead"], 65, 4.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Zombie Hornhead"], 81.5f, 16.5f);

                //19
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 22, 31.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 22, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 17, 9.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 35, 11);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Zombie Leaper"], 38.5f, 11);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Zombie Leaper"], 37, 29.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Zombie Leaper"], 11, 10.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Zombie Hornhead"], 38.5f, 4.5f);

                //03
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["Zombie Leaper"], 14, 18.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["Zombie Leaper"], 15, 31.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["Zombie Leaper"], 11.5f, 52.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["_Enemies/Spitter"], 6, 17);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["_Enemies/Spitter"], 15, 52);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["_Enemies/Spitter"], 9.5f, 58.5f);

                //21
                AddEnemyInScene(nowSceneName, "Crossroads_21", enemyDic["Zombie Hornhead"], 81.5f, 14.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_21", enemyDic["Zombie Hornhead"], 42, 17.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_21", enemyDic["Zombie Hornhead"], 38, 2.5f);

                //10（boss）

                //ShamanTemple
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 94, 6.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 134, 18.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 55, 34.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 127, 27.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 120, 47.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 108, 31.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 102, 24.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 68, 42.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 58, 21.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 62, 21.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 67, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 25, 35.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 21, 52.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 54.5f, 46);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 85.5f, 34);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 79, 44);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 115.5f, 51);

                //11_alt
                AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Spitter"], 81, 16);
                AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Spitter"], 89, 17);
                //AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Roller"], 85, 11.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Roller"], 91, 11.5f);


                //39
                AddEnemyInScene(nowSceneName, "Crossroads_39", enemyDic["Zombie Leaper"], 44, 11.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_39", enemyDic["Zombie Hornhead"], 73, 6.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_39", enemyDic["Zombie Hornhead"], 56, 6.5f);

                //14
                AddEnemyInScene(nowSceneName, "Crossroads_14", enemyDic["_Enemies/Buzzer"], 10, 35);
                AddEnemyInScene(nowSceneName, "Crossroads_14", enemyDic["_Enemies/Buzzer"], 22, 38);
                AddEnemyInScene(nowSceneName, "Crossroads_14", enemyDic["_Enemies/Buzzer"], 19, 10);

                //48
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Zombie Hornhead"], 14, 3.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Zombie Hornhead"], 24, 3.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Zombie Hornhead"], 41, 3.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Zombie Leaper"], 19, 3.5f);

                //05
                AddEnemyInScene(nowSceneName, "Crossroads_05", enemyDic["Zombie Hornhead"], 22.5f, 7.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_05", enemyDic["Zombie Leaper"], 42.5f, 12.5f);

                //40

                //16
                AddEnemyInScene(nowSceneName, "Crossroads_16", enemyDic["_Enemies/Buzzer"], 51.5f, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_16", enemyDic["_Enemies/Buzzer"], 65, 7);
                AddEnemyInScene(nowSceneName, "Crossroads_16", enemyDic["Zombie Leaper"], 67, 11);

                //25
                AddEnemyInScene(nowSceneName, "Crossroads_25", enemyDic["Zombie Leaper"], 53, 10);
                AddEnemyInScene(nowSceneName, "Crossroads_25", enemyDic["Zombie Leaper"], 42, 12.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_25", enemyDic["Zombie Hornhead"], 22, 7.5f);

                //35
                AddEnemyInScene(nowSceneName, "Crossroads_35", enemyDic["_Enemies/Spitter"], 51, 46);
                AddEnemyInScene(nowSceneName, "Crossroads_35", enemyDic["_Enemies/Spitter"], 40, 42);
                AddEnemyInScene(nowSceneName, "Crossroads_35", enemyDic["_Enemies/Spitter"], 13.5f, 45);

                //12
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["_Enemies/Buzzer"], 47, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["_Enemies/Buzzer"], 21, 12);
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["Zombie Hornhead"], 40.5f, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["Zombie Leaper"], 11, 8.5f);

                //27
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 20, 43);
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 16.5f, 57);
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 22.5f, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 3.5f, 12);

                //04
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["_Enemies/Buzzer"], 25, 23);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["_Enemies/Buzzer"], 38, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["_Enemies/Buzzer"], 58, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Zombie Leaper"], 70.5f, 7.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Zombie Leaper"], 126, 7.5f);
            }
            //十字路感染
            else
            {
                //01
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["Infected Parent/Bursting Zombie"], 26, 10.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["_Enemies/Spitter"], 14, 15);
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["_Enemies/Spitter"], 70, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_01", enemyDic["_Enemies/Spitter"], 84, 16.5f);

                //07
                //AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Spitter"], 16.5f, 85.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["_Enemies/Spitter"], 28, 85);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 10, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 19, 18);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 31, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 22, 40);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 12, 45);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 31, 72);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Angry Buzzer"], 30, 44);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Bursting Zombie"], 6, 5);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Bursting Zombie"], 36, 5);
                AddEnemyInScene(nowSceneName, "Crossroads_07", enemyDic["Infected Parent/Bursting Zombie"], 19, 79);

                //33
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Infected Parent/Spitting Zombie"], 21.5f, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Infected Parent/Spitting Zombie"], 11, 9.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Infected Parent/Spitting Zombie"], 34, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Infected Parent/Angry Buzzer"], 16, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_33", enemyDic["Infected Parent/Angry Buzzer"], 30, 19);


                //08
                AddEnemyInScene(nowSceneName, "Crossroads_08", enemyDic["Infected Parent/Bursting Zombie"], 28, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_08", enemyDic["Infected Parent/Bursting Zombie"], 41, 34.5f);

                //13
                AddEnemyInScene(nowSceneName, "Crossroads_13", enemyDic["Infected Parent/Bursting Zombie"], 17.5f, 12.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_13", enemyDic["Infected Parent/Spitting Zombie"], 68, 12.5f);

                //42
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Infected Parent/Spitting Zombie"], 28.5f, 7.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Infected Parent/Spitting Zombie"], 44, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Infected Parent/Spitting Zombie"], 96, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Infected Parent/Bursting Zombie"], 65, 4.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_42", enemyDic["Infected Parent/Bursting Zombie"], 81.5f, 16.5f);

                //19
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 22, 31.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 22, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 17, 9.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["_Enemies/Spitter"], 35, 11);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Infected Parent/Spitting Zombie"], 38.5f, 11);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Infected Parent/Spitting Zombie"], 37, 29.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Infected Parent/Spitting Zombie"], 11, 10.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_19", enemyDic["Infected Parent/Bursting Zombie"], 38.5f, 4.5f);

                //03
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["Infected Parent/Spitting Zombie"], 14, 18.5f);
                //AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["Infected Parent/Spitting Zombie"], 5, 31.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["Infected Parent/Spitting Zombie"], 11.5f, 52.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["_Enemies/Spitter"], 6, 17);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["_Enemies/Spitter"], 15, 52);
                AddEnemyInScene(nowSceneName, "Crossroads_03", enemyDic["_Enemies/Spitter"], 9.5f, 58.5f);

                //21
                AddEnemyInScene(nowSceneName, "Crossroads_21", enemyDic["Infected Parent/Bursting Zombie"], 81.5f, 14.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_21", enemyDic["Infected Parent/Bursting Zombie"], 42, 17.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_21", enemyDic["Infected Parent/Bursting Zombie"], 38, 2.5f);

                //10（boss）

                //ShamanTemple
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 94, 6.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 134, 18.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 55, 34.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 127, 27.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 120, 47.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 108, 31.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 102, 24.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 68, 42.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 58, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 62, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 67, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 25, 35.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Roller"], 21, 52.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 54.5f, 46);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 85.5f, 34);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 79, 44);
                AddEnemyInScene(nowSceneName, "Crossroads_ShamanTemple", enemyDic["_Enemies/Buzzer"], 115.5f, 51);

                //11_alt
                AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Spitter"], 81, 16);
                AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Spitter"], 89, 17);
                AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Roller"], 85, 11.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_11_alt", enemyDic["_Enemies/Roller"], 91, 11.5f);


                //39
                AddEnemyInScene(nowSceneName, "Crossroads_39", enemyDic["Infected Parent/Spitting Zombie"], 44, 11.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_39", enemyDic["Infected Parent/Bursting Zombie"], 73, 6.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_39", enemyDic["Infected Parent/Bursting Zombie"], 56, 6.5f);

                //14
                AddEnemyInScene(nowSceneName, "Crossroads_14", enemyDic["Infected Parent/Angry Buzzer"], 10, 35);
                AddEnemyInScene(nowSceneName, "Crossroads_14", enemyDic["Infected Parent/Angry Buzzer"], 22, 38);
                AddEnemyInScene(nowSceneName, "Crossroads_14", enemyDic["Infected Parent/Angry Buzzer"], 19, 10);

                //48
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Infected Parent/Bursting Zombie"], 14, 3.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Infected Parent/Bursting Zombie"], 24, 3.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Infected Parent/Bursting Zombie"], 41, 3.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_48", enemyDic["Infected Parent/Spitting Zombie"], 19, 3.5f);

                //05
                AddEnemyInScene(nowSceneName, "Crossroads_05", enemyDic["Infected Parent/Bursting Zombie"], 22.5f, 7.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_05", enemyDic["Infected Parent/Spitting Zombie"], 42.5f, 12.5f);

                //40

                //16
                AddEnemyInScene(nowSceneName, "Crossroads_16", enemyDic["Infected Parent/Angry Buzzer"], 51.5f, 8.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_16", enemyDic["Infected Parent/Angry Buzzer"], 65, 7);
                AddEnemyInScene(nowSceneName, "Crossroads_16", enemyDic["Infected Parent/Spitting Zombie"], 67, 11);

                //25
                AddEnemyInScene(nowSceneName, "Crossroads_25", enemyDic["Infected Parent/Spitting Zombie"], 53, 10);
                AddEnemyInScene(nowSceneName, "Crossroads_25", enemyDic["Infected Parent/Spitting Zombie"], 42, 12.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_25", enemyDic["Infected Parent/Bursting Zombie"], 22, 7.5f);

                //35
                AddEnemyInScene(nowSceneName, "Crossroads_35", enemyDic["_Enemies/Spitter"], 51, 46);
                AddEnemyInScene(nowSceneName, "Crossroads_35", enemyDic["_Enemies/Spitter"], 40, 42);
                AddEnemyInScene(nowSceneName, "Crossroads_35", enemyDic["_Enemies/Spitter"], 13.5f, 45);

                //12
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["Infected Parent/Angry Buzzer"], 47, 14);
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["Infected Parent/Angry Buzzer"], 21, 12);
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["Infected Parent/Bursting Zombie"], 40.5f, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_12", enemyDic["Infected Parent/Spitting Zombie"], 11, 8.5f);

                //27
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 20, 43);
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 16.5f, 57);
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 22.5f, 15.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_27", enemyDic["_Enemies/Spitter"], 3.5f, 12);

                //04
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Infected Parent/Angry Buzzer"], 25, 23);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Infected Parent/Angry Buzzer"], 38, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Infected Parent/Angry Buzzer"], 58, 21.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Infected Parent/Spitting Zombie"], 70.5f, 7.5f);
                AddEnemyInScene(nowSceneName, "Crossroads_04", enemyDic["Infected Parent/Spitting Zombie"], 126, 7.5f);

            }
        }
        //苍绿
        public void GreenPath(string nowSceneName)
        {
            //1_01
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Shaker"], 117.5f, 8.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Shaker"], 96, 18.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Shaker"], 80, 7.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Shaker"], 13.5f, 17.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Runner"], 116, 19.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Runner"], 57, 15.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_01", enemyDic["Mossman_Runner"], 12, 6.5f);

            //1_02
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mossman_Runner"], 5.5f, 31.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mossman_Runner"], 36.5f, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mosquito"], 4, 40);
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mosquito"], 21, 24);
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mosquito"], 9, 16);
            AddEnemyInScene(nowSceneName, "Fungus1_02", enemyDic["Mosquito"], 22, 15);

            //1_06
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mosquito"], 30.5f, 12);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mosquito"], 57, 13);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mosquito"], 68, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mosquito"], 103, 24);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mosquito"], 111, 7);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mosquito"], 144, 12);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mossman_Shaker"], 28.5f, 2.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mossman_Shaker"], 87, 19.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_06", enemyDic["Mossman_Shaker"], 139.5f, 7f);

            //1_07
            AddEnemyInScene(nowSceneName, "Fungus1_07", enemyDic["Mosquito"], 36.5f, 45);
            AddEnemyInScene(nowSceneName, "Fungus1_07", enemyDic["Mosquito"], 8.5f, 34.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_07", enemyDic["Mosquito"], 11, 14);
            AddEnemyInScene(nowSceneName, "Fungus1_07", enemyDic["Mosquito"], 24.5f, 21);
            AddEnemyInScene(nowSceneName, "Fungus1_07", enemyDic["Mossman_Shaker"], 22.5f, 52.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_07", enemyDic["Mossman_Shaker"], 34, 39.5f);

            //1_19
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mosquito"], 17, 17);
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mosquito"], 28.5f, 14);
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mosquito"], 45, 12.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mosquito"], 61, 15);
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mossman_Shaker"], 75, 13.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mossman_Shaker"], 47, 5.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_19", enemyDic["Mossman_Shaker"], 12, 13.5f);

            //1_11
            AddEnemyInScene(nowSceneName, "Fungus1_11", enemyDic["Mosquito"], 9, 62);
            AddEnemyInScene(nowSceneName, "Fungus1_11", enemyDic["Mosquito"], 26, 37);
            AddEnemyInScene(nowSceneName, "Fungus1_11", enemyDic["Mosquito"], 31, 23.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_11", enemyDic["Mossman_Shaker"], 21, 44.5f);

            //1_34
            AddEnemyInScene(nowSceneName, "Fungus1_34", enemyDic["_Enemies/Fat Fly"], 17, 8);
            AddEnemyInScene(nowSceneName, "Fungus1_34", enemyDic["_Enemies/Fat Fly"], 33, 9);
            AddEnemyInScene(nowSceneName, "Fungus1_34", enemyDic["_Enemies/Fat Fly"], 50, 7);
            AddEnemyInScene(nowSceneName, "Fungus1_34", enemyDic["_Enemies/Fat Fly"], 77, 7);

            //1_10
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["Mosquito"], 140, 13);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["Mosquito"], 123, 13);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["Mosquito"], 29, 16);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["Mosquito"], 13, 17);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["_Enemies/Fat Fly"], 79, 16);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["_Enemies/Fat Fly"], 70, 13);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["_Enemies/Fat Fly"], 58, 17);
            AddEnemyInScene(nowSceneName, "Fungus1_10", enemyDic["_Enemies/Fat Fly"], 22, 15);

            //1_31
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 7, 21);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 30, 20);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 19, 39);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 14, 79);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 27, 89);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 21, 112);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["Mosquito"], 5, 121);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["_Enemies/Fat Fly"], 21, 9);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["_Enemies/Fat Fly"], 7, 77);
            AddEnemyInScene(nowSceneName, "Fungus1_31", enemyDic["_Enemies/Fat Fly"], 12, 104);

            //1_32
            AddEnemyInScene(nowSceneName, "Fungus1_32", enemyDic["Mosquito"], 75, 35);
            AddEnemyInScene(nowSceneName, "Fungus1_32", enemyDic["Mosquito"], 10, 26);

            //1_20_v02
            AddEnemyInScene(nowSceneName, "Fungus1_20_v02", enemyDic["_Enemies/Buzzer"], 120, 6.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_20_v02", enemyDic["_Enemies/Buzzer"], 108, 17);
            AddEnemyInScene(nowSceneName, "Fungus1_20_v02", enemyDic["_Enemies/Buzzer"], 135, 17.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_20_v02", enemyDic["_Enemies/Buzzer"], 164.5f, 17.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_20_v02", enemyDic["_Enemies/Buzzer"], 60, 13.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_20_v02", enemyDic["_Enemies/Buzzer"], 34, 16);

            //1_21
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Plant Trap"], 18.5f, 37.6f);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Plant Trap"], 64.5f, 25.6f);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Plant Trap"], 12f, 26.6f);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Mossman_Runner"], 29, 35);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Mossman_Runner"], 40, 34.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Mossman_Runner"], 21, 15.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Mossman_Shaker"], 52, 17.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_21", enemyDic["Mossman_Shaker"], 53, 3.5f);

            //1_22
            //AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["_Enemies/Fat Fly"], 20, 101);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["_Enemies/Fat Fly"], 26, 94);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["_Enemies/Fat Fly"], 14, 89);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Mosquito"], 10, 58.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Mosquito"], 9.5f, 44);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Mosquito"], 27, 37);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Mosquito"], 15, 18);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Plant Trap"], 18, 73.6f);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Plant Trap"], 19f, 14.6f);
            AddEnemyInScene(nowSceneName, "Fungus1_22", enemyDic["Mossman_Shaker"], 18, 3.5f);

            //1_17
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mosquito"], 46, 13);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mosquito"], 8, 8.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["_Enemies/Fat Fly"], 72, 14);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["_Enemies/Fat Fly"], 42, 9);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["_Enemies/Fat Fly"], 7, 15);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mossman_Shaker"], 23, 9.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mossman_Shaker"], 55, 6.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mossman_Runner"], 37, 15.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mossman_Runner"], 17, 15.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_17", enemyDic["Mossman_Runner"], 58, 15.5f);

            //1_03
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["Mossman_Shaker"], 63, 17.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["Mossman_Shaker"], 44, 22.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["_Enemies/Fat Fly"], 46, 27);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["_Enemies/Fat Fly"], 52, 28);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["_Enemies/Fat Fly"], 51, 15);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["Mosquito"], 68, 20);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["Mosquito"], 39, 15);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["_Enemies/Zombie Shield"], 17.5f, 10.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["_Enemies/Zombie Shield"], 24, 29.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_03", enemyDic["Zombie Hornhead"], 34, 22.5f);

            //1_05
            AddEnemyInScene(nowSceneName, "Fungus1_05", enemyDic["Mosquito"], 6, 55);
            AddEnemyInScene(nowSceneName, "Fungus1_05", enemyDic["Mosquito"], 13, 39);
            AddEnemyInScene(nowSceneName, "Fungus1_05", enemyDic["Mosquito"], 20, 18);
            AddEnemyInScene(nowSceneName, "Fungus1_05", enemyDic["Mossman_Shaker"], 20, 48.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_05", enemyDic["Mossman_Runner"], 22, 10.5f);

            //1_29
            AddEnemyInScene(nowSceneName, "Fungus1_29", enemyDic["Mosquito"], 35, 24);
            AddEnemyInScene(nowSceneName, "Fungus1_29", enemyDic["Mosquito"], 44, 25);
            AddEnemyInScene(nowSceneName, "Fungus1_29", enemyDic["Mosquito"], 55, 25);
            AddEnemyInScene(nowSceneName, "Fungus1_29", enemyDic["Mossman_Runner"], 14, 21.5f);

            //1_12
            AddEnemyInScene(nowSceneName, "Fungus1_12", enemyDic["Mosquito"], 11, 53);
            AddEnemyInScene(nowSceneName, "Fungus1_12", enemyDic["Mosquito"], 9, 40);
            AddEnemyInScene(nowSceneName, "Fungus1_12", enemyDic["Mosquito"], 15, 15);
            AddEnemyInScene(nowSceneName, "Fungus1_12", enemyDic["Mossman_Shaker"], 16, 48.5f);

            //1_13
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Mosquito"], 111, 24);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Mosquito"], 119, 27);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Mosquito"], 126, 12);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Mosquito"], 148, 20);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Mosquito"], 189, 23.5f);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["Mosquito"], 161, 13);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["_Enemies/Fat Fly"], 84, 22);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["_Enemies/Fat Fly"], 79, 14);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["_Enemies/Fat Fly"], 89, 14);
            AddEnemyInScene(nowSceneName, "Fungus1_13", enemyDic["_Enemies/Fat Fly"], 156, 26);

            //1_26
            AddEnemyInScene(nowSceneName, "Fungus1_26", enemyDic["Plant Turret (2)"], 6.5f, 26.5f, 180);
        }
        //真菌
        public void Fungus(string nowSceneName)
        {
            //2_06
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 20, 154);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 6, 155);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 28, 148);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 20, 136);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 26, 130);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 18, 125);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 26, 102);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 12, 105);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 18, 45);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungoon Baby"], 13, 31);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungus Flyer"], 20, 82);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungus Flyer"], 20, 63);
            AddEnemyInScene(nowSceneName, "Fungus2_06", enemyDic["Fungus Flyer"], 8, 46);

            //2_04
            AddEnemyInScene(nowSceneName, "Fungus2_04", enemyDic["Mushroom Turret (3)"], 3.5f, 15, 270);
            AddEnemyInScene(nowSceneName, "Fungus2_04", enemyDic["Mushroom Turret (3)"], 11.5f, 62.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_04", enemyDic["Mushroom Turret (3)"], 14, 39.5f, 180);

            //2_03
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Zombie Fungus B"], 79, 6.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Zombie Fungus A"], 95, 4.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Fungus Flyer"], 114, 19);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Fungus Flyer"], 96, 28);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Fungus Flyer"], 81, 25);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Fungus Flyer"], 58, 20);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Fungus Flyer"], 21, 23);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Mushroom Turret (3)"], 99.5f, 69, 90);
            AddEnemyInScene(nowSceneName, "Fungus2_03", enemyDic["Mushroom Turret (3)"], 92, 54.5f, 180);

            //2_18
            AddEnemyInScene(nowSceneName, "Fungus2_18", enemyDic["Fungus Flyer"], 51, 18.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_18", enemyDic["Fungus Flyer"], 112, 53.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_18", enemyDic["Fungus Flyer"], 115, 22.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_18", enemyDic["Mushroom Turret (3)"], 68.5f, 39.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_18", enemyDic["Mushroom Turret (3)"], 37.5f, 13, 270);

            //2_07
            AddEnemyInScene(nowSceneName, "Fungus2_07", enemyDic["Mushroom Roller"], 34, 14.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_07", enemyDic["Mushroom Roller"], 56.5f, 13.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_07", enemyDic["Mushroom Roller"], 25f, 6.5f);

            //2_08
            AddEnemyInScene(nowSceneName, "Fungus2_08", enemyDic["Fungoon Baby"], 9, 47);
            AddEnemyInScene(nowSceneName, "Fungus2_08", enemyDic["Fungus Flyer"], 18.5f, 63);
            AddEnemyInScene(nowSceneName, "Fungus2_08", enemyDic["Fungus Flyer"], 6, 27);
            AddEnemyInScene(nowSceneName, "Fungus2_08", enemyDic["Mushroom Roller"], 8, 33.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_08", enemyDic["Mushroom Turret (3)"], 3.5f, 14.5f, 270);

            //2_10
            AddEnemyInScene(nowSceneName, "Fungus2_10", enemyDic["Fungus Flyer"], 40.5f, 66);
            AddEnemyInScene(nowSceneName, "Fungus2_10", enemyDic["Fungus Flyer"], 54, 64.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_10", enemyDic["Fungus Flyer"], 18, 67);
            AddEnemyInScene(nowSceneName, "Fungus2_10", enemyDic["Fungus Flyer"], 48, 44.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_10", enemyDic["Fungus Flyer"], 23, 40);
            AddEnemyInScene(nowSceneName, "Fungus2_10", enemyDic["Mushroom Roller"], 23, 14.5f);

            //2_11
            AddEnemyInScene(nowSceneName, "Fungus2_11", enemyDic["Fungus Flyer"], 9.5f, 41.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_11", enemyDic["Fungus Flyer"], 18.5f, 41);
            AddEnemyInScene(nowSceneName, "Fungus2_11", enemyDic["Mushroom Roller"], 20, 62.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_11", enemyDic["Mushroom Turret (3)"], 26, 10, 90);
            AddEnemyInScene(nowSceneName, "Fungus2_11", enemyDic["Mushroom Turret (3)"], 7.5f, 52, 270);

            //2_12
            AddEnemyInScene(nowSceneName, "Fungus2_12", enemyDic["Mantis"], 62, 13);
            AddEnemyInScene(nowSceneName, "Fungus2_12", enemyDic["Mantis"], 101.5f, 5);
            AddEnemyInScene(nowSceneName, "Fungus2_12", enemyDic["Mantis Flyer Child"], 85.5f, 18, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_12", enemyDic["Mantis Flyer Child"], 106.5f, 21.5f, 180);

            //2_13
            AddEnemyInScene(nowSceneName, "Fungus2_13", enemyDic["Mantis"], 10, 109);
            AddEnemyInScene(nowSceneName, "Fungus2_13", enemyDic["Mantis"], 17.5f, 77);
            AddEnemyInScene(nowSceneName, "Fungus2_13", enemyDic["Mantis Flyer Child"], 11.7f, 93.5f, 180);
            AddEnemyInScene(nowSceneName, "Fungus2_13", enemyDic["Mantis Flyer Child"], 20, 65, 180);

            //2_29
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Zombie Fungus B"], 54, 37.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Zombie Fungus A"], 33, 37.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Zombie Fungus B"], 43.5f, 21.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Zombie Fungus A"], 21, 21.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Zombie Fungus A"], 15, 3.5f);
            AddEnemyInScene(nowSceneName, "Fungus2_29", enemyDic["Fungus Flyer"], 19, 29.5f);

            //2_30
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Fungus Flyer"], 19, 121);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Fungus Flyer"], 26, 108);
            AddEnemyInScene(nowSceneName, "Fungus2_30", enemyDic["Fungus Flyer"], 22, 88);

            //2_17
            AddEnemyInScene(nowSceneName, "Fungus2_17", enemyDic["Fungus Flyer"], 22.5f, 28);
            AddEnemyInScene(nowSceneName, "Fungus2_17", enemyDic["Fungus Flyer"], 28, 17);
            AddEnemyInScene(nowSceneName, "Fungus2_17", enemyDic["Fungus Flyer"], 10.5f, 32.5f);

            //2_19
            AddEnemyInScene(nowSceneName, "Fungus2_19", enemyDic["Fungus Flyer"], 42, 18);
            AddEnemyInScene(nowSceneName, "Fungus2_19", enemyDic["Fungus Flyer"], 22, 19);
            AddEnemyInScene(nowSceneName, "Fungus2_19", enemyDic["Fungus Flyer"], 9, 16);

        }
        //泪城
        public void TearsCity(string nowSceneName)
        {
            //1_01
            AddEnemyInScene(nowSceneName, "Ruins1_01", enemyDic["Ruins Sentry 1"], 32, 17.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_01", enemyDic["Ruins Sentry 1"], 88, 17.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_01", enemyDic["Ceiling Dropper (1)"], 32.2f, 24);
            AddEnemyInScene(nowSceneName, "Ruins1_01", enemyDic["Ceiling Dropper (1)"], 52, 26.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_01", enemyDic["Ceiling Dropper (1)"], 115, 26);

            //1_02
            AddEnemyInScene(nowSceneName, "Ruins1_02", enemyDic["Ruins Flying Sentry"], 21, 64);
            AddEnemyInScene(nowSceneName, "Ruins1_02", enemyDic["Ruins Flying Sentry Javelin"], 14, 46);
            AddEnemyInScene(nowSceneName, "Ruins1_02", enemyDic["Ceiling Dropper (1)"], 17.25f, 21f);

            //1_03
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Sentry Fat"], 29, 51.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ceiling Dropper (1)"], 7, 56);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Sentry 1"], 35, 26.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Sentry 1"], 83, 36.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Sentry 1"], 137, 40.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Flying Sentry Javelin"], 60, 38);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Flying Sentry Javelin"], 88, 64);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Flying Sentry"], 99, 46);
            AddEnemyInScene(nowSceneName, "Ruins1_03", enemyDic["Ruins Flying Sentry"], 132, 18);

            //1_04
            AddEnemyInScene(nowSceneName, "Ruins1_04", enemyDic["Ruins Flying Sentry"], 107, 18);
            AddEnemyInScene(nowSceneName, "Ruins1_04", enemyDic["Ruins Flying Sentry"], 78, 17);
            AddEnemyInScene(nowSceneName, "Ruins1_04", enemyDic["Ruins Flying Sentry Javelin"], 41, 19);

            //1_05b
            AddEnemyInScene(nowSceneName, "Ruins1_05b", enemyDic["Ceiling Dropper (1)"], 5.5f, 31);

            //1_05c
            AddEnemyInScene(nowSceneName, "Ruins1_05c", enemyDic["Ruins Sentry 1"], 16, 36.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_05c", enemyDic["Ruins Sentry 1"], 11.5f, 61.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_05c", enemyDic["Ruins Sentry 1"], 12.5f, 75.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_05c", enemyDic["Ruins Flying Sentry"], 13, 56);
            AddEnemyInScene(nowSceneName, "Ruins1_05c", enemyDic["Ruins Flying Sentry"], 3.5f, 93.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_05c", enemyDic["Ceiling Dropper (1)"], 50, 110.5f);

            //1_05
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Sentry 1"], 19.5f, 135.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Flying Sentry Javelin"], 19, 118);
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Flying Sentry Javelin"], 3.5f, 141);
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Flying Sentry Javelin"], 51, 138.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_05", enemyDic["Ruins Flying Sentry"], 57, 127);

            //1_17
            AddEnemyInScene(nowSceneName, "Ruins1_17", enemyDic["Ruins Flying Sentry"], 25, 22);
            AddEnemyInScene(nowSceneName, "Ruins1_17", enemyDic["Ruins Flying Sentry"], 51.5f, 35.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_17", enemyDic["Ruins Flying Sentry Javelin"], 17.5f, 66);

            #region 灵魂圣所
            //1_09
            AddEnemyInScene(nowSceneName, "Ruins1_09", enemyDic["Mage Blob 2"], 13.5f, 21.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_09", enemyDic["Mage Blob 2"], 19, 18.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_09", enemyDic["Mage Blob 2"], 26, 21.5f);

            //1_23
            AddEnemyInScene(nowSceneName, "Ruins1_23", enemyDic["Mage Balloon"], 23, 52.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_23", enemyDic["Mage Balloon"], 31, 53);
            AddEnemyInScene(nowSceneName, "Ruins1_23", enemyDic["Mage Balloon"], 20, 63);
            AddEnemyInScene(nowSceneName, "Ruins1_23", enemyDic["Mage Balloon"], 25, 68);
            AddEnemyInScene(nowSceneName, "Ruins1_23", enemyDic["Mage Balloon"], 33.5f, 66);

            //1_25
            AddEnemyInScene(nowSceneName, "Ruins1_25", enemyDic["Mage Balloon"], 11, 58);
            AddEnemyInScene(nowSceneName, "Ruins1_25", enemyDic["Mage Balloon"], 4, 79.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_25", enemyDic["Mage Balloon"], 3, 60);
            AddEnemyInScene(nowSceneName, "Ruins1_25", enemyDic["Mage Balloon"], 11, 102);
            AddEnemyInScene(nowSceneName, "Ruins1_25", enemyDic["Mage Balloon"], 16.5f, 101);

            //1_30
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 49.5f, 14.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 60, 14.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 69, 14.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 61, 40.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 61, 32.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 8, 40.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 65.5f, 19.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 56.5f, 19.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 50, 23.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 41, 19.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Blob 2"], 4.5f, 13.5f);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 34, 33);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 40, 33);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 45, 28);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 29, 45);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 38, 45);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 33, 8);
            AddEnemyInScene(nowSceneName, "Ruins1_30", enemyDic["Mage Balloon"], 42, 12);

            //1_32
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Blob 2"], 37.7f, 8f);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Blob 2"], 41, 12f);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 32, 38);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 28, 50);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 17, 50);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 15, 28);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 8, 9);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 44, 22);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 40, 42);
            AddEnemyInScene(nowSceneName, "Ruins1_32", enemyDic["Mage Balloon"], 41, 18);

            #endregion

            //2_05
            AddEnemyInScene(nowSceneName, "Ruins2_05", enemyDic["Ruins Sentry Fat"], 24, 11.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_05", enemyDic["Ruins Sentry Fat"], 23, 74.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_05", enemyDic["Ruins Sentry Fat"], 24, 33.5f);

            //2_09
            AddEnemyInScene(nowSceneName, "Ruins2_09", enemyDic["Ruins Flying Sentry Javelin"], 31, 12);

            //2_06
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie 1"], 23, 26.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie Fat"], 26.5f, 26.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie Coward"], 30, 26.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie 1"], 23, 37.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie Fat"], 26.5f, 37.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie Coward"], 30, 37.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie 1"], 23, 14.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_06", enemyDic["Royal Zombie Coward"], 30, 14.5f);

            //2_07
            AddEnemyInScene(nowSceneName, "Ruins2_07", enemyDic["Ceiling Dropper (1)"], 15.5f, 11);
            AddEnemyInScene(nowSceneName, "Ruins2_07", enemyDic["Ceiling Dropper (1)"], 39.5f, 14);

            //2_04
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Great Shield Zombie"], 114, 26);
            AddEnemyInScene(nowSceneName, "Ruins2_04", enemyDic["Great Shield Zombie"], 89, 41);

            //2_01_b
            AddEnemyInScene(nowSceneName, "Ruins2_01_b", enemyDic["Great Shield Zombie"], 39, 29);

            //2_01
            AddEnemyInScene(nowSceneName, "Ruins2_01", enemyDic["Ruins Sentry 1"], 60, 68.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_01", enemyDic["Ruins Flying Sentry"], 45, 60);
            AddEnemyInScene(nowSceneName, "Ruins2_01", enemyDic["Ruins Flying Sentry"], 21, 66);
            AddEnemyInScene(nowSceneName, "Ruins2_01", enemyDic["Ruins Flying Sentry Javelin"], 41, 78);

            //2_03b
            AddEnemyInScene(nowSceneName, "Ruins2_03b", enemyDic["Ruins Sentry 1"], 25, 13.5f);
            AddEnemyInScene(nowSceneName, "Ruins2_03b", enemyDic["Ruins Flying Sentry"], 66, 18);

            //2_03
            AddEnemyInScene(nowSceneName, "Ruins2_03", enemyDic["Ruins Flying Sentry"], 52, 62);

        }
        //山峰
        public void CrystalPeak(string nowSceneName)
        {
            //02
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 4, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 40, 20.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 42.5f, 20.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 135, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 148, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 150, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Zombie Miner 1"], 138, 30.5f);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Crystal Flyer"], 95, 23);
            AddEnemyInScene(nowSceneName, "Mines_02", enemyDic["Crystal Flyer"], 107, 18);

            //03
            AddEnemyInScene(nowSceneName, "Mines_03", enemyDic["Zombie Miner 1"], 5, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_03", enemyDic["Zombie Miner 1"], 24.5f, 20.5f);
            AddEnemyInScene(nowSceneName, "Mines_03", enemyDic["Zombie Miner 1"], 9, 20.5f);
            AddEnemyInScene(nowSceneName, "Mines_03", enemyDic["Zombie Miner 1"], 31, 32.5f);
            AddEnemyInScene(nowSceneName, "Mines_03", enemyDic["Crystal Crawler"], 12.5f, 40.5f);
            AddEnemyInScene(nowSceneName, "Mines_03", enemyDic["Mines Crawler"], 21, 69.5f);

            //05
            AddEnemyInScene(nowSceneName, "Mines_05", enemyDic["Crystal Crawler"], 23, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_05", enemyDic["Crystal Crawler"], 15, 32.5f);
            AddEnemyInScene(nowSceneName, "Mines_05", enemyDic["Crystal Crawler"], 22, 41.5f);
            AddEnemyInScene(nowSceneName, "Mines_05", enemyDic["Crystal Crawler"], 10, 66.5f);
            AddEnemyInScene(nowSceneName, "Mines_05", enemyDic["Mines Crawler"], 27.5f, 45.5f);
            AddEnemyInScene(nowSceneName, "Mines_05", enemyDic["Mines Crawler"], 31.5f, 58.5f);

            //11
            AddEnemyInScene(nowSceneName, "Mines_11", enemyDic["Crystal Crawler"], 26, 3.5f);
            AddEnemyInScene(nowSceneName, "Mines_11", enemyDic["Zombie Miner 1"], 18, 21.5f);
            AddEnemyInScene(nowSceneName, "Mines_11", enemyDic["Crystal Crawler"], 12, 48.5f);
            AddEnemyInScene(nowSceneName, "Mines_11", enemyDic["Crystal Crawler"], 10, 27.5f);

            //20
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystal Flyer"], 37, 192);
            AddEnemyInScene(nowSceneName, "Mines_20", enemyDic["Crystal Flyer"], 54, 157);

            //31
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Crystal Flyer"], 13, 28);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Crawler"], 43.5f, 19);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Crawler"], 84.5f, 27);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Crawler"], 213.5f, 47.5f);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Crawler"], 224, 46);

            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Platform"], 125, 7);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Platform"], 140, 7);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Platform"], 155, 7);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Platform"], 170, 7);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Platform"], 185, 7);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Crystal Flyer"], 155, 14);
            AddEnemyInScene(nowSceneName, "Mines_31", enemyDic["Mines Crawler"], 185, 9);

            //37

            //04
            AddEnemyInScene(nowSceneName, "Mines_04", enemyDic["Crystal Flyer"], 24, 67);
            AddEnemyInScene(nowSceneName, "Mines_04", enemyDic["Crystal Flyer"], 28, 53);

            //17
            AddEnemyInScene(nowSceneName, "Mines_17", enemyDic["Crystal Flyer"], 29, 19);

            //23
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Crystal Flyer"], 17, 14);
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Crystal Flyer"], 36, 30);
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Crystal Flyer"], 115, 31);
            AddEnemyInScene(nowSceneName, "Mines_23", enemyDic["Zombie Beam Miner"], 168, 5.5f);

            //35
            //AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 41.5f, 12.5f);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 50.5f, 11);
            //AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 97.5f, 19);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 92.5f, 24);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 82, 50.5f);
            //AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 77, 46.5f);
            //AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 95.5f, 57.5f);
            //AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 95.5f, 62.5f);
            AddEnemyInScene(nowSceneName, "Mines_35", enemyDic["Mines Crawler"], 95.5f, 67.5f);

            //25
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Mines Crawler"], 27, 110.5f);
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Mines Crawler"], 18.5f, 106.5f);
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Mines Crawler"], 12, 116.5f);
            AddEnemyInScene(nowSceneName, "Mines_25", enemyDic["Mines Crawler"], 17, 63.5f);
            //34
            AddEnemyInScene(nowSceneName, "Mines_34", enemyDic["Mines Crawler"], 158, 23.5f);
            AddEnemyInScene(nowSceneName, "Mines_34", enemyDic["Mines Crawler"], 142.5f, 35.5f);

        }
        //安息
        public void RestingPlace(string nowSceneName)
        {
            AddEnemyInScene(nowSceneName, "RestingGrounds_06", enemyDic["Ruins Flying Sentry Javelin"], 82, 18);
        }
        //下水道
        public void RoyalWaterway(string nowSceneName)
        {
            //01
            AddEnemyInScene(nowSceneName, "Waterways_01", enemyDic["Ceiling Dropper (1)"], 68.5f, 37.2f);
            AddEnemyInScene(nowSceneName, "Waterways_01", enemyDic["Ceiling Dropper (1)"], 85.5f, 37.2f);
            AddEnemyInScene(nowSceneName, "Waterways_01", enemyDic["Ceiling Dropper (1)"], 14.5f, 17.5f);

            //04
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Ceiling Dropper (1)"], 124, 25);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Ceiling Dropper (1)"], 131, 25);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Ceiling Dropper (1)"], 6.5f, 38);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 103, 13);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 95, 8);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 85, 12);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 70, 10);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 40, 10);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 25, 10);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 28, 32);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 38, 35);
            AddEnemyInScene(nowSceneName, "Waterways_04", enemyDic["Fluke Fly"], 49, 31);

            //04b
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Ceiling Dropper (1)"], 114.5f, 29);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Ceiling Dropper (1)"], 18, 14.5f);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 115, 37);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 124, 28);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 113, 13);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 100, 9);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 37, 10);
            //AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 21, 26);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 50, 44);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 76, 26);
            AddEnemyInScene(nowSceneName, "Waterways_04b", enemyDic["Fluke Fly"], 52, 26);

            //02
            AddEnemyInScene(nowSceneName, "Waterways_02", enemyDic["Fluke Fly"], 8, 10);
            AddEnemyInScene(nowSceneName, "Waterways_02", enemyDic["Fluke Fly"], 48, 33);
            AddEnemyInScene(nowSceneName, "Waterways_02", enemyDic["Fluke Fly"], 103, 34);
            AddEnemyInScene(nowSceneName, "Waterways_02", enemyDic["Fluke Fly"], 91, 37);

            //08
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Ceiling Dropper (1)"], 40.5f, 55);
            AddEnemyInScene(nowSceneName, "Waterways_08", enemyDic["Ceiling Dropper (1)"], 4, 39.5f);

            //06
            AddEnemyInScene(nowSceneName, "Waterways_06", enemyDic["Ceiling Dropper (1)"], 78, 44.5f);
            AddEnemyInScene(nowSceneName, "Waterways_06", enemyDic["Fluke Fly"], 19, 44.5f);
            AddEnemyInScene(nowSceneName, "Waterways_06", enemyDic["Fluke Fly"], 25, 31);
            AddEnemyInScene(nowSceneName, "Waterways_06", enemyDic["Fluke Fly"], 33, 19);
            AddEnemyInScene(nowSceneName, "Waterways_06", enemyDic["Fluke Fly"], 54, 19);

            //07
            AddEnemyInScene(nowSceneName, "Waterways_07", enemyDic["Inflater"], 38, 14);
            AddEnemyInScene(nowSceneName, "Waterways_07", enemyDic["Inflater"], 54, 11);
            AddEnemyInScene(nowSceneName, "Waterways_07", enemyDic["Inflater"], 48, 15);
            AddEnemyInScene(nowSceneName, "Waterways_07", enemyDic["Inflater"], 54.5f, 19);

            //13
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ruins Flying Sentry Javelin"], 15, 92.5f);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Ruins Flying Sentry Javelin"], 25, 77);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Plant Trap"], 56.5f, 66.6f);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Plant Trap"], 68.5f, 66.6f);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Plant Trap"], 77.5f, 66.6f);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Plant Turret (2)"], 61.5f, 75.5f, 180);
            AddEnemyInScene(nowSceneName, "Waterways_13", enemyDic["Plant Turret (2)"], 68.5f, 75.5f, 180);

        }
        //雾谷
        public void FogCanyon(string nowSceneName)
        {
            //3_01
            AddEnemyInScene(nowSceneName, "Fungus3_01", enemyDic["Zap Cloud"], 9, 76);
            AddEnemyInScene(nowSceneName, "Fungus3_01", enemyDic["Zap Cloud"], 12, 62);
            AddEnemyInScene(nowSceneName, "Fungus3_01", enemyDic["Zap Cloud"], 25, 50);
            AddEnemyInScene(nowSceneName, "Fungus3_01", enemyDic["Zap Cloud"], 6, 41);
            AddEnemyInScene(nowSceneName, "Fungus3_01", enemyDic["Zap Cloud"], 16, 32);
            AddEnemyInScene(nowSceneName, "Fungus3_01", enemyDic["Zap Cloud"], 4, 21);

            //3_02
            AddEnemyInScene(nowSceneName, "Fungus3_02", enemyDic["Zap Cloud"], 9, 96);
            AddEnemyInScene(nowSceneName, "Fungus3_02", enemyDic["Zap Cloud"], 18, 78);
            AddEnemyInScene(nowSceneName, "Fungus3_02", enemyDic["Zap Cloud"], 7, 65);
            AddEnemyInScene(nowSceneName, "Fungus3_02", enemyDic["Zap Cloud"], 15, 48);
            AddEnemyInScene(nowSceneName, "Fungus3_02", enemyDic["Zap Cloud"], 13, 35);
            AddEnemyInScene(nowSceneName, "Fungus3_02", enemyDic["Zap Cloud"], 8, 24);

            //3_26
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Zap Cloud"], 22, 84);
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Jellyfish"], 25, 97);
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Jellyfish"], 19, 70);
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Jellyfish"], 7, 62.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Jellyfish"], 23, 43);
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Jellyfish"], 7, 9);
            AddEnemyInScene(nowSceneName, "Fungus3_26", enemyDic["Jellyfish"], 19, 37);

            //3_27
            AddEnemyInScene(nowSceneName, "Fungus3_27", enemyDic["Zap Cloud"], 62, 5.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_27", enemyDic["Zap Cloud"], 46.5f, 9);
            AddEnemyInScene(nowSceneName, "Fungus3_27", enemyDic["Zap Cloud"], 20.5f, 9);
            AddEnemyInScene(nowSceneName, "Fungus3_27", enemyDic["Zap Cloud"], 5, 8);
            AddEnemyInScene(nowSceneName, "Fungus3_27", enemyDic["Jellyfish"], 35, 9.5f);

            //3_24
            AddEnemyInScene(nowSceneName, "Fungus3_24", enemyDic["Jellyfish"], 77, 13);
            AddEnemyInScene(nowSceneName, "Fungus3_24", enemyDic["Jellyfish"], 88, 14);
            AddEnemyInScene(nowSceneName, "Fungus3_24", enemyDic["Jellyfish"], 44.5f, 15);
            AddEnemyInScene(nowSceneName, "Fungus3_24", enemyDic["Jellyfish"], 20, 16.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_24", enemyDic["Jellyfish"], 33, 14);

            //3_28
            AddEnemyInScene(nowSceneName, "Fungus3_28", enemyDic["Zap Cloud"], 48.5f, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_28", enemyDic["Zap Cloud"], 57, 32);
            AddEnemyInScene(nowSceneName, "Fungus3_28", enemyDic["Zap Cloud"], 38, 34);
            AddEnemyInScene(nowSceneName, "Fungus3_28", enemyDic["Zap Cloud"], 29, 18);
            AddEnemyInScene(nowSceneName, "Fungus3_28", enemyDic["Zap Cloud"], 38, 9);


            //3_25b
            for (int i = 10; i < 57; i+=2)
            {
                AddEnemyInScene(nowSceneName, "Fungus3_25b", enemyDic["Jelly Egg Bomb"], i, 14.6f);
            }


        }
        //盆地（深渊）
        public void AncientBasin(string nowSceneName)
        {
            //02
            AddEnemyInScene(nowSceneName, "Abyss_02", enemyDic["Ruins Flying Sentry Javelin"], 119, 20);
            AddEnemyInScene(nowSceneName, "Abyss_02", enemyDic["Ruins Flying Sentry Javelin"], 61, 23);
            AddEnemyInScene(nowSceneName, "Abyss_02", enemyDic["Ruins Flying Sentry Javelin"], 30, 32);

            //19
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 147, 62);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 107, 87);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 140, 62);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 141, 67);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 127, 60);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 122, 64);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 107, 64);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 110, 71);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 99, 74);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 91, 74);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 87, 88);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 79, 9);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 85, 11);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 90, 8);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 54, 15);
            AddEnemyInScene(nowSceneName, "Abyss_19", enemyDic["Parasite Balloon (1)"], 47, 11);

            //20
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 125, 66);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 128, 63);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 143, 32);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 148, 32);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 75, 36);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 80, 36);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 18, 37);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 13, 38);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 7, 39);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 4, 34);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 18, 57);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 23, 57);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 51, 63);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 56, 65);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 62, 61);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 52, 58);
            AddEnemyInScene(nowSceneName, "Abyss_20", enemyDic["Parasite Balloon (1)"], 60, 58);


            //17
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 147, 27);
            AddEnemyInScene(nowSceneName, "Abyss_17", enemyDic["Lesser Mawlek"], 141, 4);

        }
        //呼啸
        public void Cliff(string nowSceneName)
        {
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["Zombie Barger"], 128, 28.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["Zombie Barger"], 96, 11.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["Zombie Barger"], 178, 23.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["Zombie Barger"], 198.5f, 28.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["Zombie Barger"], 55.5f, 6.5f);
            AddEnemyInScene(nowSceneName, "Cliffs_02", enemyDic["Zombie Barger"], 32, 11.5f);

            if (nowSceneName == "Cliffs_01")
            {
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 83, 133);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 98, 134);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 108, 150);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 88, 145);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 100, 126);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 87, 108);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 104, 101);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 93, 95);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 84, 86);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 74, 75);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 104, 76);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 99, 59);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 96, 42);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 90, 29);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 99, 13);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["_Enemies/Buzzer"], 67, 32);

                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 10f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 12f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 14f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 16f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 18f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 20f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 22f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 24f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 26f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 28f, 4.5f);
                AddEnemyInScene(nowSceneName, "Cliffs_01", enemyDic["Zombie Barger"], 30f, 4.5f);
            }


        }
        //边缘
        public void KingdomEdge(string nowSceneName)
        {
            AddEnemyInScene(nowSceneName, "Abyss_03_c", enemyDic["Zombie Barger"], 92.5f, 10.5f);
            AddEnemyInScene(nowSceneName, "Abyss_03_c", enemyDic["Zombie Barger"], 113, 7.5f);
            AddEnemyInScene(nowSceneName, "Abyss_03_c", enemyDic["Zombie Barger"], 132, 17.5f);
            AddEnemyInScene(nowSceneName, "Abyss_03_c", enemyDic["Spider Flyer"], 97, 16);
            AddEnemyInScene(nowSceneName, "Abyss_03_c", enemyDic["Spider Flyer"], 103, 13);
            AddEnemyInScene(nowSceneName, "Abyss_03_c", enemyDic["Spider Flyer"], 121, 19);

            //01
            AddEnemyInScene(nowSceneName, "Deepnest_East_01", enemyDic["Blow Fly"], 24, 14);
            AddEnemyInScene(nowSceneName, "Deepnest_East_01", enemyDic["Blow Fly"], 33, 40);
            AddEnemyInScene(nowSceneName, "Deepnest_East_01", enemyDic["Blow Fly"], 28, 66);
            AddEnemyInScene(nowSceneName, "Deepnest_East_01", enemyDic["Blow Fly"], 21, 77);

            //02
            AddEnemyInScene(nowSceneName, "Deepnest_East_02", enemyDic["Infected Parent/Bursting Zombie"], 25.5f, 3.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_02", enemyDic["Infected Parent/Bursting Zombie"], 44, 20.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_East_02", enemyDic["Ceiling Dropper (1)"], 91.5f, 23.5f);

            //
            AddEnemyInScene(nowSceneName, "Waterways_14", enemyDic["Acid Walker"], 215, 18);
            AddEnemyInScene(nowSceneName, "Waterways_14", enemyDic["Acid Walker"], 179, 18);
            AddEnemyInScene(nowSceneName, "Waterways_14", enemyDic["Acid Walker"], 138, 18);
            AddEnemyInScene(nowSceneName, "Waterways_14", enemyDic["Acid Walker"], 89, 18);

            //03
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 32, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 20, 36);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 52, 36);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 55, 56);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 44, 63);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 52, 79);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 47, 97);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 14, 119);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 23, 132);
            AddEnemyInScene(nowSceneName, "Deepnest_East_03", enemyDic["Blow Fly"], 23, 73);

            //06

            //18
            AddEnemyInScene(nowSceneName, "Deepnest_East_18", enemyDic["Super Spitter"], 68, 13);
            AddEnemyInScene(nowSceneName, "Deepnest_East_18", enemyDic["Super Spitter"], 55, 11);
            AddEnemyInScene(nowSceneName, "Deepnest_East_18", enemyDic["Super Spitter"], 12, 15);
            AddEnemyInScene(nowSceneName, "Deepnest_East_18", enemyDic["Super Spitter"], 29, 35);

            //11

            //04
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 19, 20);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 26, 48);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 7, 73);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 13, 85);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 19, 101);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 25, 131);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 13, 158);
            AddEnemyInScene(nowSceneName, "Deepnest_East_04", enemyDic["Blow Fly"], 36, 170);

            //07
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 70, 74);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 32, 74);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 36, 101);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 47, 104);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 30, 117);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 52, 133);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 40, 162);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 25, 152);
            AddEnemyInScene(nowSceneName, "Deepnest_East_07", enemyDic["Blow Fly"], 27, 178);

            //08
            AddEnemyInScene(nowSceneName, "Deepnest_East_08", enemyDic["Super Spitter"], 104, 17);
            AddEnemyInScene(nowSceneName, "Deepnest_East_08", enemyDic["Super Spitter"], 61, 29);
            AddEnemyInScene(nowSceneName, "Deepnest_East_08", enemyDic["Super Spitter"], 111, 18);

        }
        //深巢
        public void Deepnest(string nowSceneName)
        {
            //01b
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 26, 23.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 7, 23.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 11, 34.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 45, 45.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 45, 4.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 13, 56.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_01b", enemyDic["Zombie Hornhead"], 15, 67.5f);

            //02
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Hornhead"], 10, 35.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Hornhead"], 21, 35.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Hornhead"], 16, 57.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Hornhead"], 26, 53.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Hornhead"], 15, 69.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Hornhead"], 15, 41.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_02", enemyDic["Zombie Leaper"], 11, 69.5f);

            //36
            AddEnemyInScene(nowSceneName, "Deepnest_36", enemyDic["Infected Parent/Angry Buzzer"], 45, 13);
            AddEnemyInScene(nowSceneName, "Deepnest_36", enemyDic["Infected Parent/Angry Buzzer"], 64.5f, 12);
            AddEnemyInScene(nowSceneName, "Deepnest_36", enemyDic["Infected Parent/Angry Buzzer"], 57, 12);

            //17
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["Infected Parent/Angry Buzzer"], 4, 37);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["Infected Parent/Angry Buzzer"], 11.5f, 10);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["Zombie Leaper"], 6, 32.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["Zombie Leaper"], 19.5f, 32.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["Zombie Leaper"], 2.5f, 19.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["Zombie Leaper"], 6, 6.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["_Enemies/Zombie Shield"], 17, 19.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_17", enemyDic["_Enemies/Zombie Shield"], 22, 4.5f);

            //16
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 74, 17.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 80.5f, 17);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 56.5f, 46);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 54, 36.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 16, 24.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 24, 14.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 35.5f, 57);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Infected Parent/Angry Buzzer"], 12, 46.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Zombie Leaper"], 73.5f, 12.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Zombie Leaper"], 61, 41.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_16", enemyDic["Zombie Leaper"], 14, 43.5f);

            //30
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 42, 138.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 22, 104.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 30, 110.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 75, 70.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 38, 92.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 21, 92.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Bursting Zombie"], 52, 74.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Angry Buzzer"], 12, 137);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Infected Parent/Angry Buzzer"], 23, 138);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Lesser Mawlek"], 23, 131.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_30", enemyDic["Ceiling Dropper (1)"], 64.1f, 106.2f);

            //37
            //AddEnemyInScene(nowSceneName, "Deepnest_37", enemyDic["Infected Parent/Angry Buzzer"], 15.5f, 29.5f);
            //AddEnemyInScene(nowSceneName, "Deepnest_37", enemyDic["Infected Parent/Angry Buzzer"], 43.5f, 6);
            //AddEnemyInScene(nowSceneName, "Deepnest_37", enemyDic["Infected Parent/Bursting Zombie"], 47, 16.5f);
            //AddEnemyInScene(nowSceneName, "Deepnest_37", enemyDic["Infected Parent/Bursting Zombie"], 14, 16.5f);
            //AddEnemyInScene(nowSceneName, "Deepnest_37", enemyDic["Infected Parent/Bursting Zombie"], 67, 16.5f);
            //AddEnemyInScene(nowSceneName, "Deepnest_37", enemyDic["Infected Parent/Bursting Zombie"], 60, 27.5f);

            //38
            AddEnemyInScene(nowSceneName, "Deepnest_38", enemyDic["Ceiling Dropper (1)"], 53, 17.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_38", enemyDic["Ceiling Dropper (1)"], 65, 17.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_38", enemyDic["Ceiling Dropper (1)"], 85, 17.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_38", enemyDic["Ceiling Dropper (1)"], 114, 17.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_38", enemyDic["Ceiling Dropper (1)"], 124.5f, 13f);
            AddEnemyInScene(nowSceneName, "Deepnest_38", enemyDic["Ceiling Dropper (1)"], 142.5f, 13f);

            //03
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Bursting Zombie"], 36, 5.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Bursting Zombie"], 50, 14.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Bursting Zombie"], 14, 29.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Bursting Zombie"], 31.5f, 52.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Bursting Zombie"], 36, 63.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Bursting Zombie"], 54, 105.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 10, 10.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 22, 17);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 27, 34);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 33, 85);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 47.5f, 93);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 5, 93);
            AddEnemyInScene(nowSceneName, "Deepnest_03", enemyDic["Infected Parent/Angry Buzzer"], 15, 96);

            //33
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 50, 6.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 51, 21.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 75.5f, 21.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 58.5f, 39.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 70, 30.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 8.5f, 10.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 42.5f, 12.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_33", enemyDic["Infected Parent/Bursting Zombie"], 23.5f, 4.5f);

            //14
            AddEnemyInScene(nowSceneName, "Deepnest_14", enemyDic["_Enemies/Spitter"], 14, 45);
            AddEnemyInScene(nowSceneName, "Deepnest_14", enemyDic["_Enemies/Spitter"], 30, 47);
            AddEnemyInScene(nowSceneName, "Deepnest_14", enemyDic["_Enemies/Spitter"], 25, 46);

            //26
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["_Enemies/Spitter"], 210, 13.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["_Enemies/Spitter"], 234, 18);
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["_Enemies/Spitter"], 190, 15.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["_Enemies/Spitter"], 168, 13.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["Infected Parent/Angry Buzzer"], 131, 26);
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["Infected Parent/Angry Buzzer"], 132, 7);
            AddEnemyInScene(nowSceneName, "Deepnest_26", enemyDic["Infected Parent/Bursting Zombie"], 153, 13.5f);

            //26b
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 15, 21);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 28.5f, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 40, 11);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 55.5f, 11);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 70, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 85, 17);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["_Enemies/Spitter"], 101, 24);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["Blow Fly"], 113.5f, 20);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["Blow Fly"], 88, 16.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["Blow Fly"], 45, 15.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["Blow Fly"], 19, 22);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["Blow Fly"], 74, 17);
            AddEnemyInScene(nowSceneName, "Deepnest_26b", enemyDic["Blow Fly"], 32.5f, 18);

            //35
            AddEnemyInScene(nowSceneName, "Deepnest_35", enemyDic["Ceiling Dropper (1)"], 28.5f, 105.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_35", enemyDic["Ceiling Dropper (1)"], 6, 105.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_35", enemyDic["Ceiling Dropper (1)"], 24, 85.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_35", enemyDic["Ceiling Dropper (1)"], 6.5f, 67.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_35", enemyDic["Ceiling Dropper (1)"], 20, 60.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_35", enemyDic["Infected Parent/Bursting Zombie"], 33, 4.5f);

            //34
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Infected Parent/Angry Buzzer"], 137, 27);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Infected Parent/Angry Buzzer"], 113, 13);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Infected Parent/Angry Buzzer"], 93.5f, 9.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Infected Parent/Bursting Zombie"], 100, 28.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Infected Parent/Bursting Zombie"], 64.5f, 6.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Infected Parent/Bursting Zombie"], 22, 16.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Ceiling Dropper (1)"], 12, 19);
            AddEnemyInScene(nowSceneName, "Deepnest_34", enemyDic["Ceiling Dropper (1)"], 59, 13);

            //39
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Slash Spider"], 168, 5.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Slash Spider"], 154, 22.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Slash Spider"], 91, 22.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 113, 13);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 126, 16.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 132.5f, 11f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 127, 32f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 115, 30);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 154, 48);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 76, 65);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 54, 45);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 65, 43.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 70, 29);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 32.5f, 62);
            AddEnemyInScene(nowSceneName, "Deepnest_39", enemyDic["Spider Flyer"], 115, 42);

            //42
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Bursting Zombie"], 13.5f, 3.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Bursting Zombie"], 23.5f, 66.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 11.5f, 128);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 30, 121.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 20, 111);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 30, 93.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 26.5f, 73.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 24.5f, 46);
            AddEnemyInScene(nowSceneName, "Deepnest_42", enemyDic["Infected Parent/Angry Buzzer"], 18, 35);

            //41
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Ceiling Dropper (1)"], 58, 106);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Ceiling Dropper (1)"], 90, 100);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Ceiling Dropper (1)"], 83, 90);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Ceiling Dropper (1)"], 89, 74);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Ceiling Dropper (1)"], 41.5f, 47);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Infected Parent/Bursting Zombie"], 23, 89.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Infected Parent/Bursting Zombie"], 64.5f, 72.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Infected Parent/Bursting Zombie"], 50, 5.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_41", enemyDic["Infected Parent/Bursting Zombie"], 76.5f, 98.5f);

            //Spider_Town
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 40, 6.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 100, 4.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 103, 30.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 100, 128.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 27, 99.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 25, 135.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Infected Parent/Bursting Zombie"], 91.5f, 135.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Ceiling Dropper (1)"], 113, 62);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Ceiling Dropper (1)"], 78, 96);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Ceiling Dropper (1)"], 92, 107);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Ceiling Dropper (1)"], 19, 156.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Ceiling Dropper (1)"], 50, 103);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Slash Spider (2)"], 54, 12.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Slash Spider"], 60, 133.5f);
            AddEnemyInScene(nowSceneName, "Deepnest_Spider_Town", enemyDic["Slash Spider (2)"], 65, 30.5f);

        }
        //蜂巢
        public void Beenest(string nowSceneName)
        {

        }
        //花园
        public void QueensGarden(string nowSceneName)
        {
            //3_34
            AddEnemyInScene(nowSceneName, "Fungus3_34", enemyDic["Garden Zombie"], 140, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_34", enemyDic["Garden Zombie"], 126, 9.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_34", enemyDic["Garden Zombie"], 102, 5.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_34", enemyDic["Garden Zombie"], 78, 5.5f);

            //3_04
            AddEnemyInScene(nowSceneName, "Fungus3_04", enemyDic["Garden Zombie"], 20, 51.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_04", enemyDic["Garden Zombie"], 29, 70.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_04", enemyDic["Garden Zombie"], 13, 83.5f);

            //3_05
            AddEnemyInScene(nowSceneName, "Fungus3_05", enemyDic["Plant Trap"], 33.5f, 24.7f);
            AddEnemyInScene(nowSceneName, "Fungus3_05", enemyDic["Plant Trap"], 27, 6.6f);

            //3_39
            AddEnemyInScene(nowSceneName, "Fungus3_39", enemyDic["Mantis Heavy Flyer"], 23, 46);
            AddEnemyInScene(nowSceneName, "Fungus3_39", enemyDic["Mantis Heavy Flyer"], 20, 29);
            AddEnemyInScene(nowSceneName, "Fungus3_39", enemyDic["Mantis Heavy Flyer"], 29, 17);

            //3_11
            #region MyRegion
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 58);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 56);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 54);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 52);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 50);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 48);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 46);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 44);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 42);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 40);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 38);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 20, 36);

            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 33);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 31);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 29);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 27);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 25);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 23);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 21);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 19);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 17);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 15);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 13);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 17, 11);

            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 60);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 58);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 56);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 54);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 52);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 50);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 48);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 46);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 44);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 42.5f, 42);

            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 30);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 28);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 26);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 24);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 22);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 20);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 18);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 16);
            AddEnemyInScene(nowSceneName, "Fungus3_11", enemyDic["Moss Flyer (1)"], 45.5f, 14);
            #endregion

            //3_13
            AddEnemyInScene(nowSceneName, "Fungus3_13", enemyDic["Mantis Heavy Flyer"], 9, 21);
            AddEnemyInScene(nowSceneName, "Fungus3_13", enemyDic["Mantis Heavy Flyer"], 14, 30);
            AddEnemyInScene(nowSceneName, "Fungus3_13", enemyDic["Mantis Heavy Flyer"], 9, 48);
            AddEnemyInScene(nowSceneName, "Fungus3_13", enemyDic["Mantis Heavy Flyer"], 9, 61);

            //3_22
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Garden Zombie"], 18, 3.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Garden Zombie"], 22, 11.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Garden Zombie"], 13, 24.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Garden Zombie"], 20, 83.5f);

            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 3.7f, 86, 270);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 3.7f, 98, 270);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 25.3f, 101, 90);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 4.6f, 114, 270);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 4.6f, 121, 270);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 25.3f, 125, 90);
            AddEnemyInScene(nowSceneName, "Fungus3_22", enemyDic["Plant Trap"], 15, 135.4f);


            //3_23
            AddEnemyInScene(nowSceneName, "Fungus1_23", enemyDic["Mantis Heavy Flyer"], 122, 18);
            AddEnemyInScene(nowSceneName, "Fungus1_23", enemyDic["Mantis Heavy Flyer"], 131, 14);
            AddEnemyInScene(nowSceneName, "Fungus1_23", enemyDic["Mantis Heavy Flyer"], 18, 13);

            //3_48
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Battle Scene/Mantis Heavy"], 61, 28);
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Battle Scene/Mantis Heavy"], 81, 28);
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Mantis Heavy Flyer"], 67, 19);

            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Plant Trap"], 32, 23.6f);
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Plant Trap"], 28.3f, 18.6f);
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Plant Trap"], 16f, 95.6f);
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Plant Trap"], 55, 13.6f);
            AddEnemyInScene(nowSceneName, "Fungus3_48", enemyDic["Plant Trap"], 48.5f, 9.6f);


            //3_40
            AddEnemyInScene(nowSceneName, "Fungus3_40", enemyDic["Garden Zombie"], 39, 19.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_40", enemyDic["Garden Zombie"], 23.5f, 19.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_40", enemyDic["Garden Zombie"], 14, 24.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_40", enemyDic["Garden Zombie"], 31, 25.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_40", enemyDic["Garden Zombie"], 23, 4.5f);
            AddEnemyInScene(nowSceneName, "Fungus3_40", enemyDic["Garden Zombie"], 119, 14.5f);

        }
        #endregion
        #endregion




        #region API
        /// <summary>
        /// 在某个场景中添加敌人
        /// </summary>
        /// <param name="nowSceneName">当前场景名</param>
        /// <param name="addSceneName">要添加敌人的场景名</param>
        /// <param name="enemy">要添加的敌人</param>
        /// <param name="x">坐标x</param>
        /// <param name="y">坐标y</param>
        public void AddEnemyInScene(string nowSceneName, string addSceneName, GameObject enemy, float x, float y, float angle = 0, float scale = 1)
        {
            if (nowSceneName == addSceneName)
            {
                GameObject obj = new GameObject();
                obj = GameObject.Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
                if (angle != 0)
                {
                    obj.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                obj.SetActive(true);
                Modding.Logger.Log("添加了敌人" + enemy.name + "在位置(" + x + "," + y + ")");
            }
        }

        //添加敌人并设置大小
        public void AddEnemyInScene2(string nowSceneName, string addSceneName, GameObject enemy, float x, float y, float z = 0, float angle = 0, float scale = 1)
        {
            if (nowSceneName == addSceneName)
            {
                GameObject obj = new GameObject();
                obj = GameObject.Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);
                if (angle != 0)
                {
                    obj.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                obj.transform.localScale = Vector3.one * scale;
                obj.SetActive(true);
                Modding.Logger.Log("添加了敌人" + enemy.name + "在位置(" + x + "," + y + ")");
                obj.name = enemy.name + "(" + x + "," + y + "," + z + ")";
            }
        }

        //返回GameObject的添加
        public GameObject AddEnemyInScene3(string nowSceneName, string addSceneName, GameObject enemy, float x, float y, float z = 0, float angle = 0, float scale = 1)
        {
            GameObject obj = new GameObject();
            if (nowSceneName == addSceneName)
            {
                obj = GameObject.Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);
                if (angle != 0)
                {
                    obj.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                obj.transform.localScale = Vector3.one * scale;
                obj.SetActive(true);
                Modding.Logger.Log("添加了敌人" + enemy.name + "在位置(" + x + "," + y + ")");
                obj.name = enemy.name + "(" + x + "," + y + "," + z + ")";
            }
            return obj;
        }

        //添加星爆并设置fsm
        public void AddBlast(string nowSceneName, string addSceneName, GameObject enemy, float x, float y)
        {
            if (nowSceneName == addSceneName)
            {
                GameObject obj = new GameObject();
                obj = GameObject.Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
                obj.SetActive(true);
                Modding.Logger.Log("添加了敌人" + enemy.name + "在位置(" + x + "," + y + ")");
                obj.name = enemy.name + "(" + x + "," + y + "," + 0 + ")";

                PlayMakerFSM self = obj.GetComponent<PlayMakerFSM>();
                self.ChangeTransition("Init", "FINISHED", "Wait");
                self.ChangeTransition("End", "FINISHED", "Wait");
                self.GetState("Init").GetAction<FloatOperator>(1).float2.Value = 0f;
                self.GetState("Init").GetAction<FloatOperator>(2).float2.Value = 0f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMin.Value = 0f;
                self.GetState("Wait").GetAction<WaitRandom>().timeMax.Value = 0f;
                self.GetState("Set Pos X").GetAction<RandomFloat>().max.Value = x;
                self.GetState("Set Pos X").GetAction<RandomFloat>().min.Value = x;
                self.GetState("Pos Low").GetAction<RandomFloat>().max.Value = y;
                self.GetState("Pos Low").GetAction<RandomFloat>().min.Value = y;
                self.GetState("Pos High").GetAction<RandomFloat>().max.Value = y;
                self.GetState("Pos High").GetAction<RandomFloat>().min.Value = y;
                self.GetState("Sound").GetAction<Wait>().time.Value = 0.5f;

            }
        }

        #endregion

    }
}
