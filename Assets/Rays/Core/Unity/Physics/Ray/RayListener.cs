using UnityEngine;
using System.Collections;

/// <summary>
/// Sends the OnRayEnter and OnRayExit events, whitout this behaviour, those events can't be received.
/// </summary>
public class RayListener : MonoBehaviour 
{
	private bool _received;
	private bool received;
	private RayInfo _ray;
	
	void OnRay(RayInfo ray) 
	{
		_ray = ray;
		received = true;
	}
	
	void LateUpdate()
	{
		if(_received != received) SendMessage(received ? "OnRayEnter" : "OnRayExit", _ray, SendMessageOptions.DontRequireReceiver);
		_received = received;
		received = false;
	}
}