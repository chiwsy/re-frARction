using UnityEngine;
using System.Collections;

public class DividerReceiveScript : MonoBehaviour {

	public GameObject text;
	public GameObject full;
	public bool half = false;
	public bool third = false;
	public GameObject half1;
	public GameObject half2;
	public GameObject third1;
	public GameObject third2;
	public GameObject third3;
	// Use this for initialization
	void Start () {
		text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnRayEnter(RayInfo ray){
		text.SetActive (true);
		float rayIntensity = ray.intensity;
		if(rayIntensity < 1){
			int denom = Mathf.RoundToInt(1.0f/rayIntensity);
			full.GetComponent<TextMesh>().text = "1/"+denom.ToString();
		}
		else{
			full.GetComponent<TextMesh>().text = ray.intensity.ToString();
		}
		if(half){
			int denom = Mathf.RoundToInt (1.0f/(rayIntensity/2.0f));
			//half1.GetComponent<TextMesh>().text = (ray.intensity/2.0f).ToString();
			//half2.GetComponent<TextMesh>().text = (ray.intensity/2.0f).ToString();
			half1.GetComponent<TextMesh>().text = "1/"+denom.ToString();
			half2.GetComponent<TextMesh>().text = "1/"+denom.ToString();
		}
		if(third){
			int denom = Mathf.RoundToInt (1.0f/(rayIntensity/3.0f));
			//third1.GetComponent<TextMesh>().text = (ray.intensity/3.0f).ToString();
			//third2.GetComponent<TextMesh>().text = (ray.intensity/3.0f).ToString();
			//third3.GetComponent<TextMesh>().text = (ray.intensity/3.0f).ToString();
			third1.GetComponent<TextMesh>().text = "1/"+denom.ToString();
			third2.GetComponent<TextMesh>().text = "1/"+denom.ToString();
			third3.GetComponent<TextMesh>().text = "1/"+denom.ToString();
		}
	}

	void OnRayExit(){
		text.SetActive (false);
	}
}
