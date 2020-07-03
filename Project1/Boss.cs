using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ModCommon;
using ModCommon.Util;
using System.Collections;

namespace BossTemplate
{
    public class Boss : MonoBehaviour
    {
        //sadly, this is the part where it will be easier for me to explain in the video I am making. if you aren't using the video as a guide, this is where we part ways for now. Hopefuly I'll get the video out soon.
        //this part is also heavily dependant on fsmviewer, so make sure you have got that
        private IEnumerator Start()
        {
            yield return null;
            //boss start code. if you are using phases in your boss, you should change the transitions in update and do all of the attack making stuff here(there are some instances where it is easier to do it in update)
            yield break;
        }
        private void Update()
        {
            /*here is where you can control the phases for your boss!
            if (_hm.hp < 100)
            {
                cool phase 2 stuffs
            }*/
        }
        private void Awake()
        {
            //health of the boss
            this._hm = base.gameObject.GetComponent<HealthManager>();
            //FSM that we edit
            this._control = base.gameObject.LocateMyFSM(BossTemplate.bossfsmname);
        }
        //variable for easy access to the fsm
        private PlayMakerFSM _control;
        //variable for easy access to the hp
        private HealthManager _hm;

        /*sneak peek of what we will be covering in the tutorial:
        GetAction
        RemoveAction
        CopyState
        ChangeTransition
            Some stuff we won't be covering/may lightly cover, but still are used:
        AddAction
        AddTransition
        InsertAction
        InsertMethod*/
    }
}
