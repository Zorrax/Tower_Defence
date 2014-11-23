using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour {
	
	private Vector3 Direction;
	private Vector3 MoveVector;
	public float MoveSpeed;
	public List<Transform> waypoints = new List<Transform>();






	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Direction = way.transform.position- transform.position;
		//MoveVector = Direction.normalized * MoveSpeed * Time.deltaTime;
		//transform.position += MoveVector;
	}
}
