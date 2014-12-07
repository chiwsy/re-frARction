using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {

	GameObject info_guide;
	GameObject info_team;
	// Use this for initialization
	void Start () {
		info_guide = GameObject.Find ("info_guide");
		info_team = GameObject.Find ("info_team");
		if(info_guide != null)info_guide.SetActive (false);
		if(info_team != null) info_team.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onPlay(){
		Application.LoadLevel ("level_menu");
	}

	public void onGuide(){
		info_guide.SetActive (true);
	}

	public void onExit(){
		info_guide.SetActive (false);
	}
	public void onAbout(){
		info_team.SetActive (true);
	}
	public void onExit2(){
		info_team.SetActive (false);
		}
	public void onLevel1(){
		Application.LoadLevel ("Level1Scene");
	}
	public void onLevel2(){
		Application.LoadLevel ("Level2Scene");
	}
	public void onLevel3(){
		Application.LoadLevel ("Level3Scene");
	}
	public void onLevel4(){
		Application.LoadLevel ("Level4Scene");
	}
	public void onLevel5(){
		Application.LoadLevel ("Level5Scene");
	}
	public void onPreLevel1(){
		Application.LoadLevel ("pre_level1");
	}
	public void onPreLevel2(){
		Application.LoadLevel ("pre_level2");
	}
	public void onPreLevel3(){
		Application.LoadLevel ("pre_level3");
	}
	public void onPreLevel4(){
		Application.LoadLevel ("pre_level4");
	}
	public void onPreLevel5(){
		Application.LoadLevel ("pre_level5");
	}
}
