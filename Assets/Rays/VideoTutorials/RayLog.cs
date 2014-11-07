using UnityEngine;
using System.Collections;

public class RayLog : MonoBehaviour 
{
	void OnRayEnter (RayInfo ray)
	{
		Debug.Log ("Enter - " + ray.emitter.name);
	}
	
	void OnRay (RayInfo ray)
	{
		Debug.Log ("Stay - " + ray.emitter.name);
	}
	
	void OnRayExit(RayInfo ray)
	{
		Debug.Log("Exit - " + ray.emitter.name);
	}
}