using UnityEngine;
using System.Collections;

public class MakeAug : MonoBehaviour {
	public GameObject spawn;

	public void InstantiateAug(string type){
		GameObject newAug= Instantiate(spawn,new Vector3(10,1,10),Quaternion.identity) as GameObject;
		newAug.GetComponent<Aug> ().type = type;
		if(type=="fire"){
			newAug.renderer.material.color=Color.red;
		}

	}
}
