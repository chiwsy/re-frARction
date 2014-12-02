using UnityEngine;

[RequireComponent(typeof(RayListener))]

public class RayRefractor : MonoBehaviour {
	/// <summary>
	/// Scales the incoming ray range.
	/// </summary>
	public float intensityFactor = 1;
	public float refractionIndex = 1.6f;
	
	
	
	/// <summary>
	/// Scales the incoming ray intensity.
	/// </summary>
	public float rangeFactor = 1;
	public Transform transform1;
	public Transform transform2;
	public Transform transform3;
	public Transform transform4;
	public Transform transform5;
	public Transform transform6;
	public Transform transform7;
	public Transform transform8;
	
	
	void OnRayRefract (RayInfo rayInfo, Transform t1, Transform t2)
	{
		//Reflects the incoming ray and advices the gameObject that he emit a ray.

		//from air to object
		float airToObjCosTheta1 = -1 * Vector3.Dot(rayInfo.direction, rayInfo.normal);
		float airToObjCosTheta2Square = 1 - (1 / refractionIndex * refractionIndex) * (1 - Mathf.Pow(airToObjCosTheta1, 2));
		Vector3 refractInDir = Vector3.Normalize(rayInfo.direction / refractionIndex + (airToObjCosTheta1 / refractionIndex - Mathf.Sqrt(airToObjCosTheta2Square)) * rayInfo.normal);
		
		Vector3 from = rayInfo.to + 30.0f*refractInDir;
		Vector3 refractInDirOppo = refractInDir * -1;
		//RayInfo.Emit(rayInfo.rayIndex, from, refractInDir, rayInfo.finalRange * rangeFactor,rayInfo.maxRange, rayInfo.intensity* intensityFactor, transform);
		RaycastHit hit;
		Vector3 objIntersectN;
		Vector3 point;
		if (Physics.Raycast (from, refractInDirOppo, out hit, 30)) {
			point = hit.point;
			objIntersectN = -1 * hit.normal;
			//hitTransform = hit.transform;
		} else {
			return;
		}


		//RayInfo.Emit(rayInfo.rayIndex, point, refractInDir, rayInfo.finalRange * rangeFactor,rayInfo.maxRange, rayInfo.intensity* intensityFactor, transform);

		//from object back to air
		float refractionRatioObjToAir = 1 / refractionIndex;
		float objToAirCosTheta1 = -1 * Vector3.Dot(refractInDir, objIntersectN);
		float objToAirCosTheta2Square = 1 - (1 / Mathf.Pow(refractionRatioObjToAir, 2)) * (1 - Mathf.Pow(objToAirCosTheta1, 2));
		
		if (objToAirCosTheta2Square > 0) {
			Vector3 refractOutDir = Vector3.Normalize (refractInDir / refractionRatioObjToAir + (objToAirCosTheta1 / refractionRatioObjToAir - Mathf.Sqrt (objToAirCosTheta2Square)) * objIntersectN);
			float insideDistance = Vector3.Distance(rayInfo.to, point) * 0.99f;
			RayInfo.Emit(rayInfo.rayIndex, rayInfo.to + 0.001f*rayInfo.direction, refractInDir, insideDistance, insideDistance, rayInfo.intensity* intensityFactor, t1);
			RayInfo.Emit(rayInfo.rayIndex,point, refractOutDir, rayInfo.finalRange * rangeFactor,rayInfo.maxRange, rayInfo.intensity* intensityFactor, t2);
			//RayInfo.Emit(rayInfo.rayIndex,point, refractOutDir, rayInfo.finalRange * rangeFactor,rayInfo.maxRange, rayInfo.intensity* intensityFactor, transform);
		}
		
	}
	
	
	
	void OnRay1 (RayInfo rayInfo)
	{
		OnRayRefract (rayInfo, transform1, transform2);
	}
	
	void OnRay2 (RayInfo rayInfo)
	{
		OnRayRefract (rayInfo, transform3, transform4);
	}
	
	void OnRay3 (RayInfo rayInfo)
	{
		OnRayRefract (rayInfo, transform5, transform6);
	}
	
	void OnRay4 (RayInfo rayInfo)
	{
		OnRayRefract (rayInfo, transform7, transform8);
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
