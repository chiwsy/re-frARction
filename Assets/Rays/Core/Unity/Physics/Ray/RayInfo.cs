using UnityEngine;

/// <summary>
/// Contains all the needed ray info to do calculations.
/// </summary>
public struct RayInfo
{

	public int rayIndex;
	/// <summary>
	/// Which component emitted the ray.
	/// </summary>
	public Component emitter;
	
	/// <summary>
	/// Which component received the ray.
	/// </summary>
	public Component receiver;
	
	/// <summary>
	/// The start position of the ray.
	/// </summary>
    public Vector3 from;
    
    /// <summary>
    /// The end position of the ray.
    /// </summary>
    public Vector3 to;
    
    /// <summary>
    /// The ray's hit normal.
    /// </summary>
    public Vector3 normal;
    
    /// <summary>
    /// The ray's length.
    /// </summary>
    public float length;
    
    /// <summary>
    /// The max range that the ray can reach.
    /// </summary>
    public float maxRange;
    
    /// <summary>
    /// How bright the ray will be.
    /// </summary>
    public float intensity;
    
    /// <summary>
    /// The end positions range of the ray.
    /// </summary>
    public float finalRange;
    
    /// <summary>
    /// The start positions range of the ray.
    /// </summary>
    public float initialRange;
	
	/// <summary>
	/// Gets the range percentaje.
	/// </summary>
    public float rangePercentaje
    {
        get { return finalRange / initialRange; }
    }
    
    /// <summary>
    /// Gets the direction of the ray.
    /// </summary>
    public Vector3 direction
    {
        get { return (to - from).normalized; }
    }
    
    /// <summary>
    /// Gets the direction that the ray that will be reflected by a reflector.
    /// </summary>
    public Vector3 normalReflectDirection
    {
        get { return Vector3.Reflect(direction, normal).normalized; }
    }
    
    /// <summary>
    /// Calculates a ray from the current frame in base of the parameters.
    /// </summary>
    /// <returns>
    /// The current frame ray.
    /// </returns>
    /// <param name='from'>
    /// Where the rays starts.
    /// </param>
    /// <param name='direction'>
    /// Where the rays points, or the direction.
    /// </param>
    /// <param name='range'>
    /// How much long the ray is.
    /// </param>
    /// <param name='maxRange'>
    /// The max long that the ray can be.
    /// </param>
    /// <param name='intensity'>
    /// How much bright the ray will be.
    /// </param>
    /// <param name='origin'>
    /// Who emits the ray.
    /// </param>
	public static RayInfo GetCurrentFrameRay (int rayIndex, Vector3 from, Vector3 direction, float range, float maxRange, float intensity, Transform origin = null)
	{
		if (range == 0)
			range = 0.001f;
		if (range < 0) {
			range = -range;
			direction.x = -direction.x;
			direction.y = -direction.y;
			direction.z = -direction.z;
		}
		Vector3 point;
		Vector3 normal;
		Transform hitTransform = null;
        
		RaycastHit hit;
        
		if (Physics.Raycast (from, direction, out hit, range)) {
			point = hit.point;
			normal = hit.normal;
			hitTransform = hit.transform;
		} else {
			point = from + direction * range;
			normal = point;
		}
    	
		RayInfo ray;
		ray.emitter = origin;
		ray.receiver = hitTransform;
		ray.from = from;
		ray.to = point;
		ray.normal = normal;
		ray.maxRange = range;
		ray.length = Vector3.Distance (ray.from, ray.to);
		ray.finalRange = range - ray.length;
		ray.initialRange = range;
		ray.intensity = intensity;
		ray.maxRange = maxRange;
		ray.rayIndex = rayIndex;
		
		return ray;
	}
    
    /// <summary>
    /// Emits a ray from the specified from, direction, range, maxRange, intensity and origin.
    /// </summary>
	/// <param name='from'>
	/// Where the rays starts.
	/// </param>
	/// <param name='direction'>
	/// Where the rays points, or the direction.
	/// </param>
	/// <param name='range'>
	/// How much long the ray is.
	/// </param>
	/// <param name='maxRange'>
	/// The max long that the ray can be.
	/// </param>
	/// <param name='intensity'>
	/// How much bright the ray will be.
	/// </param>
	/// <param name='origin'>
	/// Who emits the ray.
	/// </param>
	public static RayInfo Emit (int rayIndex, Vector3 from, Vector3 direction, float range, float maxRange, float intensity, Transform origin = null)
	{
		return Emit (GetCurrentFrameRay (rayIndex, from, direction, range, maxRange, intensity, origin));
	}
    
    /// <summary>
    /// Emit the specified ray and advices the receiver that has received a ray and the emitter that has
    /// also sent one.
    /// </summary>
    /// <param name='ray'>
    /// Ray to emit.
    /// </param>
	public static RayInfo Emit (RayInfo ray)
	{
		if (ray.receiver != null) {
			ray.receiver.SendMessage ("OnRay", ray, SendMessageOptions.DontRequireReceiver);
			string s = "OnRay" + ray.rayIndex.ToString ();
			ray.receiver.SendMessage (s, ray, SendMessageOptions.DontRequireReceiver);		
		
		}
		if(ray.emitter != null)
			ray.emitter.SendMessage ("OnRaySent", ray, SendMessageOptions.DontRequireReceiver);
			
		return ray;
	}
}