using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetCanvas : MonoBehaviour {

	public List<GameObject> mobs= new List<GameObject>();

	private Vector3 position;

	// Update is called once per frame
	void Update () {

		position = new Vector3 (0, 0, 0);
		int count = 0;
		foreach (GameObject a in mobs) {
			if(a!=null){
				position=position+a.transform.position;
				count++;
			}	
		}
		position = position / count;
		transform.position = new Vector3(position.x,3,position.z);
	}
}
