using UnityEngine;
using System.Collections;

public class Draganddrop : MonoBehaviour {
	
	Transform grabbed;
	float grabDistance = 1f;
	int grabLayerMask;
	Vector3 grabOffset; //delta between transform transform position and hit point
	bool useToggleDrag; // Didn't know which style you prefer. 
	
	void Update () {
		if (useToggleDrag){
			UpdateToggleDrag();
		} else {
			UpdateHoldDrag();
		}
	}
	
	// Toggles drag with mouse click
	void UpdateToggleDrag () {
		if (Input.GetMouseButtonDown(0)){ 
			Grab();
		} else {
			if (grabbed) {
				Drag();
			}
		}
	}
	
	// Drags when user holds down button
	void UpdateHoldDrag () {
		if (Input.GetMouseButton(0)) {
			if (grabbed){
				Drag();
			} else { 
				Grab();
			}
		} else {
			if(grabbed){
				//restore the original layermask
				grabbed.gameObject.layer = grabLayerMask;
			}
			grabbed = null;
		}
	}
	
	void Grab() {
		if (grabbed){ 
			grabbed = null;
		} else {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){          
				grabbed = hit.transform;
				if(grabbed.parent){
					grabbed = grabbed.parent.transform;
				}
				//set the object to ignore raycasts
				grabLayerMask = grabbed.gameObject.layer;
				grabbed.gameObject.layer = 2;
				//now immediately do another raycast to calculate the offset
				if (Physics.Raycast(ray, out hit)){
					grabOffset = grabbed.position - hit.point;
				} else {
					//important - clear the gab if there is nothing
					//behind the object to drag against
					grabbed = null;
				}
			}
		}
	}
	
	void Drag() {    
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)){      
			grabbed.position = hit.point + grabOffset;
		}
	}
}
