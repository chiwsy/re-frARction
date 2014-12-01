using UnityEngine;
using System.Collections;

public class StarRotateScript : MonoBehaviour {

	float rotateAngle = 60;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotateAngle += Time.deltaTime * 200;
		gameObject.transform.localRotation = Quaternion.Euler (new Vector3 (0, rotateAngle, 0));
	}
}
