using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

/// <summary>
/// Draws the incoming ray.
/// </summary>
public class RayDraw : MonoBehaviour
{
    private LineRenderer _renderer;
    
    /// <summary>
    /// Specifies an offset to expand or retract the ray's length.
    /// </summary>
    public float Offset = 0;
    
    void Start()
    {
        _renderer = GetComponent<LineRenderer>();
        _renderer.SetVertexCount(2);
        _renderer.useWorldSpace = true;
        _renderer.enabled = false;
    }

    void OnRaySent(RayInfo info)
    {
		_renderer.enabled = true;
        _renderer.useWorldSpace = true;
        _renderer.SetPosition(0, info.from - info.direction * Offset);
        _renderer.SetPosition(1, info.to + info.direction * Offset);
        
        Color colorFrom = Color.white;
        //colorFrom.a = (info.initialRange / info.maxRange) * info.intensity;
        
        Color colorTo = Color.white;
        //colorTo.a = (info.finalRange / info.maxRange) * info.intensity;
        
        _renderer.SetColors(colorFrom, colorTo);
    }
    
    void OnRayStopSent(Component emitter)
    {
    	_renderer.enabled = false;
    }
}