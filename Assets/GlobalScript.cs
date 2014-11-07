using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	
	//GameObject fighter;
	//FighterScript fighterScript;

	void Start () {
		//fighter = GameObject.FindGameObjectWithTag("Fighter");
		//fighterScript = fighter.GetComponent<FighterScript> ();
	}

	void OnGUI (){
		GUILayout.BeginArea(new Rect(0,  100, 100, Screen.height));//Screen.height / 2 +

		if (GUILayout.Button("Fire", GUILayout.Height(300))) {
			//Application.LoadLevel("GameplayScene");
			//fighterScript.Fire();
			//launcher.LaunchRay();
		}

		
		/*if (GUILayout.Button("Exit")) {
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}*/
		GUILayout.EndArea();
	}


	void Update () {

	}
}
