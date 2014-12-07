using UnityEngine;
using System.Collections;

public class Receiver2Script : MonoBehaviour {
	
	public bool received = false;
	public float winTimer = 3.0f; //how many seconds the light needs to hit until the player wins
	public bool win = false; //becomes true after the timer becomes 0 and the ray is still hitting
	public float expectedIntensity = 0.5f; //will be used for levels with dividers
	public GameObject explosion;
	public AudioClip explosionAudio;
	private bool startExplode = false;
	private bool gotoAnotherLevel = false;
	private float timerAfterAnimation = 0.0f;
	private bool bothReceived = false;
	public bool otherReceiverReceived = false;
	public GameObject counterText;
	// Use this for initialization
	void Start () {
		counterText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (received == true && otherReceiverReceived == true) {
			counterText.SetActive (true);
			winTimer -= Time.deltaTime;
			if(winTimer <= 1){
				counterText.GetComponent<TextMesh>().text = "1";
			}
			else if(winTimer <= 2){
				counterText.GetComponent<TextMesh>().text = "2";
			}
		} else {
			winTimer = 3.0f;	
		}
		if (winTimer <= 0){
			//won the level
			win = true;
			GameObject train = GameObject.FindGameObjectWithTag ("Train2");
			if(train != null){
				TrainAnimationScript ts = train.GetComponent<TrainAnimationScript>();
				ts.animate = true;
			}
			
			
			
			if(startExplode == false){
				GameObject[] targets = GameObject.FindGameObjectsWithTag ("Target2");
				
				foreach(GameObject g in targets){
					Destroy(g);
				}
				
				GameObject receiver = GameObject.FindGameObjectWithTag ("Receiver2");
				Collider collider =  receiver.collider;
				collider.enabled = false;
				
				GameObject explode = Instantiate (explosion, gameObject.transform.position, Quaternion.identity) as GameObject;
				startExplode = true;
				
				AudioSource.PlayClipAtPoint (explosionAudio, gameObject.transform.position);
			}
		}
		
		if (win == true) {
			timerAfterAnimation += Time.deltaTime;	
			if(timerAfterAnimation > 10.0){
				/*if(Application.loadedLevelName == "Level3Scene"){
					Application.LoadLevel("Level4Scene");
				}				
				else if(Application.loadedLevelName == "Level4Scene"){
					Application.LoadLevel("Level5Scene");
				}*/
					
			}
		}
		
	}
	
	void OnRay(RayInfo ray) {
		if (Mathf.Abs (ray.intensity - expectedIntensity) < 0.001) {
			received = true;
			GameObject receiver1 = GameObject.FindGameObjectWithTag ("Receiver1");
			Receiver1Script receiver1Script = receiver1.GetComponent<Receiver1Script> ();
			if (receiver1Script != null) {
					receiver1Script.otherReceiverReceived = true;
					//if (received == true && receiver1Script.received == true)
					//	bothReceived = true;
			}
		}
		//received = true;
		//Get the intensity of the incoming ray
		//float receivedIntensity = ray.intensity;
	}
	
	void OnRayExit() {
		//reset the timer on ray exit
		received = false;
		counterText.SetActive(false);
		counterText.GetComponent<TextMesh>().text = "3";
		//bothReceived = false;
		GameObject receiver1 = GameObject.FindGameObjectWithTag ("Receiver1");
		Receiver1Script receiver1Script = receiver1.GetComponent<Receiver1Script>();
		if (receiver1Script != null) {
			receiver1Script.otherReceiverReceived = false;
		}
		winTimer = 3.0f;
	}
}
