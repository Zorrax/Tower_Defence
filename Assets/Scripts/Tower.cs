using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
	
	public float fireRate = 0.5f;
	private float firetime = 0.5f;
	public int baseDamage =20;
	private int Damage;
	public List<GameObject> mobList = new List<GameObject>();   
	public List<GameObject> AugList = new List<GameObject>();   

	void Start(){
		for(int a = 0;a<6;a++){
			AugList.Add(null);
		}
	}

	
	
	private bool fireAtGameObject(GameObject target){
		bool destroyGameObject = false;


		target.GetComponent<Healthbar>().AddjustCurrentHealth(-Damage);
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
		Damage = baseDamage;
		foreach (GameObject beef in AugList) {
			if(beef){

				if(beef.GetComponent<AugDmg>()){
					Damage= Damage +20*beef.GetComponent<AugDmg>().level;
				}

			}
		}

		foreach (GameObject Mob in mobList) {
			if( Mob == null ){
				mobList.Remove(Mob);
				break;
			}
		}
		doFireSequence ();


	}
}
