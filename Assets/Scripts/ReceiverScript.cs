using UnityEngine;
using System.Collections;

public class ReceiverScript : MonoBehaviour {

	public bool received = false;
	public float winTimer = 3.0f; //how many seconds the light needs to hit until the player wins
	public bool win = false; //becomes true after the timer becomes 0 and the ray is still hitting
	public float expectedIntensity = 0.2f; //will be used for levels with dividers

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(received){
			winTimer -= Time.deltaTime;
		}
		if (winTimer <= 0){
			win = true;
		}
	}

	void OnRayEnter(RayInfo ray) {
		received = true;
		//Get the intensity of the incoming ray
		float receivedIntensity = ray.intensity;
	}

	void onRayExit() {
		//reset the timer on ray exit
		received = false;
		winTimer = 3.0f;
	}
}
