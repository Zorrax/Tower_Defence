﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitPaths : MonoBehaviour {
	public GameObject cube;
	public List<Path> Paths = new List<Path>();
	public Transform StartPos;
	public Transform EndPos;

	private GameObject placeholder;




	// Use this for initialization
	void Start () { // 3 forskellige start paths
		float x = StartPos.position.x;
		float y = 0.5f;
		float z = StartPos.position.z;
		Vector3 pos =new Vector3(x, y, z);



		int pathnumber = 0;
		Paths.Add(new Path());
		Paths [pathnumber].Index = pathnumber;
		Paths[pathnumber].Points.Add(pos);


		for (int i = 0; i<25; i++) {
			Vector3 direction = new Vector3 (-0.1f*i-Mathf.Pow(i,0.8f),0f,-8.5f);
			pos=pos+0.05f*direction;
			Paths[pathnumber].Points.Add(pos);
		}

		/*pathnumber++;
		Paths.Add(new Path());

		for (var i = 0; i<5; i++) {
			
			x = Random.Range(-10, 10);
			z = Random.Range(-10, 10);
			pos = new Vector3(x, y, z);
			placeholder = (GameObject) Instantiate (cube, pos,  Quaternion.identity);
			placeholder.name= "path 1 part"+d;
			Paths[pathnumber].Points.Add(placeholder.transform);
			d++;
		}*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
