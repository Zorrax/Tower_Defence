using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

	public int SpawnCounter = 0;
	public int CurrentJunctionTier=4;
	public bool Running=true;

	// Use this for initialization
	void Start () {
	
	}
	void TogglePause(){
		Running = !Running;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
