using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	

	void Start () {

	}

	void OnGUI (){
		GUILayout.BeginArea(new Rect(0,  100, 100, Screen.height));//Screen.height / 2 +

		if (GUILayout.Button("Replay", GUILayout.Height(300))) {
			Application.LoadLevel(Application.loadedLevelName);

		}
		if (GUILayout.Button("Begin", GUILayout.Height(300))) {
			Application.LoadLevel("Level1Scene");
			
		}


		GUILayout.EndArea();
	}


	void Update () {

	}
}
