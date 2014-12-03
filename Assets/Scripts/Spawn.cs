using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public Transform StartPos;
	public GameObject Mob;

	private float InstantiationTimer = 2f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		spawnmob ();
	}

	void spawnmob(){
		InstantiationTimer -= Time.deltaTime;
		if (InstantiationTimer <= 0){
			Vector3 pos= new Vector3(StartPos.position.x,StartPos.position.y,StartPos.position.z);
			Instantiate (Mob, pos, Quaternion.identity);
			InstantiationTimer = 2f;
		}
	}
}
