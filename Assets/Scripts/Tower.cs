using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	
	public float fireRate = 0.5f;
	private float firetime = 0.5f;
	public int Damage;
	public List<GameObject> mobList = new List<GameObject>();   

	
	
	private bool fireAtGameObject(GameObject target){
		bool destroyGameObject = false;


		target.GetComponent<Healthbar>().AddjustCurrentHealth(-20);
		if (target.GetComponent<Healthbar>().curHealth <= 0) {
			destroyGameObject = true;
				}

		return destroyGameObject;
	}

		

	private void OnTriggerEnter(Collider other){
		if(other.tag=="Aug"){
			return;
		}
		
		GameObject theObject = other.attachedRigidbody.gameObject; 
		
		if(!mobList.Contains(theObject)){
			mobList.Add(theObject);
		}
	}
	
	private void OnTriggerExit(Collider other){
		GameObject theObject = other.attachedRigidbody.gameObject; 
		
		if(mobList.Contains(theObject)){ 
			mobList.Remove(theObject); 
		}
	}
	
	private void doFireSequence(){
		firetime -= Time.deltaTime;
		if (firetime <= 0) {

						if (mobList.Count > 0) {
								if (fireAtGameObject (mobList [0])) {				
										Destroy (mobList [0]);
										mobList.RemoveAt (0);
								}
						}
			firetime=fireRate;

				}
	}
	void Update()
	{
		foreach (GameObject Mob in mobList) {
			if( Mob == null ){
				mobList.Remove(Mob);
				break;
			}
		}
		doFireSequence ();


	}
}
