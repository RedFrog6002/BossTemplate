using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Reflection;

namespace BossTemplate
{
    public class BossFinder : MonoBehaviour
    {
		//like initialize except for whatever we attach this class to, which in this case is the gamemanager.
		private void Start()
		{
			//hooks
			UnityEngine.SceneManagement.SceneManager.activeSceneChanged += this.SceneChanged;
		}
		//occurs when the sscene is changed.
		private void SceneChanged(Scene lastscene, Scene currentscene)
		{
			//lastscene is the scene we were just in. current scene is the scene we are transitioning to
			bool boss;
			//this next part is heavily dependant on the info that you must insert in BossTemplate
			//this checks if we want the boss to only appear in the hall of gods
			if (BossTemplate.onlyinhog)
			{
				//here we check if the lastscene that we were in was hog and if the current scene is the boss scene that has the boss we are editing. it also chacks if the boss scene has _V because some bosses have harder versions that instead use scenename_V
				boss = lastscene.name == "GG_Workshop" && (currentscene.name == BossTemplate.bossscenename || currentscene.name == BossTemplate.bossscenename + "_V");
			}
			//here we are checking if we want the boss to appear in the pantheons and hog.
			else
			{
				//now since we let the boss occur anywhere that the scene is, we only need to check if it is the correct scene. same reasoning for _V as the last one
				boss = currentscene.name == BossTemplate.bossscenename || currentscene.name == BossTemplate.bossscenename + "_V";
			}
			//this checks if our conditions for changing the boss are correct.
			if (boss)
			{
				//here we are adding our code to the boss
				AddComponent();
			}
		}
		//this adds our class that changes the boss.
		private static IEnumerator AddComponent()
		{
			yield return null;
			//This part depends on some info that you must insert in BossTemplate
			//we will now be waiting for the boss to no longer be null just in case the boss is weird.
			yield return new WaitWhile(() => !GameObject.Find(BossTemplate.bossobjectname));
			GameObject.Find(BossTemplate.bossobjectname).AddComponent<Boss>();
			yield break;
		}
	}
}
