using UnityEngine;
using System.Collections;

public class EmitterScript : MonoBehaviour {

	public ArcReactor_Launcher launcher;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		launcher.LaunchRay();
	}
}
