using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitPaths : MonoBehaviour {
	public GameObject cube;
	public List<Transform> waypoints = new List<Transform>();

	public List<List<Transform>> paths = new List<List<Transform>>();

	private GameObject placeholder;

	float x;
	float y = 0.5f;
	float z;
	Vector3 pos;



	// Use this for initialization
	void Start () {
		for (var i = 1; i<5; i++) {

			x = Random.Range(-10, 10);
			z = Random.Range(-10, 10);
			pos = new Vector3(x, y, z);
			placeholder = (GameObject) Instantiate (cube, pos,  Quaternion.identity);
			waypoints.Add(placeholder.transform);
		}
		paths.Add (waypoints);
		waypoints.Clear ();

		for (var i = 1; i<5; i++) {
			
			x = Random.Range(-10, 10);
			z = Random.Range(-10, 10);
			pos = new Vector3(x, y, z);
			placeholder = (GameObject) Instantiate (cube, pos,  Quaternion.identity);
			waypoints.Add(placeholder.transform);
		}
		paths.Add (waypoints);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
