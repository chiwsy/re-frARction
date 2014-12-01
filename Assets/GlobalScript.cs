using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	

	void Start () {

	}

	void OnGUI (){
		GUILayout.BeginArea(new Rect(0,  100, 100, Screen.height));//Screen.height / 2 +

		if (GUILayout.Button("Restart", GUILayout.Height(300))) {
			Application.LoadLevel(Application.loadedLevelName);

		}


		GUILayout.EndArea();
	}


	void Update () {

	}
}
