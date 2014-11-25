using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour {
	
	private Vector3 Direction;
	private Vector3 MoveVector;
	public float MoveSpeed;
	public float MinDistance;
	public List<Transform> waypoints = new List<Transform>();
	private List<List<Transform>> paths = new List<List<Transform>>();

	private Transform CurrentWaypoint;
	private int CurrentIndex;

	private GameObject CurrentPath;



	// Use this for initialization
	void Start () {
		CurrentPath = GameObject.Find ("PathMaker");
		paths = CurrentPath.GetComponent<InitPaths>().paths; // reference
		waypoints = paths[0];
		CurrentWaypoint = waypoints[0];
		CurrentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

				Direction  = CurrentWaypoint.transform.position - transform.position;
				MoveVector = Direction.normalized * MoveSpeed * Time.deltaTime;
				transform.position += MoveVector;
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Direction), 4 * Time.deltaTime);

		
				if (Vector3.Distance (CurrentWaypoint.transform.position, transform.position) < MinDistance) {
						++CurrentIndex;
						if (CurrentIndex > waypoints.Count - 1) {
							waypoints = paths[1]; // skifter ikke path
							CurrentIndex = 0;
						}
						CurrentWaypoint = waypoints [CurrentIndex];

				}
		}


}
