using UnityEngine;
using System.Collections;

public class TrainAnimationScript : MonoBehaviour {
	public Transform[] path;
	float t = 0;
	public bool animate = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(animate){
			Quaternion q = new Quaternion();
			transform.position	 = Spline.MoveOnPath(path, transform.position, ref t, ref q, 10.0f, 100, EasingType.Sine, true, true);
			//transform.localPosition	 = Spline.MoveOnPath(path, transform.localPosition, ref t, ref q, 10.0f, 100, EasingType.Sine, true, true);
			//transform.position = Spline.MoveOnPath(path, transform.position, ref t, 10.5f);
			//transform.rotation = q;
		}

	}
}
