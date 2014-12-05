using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	
	public float fireRate = 0.5f;
	public int Damage;
	private List<GameObject> mobList = new List<GameObject>();   
	
	private bool isFiring = false;
	
	
	private bool fireAtGameObject(GameObject target){
		bool destroyGameObject = false;
		
		Healthbar.

		destroyGameObject = true;
		
		
		return destroyGameObject;
	}
	
	
	private void OnTriggerEnter(Collider other){
		
		GameObject theObject = other.attachedRigidbody.gameObject; 
		
		if(!mobList.Contains(theObject)){
			mobList.Add(theObject);
			if(isFiring == false){ 
				isFiring = true;
				Invoke("doFireSequence",fireRate);
			}
		}
	}
	
	private void OnTriggerExit(Collider other){
		GameObject theObject = other.attachedRigidbody.gameObject; 
		
		if(mobList.Contains(theObject)){ 
			mobList.Remove(theObject); 
		}
	}
	
	private void doFireSequence(){
		if(mobList.Count > 0){
			if( fireAtGameObject( mobList[0] )){
				
				Destroy (mobList[0]);
				mobList.RemoveAt(0);
			}
			Invoke("doFireSequence",fireRate);
		} else {
			isFiring = false;
		}
	}
	
}
