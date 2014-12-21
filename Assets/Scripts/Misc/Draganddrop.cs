using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Draganddrop : MonoBehaviour {

	public Canvas tooltip;
	Plane movePlane;
	float fixedDistance=1f;
	float hitDist, t;
	Ray camRay;
	Vector3 startPos, point, corPoint, triggerPos, offset;
	public GameObject curSphere, lastSphere;
	public GameObject mousedTower;
	public GameObject tower;
	bool isPlaced=false;

	void Start(){
		tooltip.enabled = false;
		lastSphere = new GameObject();
		lastSphere.AddComponent<ID> ();
		lastSphere.GetComponent<ID> ().sphereID = 0;
	}

	void OnTriggerEnter(Collider other){
		isPlaced = true;
		curSphere = other.gameObject;
		triggerPos = other.transform.position;
		mousedTower=other.transform.parent.gameObject;
	}

	void OnTriggerExit(Collider other){
		isPlaced = false;
		lastSphere = curSphere;
	}


	void OnMouseDown ()
	{
		tooltip.enabled = !tooltip.enabled;
		if(tooltip.enabled==true){
			GetComponent<Aug> ().Updatetooltip ();
		}
		startPos = transform.position; // save position in case draged to invalid place
		movePlane = new Plane(-Camera.main.transform.forward,transform.position); // find a parallel plane to the camera based on obj start pos;
	
		camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point
		
		if (movePlane.Raycast(camRay,out hitDist)){ // finde the collision on movePlane
			point = camRay.GetPoint(hitDist); // define the point on movePlane
			offset= startPos-point; 
		}
	
	}

	void OnMouseUp ()
	{
		if (!isPlaced) {
			transform.position = startPos;
			tooltip.enabled=true;
		} else if(isPlaced) {
			transform.position = triggerPos;
			tower=mousedTower;
			if(tower.GetComponent<Tower>().AugList[lastSphere.GetComponent<ID>().sphereID]==tower.GetComponent<Tower>().AugList[curSphere.GetComponent<ID>().sphereID]){
				tooltip.enabled=false;
			}
			tower.GetComponent<Tower>().AugList[lastSphere.GetComponent<ID>().sphereID]=null;
			tower.GetComponent<Tower>().AugList[curSphere.GetComponent<ID>().sphereID]=gameObject;
		}
	}
	
	void OnMouseDrag ()
	{	
	
		camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

		if (movePlane.Raycast(camRay,out hitDist)){ // finde the collision on movePlane
			point = camRay.GetPoint(hitDist); // define the point on movePlane
			t=-(fixedDistance-camRay.origin.y)/(camRay.origin.y-point.y); // the x,y or z plane you want to be fixed to
			corPoint.x=camRay.origin.x+(point.x-camRay.origin.x)*t; // calculate the new point t futher along the ray
			corPoint.y=camRay.origin.y+(point.y-camRay.origin.y)*t;
			corPoint.z=camRay.origin.z+(point.z-camRay.origin.z)*t;
			transform.position= corPoint+offset; 
		}
	}
}
