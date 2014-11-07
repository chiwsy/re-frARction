using UnityEngine;

[RequireComponent(typeof(RayListener))]

/// <summary>
/// Reflects the incoming ray.
/// </summary>
public class RayRefractor : MonoBehaviour
{
	/// <summary>
	/// Scales the incoming ray range.
	/// </summary>
	public float intensityFactor = 1;
	
	/// <summary>
	/// Scales the incoming ray intensity.
	/// </summary>
    public float rangeFactor = 1;

    void OnRay (RayInfo rayInfo)
    {
    	//Reflects the incoming ray and advices the gameObject that he emit a ray.
    	RayInfo.Emit(rayInfo.to, rayInfo.normalReflectDirection, rayInfo.finalRange * rangeFactor,rayInfo.maxRange, rayInfo.intensity* intensityFactor, transform);
    }
    
	void OnRayExit (RayInfo rayInfo)
	{
		SendMessage ("OnRayStopSent", this, SendMessageOptions.DontRequireReceiver);
	}
    
	void OnDisable ()
	{
		SendMessage ("OnRayStopSent", this, SendMessageOptions.DontRequireReceiver);
	}
}