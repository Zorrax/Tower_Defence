﻿using UnityEngine;
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
	public GameObject tower, lastTower;
	bool isPlaced=false;

	void Start(){
		tooltip.enabled = false;
        GetComponent<Aug> ().Updatetooltip ();
		lastSphere = new GameObject();
		lastSphere.AddComponent<ID> ();
		lastSphere.GetComponent<ID> ().sphereID = 0;
        lastTower = null;
	}

	void OnTriggerEnter(Collider other){
		isPlaced = true;
		curSphere = other.gameObject;
		triggerPos = other.transform.position;
		mousedTower=other.transform.parent.gameObject;
	}

	void OnTriggerExit(Collider other){
		isPlaced = false;
	}


	void OnMouseDown ()
	{
        if (isPlaced)
        {
            tooltip.enabled = !tooltip.enabled;

        }

		startPos = transform.position; // save position in case draged to invalid place
		movePlane = new Plane(-Camera.main.transform.forward,transform.position); // find a parallel plane to the camera based on obj start pos;
	
		camRay = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point
		
		if (movePlane.Raycast(camRay,out hitDist)){ // finde the collision on movePlane
			point = camRay.GetPoint(hitDist); // define the point on movePlane
			offset= startPos-point; 
		}
        
        if(isPlaced)
        {
            lastSphere = curSphere;
            lastTower = lastSphere.transform.parent.gameObject;
        }
	}

	void OnMouseUp ()
	{

		if (!isPlaced) {
			transform.position = startPos;
			
		} else if(isPlaced) {
			transform.position = triggerPos;
			tower=mousedTower;
			if(tower.GetComponent<Tower>().AugList[lastSphere.GetComponent<ID>().sphereID]==tower.GetComponent<Tower>().AugList[curSphere.GetComponent<ID>().sphereID]){

			}
            if(lastTower != null)
            {
                lastTower.GetComponent<Tower>().AugList[lastSphere.GetComponent<ID>().sphereID] = null;
            }
            //lastTower.GetComponent<Tower>().AugList[lastSphere.GetComponent<ID>().sphereID] = null;
			tower.GetComponent<Tower>().AugList[curSphere.GetComponent<ID>().sphereID]=gameObject;
		}
	}
	
	void OnMouseDrag ()
	{	
        if(!isPlaced)
        { tooltip.enabled = false;  }
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
