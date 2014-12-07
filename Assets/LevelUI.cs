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
			Application.LoadLevel("pre_level2");
		}
		else if(Application.loadedLevelName == "Level2Scene"){
			Application.LoadLevel("pre_level3");
		}
		else if(Application.loadedLevelName == "Level3Scene"){
			Application.LoadLevel("pre_level4");
		}
		else if(Application.loadedLevelName == "Level4Scene"){
			Application.LoadLevel("pre_level5");
		}

	}
	
	public void onExit(){
		Application.Quit();
	}

	public void onReplay(){
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void onMain(){
		Application.LoadLevel ("main_menu");
	}
}
