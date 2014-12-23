using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobData : MonoBehaviour {

	public List<GameObject> mobs= new List<GameObject>();

	private bool isfilled=true;

	public void SetMobs(List<Vector3> wayp, MobType type){
		foreach(GameObject a in mobs){
			a.GetComponent<Mover>().SetWayP(wayp);
			a.GetComponent<Healthbar>().SetType(type);

		}
	}

	void Update(){
		foreach(GameObject b in mobs){
			if(b!=null){
				isfilled=true;
				break;
			}else{
				isfilled=false;
			}
		}
		if (isfilled == false) {
			Destroy(gameObject);
		}

	}

	
}
