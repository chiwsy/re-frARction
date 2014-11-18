using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public Transform[] path;
	float t = 0;
	Quaternion SmoothQuaternion;
	
	// Use this for initialization
	void Start () {
		//SmoothQuaternion = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = Spline.MoveOnPath(path, transform.position, ref t, 2.0f);
		Quaternion q = new Quaternion();
		transform.position = Spline.MoveOnPath(path, transform.position, ref t, ref q, 0.5f, 100, EasingType.Sine, true, true);
		//SmoothQuaternion = q;
		transform.rotation = q;
	}
}
