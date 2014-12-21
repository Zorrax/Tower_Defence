using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour {

	private Vector3 Direction;
	private Vector3 MoveVector;
	public float MoveSpeed= 2f;
	private float MinDistance=0.1f;


	public Vector3 CurrentWaypoint;
	public int CurrentIndex;
	public List<Vector3> waypoints = new List<Vector3>();


	// Use this for initialization
	void Start () {
		CurrentWaypoint = waypoints[0];
		CurrentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
				if (GameObject.Find ("GameState").GetComponent<State> ().Running) {

						Direction = CurrentWaypoint - transform.position;
						MoveVector = Direction.normalized * MoveSpeed * Time.deltaTime;
						transform.position += MoveVector;
						transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Direction), 4 * Time.deltaTime);

		
						if (Vector3.Distance (CurrentWaypoint, transform.position) < MinDistance) {
								++CurrentIndex;
								if (CurrentIndex > waypoints.Count - 1) {

										Destroy (gameObject);
										return;
								}
								CurrentWaypoint = waypoints [CurrentIndex];

						}
				}
		}
}
