using UnityEngine;
using System.Collections;

public class ReceiverScript : MonoBehaviour {

	public bool received = false;
	public float winTimer = 3.0f; //how many seconds the light needs to hit until the player wins
	public bool win = false; //becomes true after the timer becomes 0 and the ray is still hitting
	public float expectedIntensity = 1.0f; //will be used for levels with dividers
	public GameObject explosion;
	public AudioClip explosionAudio;
	private bool startExplode = false;
	private bool gotoAnotherLevel = false;
	private float timerAfterAnimation = 0.0f;
	public float resetTimer = 0.25f; //how many seconds need to pass before the win timer resets
	public GameObject counterText;
	public GameObject gui;

	// Use this for initialization
	void Start () {
		counterText.SetActive(false);
		gui.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(received){
			counterText.SetActive (true);
			winTimer -= Time.deltaTime;
			if(winTimer <= 1){
				counterText.GetComponent<TextMesh>().text = "1";
			}
			else if(winTimer <= 2){
				counterText.GetComponent<TextMesh>().text = "2";
			}

		}
		else{
			resetTimer -= Time.deltaTime;
			if(resetTimer <= 0){
				counterText.SetActive (false);
				winTimer = 3.0f;
				counterText.GetComponent<TextMesh>().text = "3";
			}
		}
		if (winTimer <= 0){
			//won the level
			win = true;
			counterText.SetActive (false);
			GameObject train = GameObject.FindGameObjectWithTag ("Train");
			TrainAnimationScript ts = train.GetComponent<TrainAnimationScript>();
			ts.animate = true;



			if(startExplode == false){
				GameObject[] targets = GameObject.FindGameObjectsWithTag ("Target");
				
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
			timerAfterAnimation += Time.deltaTime;	
			if(timerAfterAnimation > 10.0){
				gui.SetActive(true);
				/*if(Application.loadedLevelName == "Level1Scene"){
					Application.LoadLevel("Level2Scene");
				}
				else if(Application.loadedLevelName == "Level2Scene"){
					Application.LoadLevel("Level3Scene");
				}*/
					
			}
		}

	}

	void OnRayEnter(RayInfo ray) {
		if(Mathf.Abs(ray.intensity - expectedIntensity) < 0.001)
			received = true;

	}

	void OnRayExit(RayInfo ray) {
		//reset the timer on ray exit
		received = false;
		resetTimer = 0.25f;
		//winTimer = 3.0f;
	}
}
