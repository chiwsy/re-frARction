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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(received){
			winTimer -= Time.deltaTime;
		}
		if (winTimer <= 0){
			//won the level
			win = true;
			GameObject train = GameObject.FindGameObjectWithTag ("Train");
			//TrainAnimationScript ts = train.GetComponent<TrainAnimationScript>();
			//ts.animate = true;
			
			
			
			if(startExplode == false){
				GameObject[] targets = GameObject.FindGameObjectsWithTag ("Target2");
				
				foreach(GameObject g in targets){
					Destroy(g);
				}
				
				GameObject receiver = GameObject.FindGameObjectWithTag ("Receiver");
				Collider collider =  receiver.collider;
				collider.enabled = false;
				
				GameObject explode = Instantiate (explosion, gameObject.transform.position, Quaternion.identity) as GameObject;
				startExplode = true;
				
				AudioSource.PlayClipAtPoint (explosionAudio, gameObject.transform.position);
			}
		}
		
		if (win == true) {
			/*timerAfterAnimation += Time.deltaTime;	
			if(timerAfterAnimation > 5.0){
				if(Application.loadedLevelName == "Level1Scene"){
					Application.LoadLevel("Level2Scene");
				}
				else if(Application.loadedLevelName == "Level2Scene"){
					Application.LoadLevel("Level3Scene");
				}
					
			}*/
		}
		
	}
	
	void OnRayEnter(RayInfo ray) {
		if (ray.intensity == expectedIntensity) 
			received = true;
		
		//received = true;
		//Get the intensity of the incoming ray
		//float receivedIntensity = ray.intensity;
	}
	
	void onRayExit() {
		//reset the timer on ray exit
		received = false;
		winTimer = 3.0f;
		AudioSource.PlayClipAtPoint (explosionAudio, gameObject.transform.position);
	}
}
