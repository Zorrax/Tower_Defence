using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitPaths : MonoBehaviour {
	public GameObject cube;
	public List<Path> Paths = new List<Path>();

	private GameObject placeholder;

	float x;
	float y = 0.5f;
	float z;
	Vector3 pos;


	// Use this for initialization
	void Start () {

		int d = 1;
		int pathnumber = 0;
		Paths.Add(new Path());
		for (var i = 0; i<5; i++) {

			x = Random.Range(-10, 10);
			z = Random.Range(-10, 10);
			pos = new Vector3(x, y, z);
			placeholder = (GameObject) Instantiate (cube, pos,  Quaternion.identity);
			placeholder.name= "path 0 part"+d;
			Paths[pathnumber].Points.Add(placeholder.transform);
			d++;
		}
		pathnumber++;
		Paths.Add(new Path());

		for (var i = 0; i<5; i++) {
			
			x = Random.Range(-10, 10);
			z = Random.Range(-10, 10);
			pos = new Vector3(x, y, z);
			placeholder = (GameObject) Instantiate (cube, pos,  Quaternion.identity);
			placeholder.name= "path 1 part"+d;
			Paths[pathnumber].Points.Add(placeholder.transform);
			d++;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
