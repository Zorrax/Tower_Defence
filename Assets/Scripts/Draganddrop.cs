using UnityEngine;
using System.Collections;

public class Draganddrop : MonoBehaviour {
	
	bool dragging = false;
	Plane movePlane;
	float angle=65;
	float deltay;
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
		if (movePlane.Raycast(camRay,out hitDist)){
			Vector3 Point = camRay.GetPoint(hitDist);
			deltay=Point.y-2f;
			x=(deltay/Mathf.Sin(Mathf.Deg2Rad*25))*Mathf.Sin(Mathf.Deg2Rad*65);
			Vector3 CorPoint=new Vector3(3,2f,x);
			transform.position = CorPoint;
		}
	}
}
