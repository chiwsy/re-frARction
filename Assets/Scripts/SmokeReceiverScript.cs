using UnityEngine;
using System.Collections;

public class SmokeReceiverScript : MonoBehaviour {

	public bool received = false;
	public float smokeTimer = 1.0f; //how many seconds the light needs to hit until the player wins
	public bool smoke = false; //becomes true after the timer becomes 0 and the ray is still hitting
	public float expectedIntensity = 1.0f; //will be used for levels with dividers
	public GameObject smokeEffect;
	public AudioClip smokeAudio;
	private bool startExplode = false;
	private float timerAfterAnimation = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(received){
			smokeTimer -= Time.deltaTime;
		}
		if (smokeTimer <= 0){
			//won the level


			if(smoke == false){

				
				GameObject smokeInst = Instantiate (smokeEffect, gameObject.transform.position, Quaternion.identity) as GameObject;
				smoke = true;
				
				//AudioSource.PlayClipAtPoint (smokeAudio, gameObject.transform.position);
			}
		}
		
		/*if (win == true) {
			timerAfterAnimation += Time.deltaTime;	
			if(timerAfterAnimation > 10.0){
				if(Application.loadedLevelName == "Level1Scene"){
					Application.LoadLevel("Level2Scene");
				}
				else if(Application.loadedLevelName == "Level2Scene"){
					Application.LoadLevel("Level3Scene");
				}
				
			}
		}*/
	}

	void OnRayEnter(RayInfo ray) {
		if(Mathf.Abs(ray.intensity - expectedIntensity) < 0.001)
			received = true;
		
	}
	
	void OnRayExit(RayInfo ray) {
		//reset the timer on ray exit
		received = false;
		smokeTimer = 1.0f;
	}
}
