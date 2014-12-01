using UnityEngine;

[RequireComponent(typeof(RayListener))]


public class RaySummation : MonoBehaviour {

	public Transform direction;

	private float rayIntensity1 = 0.0f;
	private float rayIntensity2 = 0.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnRaySummation (RayInfo rayInfo){

		float intensitySum = rayIntensity1 + rayIntensity2;
		RayInfo.Emit(0, direction.position, direction.forward, rayInfo.finalRange,rayInfo.maxRange, intensitySum, direction);
	}

	void OnRay1 (RayInfo rayInfo){
		rayIntensity1 = rayInfo.intensity;
		OnRaySummation (rayInfo);

	}

	void OnRay2 (RayInfo rayInfo){
		rayIntensity2 = rayInfo.intensity;
		OnRaySummation (rayInfo);
	}
	
	void OnRayExit (RayInfo rayInfo)
	{
		if (rayInfo.rayIndex == 1)
			rayIntensity1 = 0.0f;
		else if
			(rayInfo.rayIndex == 2)
			rayIntensity2 = 0.0f;

	}
	
	void OnDisable ()
	{
	}
}
