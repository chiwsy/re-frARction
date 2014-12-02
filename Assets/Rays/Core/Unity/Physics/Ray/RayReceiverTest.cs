using UnityEngine;
using System.Collections;

public class RayReceiverTest : MonoBehaviour {

	public bool received = false;
	public float winTimer = 3.0f; //how many seconds the light needs to hit until the player wins
	public bool win = false; //becomes true after the timer becomes 0 and the ray is still hitting
	public float expectedIntensity = 1.0f; //will be used for levels with dividers
	public GameObject explosion;
	public AudioClip explosionAudio;
	private bool startExplode = false;
	private bool gotoAnotherLevel = false;
	private float timerAfterAnimation = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnRayEnter(RayInfo ray) {
		bool stop = true;
		
	}
	void OnRayEnter2(RayInfo ray) {
		bool stop = true;
		
	}
	
	void OnRayExit(RayInfo ray) {
		bool stop = true;
	}
}
