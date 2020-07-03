using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Modding;
using UnityEngine;

namespace BossTemplate
{
    public class BossTemplate : Mod, IMod
    {
        //if any of this seems wrong, it may be my fault because I am currently writing this pretty late at night and am feeling pretty tired. I still wanted to make this though.

        //You can get help with this by asking on the hk discord or watching the tutorial that I will be making soon.
        //this template is meant for godhome use. It can be used for first boss encounters, but was not meant for that use.

        //The name of the boss gameobject. you can use debug to find this.
        public static string bossobjectname = "Giant Buzzer Col";
        //The name of the scene or level that the boss is located in.
        public static string bossscenename = "GG_Vengefly";
        //The name of the playmaker FSM on the boss gameobject. you can use FSM viewer to find this.
        public static string bossfsmname = "Big Buzzer";
        //is the boss in the pantheons or only in hall of gods/hog? make false if your boss is located outside of godhome or the way to reach the boss requires you to not be in hog.
        public static bool onlyinhog = true;
        //name of the mod
        new string GetName() => "MyBossModName";
        //version of the mod. can contain text.
        override public string GetVersion() => "Place the mod's version here. Can also be a string as shown here.";
        //this is what is loaded when the game starts. use it for hooks/on such as these.
        override public void Initialize()
        {
            //hooks
            ModHooks.Instance.AfterSavegameLoadHook += this.SaveGame;
            ModHooks.Instance.NewGameHook += AddComponent;
        }
        //occurs in case we aren't starting a new game.
        private void SaveGame(SaveGameData data)
        {
            AddComponent();
        }
        //occurs when we start a new game.
        private static void AddComponent()
        {
            GameManager.instance.gameObject.AddComponent<BossFinder>();
        }
    }
}
