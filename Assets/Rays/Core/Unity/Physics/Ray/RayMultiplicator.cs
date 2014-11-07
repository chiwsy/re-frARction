using UnityEngine;

[RequireComponent(typeof(RayListener))]

/// <summary>
/// Multiplicates the incoming ray in the specified directions.
/// </summary>
public class RayMultiplicator : MonoBehaviour
{
	/// <summary>
	/// Divides the incoming ray range by the directions quantity for the output rays.
	/// </summary>
	public bool divideRange;
	
	/// <summary>
	/// Divides the incoming ray intensity by the directions quantity for the output rays.
	/// </summary>
	public bool divideIntensity;
	
	/// <summary>
	/// Scales the incoming ray range.
	/// </summary>
	public float rangeFactor = 1;
	
	/// <summary>
	/// Scales the incoming ray intensity.
	/// </summary>
	public float intenstityFactor = 1;
	
	/// <summary>
	/// The directions that the incoming ray will be multiplied.
	/// </summary>
    public Transform[] directions;
	
    void OnRay(RayInfo rayInfo)
    {
    	//Scales the corresponding range and intensity
    	float range = rayInfo.finalRange * rangeFactor;
    	float intensity = rayInfo.intensity * intenstityFactor;
    	
    	//Divides the range if the flags are marked
    	if (divideRange) range /= directions.Length;
		if (divideIntensity) intensity /= directions.Length;
    	
    	//Multiply the ray
    	for (int i = directions.Length - 1; i >= 0; i--) 
    	{
    		//Emit the ray in the specified directions.
    		Transform direction = directions[i];
    		RayInfo.Emit(direction.position, direction.forward, range, rayInfo.maxRange, intensity, direction);
		}
    }
    
	void OnRayExit(RayInfo rayInfo)
	{
		//Advices all directions that they stop emitting rays.
		for (int i = directions.Length - 1; i >= 0; i--)
			directions [i].SendMessage ("OnRayStopSent", this, SendMessageOptions.DontRequireReceiver);
	}
}