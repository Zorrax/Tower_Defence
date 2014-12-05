using UnityEngine;
using System.Collections;

public class Draganddrop : MonoBehaviour {
	
	bool dragging = false;
	Plane movePlane;
	float angle;
	float deltax,deltay,deltaz;
	float x;
	
	void OnMouseDown ()
	{
		dragging = true;
		movePlane = new Plane(-Camera.main.transform.forward,transform.position);
	}
	
	void Update ()
	{
		if (!dragging || !this.enabled) {
			return;
		}
		
		if (Input.GetMouseButtonUp (0)) {
			dragging = false;
		}
		
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		float hitDist;
		float t;
		if (movePlane.Raycast(camRay,out hitDist)){
			Vector3 Point = camRay.GetPoint(hitDist);
			deltax=Point.x-camRay.origin.x;
			deltay=Point.y-camRay.origin.y;
			deltaz=Point.z-camRay.origin.z;
			t=-(2f-camRay.origin.y)/(camRay.origin.y-Point.y);

			Vector3 CorPoint=new Vector3(camRay.origin.x+deltax*t,2f,camRay.origin.z+deltaz*t);
			transform.position = CorPoint;
		}
	}
}
