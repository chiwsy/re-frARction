using UnityEngine;
using System.Collections;

public class LevelUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onNext(){
		if(Application.loadedLevelName == "Level1Scene"){
			Application.LoadLevel("Level2Scene");
		}
		else if(Application.loadedLevelName == "Level2Scene"){
			Application.LoadLevel("Level3Scene");
		}
		else if(Application.loadedLevelName == "Level3Scene"){
			Application.LoadLevel("Level4Scene");
		}
		else if(Application.loadedLevelName == "Level4Scene"){
			Application.LoadLevel("Level5Scene");
		}

	}
	
	public void onExit(){
		Application.Quit();
	}

	public void onMain(){
		Application.LoadLevel ("main_menu");
	}
}
