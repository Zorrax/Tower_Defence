using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour {
	
	private Vector3 Direction;
	private Vector3 MoveVector;
	public float MoveSpeed;
	public float MinDistance;
	public List<Vector3> waypoints = new List<Vector3>();
	private List<Path> Paths = new List<Path>();

	private Vector3 CurrentWaypoint;
	private int CurrentIndex;

	private GameObject CurrentPath;



	// Use this for initialization
	void Start () {
		CurrentPath = GameObject.Find ("PathMaker");
		Paths = CurrentPath.GetComponent<InitPaths>().Paths; // reference
		int[] mobpaths = {0};
		foreach ( int y in mobpaths ){
			for (int i =0; i < Paths[y].Points.Count ; i++){
				waypoints.Add(Paths[y].Points[i]);
			}
		}

		CurrentWaypoint = waypoints[0];
		CurrentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

				Direction  = CurrentWaypoint - transform.position;
				MoveVector = Direction.normalized * MoveSpeed * Time.deltaTime;
				transform.position += MoveVector;
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Direction), 4 * Time.deltaTime);

		
				if (Vector3.Distance (CurrentWaypoint, transform.position) < MinDistance) {
						++CurrentIndex;
						if (CurrentIndex > waypoints.Count - 1) {
							Destroy(gameObject);
							return;
						}
						CurrentWaypoint = waypoints [CurrentIndex];

				}
		}


}
