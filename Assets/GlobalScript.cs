using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	

	public AudioClip bg;
	public AudioSource as_bgMusic;
	
	void Start () {
		as_bgMusic = (AudioSource)gameObject.AddComponent("AudioSource");
		as_bgMusic.clip = bg;
		as_bgMusic.loop = true;
		as_bgMusic.Play();
		as_bgMusic.volume = 0.5f;
		DontDestroyOnLoad(gameObject);
	}

	void OnGUI (){
		/*GUILayout.BeginArea(new Rect(0,  100, 100, Screen.height));//Screen.height / 2 +

		if (GUILayout.Button("Replay", GUILayout.Height(300))) {
			Application.LoadLevel(Application.loadedLevelName);

		}
		if (GUILayout.Button("Begin", GUILayout.Height(300))) {
			Application.LoadLevel("Level1Scene");
			
		}


		GUILayout.EndArea();*/
	}


	void Update () {

	}

}
