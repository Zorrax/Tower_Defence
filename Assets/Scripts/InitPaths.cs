using UnityEngine;
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
		float angle;
		Vector3 pos =new Vector3(x, y, z);
		Vector3 direction;
		Vector3 endpos;
		float a;
		float deltax;


		int pathnumber = 0;
		Paths.Add(new Path());
		Paths [pathnumber].Index = pathnumber;
		Paths[pathnumber].Points.Add(pos);
		angle =Random.Range(135,315);
		direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad*angle),0 , Mathf.Sin(Mathf.Deg2Rad*angle));
		endpos =Paths[pathnumber].Points[0] + direction * Random.Range (10, 15);

		a = (Paths [pathnumber].Points [0].z - endpos.z) / Mathf.Pow ((Paths [pathnumber].Points [0].x - endpos.x), 2);
		deltax=(endpos.x-Paths[pathnumber].Points[0].x)/20;
		Debug.Log (a);
		Debug.Log (endpos.x);
		Debug.Log (endpos.z);
		for (int i = 1; i<20; i++) {

			//direction = direction + new Vector3 (-Mathf.Pow(i,0.8f),0f,0f);
			//pos=pos+direction;
		
			Paths[pathnumber].Points.Add(  new Vector3(pos.x+deltax*i,0.5f,a*(Mathf.Pow((pos.x+deltax*i-endpos.x),2))+endpos.z));
		}
		Paths [pathnumber].Points.Add (endpos);

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
