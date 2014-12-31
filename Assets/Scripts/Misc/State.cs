using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

	public float SpawnCounter = 0;
	public int CurrentJunctionTier=4;
	public bool Running=true;
	public int Money=0;

	// Use this for initialization
	void Start () {
	
	}
	public void TogglePause(){
		Running = !Running;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
