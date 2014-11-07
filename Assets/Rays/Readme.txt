Reflections Engine by Nicolas Borromeo (nicolas.borromeo@gmail.com)
-------------------------------------------------------------------

Tutorials
---------
http://www.youtube.com/watch?v=B7LjHdZrYIQ
http://www.youtube.com/watch?v=tnmjTZWBsqM
http://www.youtube.com/watch?v=jogz5PeY97w
http://www.youtube.com/watch?v=A8jPXpibAbs
http://www.youtube.com/watch?v=J5pXDQFdhGM

Thanks for purchase the Reflections Engine. This will allow you to make reflected rays for multiple purpouses.

This document will explain how to make some of all the actions that can be dont with this engine.

Summary
-------

1)Important terms
2)How to: Cast and draw a ray
3)How to: Cast, reflect and draw a ray
4)How to: Cast, multiply and draw a ray
5)Engine Events.

1) Ray: Imaginary line that starts from one origin pointing to a direction and stop in the hitting object or at an 
   specified distance.
   
   Ray's Range: How long the ray can reach in unity's metric unit.
   
   Ray's Intensity: How bright the ray can be.
   
   Ray's Intensity: How bright the ray can be.
   
   Reflector Surface: A surface that can deflects an incoming ray course.
   
   Multiplier Surface: A surface that can multiply an incoming ray.
   
   Ray's Range Scale: How the range of the incoming ray will be powered in the output ray of the reflector ot
   the multiplier surface.
   
   Ray's Intensity Scale: How the intensity of the incoming ray will be powered in the output ray of the reflector ot
   the multiplier surface.
   
   Reflection Ray: A ray generated from a reflector surface when a ray hits that surface.
   
   Multiply Ray: The ray generated from a multiplier surface when a ray hits that surface.

2) To cast a ray you have two ways.

The first one is create a game object and then add a RayEmitter Component to it, this will show you a gizmo pointing
where the ray will face, you can rotate the game object to change the direction, because the forward of the game object
will be taken for the direction. Also you can configure the ray range and the intensity (see important terms).

The other one is call the static method Emit from the RayInfo class and pass the rays origin point, the direction, range,
max range, intensity and the emitting gameObject (optional).

Either way you can also draw the ray adding the RayDraw Component of the sending ray gameObject, you can configure
the aspect of the ray in the LineRenderer Component, which is auto added to the gameObject by the RayDraw Component.

To know how to configure the LineRenderer see the following links:

http://unity3d.com/support/documentation/Components/class-LineRenderer.html
http://unity3d.com/support/documentation/ScriptReference/LineRenderer

3) Besides all the ways you can emit a ray, you also can reflect that ray.

To reflect a ray you can create a gameObject with a custom Collider, any can work, and also add to that game object the
RayReflector Component. Also you can configure the range and intensity factor of the surface (see important terms).

You need to add the RayDraw Component to that game object to make the ray visible and configure it (see point 1).

4) Besides all the ways you can emit a ray, you also can multiply that ray.

To multiply a ray you can create a gameObject with a custom Collider, any can work, and also add to that game object the
RayMultiplier Component. You need to specify the directions of the resultant multiplied rays adding empty game objects
to the directions array in the component.
Also you can configure the range and intensity factor of the surface (see important terms).

You need to add the RayDraw Component to all directions game objects to make the rays visible and configure 
they (see point 1).

5)For now we have seen how to make nice reflected rays come visible in unity, but also this engine provides useful
events to use them in your aplications.

OnRay - Executed all frames that a ray touches a gameObject, receives a RayInfo object that has a lot of useful
		information about the ray.
		
OnRayEnter - Similar to OnRay but its executed once when the ray touches for first time a gameObject.

OnRayExit - Similar to OnRay but its executed once when the ray touches for last time a gameObject.

OnRaySent - Executed all frames that a ray its emitted by a gameObject, receives a RayInfo object.

OnRayStopSend - Executed when a Reflector or Multiplier Surface stop send a ray.

I.E.:

void OnRay(RayInfo info)
{
	Debug.Log(info.emitter.gameObject.name);
}

void OnRayStopSend()
{
	Debug.Log("I have stop emitting ray");
}


------------------------------------------------------------------------------------------

Unleash your imagination with Reflections Engine and boosts your app quality with all kind of ray dinamics!

Dont forget to rate this in the Asset Store and for any question you can contact me at my email:

nicolas.borromeo@gmail.com