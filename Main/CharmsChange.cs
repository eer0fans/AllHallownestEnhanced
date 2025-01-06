using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InControl.InControlInputModule;
using UnityEngine;
using UnityEngine.UI;


namespace AllHallownestEnhanced.Main
{
    public class CharmsChange : SingletonBase<CharmsChange>
    {
        public void Change(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            if (AllHallownestEnhanced.settings_.on && AllHallownestEnhanced.settings_.changeCharm)  
            {
                PlayerData.instance.charmCost_2 = 0;//指南针
                PlayerData.instance.charmCost_1 = 0;//蜂群聚集
                PlayerData.instance.charmCost_4 = 1;//坚固外壳
                PlayerData.instance.charmCost_31 = 1;//冲刺大师
                PlayerData.instance.charmCost_37 = 0;//飞毛腿
                PlayerData.instance.charmCost_35 = 2;//蜕变挽歌

                PlayerData.instance.charmCost_24 = 0;//贪婪
                PlayerData.instance.charmCost_15 = 0;//沉痛之击
                PlayerData.instance.charmCost_32 = 2;//快速劈砍
                PlayerData.instance.charmCost_6 = 1;//亡怒

                PlayerData.instance.charmCost_5 = 1;//巴德尔之壳
                PlayerData.instance.charmCost_11 = 2;//吸虫
                PlayerData.instance.charmCost_22 = 0;//发光子宫
                PlayerData.instance.charmCost_8 = 1;//生命血
                PlayerData.instance.charmCost_9 = 2;//生命血核心
                PlayerData.instance.charmCost_27 = 0;//乔尼的诅咒

                PlayerData.instance.charmCost_29 = 2;//蜂巢血
                PlayerData.instance.charmCost_16 = 1;//锋利之影
                PlayerData.instance.charmCost_39 = 1;//小蜘蛛
                PlayerData.instance.charmCost_38 = 1;//梦盾
                if (PlayerData.instance.grimmChildLevel == 5)
                {
                    PlayerData.instance.charmCost_40 = 2;//无忧旋律
                }
                else
                {
                    PlayerData.instance.charmCost_40 = 0;//格林之子
                }
            }
            else
            {
                PlayerData.instance.charmCost_2 = 1;//指南针
                PlayerData.instance.charmCost_1 = 1;//蜂群聚集
                PlayerData.instance.charmCost_4 = 2;//坚固外壳
                PlayerData.instance.charmCost_31 = 2;//冲刺大师
                PlayerData.instance.charmCost_37 = 1;//飞毛腿
                PlayerData.instance.charmCost_35 = 3;//蜕变挽歌

                PlayerData.instance.charmCost_24 = 2;//贪婪
                PlayerData.instance.charmCost_15 = 2;//沉痛之击
                PlayerData.instance.charmCost_32 = 3;//快速劈砍
                PlayerData.instance.charmCost_6 = 2;//亡怒

                PlayerData.instance.charmCost_5 = 2;//巴德尔之壳
                PlayerData.instance.charmCost_11 = 3;//吸虫
                PlayerData.instance.charmCost_22 = 2;//发光子宫
                PlayerData.instance.charmCost_8 = 2;//生命血
                PlayerData.instance.charmCost_9 = 3;//生命血核心
                PlayerData.instance.charmCost_27 = 4;//乔尼的诅咒

                PlayerData.instance.charmCost_29 = 4;//蜂巢血
                PlayerData.instance.charmCost_16 = 2;//锋利之影
                PlayerData.instance.charmCost_39 = 2;//小蜘蛛
                PlayerData.instance.charmCost_38 = 3;//梦盾
                if (PlayerData.instance.grimmChildLevel == 5)
                {
                    PlayerData.instance.charmCost_40 = 3;//无忧旋律
                }
                else
                {
                    PlayerData.instance.charmCost_40 = 2;//格林之子
                }
            }
        }

        public void Change2(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            if (AllHallownestEnhanced.settings_.on && AllHallownestEnhanced.settings_.changeCharm)
            {
                PlayerData.instance.charmCost_20 = 1;//灵魂捕手
                PlayerData.instance.charmCost_21 = 3;//噬魂者
                PlayerData.instance.charmCost_18 = 1;//修长
                PlayerData.instance.charmCost_13 = 2;//骄傲
                PlayerData.instance.charmCost_7 = 2;//快聚
                PlayerData.instance.charmCost_34 = 3;//深聚
                if (PlayerData.instance.royalCharmState == 3)
                {
                    PlayerData.instance.charmCost_36 = 2;//白心
                }
            }
            else
            {
                PlayerData.instance.charmCost_20 = 2;//灵魂捕手
                PlayerData.instance.charmCost_21 = 4;//噬魂者
                PlayerData.instance.charmCost_18 = 2;//修长
                PlayerData.instance.charmCost_13 = 3;//骄傲
                PlayerData.instance.charmCost_7 = 3;//快聚
                PlayerData.instance.charmCost_34 = 4;//深聚
                if (PlayerData.instance.royalCharmState == 3)
                {
                    PlayerData.instance.charmCost_36 = 5;//白心
                }
            }
        }

    }
}
